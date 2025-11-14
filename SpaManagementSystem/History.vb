Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class History

    Private connectionString As String =
        "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    Private WithEvents Timer1 As New Timer()

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadHistory()
        FormatGrid()

        ' 🔁 Refresh every 5 seconds
        Timer1.Interval = 5000
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadHistory(txtSearch.Text.Trim())
    End Sub

    Private Sub LoadHistory(Optional search As String = "")
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                ' ✅ Updated query to include package names (comma-separated) and total price
                Dim query As String =
                "
                SELECT 
                    B.BookingID,
                    B.FirstName,
                    B.LastName,
                    B.City,
                    B.Phone,
                    -- Combine all package names for this booking
                    STUFF((
                        SELECT ', ' + P.PackageName
                        FROM BookingPackages BP
                        INNER JOIN Packages P ON BP.PackageID = P.PackageID
                        WHERE BP.BookingID = B.BookingID
                        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS PackageNames,

                    -- Compute total price from BookingPackages
                    ISNULL((
                        SELECT SUM(BP.PackagePrice)
                        FROM BookingPackages BP
                        WHERE BP.BookingID = B.BookingID
                    ), 0) AS TotalPrice,

                    T.Name AS Therapist,
                    B.BookingDate,
                    B.BookingTime,
                    B.Status,
                    ISNULL(F.Tax, 0) AS Tax,
                    ISNULL(F.TherapistFee, 0) AS TherapistFee,
                    ISNULL(F.TotalAmount, 0) AS TotalAmount
                FROM Bookings B
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

    Private Sub FormatGrid()
        With dgvHistory
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .MultiSelect = False
        End With

        ' ✅ Format money columns
        If dgvHistory.Columns.Contains("TotalPrice") Then dgvHistory.Columns("TotalPrice").DefaultCellStyle.Format = "₱#,0.00"
        If dgvHistory.Columns.Contains("Tax") Then dgvHistory.Columns("Tax").DefaultCellStyle.Format = "₱#,0.00"
        If dgvHistory.Columns.Contains("TherapistFee") Then dgvHistory.Columns("TherapistFee").DefaultCellStyle.Format = "₱#,0.00"
        If dgvHistory.Columns.Contains("TotalAmount") Then dgvHistory.Columns("TotalAmount").DefaultCellStyle.Format = "₱#,0.00"
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadHistory(txtSearch.Text.Trim())
    End Sub

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

                    ' ✅ Delete from PointsSystem first
                    Using cmdPoints As New SqlCommand("DELETE FROM PointsSystem WHERE BookingID = @BookingID", conn)
                        cmdPoints.Parameters.AddWithValue("@BookingID", bookingID)
                        cmdPoints.ExecuteNonQuery()
                    End Using

                    ' ✅ Delete from BookingPackages next
                    Using cmdPackages As New SqlCommand("DELETE FROM BookingPackages WHERE BookingID = @BookingID", conn)
                        cmdPackages.Parameters.AddWithValue("@BookingID", bookingID)
                        cmdPackages.ExecuteNonQuery()
                    End Using

                    ' ✅ Delete from FinancialRecords
                    Using cmdFinance As New SqlCommand("DELETE FROM FinancialRecords WHERE BookingID = @BookingID", conn)
                        cmdFinance.Parameters.AddWithValue("@BookingID", bookingID)
                        cmdFinance.ExecuteNonQuery()
                    End Using

                    ' ✅ Finally, delete from Bookings
                    Using cmdBooking As New SqlCommand("DELETE FROM Bookings WHERE BookingID = @BookingID", conn)
                        cmdBooking.Parameters.AddWithValue("@BookingID", bookingID)
                        cmdBooking.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Booking deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadHistory()

            Catch ex As Exception
                MessageBox.Show("Delete failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class


