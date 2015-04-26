
Imports System

Namespace sharpPDF
	''' <summary>
	''' Class that represents a pdfDestination of Fit type.
	''' </summary>
	Friend Class pdfDestinationFit
		Implements IPdfDestination

		''' <summary>
		''' Class's constructor
		''' </summary>

		Public Sub New()
		End Sub

		''' <summary>
		''' Method that returns the PDF codes to write the destination
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
        Public Function getDestinationValue() As String Implements IPdfDestination.getDestinationValue
            Return "/Fit"
        End Function

	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
