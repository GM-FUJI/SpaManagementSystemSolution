Imports System.Drawing.Text

Public Class TherapistForm


    Public Property LoggedInUser As String


    Sub childform(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub


    Private Sub TherapistForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(LoggedInUser) Then
            ' If you have a label named lblUser, show the logged-in name
            ' Example: lblUser.Text = "Welcome, " & LoggedInUser
        End If
    End Sub


    Private Sub btnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        Dim attendanceForm As New Attendance()
        attendanceForm.LoggedInUser = LoggedInUser   ' Pass username
        childform(attendanceForm)
    End Sub


    Private Sub btnBookings_Click(sender As Object, e As EventArgs) Handles btnBookings.Click
        childform(BookingofCustomers)
    End Sub


    Private Sub btnHistoryofCustomer_Click(sender As Object, e As EventArgs) Handles btnHistoryofCustomer.Click
        childform(HistoryforTherapist)
    End Sub


    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult
        result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Hide()

            Dim loginForm As New Form1()
            loginForm.Show()
        End If
    End Sub

End Class
