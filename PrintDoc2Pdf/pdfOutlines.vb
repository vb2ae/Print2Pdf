
Imports System
Imports System.Text
Imports System.Collections

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a PDF Outlines.
	''' </summary>
	Friend Class pdfOutlines
		Implements IWritable

		Private _objectIDOutlines As Integer
		Private _childIDFirst As Integer = 0
		Private _childIDLast As Integer = 0
		Private _childCount As Integer = 0
		Private _BookmarkRoot As New ArrayList()

		''' <summary>
		''' Outlines's ID
		''' </summary>
		Public Property objectIDOutlines() As Integer
			Get
				Return _objectIDOutlines
			End Get

			Set
				_objectIDOutlines = value
			End Set
		End Property

		''' <summary>
		''' Class's constructor
		''' </summary>

		Public Sub New()
		End Sub

		''' <summary>
		''' Method that initialize
		''' </summary>
		''' <param name="counterID">Initial Object ID</param>
		''' <returns>Updated Object ID</returns>
		Public Function initializeOutlines(ByVal counterID As Integer) As Integer
			If _BookmarkRoot.Count > 0 Then
				initializeBookmarks(counterID, _BookmarkRoot, _objectIDOutlines)
				_childIDFirst = (DirectCast(_BookmarkRoot(0), pdfBookmarkNode)).ObjectID
				_childIDLast = (DirectCast(_BookmarkRoot(_BookmarkRoot.Count - 1), pdfBookmarkNode)).ObjectID
				counterID += _childCount
			Else
				_childCount = 0
				_childIDFirst = 0
				_childIDLast = 0
			End If
			Return counterID
		End Function

		''' <summary>
		''' Method that adds a bookmark to the outlines object
		''' </summary>
		''' <param name="Bookmark">BookmarkNode Object</param>
		Public Sub addBookmark(ByVal Bookmark As pdfBookmarkNode)
			_BookmarkRoot.Add(Bookmark)
		End Sub

		''' <summary>
		''' Method that initialize all bookmarks
		''' </summary>
		''' <param name="CounterID">Initial Object ID</param>
		''' <param name="StartPoint">ArrayList of BookmarkNodes of the same level</param>
		''' <param name="FatherID">Object ID of the father</param>
		''' <returns>Number of childs</returns>
		Private Function initializeBookmarks(ByVal CounterID As Integer, ByVal StartPoint As ArrayList, ByVal FatherID As Integer) As Integer
			Dim currentNodes As Integer = 0
			If StartPoint.Count > 0 Then
				Dim Node As pdfBookmarkNode
				Dim i As Integer = 0
				While i < StartPoint.Count
					Node = DirectCast(StartPoint(i), pdfBookmarkNode)
					Node.ObjectID = CounterID + _childCount
					Node.parent = FatherID
					System.Math.Max(System.Threading.Interlocked.Increment(currentNodes),currentNodes - 1)
					System.Math.Max(System.Threading.Interlocked.Increment(_childCount),_childCount - 1)
					Node.childCount = initializeBookmarks(CounterID, Node.Childs, Node.ObjectID)
					If Node.childCount > 0 Then
						Node.first = Node.getFirstChild().ObjectID
						Node.last = Node.getLastChild().ObjectID
					End If
					If StartPoint.Count > 1 Then
						If i > 0 Then
							Node.prev = (DirectCast(StartPoint(i - 1), pdfBookmarkNode)).ObjectID
						End If
						If i < (StartPoint.Count - 1) Then
							Node.[next] = CounterID + _childCount
							

						End If
					End If
					currentNodes += Node.childCount
					System.Math.Max(System.Threading.Interlocked.Increment(i),i - 1)
				End While
			End If
			Return currentNodes
		End Function

		''' <summary>
		''' Method that returns the PDF codes to write the Outlines in the document
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getText() As String Implements IWritable.getText
            Dim strOutlines As New StringBuilder()
            strOutlines.Append(_objectIDOutlines.ToString() + " 0 obj" + Convert.ToChar(13) + Convert.ToChar(10))
            strOutlines.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
            strOutlines.Append("/Type /Outlines" + Convert.ToChar(13) + Convert.ToChar(10))
            If _childCount <> 0 Then
                strOutlines.Append("/First " + _childIDFirst.ToString() + " 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
                strOutlines.Append("/Last " + _childIDLast.ToString() + " 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
                strOutlines.Append("/Count " + _childCount.ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            Else
                strOutlines.Append("/Count 0" + Convert.ToChar(13) + Convert.ToChar(10))
            End If
            strOutlines.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            strOutlines.Append("endobj" + Convert.ToChar(13) + Convert.ToChar(10))
            Return strOutlines.ToString()
        End Function

		''' <summary>
		''' Method that returns all nodes from a start collection
		''' </summary>
		''' <param name="StartPoint">ArrayList with the start point of pdfBookmarkNodes</param>
		''' <returns>Collection of all pdfBookmarkNodes from the start point</returns>
		Private Function getNodes(ByVal StartPoint As ArrayList) As ArrayList
			Dim resultList As New ArrayList()
			If StartPoint.Count > 0 Then
				resultList.AddRange(StartPoint)
				For Each Node As pdfBookmarkNode In StartPoint
					resultList.AddRange(getNodes(Node.Childs))
				Next
			End If
			Return resultList
		End Function

		''' <summary>
		''' Method that returns a sorted(by objectID) collection of pdfBookmarkNodes
		''' </summary>
		''' <returns>Sorted bookmark collection</returns>
		Public Function getBookmarks() As ArrayList
			Dim returnedList As ArrayList = getNodes(_BookmarkRoot)
			returnedList.Sort()
			Return returnedList
		End Function

	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
