
Imports System

Namespace sharpPDF.Exceptions
	''' <summary>
	''' Generic PDF Exception.
	''' </summary>
    Friend Class pdfException
        Inherits Exception
        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="message">Message for the exception</param>
        ''' <param name="ex">Inner exception</param>
        Public Sub New(ByVal message As String, ByVal ex As Exception)

            MyBase.New(message, ex)
        End Sub
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
