
Imports System.Data.SqlClient
Public Class Form4
    Dim con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Fanin\Documents\BDF.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd As New SqlCommand
    Dim dt As New DataTable

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.Open()
        Dim query As String = "SELECT * FROM Etudiant"
        Dim da As New SqlDataAdapter(query, con)
        da.Fill(dt)
        con.Close()

        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form5.Show()
    End Sub
End Class