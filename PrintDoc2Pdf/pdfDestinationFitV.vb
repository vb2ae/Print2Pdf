
Imports System

Namespace sharpPDF
	''' <summary>
	''' Class that represents a pdfDestination of FitV type.
	''' </summary>
	Friend Class pdfDestinationFitV
		Implements IPdfDestination
		Private _left As Integer

		''' <summary>
		''' Class's constructor
		''' </summary>
		''' <param name="left">Left margin</param>
		Public Sub New(ByVal left As Integer)
			_left = left
		End Sub

		''' <summary>
		''' Method that returns the PDF codes to write the destination
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getDestinationValue() As String Implements IPdfDestination.getDestinationValue
            Return "/FitV " + _left.ToString()
        End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
