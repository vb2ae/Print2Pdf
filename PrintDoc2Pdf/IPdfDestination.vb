
Imports System

Imports PrintDoc2Pdf.sharpPDF.Enumerators
Imports PrintDoc2Pdf.sharpPDF.Exceptions

Namespace sharpPDF
	''' <summary>
	''' Interface for a pdfDestination
	''' </summary>
    Friend Interface IPdfDestination
        ''' <summary>
        ''' Method that returns the PDF codes to write the destination
        ''' </summary>
        ''' <returns>String that contains PDF codes</returns>
        Function getDestinationValue() As String
    End Interface
End Namespace

