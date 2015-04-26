
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a PDF document.
	''' </summary>
    Friend Class pdfDocument
        Private _title As String
        Private _author As String
        Private _openBookmark As Boolean
        Private _header As pdfHeader
        Private _info As pdfInfo
        Private _outlines As New pdfOutlines()
        Private _pageTree As pdfPageTree
        Private _trailer As pdfTrailer
        Private _fonts As New ArrayList()
        Private _pages As New ArrayList()
        Private _pageMarker As pdfPageMarker = Nothing
        Private _persistentPage As pdfPersistentPage = Nothing

        ''' <summary>
        ''' Document's page marker
        ''' </summary>
        Public WriteOnly Property pageMarker() As pdfPageMarker
            Set(ByVal value As pdfPageMarker)
                _pageMarker = Value
            End Set
        End Property

        ''' <summary>
        ''' Document's persistent page
        ''' </summary>
        Public WriteOnly Property persistentPage() As pdfPersistentPage
            Set(ByVal value As pdfPersistentPage)
                _persistentPage = Value
            End Set
        End Property

        ''' <summary>
        ''' Collection of pdf's page
        ''' </summary>
        Default Public ReadOnly Property Item(ByVal index As Integer) As pdfPage
            Get
                Return DirectCast(_pages(index), pdfPage)
            End Get
        End Property

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="author">Author of the document</param>
        ''' <param name="title">Title of the document</param>
        Public Sub New(ByVal title As String, ByVal author As String)
            _title = title
            _author = author
            _openBookmark = False
        End Sub

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="author">Author of the document</param>
        ''' <param name="title">Title of the document</param>
        ''' <param name="openBookmark">Allow to show directly bookmarks near the document</param>
        Public Sub New(ByVal title As String, ByVal author As String, ByVal openBookmark As Boolean)
            _title = title
            _author = author
            _openBookmark = openBookmark
        End Sub
        Protected Overrides Sub Finalize()
            Try

                _header = Nothing
                _info = Nothing
                _outlines = Nothing
                _fonts = Nothing
                _pages = Nothing
                _pageTree = Nothing
                _trailer = Nothing
                _title = Nothing
                _author = Nothing
                _pageMarker = Nothing

                _persistentPage = Nothing
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        ''' <summary>
        ''' Method that writes the PDF document on the stream
        ''' </summary>
        ''' <param name="outStream">Output stream</param>
        Public Sub createPDF(ByVal outStream As Stream)
            Dim _myBuffer As BufferedStream = Nothing
            Dim _bufferLength As Long = 0

            initializeObjects()
            Try
                'Bufferedstream's initialization 
                _myBuffer = New BufferedStream(outStream)

                'PDF's definition
                _bufferLength += writeToBuffer(_myBuffer, "%PDF-1.4" + Convert.ToChar(13) + Convert.ToChar(10))

                'PDF's header object
                _trailer.addObject(_bufferLength.ToString())
                _bufferLength += writeToBuffer(_myBuffer, _header.getText())

                'PDF's info object
                _trailer.addObject(_bufferLength.ToString())
                _bufferLength += writeToBuffer(_myBuffer, _info.getText())

                'PDF's outlines object
                _trailer.addObject(_bufferLength.ToString())
                _bufferLength += writeToBuffer(_myBuffer, _outlines.getText())

                'PDF's bookmarks
                For Each Node As pdfBookmarkNode In _outlines.getBookmarks()
                    _trailer.addObject(_bufferLength.ToString())
                    _bufferLength += writeToBuffer(_myBuffer, Node.getText())
                Next

                'Fonts's initialization
                For Each font As pdfFont In _fonts
                    _trailer.addObject(_bufferLength.ToString())
                    _bufferLength += writeToBuffer(_myBuffer, font.getText())
                Next
                'PDF's pagetree object
                _trailer.addObject(_bufferLength.ToString())
                _bufferLength += writeToBuffer(_myBuffer, _pageTree.getText())

                'Generation of PDF's pages
                For Each page As pdfPage In _pages
                    _trailer.addObject(_bufferLength.ToString())
                    _bufferLength += writeToBuffer(_myBuffer, page.getText())

                    For Each element As pdfElement In page.elements
                        'if (element.GetType().Name == "imageElement") {
                        If TypeOf element Is imageElement Then
                            _trailer.addObject(_bufferLength.ToString())
                            _bufferLength += writeToBuffer(_myBuffer, element.getText())
                            _trailer.addObject(_bufferLength.ToString())
                            _bufferLength += writeToBuffer(_myBuffer, (DirectCast(element, imageElement)).getXObjectText())
                            _bufferLength += writeToBuffer(_myBuffer, "stream" + Convert.ToChar(13) + Convert.ToChar(10))
                            _bufferLength += writeToBuffer(_myBuffer, (DirectCast(element, imageElement)).content)
                            _bufferLength += writeToBuffer(_myBuffer, Convert.ToChar(13).ToString())
                            _bufferLength += writeToBuffer(_myBuffer, Convert.ToChar(10).ToString())
                            _bufferLength += writeToBuffer(_myBuffer, "endstream" + Convert.ToChar(13) + Convert.ToChar(10))
                            _bufferLength += writeToBuffer(_myBuffer, "endobj" + Convert.ToChar(13) + Convert.ToChar(10))
                        Else
                            _trailer.addObject(_bufferLength.ToString())
                            _bufferLength += writeToBuffer(_myBuffer, element.getText())
                        End If

                    Next
                Next
                'PDF's trailer object
                _trailer.xrefOffset = _bufferLength
                _bufferLength += writeToBuffer(_myBuffer, _trailer.getText())
                'Buffer's flush
                _myBuffer.Flush()
            Catch ex As IOException
                Throw New pdfWritingErrorException("Errore nella scrittura del PDF", ex)
            Finally
                If _myBuffer IsNot Nothing Then
                    _myBuffer.Close()
                    _myBuffer = Nothing
                End If
            End Try
        End Sub

        ''' <summary>
        ''' Method that writes the PDF document on a file
        ''' </summary>
        ''' <param name="outputFile">String that represents the name of the output file</param>
        Public Sub createPDF(ByVal outputFile As String)
            Dim _myFileOut As FileStream = Nothing


            Try
                _myFileOut = New FileStream(outputFile, FileMode.Create)
                createPDF(_myFileOut)
            Catch exIO As IOException
                Throw New pdfWritingErrorException("Errore nella scrittura del file", exIO)
            Catch exPDF As pdfWritingErrorException
                Throw New pdfWritingErrorException("Errore nella scrittura del PDF", exPDF)
            Finally
                If _myFileOut IsNot Nothing Then
                    _myFileOut.Close()
                    _myFileOut = Nothing
                End If
            End Try
        End Sub

        ''' <summary>
        ''' Private method for the initialization of all PDF objects
        ''' </summary>
        Private Sub initializeObjects()

            'Page's counters
            Dim pageIndex As Integer = 1
            Dim pageNum As Integer = _pages.Count

            Dim counterID As Integer = 0
            'header			
            _header = New pdfHeader(_openBookmark)
            _header.objectIDHeader = 1
            _header.objectIDInfo = 2
            _header.objectIDOutlines = 3
            'Info
            _info = New pdfInfo(_title, _author)
            _info.objectIDInfo = 2
            'Outlines			
            _outlines.objectIDOutlines = 3
            counterID = 4
            'Bookmarks	
            counterID = _outlines.initializeOutlines(counterID)
            'fonts
            Dim i As Integer = 0
            While i < 12
                _fonts.Add(New pdfFont(DirectCast((i + 1), predefinedFont), i + 1))
                DirectCast(_fonts(i), pdfFont).objectID = counterID
                System.Math.Max(System.Threading.Interlocked.Increment(counterID), counterID - 1)
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            'pagetree
            _pageTree = New pdfPageTree()
            _pageTree.objectID = counterID
            _header.pageTreeID = counterID
            System.Math.Max(System.Threading.Interlocked.Increment(counterID), counterID - 1)
            'pages
            For Each page As pdfPage In _pages
                page.objectID = counterID
                page.pageTreeID = _pageTree.objectID
                page.addFonts(_fonts)
                _pageTree.addPage(counterID)
                System.Math.Max(System.Threading.Interlocked.Increment(counterID), counterID - 1)

                'Add page's Marker
                If _pageMarker IsNot Nothing Then
                    page.addText(_pageMarker.getMarker(pageIndex, pageNum), _pageMarker.coordX, _pageMarker.coordY, _pageMarker.fontType, _pageMarker.fontSize, _pageMarker.fontColor)
                End If

                'Add persistent elements
                If _persistentPage IsNot Nothing Then
                    page.elements.AddRange(_persistentPage.persistentElements)
                End If

                'page's elements
                For Each element As pdfElement In page.elements
                    element.objectID = counterID
                    System.Math.Max(System.Threading.Interlocked.Increment(counterID), counterID - 1)
                    'Imageobject
                    If element.[GetType]().Name = "imageElement" Then
                        DirectCast(element, imageElement).xObjectID = counterID
                        System.Math.Max(System.Threading.Interlocked.Increment(counterID), counterID - 1)
                    End If
                Next

                'Update page's index counter
                pageIndex += 1
            Next
            'trailer
            _trailer = New pdfTrailer(counterID - 1)
        End Sub

        ''' <summary>
        ''' Method that creates a new page
        ''' </summary>
        ''' <returns>New PDF's page</returns>
        Public Function addPage() As pdfPage
            _pages.Add(New pdfPage())
            Return DirectCast(_pages(_pages.Count - 1), pdfPage)
        End Function

        ''' <summary>
        ''' Method that creates a new page
        ''' </summary>
        ''' <returns>New PDF's page</returns>
        ''' <param name="height">Height of the new page</param>
        ''' <param name="width">Width of the new page</param>
        Public Function addPage(ByVal height As Integer, ByVal width As Integer) As pdfPage
            _pages.Add(New pdfPage(height, width))
            Return DirectCast(_pages(_pages.Count - 1), pdfPage)
        End Function

        Public Sub addBookmark(ByVal Bookmark As pdfBookmarkNode)
            _outlines.addBookmark(Bookmark)
        End Sub

        ''' <summary>
        ''' Method that writes into the buffer a string
        ''' </summary>
        ''' <param name="myBuffer">Output Buffer</param>
        ''' <param name="stringContent">String that contains the informations</param>
        ''' <returns>The number of the bytes written in the Buffer</returns>
        Private Function writeToBuffer(ByVal myBuffer As BufferedStream, ByVal stringContent As String) As Long
            Dim myEncoder As New ASCIIEncoding()
            Dim arrTemp As Byte()
            Try
                arrTemp = myEncoder.GetBytes(stringContent)
                myBuffer.Write(arrTemp, 0, arrTemp.Length)
                Return arrTemp.Length
            Catch ex As IOException
                Throw New pdfBufferErrorException("Errore nella scrittura del Buffer", ex)
            End Try
        End Function

        ''' <summary>
        ''' Method that writes into the buffer a string
        ''' </summary>
        ''' <param name="myBuffer">Output Buffer</param>
        ''' <param name="byteContent">A Byte array that contains the informations</param>
        ''' <returns>The number of the bytes written in the Buffer</returns>
        Private Function writeToBuffer(ByVal myBuffer As BufferedStream, ByVal byteContent As Byte()) As Long
            Try
                myBuffer.Write(byteContent, 0, byteContent.Length)
                Return byteContent.Length
            Catch ex As IOException
                Throw New pdfBufferErrorException("Errore nella scrittura del Buffer", ex)
            End Try
        End Function

    End Class
End Namespace

