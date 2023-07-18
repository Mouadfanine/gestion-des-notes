Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging


Public Class Form3
    Dim con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Fanin\Documents\BDF.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd As New SqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            con.Open()
            cmd = New SqlCommand("insert into Bulletin values( @notes)", con)
            Dim ms As New MemoryStream()
            PictureBox2.Image.Save(ms, ImageFormat.Jpeg)
            Dim imgData As Byte() = ms.ToArray()

            cmd.Parameters.AddWithValue("@notes", imgData)
            cmd.ExecuteNonQuery()
            MsgBox("bien ajouter")
            con.Close()
        Catch ex As Exception
            MsgBox("ne pas ajouter. Erreur: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            con.Open()
            cmd = New SqlCommand("SELECT profil FROM Bulletin WHERE cne='" & TextBox1.Text & "'", con)
            Dim img As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
            If img IsNot Nothing Then
                Dim ms As New MemoryStream(img)
                PictureBox2.Image = Image.FromStream(ms)
            Else
                MsgBox("Aucune image trouvée pour le CNE donné !")
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Erreur lors de la récupération de l'image. Erreur : " & ex.Message)
        End Try
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        con.Open()

        Dim query As String = "SELECT * FROM Etudiant"
        Dim da As New SqlDataAdapter(query, con)

        Dim dt As New DataTable

        da.Fill(dt)
        con.Close()
        Form4.DataGridView1.DataSource = dt

        Form4.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim op As OpenFileDialog = New OpenFileDialog
        If op.ShowDialog = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(op.FileName)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub
End Class