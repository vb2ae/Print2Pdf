
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Text

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
    ''' <summary>
    ''' A Class that implements a PDF image.
    ''' </summary>
    Friend Class imageElement
        Inherits pdfElement

        Private _height As Integer
        Private _width As Integer
        Private _newHeight As Integer
        Private _newWidth As Integer
        Private _content As Byte()
        Private _xObjectID As Integer

        ''' <summary>
        ''' Original height of the image
        ''' </summary>
        Friend ReadOnly Property height() As Integer
            Get
                Return _height
            End Get
        End Property

        ''' <summary>
        ''' Original width of the image
        ''' </summary>
        Friend ReadOnly Property width() As Integer
            Get
                Return _width
            End Get
        End Property

        ''' <summary>
        ''' New height of the image
        ''' </summary>
        Friend Property newHeight() As Integer
            Get
                Return _newHeight
            End Get
            Set(ByVal value As Integer)
                _newHeight = value
            End Set
        End Property

        ''' <summary>
        ''' New width of the image
        ''' </summary>
        Friend Property newWidth() As Integer
            Get
                Return _newWidth
            End Get
            Set(ByVal value As Integer)
                _newWidth = value
            End Set
        End Property

        ''' <summary>
        ''' Byte array that contains the stream of the image
        ''' </summary>
        Friend ReadOnly Property content() As Byte()
            Get
                Return _content
            End Get
        End Property

        ''' <summary>
        ''' XObject ID
        ''' </summary>
        Friend Property xObjectID() As Integer
            Get
                Return _xObjectID
            End Get
            Set(ByVal value As Integer)
                _xObjectID = value
            End Set
        End Property

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="imageName">Image's Name</param>
        ''' <param name="newCoordX">X position in the PDF document</param>
        ''' <param name="newCoordY">Y position in the PDF document</param>
        Friend Sub New(ByVal imageName As String, ByVal newCoordX As Integer, ByVal newCoordY As Integer)
            Dim myImage As Image = Nothing
            Dim outStream As MemoryStream = Nothing
            Try
                myImage = Image.FromFile(imageName)
                outStream = New MemoryStream()
                myImage.Save(outStream, System.Drawing.Imaging.ImageFormat.Jpeg)
                _content = New Byte(CInt(outStream.Length)) {}
                _content = outStream.ToArray()
                _height = myImage.Height
                _width = myImage.Width
                _coordX = newCoordX
                _coordY = newCoordY
            Catch ex As System.IO.FileNotFoundException
                Throw New pdfImageNotFoundException("Immagine " + imageName + " non trovata!", ex)
            Catch ex As System.IO.IOException
                Throw New pdfImageIOException("Errore generale di IO sull'immagine " + imageName, ex)
            Finally
                If myImage IsNot Nothing Then
                    myImage.Dispose()
                    myImage = Nothing
                End If
                If outStream IsNot Nothing Then
                    outStream.Close()
                    outStream = Nothing
                End If
            End Try
        End Sub

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="myImage">Image Object</param>
        ''' <param name="newCoordX">X position in the PDF document</param>
        ''' <param name="newCoordY">Y position in the PDF document</param>
        Friend Sub New(ByVal myImage As Image, ByVal newCoordX As Integer, ByVal newCoordY As Integer)
            Dim outStream As MemoryStream = Nothing
            Try
                outStream = New MemoryStream()
                myImage.Save(outStream, System.Drawing.Imaging.ImageFormat.Jpeg)
                _content = New Byte(CInt(outStream.Length)) {}
                _content = outStream.ToArray()
                _height = myImage.Height
                _width = myImage.Width
                _coordX = newCoordX
                _coordY = newCoordY
            Catch ex As System.IO.FileNotFoundException
                Throw New pdfImageNotFoundException("Oggetto Immagine non corretto!", ex)
            Catch ex As System.IO.IOException
                Throw New pdfImageIOException("Errore generale di IO sull' oggetto immagine!", ex)
            Finally
                If outStream IsNot Nothing Then
                    outStream.Close()
                    outStream = Nothing
                End If
            End Try
        End Sub

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="imageName">Image's Name</param>
        ''' <param name="newCoordX">X position in the PDF document</param>
        ''' <param name="newCoordY">Y position in the PDF document</param>
        ''' <param name="newHeight">New height of the image</param>
        ''' <param name="newWidth">New width of the image</param>
        Friend Sub New(ByVal imageName As String, ByVal newCoordX As Integer, ByVal newCoordY As Integer, ByVal newHeight As Integer, ByVal newWidth As Integer)
            Dim myImage As Image = Nothing
            Dim outStream As MemoryStream = Nothing
            Try
                myImage = Image.FromFile(imageName)
                outStream = New MemoryStream()
                myImage.Save(outStream, System.Drawing.Imaging.ImageFormat.Jpeg)
                _content = New Byte(CInt(outStream.Length)) {}
                _content = outStream.ToArray()
                _height = myImage.Height
                _width = myImage.Width
                _newHeight = newHeight
                _newWidth = newWidth
                _coordX = newCoordX
                _coordY = newCoordY
            Catch ex As System.IO.FileNotFoundException
                Throw New pdfImageNotFoundException("Immagine " + imageName + " non trovata o formato non corretto!", ex)
            Catch ex As System.IO.IOException
                Throw New pdfImageIOException("Errore generale di IO sull'immagine " + imageName, ex)
            Finally
                If myImage IsNot Nothing Then
                    myImage.Dispose()
                    myImage = Nothing
                End If
                If outStream IsNot Nothing Then
                    outStream.Close()
                    outStream = Nothing
                End If
            End Try
        End Sub

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="myImage">Image Object</param>
        ''' <param name="newCoordX">X position in the PDF document</param>
        ''' <param name="newCoordY">Y position in the PDF document</param>
        ''' <param name="newHeight">New height of the image</param>
        ''' <param name="newWidth">New width of the image</param>
        Friend Sub New(ByVal myImage As Image, ByVal newCoordX As Integer, ByVal newCoordY As Integer, ByVal newHeight As Integer, ByVal newWidth As Integer)
            Dim outStream As MemoryStream = Nothing
            Try
                outStream = New MemoryStream()
                myImage.Save(outStream, System.Drawing.Imaging.ImageFormat.Jpeg)
                _content = New Byte(CInt(outStream.Length)) {}
                _content = outStream.ToArray()
                _height = myImage.Height
                _width = myImage.Width
                _newHeight = newHeight
                _newWidth = newWidth
                _coordX = newCoordX
                _coordY = newCoordY
            Catch ex As System.IO.FileNotFoundException
                Throw New pdfImageNotFoundException("Oggetto Immagine non corretto!", ex)
            Catch ex As System.IO.IOException
                Throw New pdfImageIOException("Errore generale di IO sull' oggetto immagine!", ex)
            Finally
                If outStream IsNot Nothing Then
                    outStream.Close()
                    outStream = Nothing
                End If
            End Try
        End Sub

        ''' <summary>
        ''' Method that returns the PDF codes to write the image in the document
        ''' </summary>
        ''' <returns>String that contains PDF codes</returns>
        Public Overloads Overrides Function getText() As String
            Dim resultImage As New StringBuilder()
            Dim imageContent As New StringBuilder()
            imageContent.Append("q" + Convert.ToChar(13) + Convert.ToChar(10))
            If _newHeight = 0 OrElse _newWidth = 0 Then
                imageContent.Append(_width.ToString() + " 0 0 " + _height.ToString() + " " + _coordX.ToString() + " " + _coordY.ToString() + " cm" + Convert.ToChar(13) + Convert.ToChar(10))
            Else
                imageContent.Append(_newWidth.ToString() + " 0 0 " + _newHeight.ToString() + " " + _coordX.ToString() + " " + _coordY.ToString() + " cm" + Convert.ToChar(13) + Convert.ToChar(10))
            End If
            imageContent.Append("/I" + _xObjectID.ToString() + " Do" + Convert.ToChar(13) + Convert.ToChar(10))
            imageContent.Append("Q" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append(_objectID.ToString() + " 0 obj" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("/Length " + imageContent.Length.ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("stream" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append(imageContent.ToString())
            resultImage.Append("endstream" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("endobj" + Convert.ToChar(13) + Convert.ToChar(10))
            imageContent = Nothing
            Return resultImage.ToString()
        End Function

        ''' <summary>
        ''' Method that returns the PDF codes to write the XObject in the document
        ''' </summary>
        ''' <returns>String that contains PDF codes</returns>
        Friend Function getXObjectText() As String
            Dim resultImage As New StringBuilder()
            '------<XObject Header>------
            resultImage.Append(_xObjectID.ToString() + " 0 obj" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("/Type /XObject" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("/Subtype /Image" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("/Name /I" + _xObjectID.ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("/Filter /DCTDecode" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("/Width " + _width.ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("/Height " + _height.ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("/BitsPerComponent 8" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("/ColorSpace /DeviceRGB" + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append("/Length " + _content.Length.ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            resultImage.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            '------</XObject Header>-----
            Return resultImage.ToString()
        End Function
    End Class
End Namespace

