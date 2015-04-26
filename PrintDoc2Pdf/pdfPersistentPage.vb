
Imports System
Imports System.Collections
Imports System.Drawing

Imports PrintDoc2Pdf.sharpPDF.Enumerators
Imports PrintDoc2Pdf.sharpPDF.Exceptions

Namespace sharpPDF
    ''' <summary>
    ''' Class that represents a persistent page.
    ''' All its objects are inherited by all document's pages.
    ''' </summary>
    Friend Class pdfPersistentPage

        Private _persistentElements As ArrayList

        ''' <summary>
        ''' Page's persistent elements
        ''' </summary>
        Public ReadOnly Property persistentElements() As ArrayList
            Get
                Return _persistentElements
            End Get
        End Property

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        Public Sub New()
            _persistentElements = New ArrayList()
        End Sub
        Protected Overrides Sub Finalize()
            Try
                _persistentElements = Nothing
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
                _persistentElements.Add(objImage)
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
                _persistentElements.Add(objImage)
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
                _persistentElements.Add(objImage)
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
                _persistentElements.Add(objImage)
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
            _persistentElements.Add(objText)
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
            _persistentElements.Add(objText)
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
            _persistentElements.Add(objText)
            objText = Nothing
        End Sub

    End Class
End Namespace
