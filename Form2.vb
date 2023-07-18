
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Drawing.Printing

Public Class Form2
    Dim con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Fanin\Documents\BDF.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd As New SqlCommand

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con.Open()
            cmd = New SqlCommand("insert into Etudiant values(@cne, @annee, @filiere, @profil)", con)
            cmd.Parameters.AddWithValue("@cne", TextBox1.Text)
            cmd.Parameters.AddWithValue("@annee", TextBox2.Text)
            cmd.Parameters.AddWithValue("@filiere", TextBox3.Text)

            ' Convert the image to binary data
            Dim ms As New MemoryStream()
            PictureBox1.Image.Save(ms, ImageFormat.Jpeg)
            Dim imgData As Byte() = ms.ToArray()

            cmd.Parameters.AddWithValue("@profil", imgData)
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
            cmd = New SqlCommand("DELETE FROM Etudiant WHERE cne='" & TextBox1.Text & "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Record deleted successfully!")
        Catch ex As Exception
            MessageBox.Show("Error deleting record: " & ex.Message)
        End Try
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            con.Open()
            Dim ms As New MemoryStream()
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim img As Byte() = ms.ToArray()
            ms.Close()
            cmd = New SqlCommand("UPDATE Etudiant SET filiere='" & TextBox2.Text & "', Annee='" & TextBox3.Text & "', profil =@img WHERE cne='" & TextBox1.Text & "'", con)
            cmd.Parameters.AddWithValue("@img", img)
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Bien modifié !")
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub




    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form3.Show()
    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Hide()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim op As OpenFileDialog = New OpenFileDialog
        If op.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(op.FileName)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        con.Open()
        Dim query As String = "SELECT * FROM Etudiant"

        Dim da As New SqlDataAdapter(query, con)

        Dim dt As New DataTable

        da.Fill(dt)

        con.Close()

        Form4.DataGridView1.DataSource = dt

        Form4.Show()
    End Sub

End Class