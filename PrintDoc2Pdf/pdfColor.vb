
Imports System

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a PDF color.
	''' </summary>
    Friend Class pdfColor
        Private _rColor As String
        Private _gColor As String
        Private _bColor As String
        Private _color As predefinedColor = predefinedColor.csNoColor

        ''' <summary>
        ''' R property of RGB color
        ''' </summary>
        Friend ReadOnly Property rColor() As String
            Get
                Return _rColor
            End Get
        End Property

        ''' <summary>
        ''' G property of RGB color
        ''' </summary>
        Friend ReadOnly Property gColor() As String
            Get
                Return _gColor
            End Get
        End Property

        ''' <summary>
        ''' B property of RGB color
        ''' </summary>
        Friend ReadOnly Property bColor() As String
            Get
                Return _bColor
            End Get
        End Property

        ''' <summary>
        ''' The predefinedColor of the pdfColor
        ''' </summary>
        Friend ReadOnly Property baseColor() As predefinedColor
            Get
                Return _color
            End Get
        End Property

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="newColor">Color</param>
        Public Sub New(ByVal newColor As predefinedColor)
            Select Case newColor
                Case predefinedColor.csNoColor
                    _rColor = ""
                    _gColor = ""
                    _bColor = ""
                Case predefinedColor.csBlack
                    _rColor = "0"
                    _gColor = "0"
                    _bColor = "0"
                Case predefinedColor.csWhite
                    _rColor = "1"
                    _gColor = "1"
                    _bColor = "1"
                Case predefinedColor.csRed
                    _rColor = "1"
                    _gColor = "0"
                    _bColor = "0"
                Case predefinedColor.csLightRed
                    _rColor = "1"
                    _gColor = ".75"
                    _bColor = ".75"
                Case predefinedColor.csDarkRed
                    _rColor = ".5"
                    _gColor = "0"
                    _bColor = "0"
                Case predefinedColor.csOrange
                    _rColor = "1"
                    _gColor = ".5"
                    _bColor = "0"
                Case predefinedColor.csLightOrange
                    _rColor = "1"
                    _gColor = ".75"
                    _bColor = "0"
                Case predefinedColor.csDarkOrange
                    _rColor = "1"
                    _gColor = ".25"
                    _bColor = "0"
                Case predefinedColor.csYellow
                    _rColor = "1"
                    _gColor = "1"
                    _bColor = ".25"
                Case predefinedColor.csLightYellow
                    _rColor = "1"
                    _gColor = "1"
                    _bColor = ".75"
                Case predefinedColor.csDarkYellow
                    _rColor = "1"
                    _gColor = "1"
                    _bColor = "0"
                Case predefinedColor.csBlue
                    _rColor = "0"
                    _gColor = "0"
                    _bColor = "1"
                Case predefinedColor.csLightBlue
                    _rColor = ".1"
                    _gColor = ".3"
                    _bColor = ".75"
                Case predefinedColor.csDarkBlue
                    _rColor = "0"
                    _gColor = "0"
                    _bColor = ".5"
                Case predefinedColor.csGreen
                    _rColor = "0"
                    _gColor = "1"
                    _bColor = "0"
                Case predefinedColor.csLightGreen
                    _rColor = ".75"
                    _gColor = "1"
                    _bColor = ".75"
                Case predefinedColor.csDarkGreen
                    _rColor = "0"
                    _gColor = ".5"
                    _bColor = "0"
                Case predefinedColor.csCyan
                    _rColor = "0"
                    _gColor = ".5"
                    _bColor = "1"
                Case predefinedColor.csLightCyan
                    _rColor = ".2"
                    _gColor = ".8"
                    _bColor = "1"
                Case predefinedColor.csDarkCyan
                    _rColor = "0"
                    _gColor = ".4"
                    _bColor = ".8"
                Case predefinedColor.csPurple
                    _rColor = ".5"
                    _gColor = "0"
                    _bColor = "1"
                Case predefinedColor.csLightPurple
                    _rColor = ".75"
                    _gColor = ".45"
                    _bColor = ".95"
                Case predefinedColor.csDarkPurple
                    _rColor = ".4"
                    _gColor = ".1"
                    _bColor = ".5"
                Case predefinedColor.csGray
                    _rColor = ".5"
                    _gColor = ".5"
                    _bColor = ".5"
                Case predefinedColor.csLightGray
                    _rColor = ".75"
                    _gColor = ".75"
                    _bColor = ".75"
                Case predefinedColor.csDarkGray
                    _rColor = ".25"
                    _gColor = ".25"
                    _bColor = ".25"
            End Select
            _color = newColor
        End Sub

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="HEXColor">Hex Color</param>
        Public Sub New(ByVal HEXColor As String)
            _rColor = formatColorComponent(Integer.Parse(HEXColor.Substring(0, 2), System.Globalization.NumberStyles.HexNumber))
            _gColor = formatColorComponent(Integer.Parse(HEXColor.Substring(2, 2), System.Globalization.NumberStyles.HexNumber))
            _bColor = formatColorComponent(Integer.Parse(HEXColor.Substring(4, 2), System.Globalization.NumberStyles.HexNumber))
            _color = predefinedColor.csUserColor
        End Sub

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="rColor">Red component of the color</param>
        ''' <param name="gColor">Green component of the color</param>
        ''' <param name="bColor">Blue component of the color</param>
        Public Sub New(ByVal rColor As Integer, ByVal gColor As Integer, ByVal bColor As Integer)
            _rColor = formatColorComponent(rColor)
            _gColor = formatColorComponent(gColor)
            _bColor = formatColorComponent(bColor)
            _color = predefinedColor.csUserColor
        End Sub

        ''' <summary>
        ''' Method that formats a int color value with the pdf color format
        ''' </summary>
        ''' <param name="colorValue">Component of the color</param>
        ''' <returns>Formatted component of the color</returns>
        Private Function formatColorComponent(ByVal colorValue As Integer) As String
            Dim colorComponent As Integer
            colorComponent = Convert.ToInt32(((Convert.ToSingle(colorValue) / 255) * 100))
            Dim resultValue As String
            If colorComponent > 100 Then
                colorComponent = 100
            Else
                If colorComponent < 0 Then
                    colorComponent = 0
                End If
            End If
            If colorComponent < 100 Then
                resultValue = "." + colorComponent.ToString()
                If resultValue(resultValue.Length - 1) = "0"c Then
                    resultValue = resultValue.Substring(0, resultValue.Length - 1)
                End If
            Else
                resultValue = "1"
            End If
            Return resultValue
        End Function

        ''' <summary>
        ''' Method that validates the color
        ''' </summary>
        ''' <returns>Boolean value that represents the validity of the color</returns>
        Friend Function isColor() As Boolean
            Return (_color <> predefinedColor.csNoColor)
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
