Imports Microsoft.Data.SqlClient

Public Class Attendance

    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;"


    Public LoggedInUser As String


    Private Sub btnTimeIn_Click(sender As Object, e As EventArgs) Handles btnTimeIn.Click
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "UPDATE Therapists SET Status = 'Available' WHERE Name = @name"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@name", LoggedInUser.Trim())
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MsgBox("You are now marked as AVAILABLE.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Therapist not found in database.", MsgBoxStyle.Exclamation)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error during Time In: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub btnTimeOut_Click(sender As Object, e As EventArgs) Handles btnTimeOut.Click
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "UPDATE Therapists SET Status = 'Unavailable' WHERE Name = @name"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@name", LoggedInUser.Trim())
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MsgBox("You are now marked as UNAVAILABLE.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Therapist not found in database.", MsgBoxStyle.Exclamation)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error during Time Out: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class