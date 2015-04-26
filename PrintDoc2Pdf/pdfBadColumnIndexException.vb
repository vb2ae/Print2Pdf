
Imports System

Namespace sharpPDF.Exceptions
	''' <summary>
	''' Exception that represents an error during an access on the pdfTableRow's columns with a bad index
	''' </summary>
    Friend Class pdfBadColumnIndexException
        Inherits pdfException
        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        Public Sub New()
            MyBase.New("The columnd index does not exist", Nothing)
        End Sub
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
