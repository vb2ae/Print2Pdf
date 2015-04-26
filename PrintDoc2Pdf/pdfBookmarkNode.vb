
Imports System
Imports System.Text
Imports System.Collections

Imports PrintDoc2Pdf.sharpPDF.Enumerators
Imports PrintDoc2Pdf.sharpPDF.Exceptions

Namespace sharpPDF
	''' <summary>
	''' Class that representa a single bookmark element
	''' </summary>
    Friend Class pdfBookmarkNode
        Implements IWritable
        Implements IComparable

        ''' <summary>
        ''' Method that allows to compare pdfBookmarkNodes (Inherited from IComparable)
        ''' </summary>
        ''' <param name="obj">Object to compare</param>
        ''' <returns>Compare result</returns>
        Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
            If TypeOf obj Is pdfBookmarkNode Then
                Dim myComparableNode As pdfBookmarkNode = DirectCast(obj, pdfBookmarkNode)
                Return _ObjectID.CompareTo(myComparableNode.ObjectID)
            Else
                Throw New ArgumentException("Object is not a pdfBookmarkNode")
            End If
        End Function


        Private _Title As String
        Private _Page As pdfPage
        Private _Destination As IPdfDestination
        Private _open As Boolean
        Private _ObjectID As Integer
        Private _prev As Integer
        Private _next As Integer
        Private _first As Integer
        Private _last As Integer
        Private _parent As Integer
        Private _childCount As Integer
        Private _Childs As New ArrayList()

        ''' <summary>
        ''' Bookmark's title
        ''' </summary>
        Friend ReadOnly Property Title() As String
            Get
                Return _Title
            End Get
        End Property

        ''' <summary>
        ''' Page's reference for the bookmark
        ''' </summary>
        Friend ReadOnly Property Page() As pdfPage
            Get
                Return _Page
            End Get
        End Property

        ''' <summary>
        ''' Destination of the bookmark
        ''' </summary>
        Friend ReadOnly Property Destination() As IPdfDestination
            Get
                Return _Destination
            End Get
        End Property

        ''' <summary>
        ''' The visibility of bookmark's childs
        ''' </summary>
        Friend ReadOnly Property open() As Boolean
            Get
                Return _open
            End Get
        End Property

        ''' <summary>
        ''' Bookmark's ID
        ''' </summary>
        Friend Property ObjectID() As Integer
            Get
                Return _ObjectID
            End Get
            Set(ByVal value As Integer)
                _ObjectID = Value
            End Set
        End Property

        ''' <summary>
        ''' Prev bookmark ID
        ''' </summary>
        Friend Property prev() As Integer
            Get
                Return _prev
            End Get
            Set(ByVal value As Integer)
                _prev = Value
            End Set
        End Property

        ''' <summary>
        ''' Next bookmark ID
        ''' </summary>
        Friend Property [next]() As Integer
            Get
                Return _next
            End Get
            Set(ByVal value As Integer)
                _next = Value
            End Set
        End Property

        ''' <summary>
        ''' First child ID
        ''' </summary>
        Friend Property first() As Integer
            Get
                Return _first
            End Get
            Set(ByVal value As Integer)
                _first = Value
            End Set
        End Property

        ''' <summary>
        ''' Last child ID
        ''' </summary>
        Friend Property last() As Integer
            Get
                Return _last
            End Get
            Set(ByVal value As Integer)
                _last = Value
            End Set
        End Property

        ''' <summary>
        ''' Bokkmark's partent ID
        ''' </summary>
        Friend Property parent() As Integer
            Get
                Return _parent
            End Get
            Set(ByVal value As Integer)
                _parent = Value
            End Set
        End Property

        ''' <summary>
        ''' Number of childs
        ''' </summary>
        Friend Property childCount() As Integer
            Get
                Return _childCount
            End Get
            Set(ByVal value As Integer)
                _childCount = Value
            End Set
        End Property

        ''' <summary>
        ''' Bookmark's childs
        ''' </summary>
        Friend ReadOnly Property Childs() As ArrayList
            Get
                Return _Childs
            End Get
        End Property

        ''' <summary>
        ''' Method that returns the first child
        ''' </summary>
        ''' <returns>Object that represent the first child</returns>
        Friend Function getFirstChild() As pdfBookmarkNode
            If _childCount > 0 Then
                Return DirectCast(_Childs(0), pdfBookmarkNode)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Method that returns the last child
        ''' </summary>
        ''' <returns>Object that represent the last child</returns>
        Friend Function getLastChild() As pdfBookmarkNode
            If _childCount > 0 Then
                Return DirectCast(_Childs(_Childs.Count - 1), pdfBookmarkNode)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="Title">Bookmark's title</param>
        ''' <param name="Page">Destination Page</param>
        ''' <param name="openBookmark">The visibility of bookmark's childs</param>
        Public Sub New(ByVal Title As String, ByVal Page As pdfPage, ByVal openBookmark As Boolean)
            _Title = Title
            _Page = Page
            _Destination = Nothing
            _prev = 0
            _next = 0
            _first = 0
            _last = 0
            _parent = 0
            _childCount = 0
            _open = openBookmark
        End Sub

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="Title">Bookmark's title</param>
        ''' <param name="Page">Destination Page</param>
        ''' <param name="openBookmark">The visibility of bookmark's childs</param>
        ''' <param name="Destination">Destination object</param>
        Public Sub New(ByVal Title As String, ByVal Page As pdfPage, ByVal openBookmark As Boolean, ByVal Destination As IPdfDestination)
            _Title = Title
            _Page = Page
            _Destination = Destination
            _prev = 0
            _next = 0
            _first = 0
            _last = 0
            _parent = 0
            _childCount = 0
            _open = openBookmark
        End Sub

        ''' <summary>
        ''' Method that add a child to the bookmark
        ''' </summary>
        ''' <param name="Child">Child object</param>
        Public Sub addChildNode(ByVal Child As pdfBookmarkNode)
            _Childs.Add(Child)
        End Sub

        ''' <summary>
        ''' Method that returns the PDF codes to write the object in the document
        ''' </summary>
        ''' <returns>String that contains PDF codes</returns>
        Public Function getText() As String Implements IWritable.getText
            Dim strBookmark As New StringBuilder()
            strBookmark.Append(_ObjectID.ToString() + " 0 obj" + Convert.ToChar(13) + Convert.ToChar(10))
            strBookmark.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
            strBookmark.Append("/Title (" + textAdapter.checkText(_Title) + ")" + Convert.ToChar(13) + Convert.ToChar(10))
            If _prev > 0 Then
                strBookmark.Append("/Prev " + _prev.ToString() + " 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
            End If
            If _next > 0 Then
                strBookmark.Append("/Next " + _next.ToString() + " 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
            End If
            If _parent > 0 Then
                strBookmark.Append("/Parent " + _parent.ToString() + " 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
            End If
            If _childCount > 0 Then
                strBookmark.Append("/First " + _first.ToString() + " 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
                strBookmark.Append("/Last " + _last.ToString() + " 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
                If _open Then
                    strBookmark.Append("/Count " + _childCount.ToString() + Convert.ToChar(13) + Convert.ToChar(10))
                End If
            End If
            If _Destination IsNot Nothing Then
                strBookmark.Append("/Dest [" + _Page.objectID.ToString() + " 0 R " + _Destination.getDestinationValue() + "]" + Convert.ToChar(13) + Convert.ToChar(10))
            End If
            strBookmark.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            strBookmark.Append("endobj" + Convert.ToChar(13) + Convert.ToChar(10))
            Return strBookmark.ToString()
        End Function


    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
