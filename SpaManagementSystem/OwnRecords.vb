Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class OwnRecords
    Private connectionString As String =
        "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
    Public Property LoggedInTherapistID As Integer

    Private WithEvents refreshTimer As New Timer()

    Public Sub New(Optional therapistID As Integer = 0)
        InitializeComponent()
        If therapistID <> 0 Then LoggedInTherapistID = therapistID
    End Sub

    Private Sub OwnRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvOwnRecords.ReadOnly = True
        dgvOwnRecords.AllowUserToAddRows = False
        dgvOwnRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOwnRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        refreshTimer.Interval = 5000 ' Refresh every 5 seconds
        refreshTimer.Start()

        LoadOwnRecords()
    End Sub

    Private Sub refreshTimer_Tick(sender As Object, e As EventArgs) Handles refreshTimer.Tick
        LoadOwnRecords()
    End Sub

    Private Sub LoadOwnRecords()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' ✅ Updated query: Get all packages + total package price per booking
                Dim query As String =
                    "
                    SELECT 
                        B.BookingID, 
                        B.LastName, 
                        B.FirstName, 
                        B.City, 
                        B.Phone, 
                        STRING_AGG(P.PackageName, ', ') AS PackageList,
                        SUM(P.Price) AS TotalPackagePrice,
                        B.BookingDate, 
                        B.BookingTime, 
                        B.Status,
                        ISNULL(F.Tax, 0) AS Tax, 
                        ISNULL(F.TherapistFee, 0) AS TherapistFee, 
                        ISNULL(F.TotalAmount, 0) AS TotalAmount
                    FROM Bookings B
                    LEFT JOIN BookingPackages BP ON B.BookingID = BP.BookingID
                    LEFT JOIN Packages P ON BP.PackageID = P.PackageID
                    LEFT JOIN FinancialRecords F ON B.BookingID = F.BookingID
                    WHERE B.TherapistID = @TherapistID 
                    AND B.Status = 'Completed'
                    GROUP BY 
                        B.BookingID, B.LastName, B.FirstName, B.City, B.Phone,
                        B.BookingDate, B.BookingTime, B.Status,
                        F.Tax, F.TherapistFee, F.TotalAmount
                    ORDER BY B.BookingDate DESC
                    "

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@TherapistID", LoggedInTherapistID)
                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvOwnRecords.DataSource = dt
                End Using
            End Using

            FormatGrid()
        Catch ex As Exception
            MessageBox.Show("Error loading therapist records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        If dgvOwnRecords.Columns.Count = 0 Then Return

        For Each column As DataGridViewColumn In dgvOwnRecords.Columns
            column.SortMode = DataGridViewColumnSortMode.Automatic
        Next

        ' ✅ Format currency columns
        If dgvOwnRecords.Columns.Contains("TotalPackagePrice") Then dgvOwnRecords.Columns("TotalPackagePrice").DefaultCellStyle.Format = "₱#,##0.00"
        If dgvOwnRecords.Columns.Contains("Tax") Then dgvOwnRecords.Columns("Tax").DefaultCellStyle.Format = "₱#,##0.00"
        If dgvOwnRecords.Columns.Contains("TherapistFee") Then dgvOwnRecords.Columns("TherapistFee").DefaultCellStyle.Format = "₱#,##0.00"
        If dgvOwnRecords.Columns.Contains("TotalAmount") Then dgvOwnRecords.Columns("TotalAmount").DefaultCellStyle.Format = "₱#,##0.00"

        ' ✅ Format date/time
        If dgvOwnRecords.Columns.Contains("BookingDate") Then dgvOwnRecords.Columns("BookingDate").DefaultCellStyle.Format = "MMM dd, yyyy"
        If dgvOwnRecords.Columns.Contains("BookingTime") Then dgvOwnRecords.Columns("BookingTime").DefaultCellStyle.Format = "hh:mm tt"
    End Sub

End Class
