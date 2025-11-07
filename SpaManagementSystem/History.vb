Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class History

    ' ✅ Database connection string
    Private connectionString As String =
        "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    ' ✅ Timer (auto-refresh)
    Private WithEvents Timer1 As New Timer()

    ' ✅ Load Form
    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadHistory()
        FormatGrid()

        Timer1.Interval = 5000 ' Auto-refresh every 5 seconds
        Timer1.Start()
    End Sub

    ' ✅ Auto-refresh every 5 seconds
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadHistory(txtSearch.Text.Trim())
    End Sub

    ' ✅ Load Booking History (with Name instead of IDs)
    Private Sub LoadHistory(Optional search As String = "")
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim query As String =
                "
                SELECT 
                    B.BookingID,
                    B.FirstName,
                    B.LastName,
                    B.City,
                    B.Phone,
                    P.PackageName AS Package,
                    T.Name AS Therapist,
                    B.Price,
                    B.BookingDate,
                    B.BookingTime,
                    B.Status,
                    ISNULL(F.Tax, 0) AS Tax,
                    ISNULL(F.TherapistFee, 0) AS TherapistFee,
                    ISNULL(F.TotalAmount, 0) AS TotalAmount
                FROM Bookings B
                LEFT JOIN Packages P ON B.PackageID = P.PackageID
                LEFT JOIN Therapists T ON B.TherapistID = T.TherapistID
                LEFT JOIN FinancialRecords F ON B.BookingID = F.BookingID
                WHERE 
                    (B.FirstName LIKE @Search OR 
                     B.LastName LIKE @Search OR 
                     CAST(B.BookingID AS NVARCHAR) LIKE @Search)
                ORDER BY B.BookingDate DESC
                "

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Search", "%" & search & "%")

                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvHistory.DataSource = dt
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ Format DataGridView
    Private Sub FormatGrid()
        With dgvHistory
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .MultiSelect = False
        End With

        If dgvHistory.Columns.Contains("Price") Then dgvHistory.Columns("Price").DefaultCellStyle.Format = "₱#,0.00"
        If dgvHistory.Columns.Contains("Tax") Then dgvHistory.Columns("Tax").DefaultCellStyle.Format = "₱#,0.00"
        If dgvHistory.Columns.Contains("TherapistFee") Then dgvHistory.Columns("TherapistFee").DefaultCellStyle.Format = "₱#,0.00"
        If dgvHistory.Columns.Contains("TotalAmount") Then dgvHistory.Columns("TotalAmount").DefaultCellStyle.Format = "₱#,0.00"
    End Sub

    ' ✅ Manual Search
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadHistory(txtSearch.Text.Trim())
    End Sub

    ' ✅ Delete Booking (Also removes FinancialRecords if exists)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvHistory.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a booking first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim bookingID As Integer = Convert.ToInt32(dgvHistory.SelectedRows(0).Cells("BookingID").Value)

        If MessageBox.Show($"Are you sure you want to delete Booking ID {bookingID}?",
                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(connectionString)
                    conn.Open()

                    ' Delete financial records first
                    Dim deleteFinance As New SqlCommand("DELETE FROM FinancialRecords WHERE BookingID = @BookingID", conn)
                    deleteFinance.Parameters.AddWithValue("@BookingID", bookingID)
                    deleteFinance.ExecuteNonQuery()

                    ' Then delete the booking
                    Dim deleteBooking As New SqlCommand("DELETE FROM Bookings WHERE BookingID = @BookingID", conn)
                    deleteBooking.Parameters.AddWithValue("@BookingID", bookingID)
                    deleteBooking.ExecuteNonQuery()
                End Using

                MessageBox.Show("Booking deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadHistory()

            Catch ex As Exception
                MessageBox.Show("Delete failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class
