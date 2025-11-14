Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class Booking
    Private adminForm As AdminInterface ' specific AdminInterface reference
    Private connectionString As String =
        "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
    Private selectedTime As String = ""
    Private refreshTimer As New System.Windows.Forms.Timer()
    Private discountPercent As Decimal = 0D
    Private discountName As String = ""

    ' Accept AdminInterface reference when opening Booking (optional)
    Public Sub New(Optional admin As AdminInterface = Nothing)
        InitializeComponent()
        Me.adminForm = admin
    End Sub

    '================= FORM LOAD ================='
    Private Sub Booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGenders()
        LoadPackages()
        LoadDiscounts()
        GenerateTimeSlots()

        ' refresh packages every 30 seconds
        refreshTimer.Interval = 30000
        AddHandler refreshTimer.Tick, AddressOf refreshTimer_Tick
        refreshTimer.Start()
    End Sub

    Private Sub refreshTimer_Tick(sender As Object, e As EventArgs)
        LoadPackages()
    End Sub

    '================= GENDER COMBOBOX ================='
    Private Sub LoadGenders()
        cmbGender.Items.Clear()
        cmbGender.Items.AddRange(New String() {"Male", "Female"})
    End Sub

    Private Sub cmbGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGender.SelectedIndexChanged
        If cmbGender.SelectedItem IsNot Nothing Then
            LoadTherapistsByGender(cmbGender.SelectedItem.ToString())
        End If
    End Sub

    Private Sub LoadTherapistsByGender(gender As String)
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query = "SELECT TherapistID, Name FROM Therapists WHERE Gender = @Gender AND Status = 'Available'"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Gender", gender)
                Dim dt As New DataTable()
                dt.Load(cmd.ExecuteReader())
                cmbTherapist.DataSource = dt
                cmbTherapist.DisplayMember = "Name"
                cmbTherapist.ValueMember = "TherapistID"
            End Using
        End Using
    End Sub

    '================= LOAD DISCOUNTS ================='
    Private Sub LoadDiscounts()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query = "SELECT DiscountID, DiscountName, DiscountPercent FROM Discounts"
            Using cmd As New SqlCommand(query, con)
                Dim dt As New DataTable()
                dt.Load(cmd.ExecuteReader())

                ' Add "No Discount" option at top
                Dim newRow As DataRow = dt.NewRow()
                newRow("DiscountID") = 0
                newRow("DiscountName") = "No Discount"
                newRow("DiscountPercent") = 0
                dt.Rows.InsertAt(newRow, 0)

                cmbDiscount.DataSource = dt
                cmbDiscount.DisplayMember = "DiscountName"
                cmbDiscount.ValueMember = "DiscountPercent"

                ' ensure default selection
                cmbDiscount.SelectedIndex = 0
            End Using
        End Using
    End Sub

    '================= DISCOUNT SELECTION ================='
    Private Sub cmbDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscount.SelectedIndexChanged
        Try
            If cmbDiscount.SelectedItem Is Nothing Then
                discountPercent = 0
                discountName = ""
            Else
                Dim row As DataRowView = TryCast(cmbDiscount.SelectedItem, DataRowView)
                If row IsNot Nothing Then
                    discountPercent = Convert.ToDecimal(row("DiscountPercent"))
                    discountName = row("DiscountName").ToString()
                ElseIf cmbDiscount.SelectedValue IsNot Nothing Then
                    discountPercent = Convert.ToDecimal(cmbDiscount.SelectedValue)
                    discountName = cmbDiscount.Text
                Else
                    discountPercent = 0
                    discountName = ""
                End If
            End If

            lblDiscountPercent1.Text = $"{discountPercent}%"
            UpdateTotalPrice()
        Catch ex As Exception
            MessageBox.Show("Error loading discount: " & ex.Message)
        End Try
    End Sub

    '================= PACKAGES ================='
    Private Sub LoadPackages()
        ' Remember checked package IDs before clearing/reloading
        Dim checkedPackageIDs As New List(Of Integer)
        For i As Integer = 0 To clbPackages.Items.Count - 1
            If clbPackages.GetItemChecked(i) Then
                checkedPackageIDs.Add(CType(clbPackages.Items(i), PackageItem).PackageID)
            End If
        Next

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query = "SELECT PackageID, PackageName, Price FROM Packages"
            Using cmd As New SqlCommand(query, con)
                Dim dt As New DataTable()
                dt.Load(cmd.ExecuteReader())

                clbPackages.Items.Clear()
                For Each row As DataRow In dt.Rows
                    Dim pkg As New PackageItem With {
                        .PackageID = Convert.ToInt32(row("PackageID")),
                        .PackageName = row("PackageName").ToString(),
                        .Price = Convert.ToDecimal(row("Price"))
                    }
                    Dim wasChecked As Boolean = checkedPackageIDs.Contains(pkg.PackageID)
                    clbPackages.Items.Add(pkg, wasChecked)
                Next
            End Using
        End Using

        UpdateTotalPrice()
    End Sub

    Private Sub clbPackages_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbPackages.ItemCheck
        ' Defer update until item check state actually changes in UI
        Me.BeginInvoke(New Action(AddressOf UpdateTotalPrice))
    End Sub

    Private Sub UpdateTotalPrice()
        Dim total As Decimal = 0D
        For i As Integer = 0 To clbPackages.Items.Count - 1
            If clbPackages.GetItemChecked(i) Then
                total += CType(clbPackages.Items(i), PackageItem).Price
            End If
        Next

        Dim discountedTotal As Decimal = total - (total * (discountPercent / 100))
        lblTotalPrice.Text = $"₱{discountedTotal:F2}"
    End Sub

    '================= TIME SLOTS ================='
    Private Sub GenerateTimeSlots()
        flpTimeSlots.Controls.Clear()
        Dim startTime As DateTime = DateTime.Today.AddHours(8)
        Dim endTime As DateTime = DateTime.Today.AddHours(22)

        While startTime < endTime
            Dim rdo As New RadioButton()
            rdo.Text = $"{startTime:hh:mm tt} - {startTime.AddHours(1):hh:mm tt}"
            rdo.AutoSize = True
            AddHandler rdo.CheckedChanged, AddressOf TimeSlot_CheckedChanged
            flpTimeSlots.Controls.Add(rdo)
            startTime = startTime.AddHours(1)
        End While
    End Sub

    Private Sub TimeSlot_CheckedChanged(sender As Object, e As EventArgs)
        Dim rdo = CType(sender, RadioButton)
        If rdo.Checked Then
            selectedTime = rdo.Text
        End If
    End Sub

    '================= SAVE BUTTON ================='
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(selectedTime) Then
            MessageBox.Show("Please select a booking time.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cmbTherapist.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a therapist.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedPackages As New List(Of PackageItem)
        For i As Integer = 0 To clbPackages.Items.Count - 1
            If clbPackages.GetItemChecked(i) Then
                selectedPackages.Add(CType(clbPackages.Items(i), PackageItem))
            End If
        Next

        If selectedPackages.Count = 0 Then
            MessageBox.Show("Please select at least one package.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim bookingID As Integer

            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim bookingQuery As String =
                    "INSERT INTO Bookings
                     (LastName, FirstName, MiddleInitial, Block, Street, City, Phone,
                      TherapistID, Status, BookingDate, BookingTime, DiscountPercent)
                     OUTPUT INSERTED.BookingID
                     VALUES
                     (@LastName, @FirstName, @MiddleInitial, @Block, @Street, @City, @Phone,
                      @TherapistID, 'Pending', @BookingDate, @BookingTime, @DiscountPercent)"

                Using cmd As New SqlCommand(bookingQuery, con)
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim())
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim())
                    cmd.Parameters.AddWithValue("@MiddleInitial", txtMiddleInitial.Text.Trim())
                    cmd.Parameters.AddWithValue("@Block", txtBlock.Text.Trim())
                    cmd.Parameters.AddWithValue("@Street", txtStreet.Text.Trim())
                    cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@TherapistID", CInt(cmbTherapist.SelectedValue))
                    cmd.Parameters.AddWithValue("@BookingDate", dtpBookingDate.Value.Date)
                    cmd.Parameters.AddWithValue("@BookingTime", selectedTime)
                    cmd.Parameters.AddWithValue("@DiscountPercent", discountPercent)
                    bookingID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' Insert selected packages into BookingPackages
                For Each pkg As PackageItem In selectedPackages
                    Dim pkgQuery As String =
                        "INSERT INTO BookingPackages (BookingID, PackageID, PackagePrice)
                         VALUES (@BookingID, @PackageID, @PackagePrice)"
                    Using cmdPkg As New SqlCommand(pkgQuery, con)
                        cmdPkg.Parameters.AddWithValue("@BookingID", bookingID)
                        cmdPkg.Parameters.AddWithValue("@PackageID", pkg.PackageID)
                        cmdPkg.Parameters.AddWithValue("@PackagePrice", pkg.Price)
                        cmdPkg.ExecuteNonQuery()
                    End Using
                Next

                ' Add points
                Dim pointsQuery As String =
                    "INSERT INTO PointsSystem (TherapistID, BookingID, PointsEarned)
                     VALUES (@TherapistID, @BookingID, 50)"
                Using cmdPoints As New SqlCommand(pointsQuery, con)
                    cmdPoints.Parameters.AddWithValue("@TherapistID", CInt(cmbTherapist.SelectedValue))
                    cmdPoints.Parameters.AddWithValue("@BookingID", bookingID)
                    cmdPoints.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Booking saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Open Receipt and pass AdminInterface reference (if available)
            Dim receiptForm As New Receipt(adminForm)
            receiptForm.BookingID = bookingID
            receiptForm.StartPosition = FormStartPosition.CenterScreen
            Me.Hide()
            receiptForm.Show()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '================= WHEN CLOSED ================='
    Private Sub Booking_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        refreshTimer.Stop()
        If adminForm IsNot Nothing Then adminForm.Show()
    End Sub

    '================= PACKAGE CLASS ================='
    Private Class PackageItem
        Public Property PackageID As Integer
        Public Property PackageName As String
        Public Property Price As Decimal

        Public Overrides Function ToString() As String
            Return $"{PackageName} - ₱{Price:F2}"
        End Function
    End Class
End Class
