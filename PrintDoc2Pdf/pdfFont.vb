
Imports System
Imports System.Text

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a PDF font.
	''' </summary>
	Friend Class pdfFont
		Implements IWritable
		Private _fontStyle As predefinedFont
		Private _objectID As Integer
		Private _fontNumber As Integer

		''' <summary>
		''' Font's style
		''' </summary>
		Public ReadOnly Property fontStyle() As predefinedFont
			Get
				Return _fontStyle
			End Get
		End Property

		''' <summary>
		''' Font's ID
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
		''' <param name="newFontStyle">Font's style</param>
		''' <param name="newFontNumber">Font's number in the PDF </param>
		Public Sub New(ByVal newFontStyle As predefinedFont, ByVal newFontNumber As Integer)
			_fontStyle = newFontStyle
			_fontNumber = newFontNumber
		End Sub

		''' <summary>
		''' Method that returns the PDF codes to write the Font in the document
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getText() As String Implements IWritable.getText
            Dim content As New StringBuilder()
            content.Append(_objectID.ToString() + " 0 obj" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("/Type /Font" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("/Subtype /Type1" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("/Name /F" + _fontNumber.ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("/BaseFont /" + pdfFont.getFontName(_fontStyle) + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("/Encoding /WinAnsiEncoding" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("endobj" + Convert.ToChar(13) + Convert.ToChar(10))
            Return content.ToString()
        End Function

		''' <summary>
		''' Static Mehtod that returns the name of the font
		''' </summary>
		''' <param name="fontType">Font's Type</param>
		''' <returns>String that contains the name of the font</returns>
		Public Shared Function getFontName(ByVal fontType As predefinedFont) As String
			Select Case fontType
				Case predefinedFont.csHelvetica
					Return "Helvetica"
				Case predefinedFont.csHelveticaBold
					Return "Helvetica-Bold"
				Case predefinedFont.csHelveticaOblique
					Return "Helvetica-Oblique"
				Case predefinedFont.csHelvetivaBoldOblique
					Return "Helvetica-BoldOblique"
				Case predefinedFont.csCourier
					Return "Courier"
				Case predefinedFont.csCourierBold
					Return "Courier-Bold"
				Case predefinedFont.csCourierOblique
					Return "Courier-Oblique"
				Case predefinedFont.csCourierBoldOblique
					Return "Courier-BoldOblique"
				Case predefinedFont.csTimes
					Return "Times-Roman"
				Case predefinedFont.csTimesBold
					Return "Times-Bold"
				Case predefinedFont.csTimesOblique
					Return "Times-Italic"
				Case predefinedFont.csTimesBoldOblique
					Return "Times-BoldItalic"
				Case Else
					Return ""
			End Select
		End Function

	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
