Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class History

    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"


    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadHistory("")
    End Sub


    Private Sub LoadHistory(searchTerm As String)
        Using con As New SqlConnection(connectionString)
            Dim query As String = "
                SELECT 
                    BookingID,
                    LastName,
                    FirstName,
                    MiddleInitial,
                    Block,
                    Street,
                    City,
                    Phone,
                    TherapistID,
                    PackageID,
                    Price,
                    BookingDate,
                    BookingTime
                FROM Bookings
                WHERE 
                    CAST(BookingID AS NVARCHAR) LIKE '%' + @Search + '%' OR
                    LastName LIKE '%' + @Search + '%' OR
                    FirstName LIKE '%' + @Search + '%' OR
                    MiddleInitial LIKE '%' + @Search + '%' OR
                    Block LIKE '%' + @Search + '%' OR
                    Street LIKE '%' + @Search + '%' OR
                    City LIKE '%' + @Search + '%' OR
                    Phone LIKE '%' + @Search + '%' OR
                    CAST(TherapistID AS NVARCHAR) LIKE '%' + @Search + '%' OR
                    CAST(PackageID AS NVARCHAR) LIKE '%' + @Search + '%' OR
                    CAST(Price AS NVARCHAR) LIKE '%' + @Search + '%' OR
                    CONVERT(NVARCHAR, BookingDate, 23) LIKE '%' + @Search + '%' OR
                    BookingTime LIKE '%' + @Search + '%'
                ORDER BY BookingDate DESC"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Search", searchTerm)

            Dim adapter As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dgvHistory.AutoGenerateColumns = True
            dgvHistory.DataSource = dt


            If dgvHistory.Columns.Contains("BookingID") Then dgvHistory.Columns("BookingID").HeaderText = "Booking #"
            If dgvHistory.Columns.Contains("LastName") Then dgvHistory.Columns("LastName").HeaderText = "Last Name"
            If dgvHistory.Columns.Contains("FirstName") Then dgvHistory.Columns("FirstName").HeaderText = "First Name"
            If dgvHistory.Columns.Contains("MiddleInitial") Then dgvHistory.Columns("MiddleInitial").HeaderText = "M.I."
            If dgvHistory.Columns.Contains("BookingDate") Then dgvHistory.Columns("BookingDate").HeaderText = "Booking Date"
            If dgvHistory.Columns.Contains("BookingTime") Then dgvHistory.Columns("BookingTime").HeaderText = "Booking Time"
        End Using
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadHistory(txtSearch.Text.Trim())
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvHistory.SelectedRows.Count = 0 AndAlso dgvHistory.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a record to update.", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = If(dgvHistory.SelectedRows.Count > 0, dgvHistory.SelectedRows(0), dgvHistory.CurrentRow)
        Dim bookingID As Integer = Convert.ToInt32(selectedRow.Cells("BookingID").Value)
        Dim lastName As String = selectedRow.Cells("LastName").Value.ToString()
        Dim firstName As String = selectedRow.Cells("FirstName").Value.ToString()
        Dim middleInitial As String = selectedRow.Cells("MiddleInitial").Value.ToString()
        Dim phone As String = selectedRow.Cells("Phone").Value.ToString()

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "
                UPDATE Bookings 
                SET LastName=@LastName, FirstName=@FirstName, MiddleInitial=@MiddleInitial, Phone=@Phone 
                WHERE BookingID=@BookingID"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@LastName", lastName)
            cmd.Parameters.AddWithValue("@FirstName", firstName)
            cmd.Parameters.AddWithValue("@MiddleInitial", middleInitial)
            cmd.Parameters.AddWithValue("@Phone", phone)
            cmd.Parameters.AddWithValue("@BookingID", bookingID)
            cmd.ExecuteNonQuery()
        End Using

        MessageBox.Show("Record updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadHistory(txtSearch.Text.Trim())
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim selectedRow As DataGridViewRow = Nothing

        If dgvHistory.SelectedRows.Count > 0 Then
            selectedRow = dgvHistory.SelectedRows(0)
        ElseIf dgvHistory.CurrentRow IsNot Nothing Then
            selectedRow = dgvHistory.CurrentRow
        End If


        If selectedRow Is Nothing Then
            MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim bookingID As Integer = Convert.ToInt32(selectedRow.Cells("BookingID").Value)


        If MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "DELETE FROM Bookings WHERE BookingID=@BookingID"
                Dim cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@BookingID", bookingID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Record deleted successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadHistory(txtSearch.Text.Trim())
        End If
    End Sub

End Class
