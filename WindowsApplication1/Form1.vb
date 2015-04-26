Imports System.Data.SqlClient
Imports PrintDoc2Pdf

Public Class Form1
    Public WithEvents p As New Printing.PrintDocument
    Dim iRecord As Integer = 0
    Dim fntPrice As New Font("Arial", 12)
    Dim ds As New DataSet

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If PrintDialog1.PrinterSettings.PrintToFile = True Then
                With PdfPrinter1
                    .Title = "Product Catalog"
                    .Author = "Ken Tucker"
                    .FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\NorthwindCatalog.pdf"
                    Try
                        .Print()
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                    End Try
                End With
            Else
                PrintDocument1.Print()
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strConn As String
        Dim conn As SqlConnection
        Dim da As SqlDataAdapter

        strConn = "Server = .\SQLEXPRESS;"
        strConn &= "Database = Northwind; Integrated Security = SSPI;"
        conn = New SqlConnection(strConn)
        da = New SqlDataAdapter("Select ProductName, UnitPrice From Products", conn)
        da.Fill(ds, "Products")

        DataGridView1.DataSource = ds.Tables("Products")
    End Sub


    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        iRecord = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim g As Graphics = e.Graphics
        Dim iPageHeight As Integer = e.PageBounds.Height
        Dim iPageWidth As Integer = e.PageBounds.Width
        Dim iFntHeight As Integer = CInt(g.MeasureString("Test", fntPrice).Height)
        Dim iLinesPerPage As Integer = iPageHeight \ iFntHeight - 15
        Dim yPos As Integer = 0
        Dim iTop As Integer
        Dim iMax As Integer = ds.Tables("Products").Rows.Count
        Dim strDescription As String
        Dim x As Integer
        Dim xPos As Integer
        Dim strPrice As String
        Dim fntTitle As Font = New Font("Microsoft Sans Serf", 14)
        Dim iCount As Integer = ds.Tables("Products").Rows.Count
        Dim strDate As String = Trim(Now.ToLongDateString)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Far

        xPos = CInt(iPageWidth - g.MeasureString("Price List", fntTitle).Width) \ 2
        g.DrawString("Price List", fntTitle, Brushes.Black, xPos, 10)
        yPos = 10 + CInt(g.MeasureString("Price List", fntTitle).Height)

        xPos = CInt(iPageWidth - g.MeasureString(strDate, fntPrice).Width) \ 2
        g.DrawString(strDate, fntPrice, Brushes.Black, xPos, yPos)
        yPos += 2 * iFntHeight
        g.DrawString("Product", fntPrice, Brushes.Black, 50, yPos)

        g.DrawString("Price", fntPrice, Brushes.Black, _
                New Rectangle(430, yPos, 100, 2 * iFntHeight), sf)

        yPos += iFntHeight
        g.DrawLine(Pens.Black, 0, yPos, iPageWidth, yPos)

        e.HasMorePages = True
        iTop = yPos

        For x = 0 To iLinesPerPage
            If iRecord < iMax Then
                With ds.Tables("Products").Rows(iRecord)
                    strDescription = .Item("ProductName").ToString
                    strPrice = Convert.ToDecimal(.Item("UnitPrice")).ToString("c")
                End With
                Dim rName As New Rectangle(5, yPos, 400, iFntHeight)
                Dim rPrice As New Rectangle(430, yPos, 100, iFntHeight)

                g.DrawString(strDescription, fntPrice, Brushes.Black, rName)
                g.DrawString(strPrice, fntPrice, Brushes.Black, rPrice, sf)
            Else
                e.HasMorePages = False
            End If
            yPos += iFntHeight
            iRecord += 1
        Next
        fntTitle.Dispose()
        If e.HasMorePages = False Then iRecord = 0
    End Sub
End Class
