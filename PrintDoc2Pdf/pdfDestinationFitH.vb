
Imports System

Namespace sharpPDF
	''' <summary>
	''' Class that represents a pdfDestination of FitH type.
	''' </summary>
	Friend Class pdfDestinationFitH
		Implements IPdfDestination

		Private _top As Integer

		''' <summary>
		''' Class's constructor
		''' </summary>
		''' <param name="top">Top margin</param>
		Public Sub New(ByVal top As Integer)
			_top = top
		End Sub

		''' <summary>
		''' Method that returns the PDF codes to write the destination
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getDestinationValue() As String Implements IPdfDestination.getDestinationValue
            Return "/FitH " + _top.ToString()
        End Function

	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
