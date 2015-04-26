
Imports System
Imports System.Text
Imports System.Collections

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a PDF trailer.
	''' </summary>
	Friend Class pdfTrailer
		Implements IWritable

		Private _lastObjectID As Integer
		Private _objectOffsets As ArrayList
		Private _xrefOffset As Long

		''' <summary>
		''' The offset of the XREF table
		''' </summary>
		Public Property xrefOffset() As Long
			Get
				Return _xrefOffset
			End Get

			Set
				_xrefOffset = value
			End Set
		End Property

		''' <summary>
		''' Class's constructor
		''' </summary>
		''' <param name="lastObjectID">The ID of the last object in the document</param>
		Public Sub New(ByVal lastObjectID As Integer)
			_lastObjectID = lastObjectID
			_objectOffsets = New ArrayList()
		End Sub

        ''' <summary>
        ''' Class's destructor
        ''' </summary>
        Protected Overrides Sub Finalize()
            Try
                _objectOffsets = Nothing
            Finally
                MyBase.Finalize()
            End Try
        End Sub

		''' <summary>
		''' Method that adds an object to the trailer object
		''' </summary>
		''' <param name="offset"></param>
		Public Sub addObject(ByVal offset As String)
			_objectOffsets.Add(New String("0"C, 10 - offset.Length) + offset)
		End Sub

		''' <summary>
		''' Method that returns the PDF codes to write the trailer in the document
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getText() As String Implements IWritable.getText
            Dim content As New StringBuilder()
            content.Append("xref" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("0 " + (_lastObjectID + 1).ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("0000000000 65535 f" + Convert.ToChar(13) + Convert.ToChar(10))
            For Each offset As Object In _objectOffsets
                content.Append(offset.ToString() + " 00000 n" + Convert.ToChar(13) + Convert.ToChar(10))
            Next
            content.Append("trailer" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("<<" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("/Size " + (_lastObjectID + 1).ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("/Root 1 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("/Info 2 0 R" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append(">>" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("startxref" + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append(_xrefOffset.ToString() + Convert.ToChar(13) + Convert.ToChar(10))
            content.Append("%%EOF")
            Return content.ToString()
        End Function

	End Class
End Namespace

