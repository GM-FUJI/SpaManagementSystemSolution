Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class BookingofCustomers
    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    Public LoggedInTherapistID As Integer

    Private Sub BookingofCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookings()
        AddButtonColumns()
        StyleButtonColumns()
    End Sub

    Private Sub LoadBookings()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "
                SELECT BookingID, FirstName, LastName, City, Phone, BookingDate, BookingTime, Price
                FROM Bookings 
                WHERE TherapistID = @TherapistID"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@TherapistID", LoggedInTherapistID)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvBookings.DataSource = table
            End Using
        End Using
    End Sub


    Private Sub AddButtonColumns()

        If Not dgvBookings.Columns.Contains("AcceptBtn") Then
            Dim acceptBtn As New DataGridViewButtonColumn()
            acceptBtn.Name = "AcceptBtn"
            acceptBtn.HeaderText = "Accept"
            acceptBtn.Text = "Accept"
            acceptBtn.UseColumnTextForButtonValue = True
            dgvBookings.Columns.Insert(0, acceptBtn)
        End If

        If Not dgvBookings.Columns.Contains("DeleteBtn") Then
            Dim deleteBtn As New DataGridViewButtonColumn()
            deleteBtn.Name = "DeleteBtn"
            deleteBtn.HeaderText = "Delete"
            deleteBtn.Text = "Delete"
            deleteBtn.UseColumnTextForButtonValue = True
            dgvBookings.Columns.Insert(1, deleteBtn)
        End If
    End Sub


    Private Sub dgvBookings_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBookings.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim bookingID As Integer = CInt(dgvBookings.Rows(e.RowIndex).Cells("BookingID").Value)

        If e.ColumnIndex = dgvBookings.Columns("AcceptBtn").Index Then
            UpdateBookingStatus(bookingID, "Accepted")
            UpdateTherapistStatus("In Session")
        ElseIf e.ColumnIndex = dgvBookings.Columns("DeleteBtn").Index Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                UpdateBookingStatus(bookingID, "Deleted")
            End If
        End If
    End Sub

    Private Sub UpdateBookingStatus(bookingID As Integer, newStatus As String)
        Using con As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Bookings SET BookingStatus = @Status WHERE BookingID = @BookingID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Status", newStatus)
                cmd.Parameters.AddWithValue("@BookingID", bookingID)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
        MessageBox.Show($"Booking {bookingID} has been {newStatus.ToLower()}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadBookings()
        StyleButtonColumns()
    End Sub

    Private Sub UpdateTherapistStatus(newStatus As String)
        Using con As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Therapists SET Status = @Status WHERE TherapistID = @TherapistID"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Status", newStatus)
                cmd.Parameters.AddWithValue("@TherapistID", LoggedInTherapistID)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    Private Sub StyleButtonColumns()
        If dgvBookings.Columns.Contains("AcceptBtn") Then
            With dgvBookings.Columns("AcceptBtn").DefaultCellStyle
                .BackColor = Color.LightGreen
                .ForeColor = Color.Black
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            End With
        End If

        If dgvBookings.Columns.Contains("DeleteBtn") Then
            With dgvBookings.Columns("DeleteBtn").DefaultCellStyle
                .BackColor = Color.IndianRed
                .ForeColor = Color.White
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            End With
        End If
    End Sub
End Class
