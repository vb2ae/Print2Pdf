Imports System.Drawing
Imports PrintDoc2Pdf.sharpPDF

Public Class PdfPrintController
    Inherits Printing.PrintController
    Dim pdf As pdfDocument
    Dim bm As Image

    Private _Author As String = ""

    Public Property Author() As String
        Get
            Return _Author
        End Get
        Set(ByVal value As String)
            _Author = value
        End Set
    End Property

    Private _FileName As String = ""
    Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property

    Private _Title As String = ""
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property

    Public Overrides ReadOnly Property IsPreview() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Function OnStartPage(ByVal document As System.Drawing.Printing.PrintDocument, ByVal e As System.Drawing.Printing.PrintPageEventArgs) As System.Drawing.Graphics
        bm = New Bitmap(e.PageBounds.Width, e.PageBounds.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        g.Clear(Color.White)
        Return g
    End Function

    Public Overrides Sub OnStartPrint(ByVal document As System.Drawing.Printing.PrintDocument, ByVal e As System.Drawing.Printing.PrintEventArgs)
        Try
            pdf = New pdfDocument(Title, Author)
        Catch ex As Exception
            Throw ex
        End Try
        MyBase.OnStartPrint(document, e)
    End Sub

    Public Overrides Sub OnEndPage(ByVal document As System.Drawing.Printing.PrintDocument, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Try
            Dim p As pdfPage = pdf.addPage(e.PageBounds.Height, e.PageBounds.Width)
            p.addImage(bm, 0, 0)
        Catch ex As Exception
            Throw ex
        End Try
        MyBase.OnEndPage(document, e)
    End Sub

    Public Overrides Sub OnEndPrint(ByVal document As System.Drawing.Printing.PrintDocument, ByVal e As System.Drawing.Printing.PrintEventArgs)
        Try
            pdf.createPDF(FileName)
        Catch ex As Exception
            Throw ex
        End Try
        MyBase.OnEndPrint(document, e)
    End Sub

End Class
