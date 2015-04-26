
Imports System

Imports PrintDoc2Pdf.sharpPDF
Imports PrintDoc2Pdf.sharpPDF.Enumerators
Imports PrintDoc2Pdf.sharpPDF.Exceptions

Namespace sharpPDF
	''' <summary>
	''' Class that represent a destination into a pdf document
	''' </summary>
    Friend MustInherit Class pdfDestinationFactory

        ''' <summary>
        ''' Method that creates a pdfDestination with XYZ type
        ''' </summary>
        ''' <param name="left">Left margin</param>
        ''' <param name="top">Top margin</param>
        ''' <param name="zoom">Page's zoom</param>
        ''' <returns>pdfDestination object</returns>
        Public Shared Function createPdfDestinationXYZ(ByVal left As Integer, ByVal top As Integer, ByVal zoom As Integer) As IPdfDestination
            Return New pdfDestinationXYZ(left, top, zoom)
        End Function

        ''' <summary>
        ''' Method that creates a pdfDestination with Fit type
        ''' </summary>
        ''' <returns>pdfDestination object</returns>
        Public Shared Function createPdfDestinationFit() As IPdfDestination
            Return New pdfDestinationFit()
        End Function

        ''' <summary>
        ''' Method that creates a pdfDestination with FitH type
        ''' </summary>
        ''' <param name="top">Top margin</param>
        ''' <returns>pdfDestination object</returns>
        Public Shared Function createPdfDestinationFitH(ByVal top As Integer) As IPdfDestination
            Return New pdfDestinationFitH(top)
        End Function

        ''' <summary>
        ''' Method that creates a pdfDestination with FitV type
        ''' </summary>
        ''' <param name="left">Left margin</param>
        ''' <returns>pdfDestination object</returns>
        Public Shared Function createPdfDestinationFitV(ByVal left As Integer) As IPdfDestination
            Return New pdfDestinationFitV(left)
        End Function

        ''' <summary>
        ''' Mathod that creates a pdfDestination with FitR type
        ''' </summary>
        ''' <param name="left">Left margin</param>
        ''' <param name="top">Top margin</param>
        ''' <param name="bottom">Bottom margin</param>
        ''' <param name="right">Right margin</param>
        ''' <returns>pdfDestination object</returns>
        Public Shared Function createPdfDestinationFitR(ByVal left As Integer, ByVal top As Integer, ByVal bottom As Integer, ByVal right As Integer) As IPdfDestination
            Return New pdfDestinationFitR(left, top, bottom, right)
        End Function

    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
