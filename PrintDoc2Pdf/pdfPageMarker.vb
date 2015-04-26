
Imports System
Imports System.Text

Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' Class that implements a pdf page marker
	''' </summary>
    Friend Class pdfPageMarker

        Private _style As predefinedMarkerStyle = predefinedMarkerStyle.csArabic
        Private _coordX As Integer
        Private _coordY As Integer
        Private _fontType As predefinedFont = predefinedFont.csHelvetica
        Private _fontSize As Integer = 10
        Private _fontColor As New pdfColor(predefinedColor.csBlack)
        Private _pattern As String = "Page #n# Of #N#"

        ''' <summary>
        ''' X position of the marker
        ''' </summary>
        Public Property coordX() As Integer
            Get
                Return _coordX
            End Get

            Set(ByVal value As Integer)
                _coordX = Value
            End Set
        End Property

        ''' <summary>
        ''' Y position of the marker
        ''' </summary>
        Public Property coordY() As Integer
            Get
                Return _coordY
            End Get

            Set(ByVal value As Integer)
                _coordY = Value
            End Set
        End Property

        ''' <summary>
        ''' Font's type
        ''' </summary>
        Public Property fontType() As predefinedFont
            Get
                Return _fontType
            End Get

            Set(ByVal value As predefinedFont)
                _fontType = Value
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
                _fontSize = Value
            End Set
        End Property

        ''' <summary>
        ''' Marker's color
        ''' </summary>
        Public Property fontColor() As pdfColor
            Get
                Return _fontColor
            End Get

            Set(ByVal value As pdfColor)
                _fontColor = Value
            End Set
        End Property

        ''' <summary>
        ''' Marker's pattern. In the pattern there are two simbols: #n# (that represents the
        ''' actual page) and #N# (that represents the number of pages).
        ''' The Default pattern is : "Page #n# Of #N#"
        ''' </summary>
        ''' <example>
        ''' This example shows how to use the pattern property:
        ''' <code>
        ''' pdfPageMarker marker = new pdfPageMarker(400,30);
        ''' marker.pattern = "Page #n#/#N#";
        ''' myDoc.pageMarker = marker
        ''' ......
        ''' ......
        ''' </code>
        ''' The result on the document is : "Page 1/2"
        ''' </example>
        Public Property pattern() As String
            Get
                Return _pattern
            End Get

            Set(ByVal value As String)
                _pattern = Value
            End Set
        End Property

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="coordX">X position in the PDF document</param>
        ''' <param name="coordY">Y position in the PDF document</param>
        ''' <param name="style">Marker's style</param>
        Public Sub New(ByVal coordX As Integer, ByVal coordY As Integer, ByVal style As predefinedMarkerStyle)
            _style = style
            _coordX = coordX
            _coordY = coordY
        End Sub

        ''' <summary>
        ''' Method that creates a string for the page's marker
        ''' </summary>
        ''' <param name="pgIndex">Actual page</param>
        ''' <param name="pgNum">Number of pages</param>
        ''' <returns>Text that represents page's marker</returns>
        Public Function getMarker(ByVal pgIndex As Integer, ByVal pgNum As Integer) As String
            Dim strPgIndex As String = ""
            Dim strPgNum As String = ""
            Select Case _style
                Case predefinedMarkerStyle.csArabic
                    strPgIndex = pgIndex.ToString()
                    strPgNum = pgNum.ToString()
                Case predefinedMarkerStyle.csRoman
                    strPgIndex = arabicToRoman(pgIndex)
                    strPgNum = arabicToRoman(pgNum)
                    Exit Select
            End Select
            Return _pattern.Replace("#n#", strPgIndex).Replace("#N#", strPgNum)
        End Function

        ''' <summary>
        ''' Private method that converts arabic numbers into roman numbers
        ''' </summary>
        ''' <param name="arabic">Arabic number</param>
        ''' <returns>Equivalent roman number</returns>
        Private Function arabicToRoman(ByVal arabic As Integer) As String
            Dim roman As New StringBuilder()

            While arabic - 1000000 >= 0
                roman.Append("m")
                arabic -= 1000000
            End While

            While arabic - 900000 >= 0
                roman.Append("cm")
                arabic -= 900000
            End While

            While arabic - 500000 >= 0
                roman.Append("d")
                arabic -= 500000
            End While

            While arabic - 400000 >= 0
                roman.Append("cd")
                arabic -= 400000
            End While

            While arabic - 100000 >= 0
                roman.Append("c")
                arabic -= 100000
            End While

            While arabic - 90000 >= 0
                roman.Append("xc")
                arabic -= 90000
            End While

            While arabic - 50000 >= 0
                roman.Append("l")
                arabic -= 50000
            End While

            While arabic - 40000 >= 0
                roman.Append("xl")
                arabic -= 40000
            End While

            While arabic - 10000 >= 0
                roman.Append("x")
                arabic -= 10000
            End While

            While arabic - 9000 >= 0
                roman.Append("Mx")
                arabic -= 9000
            End While

            While arabic - 5000 >= 0
                roman.Append("v")
                arabic -= 5000
            End While

            While arabic - 4000 >= 0
                roman.Append("Mv")
                arabic -= 4000
            End While

            While arabic - 1000 >= 0
                roman.Append("M")
                arabic -= 1000
            End While

            While arabic - 900 >= 0
                roman.Append("CM")
                arabic -= 900
            End While

            While arabic - 500 >= 0
                roman.Append("D")
                arabic -= 500
            End While

            While arabic - 400 >= 0
                roman.Append("CD")
                arabic -= 400
            End While

            While arabic - 100 >= 0
                roman.Append("C")
                arabic -= 100
            End While

            While arabic - 90 >= 0
                roman.Append("XC")
                arabic -= 90
            End While

            While arabic - 50 >= 0
                roman.Append("L")
                arabic -= 50
            End While

            While arabic - 40 >= 0
                roman.Append("XL")
                arabic -= 40
            End While

            While arabic - 10 >= 0
                roman.Append("X")
                arabic -= 10
            End While

            While arabic - 9 >= 0
                roman.Append("IX")
                arabic -= 9
            End While

            While arabic - 5 >= 0
                roman.Append("V")
                arabic -= 5
            End While

            While arabic - 4 >= 0
                roman.Append("IV")
                arabic -= 4
            End While

            While arabic - 1 >= 0
                roman.Append("I")
                arabic -= 1
            End While

            Return roman.ToString()
        End Function

    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
