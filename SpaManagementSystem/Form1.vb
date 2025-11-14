Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class Receipt
    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
    Private adminForm As AdminInterface
    Public Property BookingID As Integer

    ' Constructor (optional AdminInterface reference)
    Public Sub New(Optional admin As AdminInterface = Nothing)
        InitializeComponent()
        adminForm = admin
    End Sub

    ' ===================== FORM LOAD ===================== '
    Private Sub Receipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadReceiptDetails()
    End Sub

    ' ===================== LOAD RECEIPT DETAILS ===================== '
    Public Sub LoadReceiptDetails()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim query As String = "
                    SELECT 
                        b.BookingID,
                        (b.FirstName + ' ' + b.LastName) AS ClientName,
                        b.BookingDate,
                        b.DiscountPercent,
                        b.Tax,
                        p.PackageName,
                        bp.PackagePrice
                    FROM Bookings b
                    LEFT JOIN BookingPackages bp ON b.BookingID = bp.BookingID
                    LEFT JOIN Packages p ON bp.PackageID = p.PackageID
                    WHERE b.BookingID = @BookingID
                "

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@BookingID", BookingID)

                    Dim table As New DataTable()
                    table.Columns.Add("Package Name")
                    table.Columns.Add("Price")

                    Dim clientName As String = ""
                    Dim bookingDate As Date
                    Dim discountPercent As Decimal = 0D
                    Dim taxAmount As Decimal = 0D
                    Dim subtotal As Decimal = 0D

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            If clientName = "" Then
                                clientName = SafeGet(reader, "ClientName")
                                bookingDate = Convert.ToDateTime(reader("BookingDate"))
                                discountPercent = If(IsDBNull(reader("DiscountPercent")), 0D, Convert.ToDecimal(reader("DiscountPercent")))
                                taxAmount = If(IsDBNull(reader("Tax")), 0D, Convert.ToDecimal(reader("Tax")))
                            End If

                            Dim packageName As String = SafeGet(reader, "PackageName")
                            Dim price As Decimal = If(IsDBNull(reader("PackagePrice")), 0D, Convert.ToDecimal(reader("PackagePrice")))

                            If packageName <> "" Then
                                table.Rows.Add(packageName, "₱" & price.ToString("N2"))
                            End If

                            subtotal += price
                        End While
                    End Using

                    ' Compute totals
                    Dim discountValue As Decimal = subtotal * (discountPercent / 100)
                    Dim totalBeforeTax As Decimal = subtotal - discountValue
                    Dim total As Decimal = totalBeforeTax + taxAmount

                    ' Display values
                    lblClientName.Text = clientName
                    lblReceiptNo.Text = BookingID.ToString()
                    lblDate.Text = bookingDate.ToShortDateString()
                    lblSubtotal.Text = "₱" & subtotal.ToString("N2")
                    lblDiscount.Text = discountPercent.ToString("N0") & "%"
                    lblTax.Text = "₱" & taxAmount.ToString("N2")
                    lblTotal.Text = "₱" & total.ToString("N2")

                    ' Display package list
                    dgvPackages.DataSource = table
                    dgvPackages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    dgvPackages.ReadOnly = True
                    dgvPackages.RowHeadersVisible = False
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading receipt: " & ex.Message)
        End Try
    End Sub

    ' ===================== SAFE HELPERS ===================== '
    Private Function SafeGet(reader As SqlDataReader, columnName As String) As String
        If reader.IsDBNull(reader.GetOrdinal(columnName)) Then Return ""
        Return reader(columnName).ToString()
    End Function

    ' ===================== FORM CLOSING ===================== '
    Private Sub Receipt_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If adminForm IsNot Nothing Then
            adminForm.StartPosition = FormStartPosition.CenterScreen
            adminForm.Show()
        End If
    End Sub
End Class
