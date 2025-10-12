Imports Microsoft.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = "Username"
        txtUsername.ForeColor = Color.DarkGray

        txtPassword.Text = "Password"
        txtPassword.ForeColor = Color.DarkGray
    End Sub

    Private Sub txtUsername_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        If txtUsername.Text = "Username" Then
            txtUsername.Text = ""
            txtUsername.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtUsername_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus
        If txtUsername.Text = "" Then
            txtUsername.Text = "Username"
            txtUsername.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
            txtPassword.PasswordChar = "•"
            txtPassword.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If txtPassword.Text = "" Then
            txtPassword.Text = "Password"
            txtPassword.PasswordChar = ""
            txtPassword.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If (txtUsername.Text = "" Or txtUsername.Text = "Username") Then
            MsgBox("Enter the username")
            txtUsername.Focus()
            Exit Sub
        End If

        If (txtPassword.Text = "" Or txtPassword.Text = "Password") Then
            MsgBox("Enter the Password")
            txtPassword.Focus()
            Exit Sub
        End If

        Try

            Dim con As New SqlConnection("Data Source=DESKTOP-UKNIJ8J\SQLEXPRESS;Initial Catalog=SpaManagementSystem;Integrated Security=True;Encrypt=False;TrustServerCertificate=True")

            con.Open()

            Dim cmd As New SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@user AND Password=@pass", con)
            cmd.Parameters.AddWithValue("@user", txtUsername.Text)
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text)

            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If count > 0 Then
                MsgBox("Login Successful", MsgBoxStyle.Information)

                Dim f2 As New Form2()
                f2.Show()
                Me.Hide()
            Else
                MsgBox("Invalid Username or Password", MsgBoxStyle.Critical)
            End If

            con.Close()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub


End Class
