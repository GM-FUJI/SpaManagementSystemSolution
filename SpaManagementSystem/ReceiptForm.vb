Imports Microsoft.Data.SqlClient

Public Class ReceiptForm

    ' This will be filled by Booking Form
    Public Property BookingID As Integer

    Private ReadOnly connectionString As String =
        "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    Private Sub ReceiptForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadReceiptInfo()
    End Sub

    Private Sub LoadReceiptInfo()

        If BookingID = 0 Then
            MessageBox.Show("Booking ID was not received.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Using con As New SqlConnection(connectionString)
            con.Open()

            ' ==========================================================
            ' LOAD BOOKING DETAILS + DISCOUNT %
            ' ==========================================================
            Dim queryBooking As String =
                "SELECT 
                    BookingID,
                    (FirstName + ' ' + MiddleInitial + ' ' + LastName) AS FullName,
                    (Block + ' ' + Street + ' ' + City) AS FullAddress,
                    BookingDate,
                    BookingTime,
                    DiscountPercent
                 FROM Bookings
                 WHERE BookingID = @ID"

            Dim discountPercent As Decimal = 0D

            Using cmd As New SqlCommand(queryBooking, con)
                cmd.Parameters.AddWithValue("@ID", BookingID)

                Dim rd = cmd.ExecuteReader()
                If rd.Read() Then

                    lblFullname.Text = rd("FullName").ToString()
                    lblFullAdd.Text = rd("FullAddress").ToString()
                    lblReceiptNo.Text = BookingID.ToString()
                    lblReceiptDate.Text =
                        Convert.ToDateTime(rd("BookingDate")).ToString("MMMM dd, yyyy")

                    ' Read DISCOUNT PERCENT
                    discountPercent = CDec(rd("DiscountPercent"))
                End If
                rd.Close()
            End Using

            ' ==========================================================
            ' LOAD BOOKING PACKAGES
            ' ==========================================================
            Dim dt As New DataTable()

            Dim queryPackages As String =
                "SELECT 
                    P.PackageName AS [Package Description],
                    BP.PackagePrice AS Price
                 FROM BookingPackages BP
                 INNER JOIN Packages P ON BP.PackageID = P.PackageID
                 WHERE BP.BookingID = @ID"

            Using da As New SqlDataAdapter(queryPackages, con)
                da.SelectCommand.Parameters.AddWithValue("@ID", BookingID)
                da.Fill(dt)
            End Using

            dgvDescription.DataSource = dt

            ' Format Prices
            If dgvDescription.Columns.Contains("Price") Then
                dgvDescription.Columns("Price").DefaultCellStyle.Format = "₱#,##0.00"
                dgvDescription.Columns("Price").Width = 120
            End If

            dgvDescription.Columns(0).Width = 350
            dgvDescription.RowHeadersVisible = False

            ' ==========================================================
            ' CALCULATE TOTAL + APPLY DISCOUNT
            ' ==========================================================
            Dim subtotal As Decimal = 0D

            For Each row As DataRow In dt.Rows
                subtotal += CDec(row("Price"))
            Next

            ' Apply discount directly
            Dim finalTotal As Decimal =
                subtotal - (subtotal * (discountPercent / 100D))

            ' Show final discounted total only
            lblTotal.Text = $"₱{finalTotal:F2}"

        End Using

    End Sub

End Class
