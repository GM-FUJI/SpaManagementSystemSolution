Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class TherapistInterface
    Public Property LoggedInUser As String
    Public Property LoggedInTherapistID As Integer

    Private ReadOnly connectionString As String =
        "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    Private Sub TherapistInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTherapistStatus()
    End Sub


    Private Sub LoadTherapistStatus()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT Status FROM Therapists WHERE TherapistID = @id"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@id", LoggedInTherapistID)
                    Dim currentStatus As Object = cmd.ExecuteScalar()

                    If currentStatus IsNot Nothing Then
                        Dim status As String = currentStatus.ToString()

                        Select Case status
                            Case "Available"
                                btnTimeIn.Enabled = False
                                btnTimeOut.Enabled = True
                                btnDoneSession.Enabled = False

                            Case "Unavailable"
                                btnTimeIn.Enabled = True
                                btnTimeOut.Enabled = False
                                btnDoneSession.Enabled = False

                            Case "In Session"
                                btnTimeIn.Enabled = False
                                btnTimeOut.Enabled = False
                                btnDoneSession.Enabled = True
                        End Select
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error getting status: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub UpdateTherapistStatus(newStatus As String)
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "UPDATE Therapists SET Status = @status WHERE TherapistID = @id"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@id", LoggedInTherapistID)
                    cmd.Parameters.AddWithValue("@status", newStatus)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MsgBox("Status updated to " & newStatus, MsgBoxStyle.Information)
            LoadTherapistStatus()

        Catch ex As Exception
            MsgBox("Error updating status: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnTimeIn_Click(sender As Object, e As EventArgs) Handles btnTimeIn.Click
        UpdateTherapistStatus("Available")
    End Sub

    Private Sub btnTimeOut_Click(sender As Object, e As EventArgs) Handles btnTimeOut.Click
        UpdateTherapistStatus("Unavailable")
    End Sub


    Private Sub btnDoneSession_Click(sender As Object, e As EventArgs) Handles btnDoneSession.Click
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' 1. Update Therapist to Available
                Dim updateTherapistQuery As String = "UPDATE Therapists SET Status = 'Available' WHERE TherapistID = @id"
                Using cmd1 As New SqlCommand(updateTherapistQuery, con)
                    cmd1.Parameters.AddWithValue("@id", LoggedInTherapistID)
                    cmd1.ExecuteNonQuery()
                End Using

                ' 2. Mark booking as Completed
                Dim updateBookingQuery As String =
                    "UPDATE Bookings SET Status = 'Completed'
                     WHERE TherapistID = @id AND Status = 'Accepted'"
                Using cmd2 As New SqlCommand(updateBookingQuery, con)
                    cmd2.Parameters.AddWithValue("@id", LoggedInTherapistID)
                    cmd2.ExecuteNonQuery()
                End Using
            End Using

            MsgBox("Session completed! Therapist is now Available.", MsgBoxStyle.Information)
            LoadTherapistStatus()

        Catch ex As Exception
            MsgBox("Error finishing session: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub btnBookings_Click(sender As Object, e As EventArgs) Handles btnBookings.Click
        If Not IsTherapistAvailable() Then
            MessageBox.Show("You must be 'Available' to accept bookings.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim bookingForm As New BookingAccepting()
        bookingForm.LoggedInTherapistID = LoggedInTherapistID
        Me.Hide()
        bookingForm.ShowDialog()
        Me.Show()
        LoadTherapistStatus()
    End Sub


    Private Function IsTherapistAvailable() As Boolean
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT Status FROM Therapists WHERE TherapistID = @id", con)
            cmd.Parameters.AddWithValue("@id", LoggedInTherapistID)
            Return cmd.ExecuteScalar().ToString() = "Available"
        End Using
    End Function

    Private Sub btnHistoryofCustomer_Click(sender As Object, e As EventArgs) Handles btnHistoryofCustomer.Click
        Dim recordsForm As New OwnRecords()
        recordsForm.LoggedInTherapistID = LoggedInTherapistID
        Me.Hide()
        recordsForm.ShowDialog()
        Me.Show()
        LoadTherapistStatus()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to log out?", "Logout",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Hide()
            Dim loginForm As New LogIn()
            loginForm.Show()
        End If
    End Sub
End Class
