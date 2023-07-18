Imports System.Data.SqlClient
Public Class Form5
    Dim con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Fanin\Documents\BDF.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd As New SqlCommand
    Dim dt As New DataTable

    Private Sub PrintPreviewControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        con.Open()
        Dim font As New Font("Arial", 17, FontStyle.Bold)
        Dim ce = Form4.DataGridView1.CurrentCell.RowIndex
        Dim St As String = "Code D'étudent CNE : "
        e.Graphics.DrawString(St + Form4.DataGridView1.Item(Form4.DataGridView1.Columns(0).HeaderText, ce).Value.ToString, font, Brushes.Black, 280, 200)
        Dim cc = Form4.DataGridView1.CurrentCell.RowIndex
        Dim ck As String = "Filiere : "
        e.Graphics.DrawString(ck + Form4.DataGridView1.Item(Form4.DataGridView1.Columns(1).HeaderText, cc).Value.ToString, font, Brushes.Black, 280, 250)
        Dim ee = Form4.DataGridView1.CurrentCell.RowIndex
        Dim ea As String = "Annee Scolaire : "
        e.Graphics.DrawString(ea + Form4.DataGridView1.Item(Form4.DataGridView1.Columns(2).HeaderText, ee).Value.ToString, font, Brushes.Black, 280, 300)
        Dim zz = Form4.DataGridView1.CurrentCell.RowIndex
        Dim ze As String = "Profil : "
        e.Graphics.DrawString(ze + Form4.DataGridView1.Item(Form4.DataGridView1.Columns(3).HeaderText, zz).Value.ToString, font, Brushes.Black, 280, 350)
        con.Close()

    End Sub

End Class