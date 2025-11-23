Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class TherapistInterface

    Public Property LoggedInUser As String      ' Username from Users table
    Private Property LoggedInTherapistID As Integer

    Private ReadOnly connectionString As String =
        "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    ' ===================================================================
    ' FORM LOAD
    ' ===================================================================
    Private Sub TherapistInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Get TherapistID based on logged-in user
        If Not LoadTherapistID() Then
            MsgBox("Error: Could not find therapist account.")
            Me.Close()
            Return
        End If

        LoadTherapistStatus()
        LoadTherapistName()
        LoadDailyEarnings()
        LoadMonthlyPoints()
        LoadAcceptedCustomers()
    End Sub

    ' ===================================================================
    ' LOAD THERAPIST ID BASED ON USERNAME
    ' ===================================================================
    Private Function LoadTherapistID() As Boolean
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT TherapistID FROM Therapists WHERE Name = @username"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@username", LoggedInUser)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        LoggedInTherapistID = Convert.ToInt32(result)
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error retrieving TherapistID: " & ex.Message)
            Return False
        End Try
    End Function

    ' ===================================================================
    ' LOAD THERAPIST NAME
    ' ===================================================================
    Private Sub LoadTherapistName()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT Name FROM Therapists WHERE TherapistID = @id"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@id", LoggedInTherapistID)
                    Dim result = cmd.ExecuteScalar()
                    lblTherapist.Text = If(result IsNot Nothing, result.ToString(), "Unknown Therapist")
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading therapist name: " & ex.Message)
        End Try
    End Sub

    ' ===================================================================
    ' LOAD DAILY EARNINGS
    ' ===================================================================
    Private Sub LoadDailyEarnings()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String =
                    "SELECT SUM(TherapistEarnings)
                     FROM FinancialRecords
                     WHERE TherapistID = @id
                     AND Date = CAST(GETDATE() AS DATE)"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@id", LoggedInTherapistID)
                    Dim earnings = cmd.ExecuteScalar()
                    lblEarnings.Text = "₱ " & If(IsDBNull(earnings) OrElse earnings Is Nothing, 0D, Convert.ToDecimal(earnings)).ToString("N2")
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading earnings: " & ex.Message)
        End Try
    End Sub

    ' ===================================================================
    ' LOAD MONTHLY POINTS
    ' ===================================================================
    Private Sub LoadMonthlyPoints()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String =
                    "SELECT ISNULL(SUM(PointsEarned),0)
                     FROM PointsSystem
                     WHERE TherapistID = @id
                     AND MONTH(DateEarned) = MONTH(GETDATE())
                     AND YEAR(DateEarned) = YEAR(GETDATE())"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@id", LoggedInTherapistID)
                    Dim points As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    lblPointsEarn.Text = points.ToString()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading points: " & ex.Message)
        End Try
    End Sub

    ' ===================================================================
    ' LOAD BOOKINGS INTO dgvList
    ' ===================================================================
    Private Sub LoadAcceptedCustomers()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String =
                    "SELECT 
                        B.BookingID,
                        (B.LastName + ', ' + B.FirstName) AS CustomerName,
                        B.BookingDate,
                        B.BookingTime
                     FROM Bookings B
                     WHERE B.TherapistID = @TherapistID
                     ORDER BY B.BookingDate DESC, B.BookingTime DESC"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@TherapistID", LoggedInTherapistID)
                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    dgvList.DataSource = table
                End Using
            End Using
            FormatDGV()
        Catch ex As Exception
            MsgBox("Error loading bookings: " & ex.Message)
        End Try
    End Sub

    Private Sub FormatDGV()
        If dgvList.Columns.Count = 0 Then Exit Sub
        dgvList.Columns("BookingID").HeaderText = "Booking ID"
        dgvList.Columns("CustomerName").HeaderText = "Customer"
        dgvList.Columns("BookingDate").HeaderText = "Date"
        dgvList.Columns("BookingTime").HeaderText = "Time"
        dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvList.RowHeadersVisible = False
        dgvList.AllowUserToAddRows = False
        dgvList.ReadOnly = True
    End Sub

    ' ===================================================================
    ' STATUS SYSTEM
    ' ===================================================================
    Private Sub LoadTherapistStatus()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT Status FROM Therapists WHERE TherapistID = @id"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@id", LoggedInTherapistID)
                    Dim statusObj = cmd.ExecuteScalar()

                    Dim status As String = If(statusObj IsNot Nothing, statusObj.ToString(), "Unavailable")

                    Select Case status
                        Case "Available"
                            btnTimeIn.Enabled = True
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
                        Case Else
                            btnTimeIn.Enabled = True
                            btnTimeOut.Enabled = False
                            btnDoneSession.Enabled = False
                            UpdateTherapistStatus("Unavailable")
                    End Select
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error getting status: " & ex.Message)
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
            LoadTherapistStatus()
        Catch ex As Exception
            MsgBox("Error updating status: " & ex.Message)
        End Try
    End Sub

    ' ===================================================================
    ' TIME IN / TIME OUT BUTTONS
    ' ===================================================================
    Private Sub btnTimeIn_Click(sender As Object, e As EventArgs) Handles btnTimeIn.Click
        UpdateTherapistStatus("In Session")
        MsgBox("You are now in session.")
    End Sub

    Private Sub btnTimeOut_Click(sender As Object, e As EventArgs) Handles btnTimeOut.Click
        UpdateTherapistStatus("Unavailable")
        MsgBox("You are now unavailable.")
    End Sub

    ' ===================================================================
    ' COMPLETE SESSION BUTTON
    ' ===================================================================
    Private Sub btnDoneSession_Click(sender As Object, e As EventArgs) Handles btnDoneSession.Click
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim updateTherapistQuery As String = "UPDATE Therapists SET Status = 'Available' WHERE TherapistID = @id"
                Dim updateBookingQuery As String = "UPDATE Bookings SET Status = 'Completed' WHERE TherapistID = @id AND Status = 'Accepted'"

                Using cmd1 As New SqlCommand(updateTherapistQuery, con)
                    cmd1.Parameters.AddWithValue("@id", LoggedInTherapistID)
                    cmd1.ExecuteNonQuery()
                End Using

                Using cmd2 As New SqlCommand(updateBookingQuery, con)
                    cmd2.Parameters.AddWithValue("@id", LoggedInTherapistID)
                    cmd2.ExecuteNonQuery()
                End Using
            End Using

            MsgBox("Session completed!")
            LoadTherapistStatus()
            LoadAcceptedCustomers()
            LoadDailyEarnings()
            LoadMonthlyPoints()
        Catch ex As Exception
            MsgBox("Error finishing session: " & ex.Message)
        End Try
    End Sub

    ' ===================================================================
    ' HELPER FUNCTION
    ' ===================================================================
    Private Function IsTherapistAvailable() As Boolean
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT Status FROM Therapists WHERE TherapistID = @id", con)
            cmd.Parameters.AddWithValue("@id", LoggedInTherapistID)
            Return cmd.ExecuteScalar().ToString() = "Available"
        End Using
    End Function

    ' ===================================================================
    ' BUTTONS
    ' ===================================================================
    Private Sub btnBookings_Click(sender As Object, e As EventArgs) Handles btnBookings.Click
        If Not IsTherapistAvailable() Then
            MessageBox.Show("You must be 'Available' to accept bookings.")
            Return
        End If

        Dim bookingForm As New BookingAccepting()
        bookingForm.LoggedInTherapistID = LoggedInTherapistID
        Me.Hide()
        bookingForm.ShowDialog()
        Me.Show()

        LoadTherapistStatus()
        LoadAcceptedCustomers()
        LoadDailyEarnings()
    End Sub

    Private Sub btnHistoryofCustomer_Click(sender As Object, e As EventArgs) Handles btnHistoryofCustomer.Click
        Dim recordsForm As New OwnRecords()
        recordsForm.LoggedInTherapistID = LoggedInTherapistID
        Me.Hide()
        recordsForm.ShowDialog()
        Me.Show()
        LoadTherapistStatus()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Me.Hide()
            Dim loginForm As New LogIn()
            loginForm.Show()
        End If
    End Sub

End Class
