
Imports System
Imports System.Collections
Imports System.Text
Imports System.Drawing

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a PDF page.
	''' </summary>
    Friend Class pdfPage
        Implements IWritable

        Private _height As Integer
        Private _width As Integer
        Private _objectID As Integer
        Private _pageTreeID As Integer
        Private _fontObjectsReference As String
        Private _elements As ArrayList

        ''' <summary>
        ''' Page's ID
        ''' </summary>
        Public Property objectID() As Integer
            Get
                Return _objectID
            End Get

            Set(ByVal value As Integer)
                _objectID = Value
            End Set
        End Property


        ''' <summary>
        ''' PageTree's ID
        ''' </summary>
        Public Property pageTreeID() As Integer
            Get
                Return _pageTreeID
            End Get

            Set(ByVal value As Integer)
                _pageTreeID = Value
            End Set
        End Property


        ''' <summary>
        ''' Page's height
        ''' </summary>
        Public ReadOnly Property height() As Integer
            Get
                Return _height
            End Get
        End Property

        ''' <summary>
        ''' Page's width
        ''' </summary>
        Public ReadOnly Property width() As Integer
            Get
                Return _width
            End Get
        End Property

        ''' <summary>
        ''' Page's elements
        ''' </summary>
        Friend ReadOnly Property elements() As ArrayList
            Get
                Return _elements
            End Get
        End Property

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        Public Sub New()
            _height = 792
            _width = 612
            _elements = New ArrayList()
        End Sub

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="newHeight">Page's height</param>
        ''' <param name="newWidth">Page's width</param>
        Public Sub New(ByVal newHeight As Integer, ByVal newWidth As Integer)
            _height = newHeight
            _width = newWidth
            _elements = New ArrayList()
        End Sub
        Protected Overrides Sub Finalize()
            Try

                _elements = Nothing
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        ''' <summary>
        ''' Method that adds an image to the page object
        ''' </summary>
        ''' <param name="newImgSource">Image's name</param>
        ''' <param name="X">X position of the image in the page</param>
        ''' <param name="Y">Y position of the image in the page</param>		
        Public Sub addImage(ByVal newImgSource As String, ByVal X As Integer, ByVal Y As Integer)
            Try
                Dim objImage As New imageElement(newImgSource, X, Y)
                _elements.Add(objImage)
                objImage = Nothing
            Catch ex As pdfImageNotFoundException
                Throw New pdfImageNotFoundException(ex.Message, ex)
            Catch ex As pdfImageIOException
                Throw New pdfImageIOException(ex.Message, ex)
            End Try
        End Sub

        ''' <summary>
        ''' Method that adds an image to the page object
        ''' </summary>
        ''' <param name="newImgObject">Image Object</param>
        ''' <param name="X">X position of the image in the page</param>
        ''' <param name="Y">Y position of the image in the page</param>		
        Public Sub addImage(ByVal newImgObject As Image, ByVal X As Integer, ByVal Y As Integer)
            Try
                Dim objImage As New imageElement(newImgObject, X, Y)
                _elements.Add(objImage)
                objImage = Nothing
            Catch ex As pdfImageNotFoundException
                Throw New pdfImageNotFoundException(ex.Message, ex)
            Catch ex As pdfImageIOException
                Throw New pdfImageIOException(ex.Message, ex)
            End Try
        End Sub

        ''' <summary>
        ''' Method that adds an image to the page object
        ''' </summary>
        ''' <param name="newImgSource">Image's name</param>
        ''' <param name="X">X position of the image in the page</param>
        ''' <param name="Y">Y position of the image in the page</param>
        ''' <param name="height">New height of the image</param>
        ''' <param name="width">New width of the image</param>
        Public Sub addImage(ByVal newImgSource As String, ByVal X As Integer, ByVal Y As Integer, ByVal height As Integer, ByVal width As Integer)
            Try
                Dim objImage As New imageElement(newImgSource, X, Y, height, width)
                _elements.Add(objImage)
                objImage = Nothing
            Catch ex As pdfImageNotFoundException
                Throw New pdfImageNotFoundException(ex.Message, ex)
            Catch ex As pdfImageIOException
                Throw New pdfImageIOException(ex.Message, ex)
            End Try
        End Sub

        ''' <summary>
        ''' Method that adds an image to the page object
        ''' </summary>
        ''' <param name="newImgObject">Image Object</param>
        ''' <param name="X">X position of the image in the page</param>
        ''' <param name="Y">Y position of the image in the page</param>
        ''' <param name="height">New height of the image</param>
        ''' <param name="width">New width of the image</param>
        Public Sub addImage(ByVal newImgObject As Image, ByVal X As Integer, ByVal Y As Integer, ByVal height As Integer, ByVal width As Integer)
            Try
                Dim objImage As New imageElement(newImgObject, X, Y, height, width)
                _elements.Add(objImage)
                objImage = Nothing
            Catch ex As pdfImageNotFoundException
                Throw New pdfImageNotFoundException(ex.Message, ex)
            Catch ex As pdfImageIOException
                Throw New pdfImageIOException(ex.Message, ex)
            End Try
        End Sub

        ''' <summary>
        ''' Method that adds a text element to the page object
        ''' </summary>
        ''' <param name="newText">Text</param>
        ''' <param name="X">X position of the text in the page</param>
        ''' <param name="Y">Y position of the text in the page</param>
        ''' <param name="fontType">Font's type</param>
        ''' <param name="fontSize">Font's size</param>
        Public Sub addText(ByVal newText As String, ByVal X As Integer, ByVal Y As Integer, ByVal fontType As predefinedFont, ByVal fontSize As Integer)
            Dim objText As New textElement(newText, fontSize, fontType, X, Y)
            _elements.Add(objText)
            objText = Nothing
        End Sub

        ''' <summary>
        ''' Method that adds a text element to the page object [DEPRECATED]
        ''' </summary>
        ''' <param name="newText">Text</param>
        ''' <param name="X">X position of the text in the page</param>
        ''' <param name="Y">Y position of the text in the page</param>
        ''' <param name="fontType">Font's type</param>
        ''' <param name="fontSize">Font's size</param>
        ''' <param name="fontColor">Font's color</param>
        Public Sub addText(ByVal newText As String, ByVal X As Integer, ByVal Y As Integer, ByVal fontType As predefinedFont, ByVal fontSize As Integer, ByVal fontColor As predefinedColor)
            Dim objText As New textElement(newText, fontSize, fontType, X, Y, fontColor)
            _elements.Add(objText)
            objText = Nothing
        End Sub

        ''' <summary>
        ''' Method that adds a text element to the page object
        ''' </summary>
        ''' <param name="newText">Text</param>
        ''' <param name="X">X position of the text in the page</param>
        ''' <param name="Y">Y position of the text in the page</param>
        ''' <param name="fontType">Font's type</param>
        ''' <param name="fontSize">Font's size</param>
        ''' <param name="fontColor">Font's color</param>
        Public Sub addText(ByVal newText As String, ByVal X As Integer, ByVal Y As Integer, ByVal fontType As predefinedFont, ByVal fontSize As Integer, ByVal fontColor As pdfColor)
            Dim objText As New textElement(newText, fontSize, fontType, X, Y, fontColor)
            _elements.Add(objText)
            objText = Nothing
        End Sub




        ''' <summary>
        ''' Internal method that adds fonts object to the page object
        ''' </summary>
        ''' <param name="fonts">ArrayList of fonts object</param>
        Friend Sub addFonts(ByVal fonts As ArrayList)
            Dim resultString As New StringBuilder()
            Dim i As Integer = 0
            While i < fonts.Count
                resultString.Append("/F" + (i + 1).ToString() + " " + (DirectCast(fonts(i), pdfFont)).objectID.ToString() + " 0 R ")
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            _fontObjectsReference = resultString.ToString()
            resultString = Nothing
        End Sub

        ''' <summary>
        ''' Method that returns the PDF codes to write the page in the document
        ''' </summary>
        ''' <returns>String that contains PDF codes</returns>
        Public Function getText() As String Implements IWritable.getText
            Dim pageContent As New StringBuilder()
            Dim objContent As New StringBuilder()
            Dim imgContent As New StringBuilder()
            pageContent.Append(_objectID.ToString() + " 0 obj" + Convert.ToChar(13) + Convert.ToChar(10))
            pageContent.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
            pageContent.Append("/Type /Page" + Convert.ToChar(13) + Convert.ToChar(10))
            pageContent.Append("/Parent " + _pageTreeID.ToString() + " 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
            pageContent.Append("/Resources <</Font <<" + _fontObjectsReference + ">>" + Convert.ToChar(13) + Convert.ToChar(10))
            For Each item As pdfElement In _elements
                objContent.Append(item.objectID.ToString() + " 0 R ")
                If item.[GetType]().Name = "imageElement" Then
                    imgContent.Append("/I" + (DirectCast(item, imageElement)).xObjectID.ToString() + " " + (DirectCast(item, imageElement)).xObjectID.ToString() + " 0 R ")
                End If
            Next
            If imgContent.Length > 0 Then
                pageContent.Append("/XObject <<" + imgContent.ToString() + ">>" + Convert.ToChar(13) + Convert.ToChar(10))
            End If
            pageContent.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            pageContent.Append("/MediaBox [0 0 " & _width.ToString & " " & _height.ToString + "]" & Convert.ToChar(13) & Convert.ToChar(10))
            pageContent.Append("/CropBox [0 0 " & _width.ToString & " " & _height.ToString & "]" & Convert.ToChar(13) & Convert.ToChar(10))
            pageContent.Append("/Rotate 0" + Convert.ToChar(13) + Convert.ToChar(10))
            pageContent.Append("/ProcSet [/PDF /Text /ImageC]" + Convert.ToChar(13) + Convert.ToChar(10))
            If objContent.Length > 0 Then
                pageContent.Append("/Contents [" + objContent.ToString() + "]" + Convert.ToChar(13) + Convert.ToChar(10))
            End If
            pageContent.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            pageContent.Append("endobj" + Convert.ToChar(13) + Convert.ToChar(10))
            objContent = Nothing
            imgContent = Nothing
            Return pageContent.ToString()
        End Function
    End Class
End Namespace
