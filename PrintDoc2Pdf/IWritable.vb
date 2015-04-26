
Imports System

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' Generic interface for pdf's objects
	''' </summary>	
	Friend Interface IWritable
		''' <summary>
		''' Method that returns the PDF codes to write the object in the document
		''' </summary>
		''' <returns>String that contains PDF codes</returns>
		Function getText() As String
	End Interface
End Namespace

