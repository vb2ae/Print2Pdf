
Imports System
Imports System.Text

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
    ''' <summary>
    ''' Descrizione di riepilogo per textElement.
    ''' </summary>
    Friend Class textElement
        Inherits pdfElement
        Private _content As String
        Private _fontSize As Integer
        Private _fontType As predefinedFont

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="newContent">Text's content</param>
        ''' <param name="newFontSize">Font's size</param>
        ''' <param name="newFontType">Font's type</param>
        ''' <param name="newCoordX">X position of the text in the page</param>
        ''' <param name="newCoordY">Y position of the text in the page</param>
        Public Sub New(ByVal newContent As String, ByVal newFontSize As Integer, ByVal newFontType As predefinedFont, ByVal newCoordX As Integer, ByVal newCoordY As Integer)
            _content = newContent
            _fontSize = newFontSize
            _fontType = newFontType
            _coordX = newCoordX
            _coordY = newCoordY
        End Sub

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="newContent">Text's content</param>
        ''' <param name="newFontSize">Font's size</param>
        ''' <param name="newFontType">Font's type</param>
        ''' <param name="newCoordX">X position of the text in the page</param>
        ''' <param name="newCoordY">Y position of the text in the page</param>
        ''' <param name="newStrokeColor">Font's color</param>
        Public Sub New(ByVal newContent As String, ByVal newFontSize As Integer, ByVal newFontType As predefinedFont, ByVal newCoordX As Integer, ByVal newCoordY As Integer, ByVal newStrokeColor As predefinedColor)
            _content = newContent
            _fontSize = newFontSize
            _fontType = newFontType
            _coordX = newCoordX
            _coordY = newCoordY
            _strokeColor = New pdfColor(newStrokeColor)
        End Sub

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="newContent">Text's content</param>
        ''' <param name="newFontSize">Font's size</param>
        ''' <param name="newFontType">Font's type</param>
        ''' <param name="newCoordX">X position of the text in the page</param>
        ''' <param name="newCoordY">Y position of the text in the page</param>
        ''' <param name="newStrokeColor">Font's color</param>
        Public Sub New(ByVal newContent As String, ByVal newFontSize As Integer, ByVal newFontType As predefinedFont, ByVal newCoordX As Integer, ByVal newCoordY As Integer, ByVal newStrokeColor As pdfColor)
            _content = newContent
            _fontSize = newFontSize
            _fontType = newFontType
            _coordX = newCoordX
            _coordY = newCoordY
            _strokeColor = newStrokeColor
        End Sub

        ''' <summary>
        ''' Text's content
        ''' </summary>
        Public Property content() As String
            Get
                Return _content
            End Get

            Set(ByVal value As String)
                _content = value
            End Set
        End Property


        ''' <summary>
        ''' Font's size
        ''' </summary>
        Public Property fontSize() As Integer
            Get
                Return _fontSize
            End Get

            Set(ByVal value As Integer)
                _fontSize = value
            End Set
        End Property

        ''' <summary>
        ''' Font's type
        ''' </summary>
        Public Property fontType() As predefinedFont
            Get
                Return fontType
            End Get

            Set(ByVal value As predefinedFont)
                _fontType = value
            End Set
        End Property

        ''' <summary>
        ''' Method that returns the PDF codes to write the text in the document
        ''' </summary>
        ''' <returns>String that contains PDF codes</returns>
        Public Overloads Overrides Function getText() As String
            Dim resultText As New StringBuilder()
            Dim hexContent As New StringBuilder()
            resultText.Append(_objectID.ToString() + " 0 obj" + Convert.ToChar(13) + Convert.ToChar(10))
            resultText.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
            resultText.Append("/Filter [/ASCIIHexDecode]" + Convert.ToChar(13) + Convert.ToChar(10))
            hexContent.Append("q" + Convert.ToChar(13) + Convert.ToChar(10))
            hexContent.Append("BT" + Convert.ToChar(13) + Convert.ToChar(10))
            hexContent.Append("/F" + Convert.ToInt32(_fontType).ToString() + " " + _fontSize.ToString() + " Tf" + Convert.ToChar(13) + Convert.ToChar(10))
            If _strokeColor.isColor() Then
                hexContent.Append(_strokeColor.rColor + " " + _strokeColor.gColor + " " + _strokeColor.bColor + " rg" + Convert.ToChar(13) + Convert.ToChar(10))
            End If
            hexContent.Append(_coordX.ToString() + " " + _coordY.ToString() + " Td" + Convert.ToChar(13) + Convert.ToChar(10))
            hexContent.Append("(" + textAdapter.checkText(_content) + ") Tj" + Convert.ToChar(13) + Convert.ToChar(10))
            hexContent.Append("ET" + Convert.ToChar(13) + Convert.ToChar(10))
            hexContent.Append("Q")
            resultText.Append("/Length " + ((hexContent.Length * 2) + 1).ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            resultText.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            resultText.Append("stream" + Convert.ToChar(13) + Convert.ToChar(10))
            resultText.Append(textAdapter.encodeHEX(hexContent.ToString()) + ">" + Convert.ToChar(13) + Convert.ToChar(10))
            resultText.Append("endstream" + Convert.ToChar(13) + Convert.ToChar(10))
            resultText.Append("endobj" + Convert.ToChar(13) + Convert.ToChar(10))
            hexContent = Nothing
            Return resultText.ToString()
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
