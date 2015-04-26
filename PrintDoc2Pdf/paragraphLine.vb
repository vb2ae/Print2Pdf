
Imports System
Imports System.Text

Imports PrintDoc2Pdf.sharpPDF.Exceptions
Imports PrintDoc2Pdf.sharpPDF.Enumerators

Namespace sharpPDF
	''' <summary>
	''' A Class that implements a PDF paragraph's line.
	''' </summary>
    Friend Class paragraphLine
        Implements IWritable
        Private _strLine As String
        Private _lineLeftMargin As Integer
        Private _lineTopMargin As Integer

        ''' <summary>
        ''' Class's constructor
        ''' </summary>
        ''' <param name="strLine">Text of the line</param>
        ''' <param name="lineTopMargin">Top margin</param>
        ''' <param name="lineLeftMargin">Left margin</param>
        Public Sub New(ByVal strLine As String, ByVal lineTopMargin As Integer, ByVal lineLeftMargin As Integer)
            _strLine = strLine
            _lineTopMargin = lineTopMargin
            _lineLeftMargin = lineLeftMargin
        End Sub

        ''' <summary>
        ''' Method that returns the PDF codes to write the paragraph's line in the document
        ''' </summary>
        ''' <returns>String that contains PDF codes</returns>
        Public Function getText() As String Implements IWritable.getText
            Dim resultString As New StringBuilder()
            resultString.Append(_lineLeftMargin.ToString() + " -" + _lineTopMargin.ToString() + " Td" + Convert.ToChar(13) + Convert.ToChar(10))
            resultString.Append("(" + textAdapter.checkText(_strLine) + ") Tj" + Convert.ToChar(13) + Convert.ToChar(10))
            resultString.Append("-" + _lineLeftMargin.ToString().Replace(",", ".") + " 0 Td" + Convert.ToChar(13) + Convert.ToChar(10))
            Return resultString.ToString()
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Built and maintained by Todd Anglin and Telerik
'=======================================================
