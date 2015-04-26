
Imports System
Imports System.Text

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a PDF info.
	''' </summary>
	Friend Class pdfInfo
		Implements IWritable

		Private _objectIDInfo As Integer
		Private _title As String
		Private _author As String

		''' <summary>
		''' Info'sID
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
		''' Class's constructor
		''' </summary>
		''' <param name="title">Document's title</param>
		''' <param name="author">Document's author</param>
		Public Sub New(ByVal title As String, ByVal author As String)
			_title = title
			_author = author
		End Sub

		''' <summary>
		''' Method that returns the PDF codes to write the Info in the document
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getText() As String Implements IWritable.getText
            Dim strInfo As New StringBuilder()
            strInfo.Append(_objectIDInfo.ToString() + " 0 obj" + Convert.ToChar(13) + Convert.ToChar(10))
            strInfo.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
            strInfo.Append("/Title (" + _title + ")" + Convert.ToChar(13) + Convert.ToChar(10))
            strInfo.Append("/Author (" + _author + ")" + Convert.ToChar(13) + Convert.ToChar(10))
            strInfo.Append("/Creator (sharpPDF)" + Convert.ToChar(13) + Convert.ToChar(10))
            strInfo.Append("/CreationDate (" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + ")" + Convert.ToChar(13) + Convert.ToChar(10))
            strInfo.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            strInfo.Append("endobj" + Convert.ToChar(13) + Convert.ToChar(10))
            Return strInfo.ToString()
        End Function

	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
