Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class BookingAccepting
    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
    Public Property LoggedInTherapistID As Integer
    Private refreshTimer As New Timer()

    Private Sub BookingAccepting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookings()
        FormatGrid()
        SetupTimer()
    End Sub

    ' Auto-refresh every 5 seconds
    Private Sub SetupTimer()
        refreshTimer.Interval = 5000
        AddHandler refreshTimer.Tick, AddressOf RefreshData
        refreshTimer.Start()
    End Sub

    Private Sub BookingAccepting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        refreshTimer.Stop() ' ✅ Prevents memory leak when form closes
    End Sub

    Private Sub RefreshData()
        LoadBookings()
    End Sub

    ' Load pending bookings
    Private Sub LoadBookings()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String =
                    "SELECT BookingID, LastName, FirstName, Phone, Price, BookingDate, BookingTime, Status
                     FROM Bookings
                     WHERE TherapistID = @TherapistID AND Status = 'Pending'
                     ORDER BY BookingDate DESC"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@TherapistID", LoggedInTherapistID)
                    Dim dt As New DataTable()
                    dt.Load(cmd.ExecuteReader())
                    dgvBookings.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading bookings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvBookings.ReadOnly = True
        dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        If dgvBookings.Columns.Contains("Price") Then
            dgvBookings.Columns("Price").DefaultCellStyle.Format = "₱#,0.00"
        End If
    End Sub

    ' Accept booking and insert/update financial record
    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        If dgvBookings.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a booking first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim bookingID As Integer = CInt(dgvBookings.SelectedRows(0).Cells("BookingID").Value)
        Dim price As Decimal = CDec(dgvBookings.SelectedRows(0).Cells("Price").Value)

        Dim tax As Decimal = Math.Round(price * 0.03D, 2)
        Dim therapistFee As Decimal = Math.Round(price * 0.3D, 2)
        Dim therapistEarnings As Decimal = therapistFee
        Dim totalAmount As Decimal = Math.Round(price + tax, 2)

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Using tran As SqlTransaction = con.BeginTransaction()
                    Try
                        Dim bookingDate As Date = Date.MinValue
                        Dim bookingTimeText As String = ""
                        Dim currentStatus As String = ""

                        Using cmdGet As New SqlCommand("SELECT BookingDate, BookingTime, Status FROM Bookings WHERE BookingID=@BookingID", con, tran)
                            cmdGet.Parameters.AddWithValue("@BookingID", bookingID)
                            Using rdr = cmdGet.ExecuteReader()
                                If rdr.Read() Then
                                    bookingDate = Convert.ToDateTime(rdr("BookingDate"))
                                    bookingTimeText = rdr("BookingTime").ToString()
                                    currentStatus = rdr("Status").ToString()
                                End If
                            End Using
                        End Using

                        If currentStatus <> "Pending" Then
                            MessageBox.Show("This booking is already processed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            tran.Rollback()
                            Return
                        End If

                        ' Extract time
                        Dim startTimeOnly As String = bookingTimeText.Split("-"c)(0).Trim()
                        Dim timeOfDay As TimeSpan
                        Dim parsedDateTime As DateTime

                        If Not TimeSpan.TryParse(startTimeOnly, timeOfDay) AndAlso DateTime.TryParse(startTimeOnly, parsedDateTime) Then
                            timeOfDay = parsedDateTime.TimeOfDay
                        End If

                        ' ✅ Update booking to Accepted
                        Using cmdUpdate As New SqlCommand("UPDATE Bookings SET Status='Accepted' WHERE BookingID=@BookingID", con, tran)
                            cmdUpdate.Parameters.AddWithValue("@BookingID", bookingID)
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                        ' ✅ Change Therapist to In Session
                        Using cmdStatus As New SqlCommand("UPDATE Therapists SET Status='In Session' WHERE TherapistID=@TherapistID", con, tran)
                            cmdStatus.Parameters.AddWithValue("@TherapistID", LoggedInTherapistID)
                            cmdStatus.ExecuteNonQuery()
                        End Using

                        ' ✅ Save or update financial record
                        Dim checkFin As New SqlCommand("SELECT COUNT(*) FROM FinancialRecords WHERE BookingID = @BookingID", con, tran)
                        checkFin.Parameters.AddWithValue("@BookingID", bookingID)
                        Dim finCount As Integer = Convert.ToInt32(checkFin.ExecuteScalar())

                        If finCount > 0 Then
                            Using cmdFinUpdate As New SqlCommand("
                                UPDATE FinancialRecords SET 
                                    TherapistID = @TherapistID,
                                    Tax = @Tax,
                                    TherapistFee = @TherapistFee,
                                    TotalAmount = @TotalAmount,
                                    TherapistEarnings = @TherapistEarnings,
                                    Date = @Date,
                                    Time = @Time
                                WHERE BookingID = @BookingID", con, tran)
                                cmdFinUpdate.Parameters.AddWithValue("@TherapistID", LoggedInTherapistID)
                                cmdFinUpdate.Parameters.AddWithValue("@Tax", tax)
                                cmdFinUpdate.Parameters.AddWithValue("@TherapistFee", therapistFee)
                                cmdFinUpdate.Parameters.AddWithValue("@TherapistEarnings", therapistEarnings)
                                cmdFinUpdate.Parameters.AddWithValue("@TotalAmount", totalAmount)
                                cmdFinUpdate.Parameters.AddWithValue("@Date", bookingDate)
                                cmdFinUpdate.Parameters.AddWithValue("@Time", timeOfDay)
                                cmdFinUpdate.Parameters.AddWithValue("@BookingID", bookingID)
                                cmdFinUpdate.ExecuteNonQuery()
                            End Using
                        Else
                            Using cmdFin As New SqlCommand("
                                INSERT INTO FinancialRecords
                                (BookingID, TherapistID, Tax, TherapistFee, TotalAmount, TherapistEarnings, Date, Time)
                                VALUES
                                (@BookingID, @TherapistID, @Tax, @TherapistFee, @TotalAmount, @TherapistEarnings, @Date, @Time)", con, tran)
                                cmdFin.Parameters.AddWithValue("@BookingID", bookingID)
                                cmdFin.Parameters.AddWithValue("@TherapistID", LoggedInTherapistID)
                                cmdFin.Parameters.AddWithValue("@Tax", tax)
                                cmdFin.Parameters.AddWithValue("@TherapistFee", therapistFee)
                                cmdFin.Parameters.AddWithValue("@TherapistEarnings", therapistEarnings)
                                cmdFin.Parameters.AddWithValue("@TotalAmount", totalAmount)
                                cmdFin.Parameters.AddWithValue("@Date", bookingDate)
                                cmdFin.Parameters.AddWithValue("@Time", timeOfDay)
                                cmdFin.ExecuteNonQuery()
                            End Using
                        End If

                        tran.Commit()
                    Catch
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            MessageBox.Show("Booking accepted! Therapist is now In Session.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadBookings()

        Catch ex As Exception
            MessageBox.Show("Error accepting booking: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
