Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class History


    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"


    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadHistory("")
    End Sub


    Private Sub LoadHistory(searchName As String)
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT BookingID, ClientName, Block, Street, City, Phone, TherapistID, PackageID, Price, BookingDate
                                   FROM Bookings
                                   WHERE ClientName LIKE @Search + '%'"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Search", searchName)

            Dim adapter As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dgvHistory.AutoGenerateColumns = True
            dgvHistory.DataSource = dt


            If dgvHistory.Columns.Contains("ClientName") Then dgvHistory.Columns("ClientName").HeaderText = "Client Name"
            If dgvHistory.Columns.Contains("Phone") Then dgvHistory.Columns("Phone").HeaderText = "Phone No#"
            If dgvHistory.Columns.Contains("TherapistID") Then dgvHistory.Columns("TherapistID").HeaderText = "Therapist"
            If dgvHistory.Columns.Contains("PackageID") Then dgvHistory.Columns("PackageID").HeaderText = "Package"
            If dgvHistory.Columns.Contains("BookingDate") Then dgvHistory.Columns("BookingDate").HeaderText = "Booking Date"


            If dgvHistory.Columns.Contains("BookingID") Then dgvHistory.Columns("BookingID").Visible = False
        End Using
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadHistory(txtSearch.Text.Trim())
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvHistory.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to update.")
            Return
        End If

        Dim bookingID As Integer = Convert.ToInt32(dgvHistory.SelectedRows(0).Cells("BookingID").Value)
        Dim clientName As String = dgvHistory.SelectedRows(0).Cells("ClientName").Value.ToString()
        Dim phone As String = dgvHistory.SelectedRows(0).Cells("Phone").Value.ToString()

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "UPDATE Bookings SET ClientName=@ClientName, Phone=@Phone WHERE BookingID=@BookingID"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@ClientName", clientName)
            cmd.Parameters.AddWithValue("@Phone", phone)
            cmd.Parameters.AddWithValue("@BookingID", bookingID)
            cmd.ExecuteNonQuery()
        End Using

        MessageBox.Show("Record updated successfully!")
        LoadHistory(txtSearch.Text.Trim())
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvHistory.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to delete.")
            Return
        End If

        Dim bookingID As Integer = Convert.ToInt32(dgvHistory.SelectedRows(0).Cells("BookingID").Value)

        If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "DELETE FROM Bookings WHERE BookingID=@BookingID"
                Dim cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@BookingID", bookingID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Record deleted successfully!")
            LoadHistory(txtSearch.Text.Trim())
        End If
    End Sub

End Class
