Imports System.Drawing.Printing
Imports System.ComponentModel
Imports System.Drawing

<ToolboxBitmap(GetType(pdfPrinter), "document.ico")> _
Public Class pdfPrinter
    Inherits System.ComponentModel.Component

    Private _Author As String = ""

    Public Property Author() As String
        Get
            Return _Author
        End Get
        Set(ByVal value As String)
            _Author = value
        End Set
    End Property

    Private _FileName As String = "Printed.pdf"
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


    Private _Document As PrintDocument
    Public Property Document() As PrintDocument
        Get
            Return _Document
        End Get
        Set(ByVal value As PrintDocument)
            _Document = value
        End Set
    End Property

    Public Sub Print()
        Dim pc As New PdfPrintController
        pc.Title = Title
        pc.Author = Author
        pc.FileName = FileName
        Document.PrintController = pc
        Try
            Document.Print()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
