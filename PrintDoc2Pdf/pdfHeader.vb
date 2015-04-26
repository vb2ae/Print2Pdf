
Imports System
Imports System.Text

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a PDF header.
	''' </summary>
	Friend Class pdfHeader
		Implements IWritable

		Private _objectIDHeader As Integer
		Private _objectIDInfo As Integer
		Private _objectIDOutlines As Integer
		Private _pageTreeID As Integer
		Private _openBookmark As Boolean

		''' <summary>
		''' Header's ID
		''' </summary>
		Public Property objectIDHeader() As Integer
			Get
				Return _objectIDHeader
			End Get

			Set
				_objectIDHeader = value
			End Set
		End Property

		''' <summary>
		''' Outlines's ID
		''' </summary>
		Public Property objectIDOutlines() As Integer
			Get
				Return _objectIDOutlines
			End Get

			Set
				_objectIDOutlines = value
			End Set
		End Property

		''' <summary>
		''' Info's ID
		''' </summary>
		Public Property objectIDInfo() As Integer
			Get
				Return _objectIDInfo
			End Get

			Set
				_objectIDInfo = value
			End Set
		End Property

		''' <summary>
		''' PageTree's ID
		''' </summary>
		Public Property pageTreeID() As Integer
			Get
				Return _pageTreeID
			End Get

			Set
				_pageTreeID = value
			End Set
		End Property

		''' <summary>
		''' Class's constructor
		''' </summary>
		''' <param name="openBookmark">Allows to show directly bookmarks near the document</param>
		Public Sub New(ByVal openBookmark As Boolean)
			_openBookmark = openBookmark
		End Sub

		''' <summary>
		''' Method that returns the PDF codes to write the Header in the document
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getText() As String Implements IWritable.getText
            Dim strHeader As New StringBuilder()
            strHeader.Append(_objectIDHeader.ToString() + " 0 obj" + Convert.ToChar(13) + Convert.ToChar(10))
            strHeader.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
            strHeader.Append("/Type /Catalog" + Convert.ToChar(13) + Convert.ToChar(10))
            strHeader.Append("/Version /1.4" + Convert.ToChar(13) + Convert.ToChar(10))
            strHeader.Append("/Pages " + _pageTreeID.ToString() + " 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
            strHeader.Append("/Outlines " + _objectIDOutlines.ToString() + " 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
            If _openBookmark Then
                strHeader.Append("/PageMode /UseOutlines" + Convert.ToChar(13) + Convert.ToChar(10))
            End If
            strHeader.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            strHeader.Append("endobj" + Convert.ToChar(13) + Convert.ToChar(10))
            Return strHeader.ToString()
        End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
