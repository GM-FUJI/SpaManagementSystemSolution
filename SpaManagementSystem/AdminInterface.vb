Public Class AdminInterface

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ther As New Therapist(Me)
        ther.StartPosition = FormStartPosition.CenterScreen
        Me.Hide()
        ther.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pack As New Package(Me)
        pack.StartPosition = FormStartPosition.CenterScreen
        Me.Hide()
        pack.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim hist As New History() ' ✅ No parameter needed now
        hist.StartPosition = FormStartPosition.CenterScreen
        Me.Hide()
        hist.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim book As New Booking(Me)
        book.StartPosition = FormStartPosition.CenterScreen
        Me.Hide()
        book.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult =
            MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Close()
            Dim loginForm As New LogIn()
            loginForm.StartPosition = FormStartPosition.CenterScreen
            loginForm.Show()
        End If
    End Sub

End Class
