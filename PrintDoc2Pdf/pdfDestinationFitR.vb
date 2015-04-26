
Imports System

Namespace sharpPDF
	''' <summary>
	''' Class that represents a pdfDestination of FitR type.
	''' </summary>
	Friend Class pdfDestinationFitR
		Implements IPdfDestination

		Private _left As Integer
		Private _top As Integer
		Private _bottom As Integer
		Private _right As Integer

		''' <summary>
		''' Class's constructor
		''' </summary>
		''' <param name="left">Left margin</param>
		''' <param name="top">Top margin</param>
		''' <param name="bottom">Bottom margin</param>
		''' <param name="right">Right margin</param>
		Public Sub New(ByVal left As Integer, ByVal top As Integer, ByVal bottom As Integer, ByVal right As Integer)
			_left = left
			_top = top
			_bottom = bottom
			_right = right
		End Sub

		''' <summary>
		''' Method that returns the PDF codes to write the destination
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getDestinationValue() As String Implements IPdfDestination.getDestinationValue
            Return "/FitR " + _left.ToString() + " " + _top.ToString() + " " + _bottom.ToString() + " " + _right.ToString()
        End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
