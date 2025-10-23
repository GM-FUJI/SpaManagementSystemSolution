Imports Microsoft.Data.SqlClient

Public Class Form1

    Private connectionString As String = "Data Source=DESKTOP-UKNIJ8J\SQLEXPRESS;Initial Catalog=SpaManagementSystem;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"

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
        If txtUsername.Text = "" Or txtUsername.Text = "Username" Then
            MsgBox("Enter the username")
            txtUsername.Focus()
            Exit Sub
        End If

        If txtPassword.Text = "" Or txtPassword.Text = "Password" Then
            MsgBox("Enter the password")
            txtPassword.Focus()
            Exit Sub
        End If

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim sql As String = "SELECT Password, Role FROM Users WHERE Username = @user"
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim dbPass As String = reader("Password").ToString()
                            Dim role As String = reader("Role").ToString()

                            If txtPassword.Text = dbPass Then
                                If role.ToLower() = "admin" Then
                                    Dim adminForm As New Form2()
                                    adminForm.Show()
                                    Me.Hide()
                                ElseIf role.ToLower() = "therapist" Then
                                    Dim therapistForm As New TherapistForm()
                                    therapistForm.LoggedInUser = txtUsername.Text.Trim()
                                    therapistForm.Show()
                                    Me.Hide()
                                Else
                                    MsgBox("Unknown role.")
                                End If
                            Else
                                MsgBox("Invalid username or password", MsgBoxStyle.Critical)
                            End If
                        Else
                            MsgBox("Invalid username or password", MsgBoxStyle.Critical)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
