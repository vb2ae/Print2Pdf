
Imports System
Imports System.Text
Imports System.Collections

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a PDF pageTree.
	''' </summary>
	Friend Class pdfPageTree
		Implements IWritable

		Private _pages As ArrayList
		Private _pageCount As Integer
		Private _objectID As Integer

		''' <summary>
		''' Pagetree's ID
		''' </summary>
		Public Property objectID() As Integer

			Get
				Return _objectID
			End Get

			Set
				_objectID = value
			End Set
		End Property


		''' <summary>
		''' Class's constructor
		''' </summary>
		Public Sub New()
			_pageCount = 0
			_pages = New ArrayList()
		End Sub

		''' <summary>
		''' Method that adds a page to the pageTree object
		''' </summary>
		''' <param name="pageID"></param>
		Public Sub addPage(ByVal pageID As Integer)
			_pages.Add(pageID)
			System.Math.Max(System.Threading.Interlocked.Increment(_pageCount),_pageCount - 1)
		End Sub

		''' <summary>
		''' Method that returns the PDF codes to write the pageTree in the document
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getText() As String Implements IWritable.getText
            If _pages.Count > 0 Then
                Dim content As New StringBuilder()
                content.Append(_objectID.ToString() + " 0 obj" + Convert.ToChar(13) + Convert.ToChar(10))
                content.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
                content.Append("/Type /Pages" + Convert.ToChar(13) + Convert.ToChar(10))
                content.Append("/Count " + _pages.Count.ToString() + Convert.ToChar(13) + Convert.ToChar(10))
                content.Append("/Kids [")
                For Each item As Integer In _pages
                    content.Append(item.ToString() + " 0 R ")
                Next
                content.Append("]" + Convert.ToChar(13) + Convert.ToChar(10))
                content.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
                content.Append("endobj" + Convert.ToChar(13) + Convert.ToChar(10))
                Return content.ToString()
            Else
                Return Nothing
            End If
        End Function

	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
