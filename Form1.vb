Imports System.Data.SqlClient

Public Class Form1
    Dim con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Fanin\Documents\BDF.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd As New SqlCommand


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "mouad" And TextBox2.Text = "fanine" Then
            Form2.Show()
            Me.Hide()
        Else
            MsgBox("sorry incorrect username and passwor", MsgBoxStyle.OkOnly, "invalide")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = "  "
        TextBox2.Text = "  "

        TextBox2.Focus()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
End Class

