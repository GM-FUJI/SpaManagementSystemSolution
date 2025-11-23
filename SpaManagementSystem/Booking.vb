Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data

Public Class Booking

    Private adminForm As AdminInterface
    Private connectionString As String =
        "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    Private selectedTime As String = ""
    Private refreshTimer As New Timer()
    Private discountPercent As Decimal = 0D
    Private discountName As String = ""

    ' Stores selected packages across types
    Private selectedPackages As New Dictionary(Of Integer, PackageItem)

    Public Sub New(Optional admin As AdminInterface = Nothing)
        InitializeComponent()
        Me.adminForm = admin
    End Sub

    ' ================================
    ' FORM LOAD
    ' ================================
    Private Sub Booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGenders()
        LoadDiscounts()
        LoadPackageTypes()
        LoadPackages()
        GenerateTimeSlots()

        txtPhone.MaxLength = 11

        refreshTimer.Interval = 30000
        AddHandler refreshTimer.Tick, AddressOf refreshTimer_Tick
        refreshTimer.Start()
    End Sub

    Private Sub refreshTimer_Tick(sender As Object, e As EventArgs)
        LoadPackages()
    End Sub

    ' ================================
    ' GENDERS
    ' ================================
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

            Dim query As String =
                "SELECT TherapistID, Name FROM Therapists 
                 WHERE Gender = @Gender AND Status = 'Available'"

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

    ' ================================
    ' DISCOUNTS
    ' ================================
    Private Sub LoadDiscounts()
        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim dt As New DataTable()
            Dim query = "SELECT DiscountID, DiscountName, DiscountPercent FROM Discounts"

            Using cmd As New SqlCommand(query, con)
                dt.Load(cmd.ExecuteReader())
            End Using

            Dim newRow As DataRow = dt.NewRow()
            newRow("DiscountID") = 0
            newRow("DiscountName") = "No Discount"
            newRow("DiscountPercent") = 0
            dt.Rows.InsertAt(newRow, 0)

            cmbDiscount.DataSource = dt
            cmbDiscount.DisplayMember = "DiscountName"
            cmbDiscount.ValueMember = "DiscountPercent"
            cmbDiscount.SelectedIndex = 0
        End Using
    End Sub

    Private Sub cmbDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscount.SelectedIndexChanged
        Dim row As DataRowView = TryCast(cmbDiscount.SelectedItem, DataRowView)

        If row IsNot Nothing Then
            discountPercent = CDec(row("DiscountPercent"))
            discountName = row("DiscountName").ToString()
        Else
            discountPercent = 0
        End If

        lblDiscountPercent1.Text = $"{discountPercent}%"
        UpdateTotalPrice()
    End Sub

    ' ================================
    ' PACKAGE TYPES
    ' ================================
    Private Sub LoadPackageTypes()
        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim dt As New DataTable()
            Dim query = "SELECT DISTINCT PackageType FROM Packages ORDER BY PackageType"

            Using cmd As New SqlCommand(query, con)
                dt.Load(cmd.ExecuteReader())
            End Using

            Dim newRow = dt.NewRow()
            newRow("PackageType") = "All Types"
            dt.Rows.InsertAt(newRow, 0)

            cmbPackageType.DataSource = dt
            cmbPackageType.DisplayMember = "PackageType"
            cmbPackageType.ValueMember = "PackageType"
        End Using
    End Sub

    Private Sub cmbPackageType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPackageType.SelectedIndexChanged
        LoadPackages()
    End Sub

    ' ==========================================================
    ' POLYMORPHIC TYPE CREATOR — FACTORY
    ' ==========================================================
    Private Function CreateTypeClass(typeName As String) As PackageType
        If typeName Is Nothing Then Return New PackageType(0, "", 0)

        Select Case typeName.Trim().ToLowerInvariant()
            Case "whole body" : Return New WholeBodyPackage(0, typeName, 0)
            Case "head" : Return New HeadPackage(0, typeName, 0)
            Case "neck" : Return New NeckPackage(0, typeName, 0)
            Case "back" : Return New BackPackage(0, typeName, 0)
            Case "arms" : Return New ArmsPackage(0, typeName, 0)
            Case "legs" : Return New LegsPackage(0, typeName, 0)
            Case Else
                Return New PackageType(0, typeName, 0)
        End Select
    End Function

    ' ================================
    ' LOAD PACKAGES
    ' ================================
    Private Sub LoadPackages()
        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String

            If cmbPackageType.SelectedValue IsNot Nothing AndAlso cmbPackageType.SelectedValue.ToString() <> "All Types" Then
                query =
                    "SELECT PackageID, PackageName, Price, PackageType 
                     FROM Packages WHERE PackageType = @PackageType ORDER BY PackageName"
            Else
                query =
                    "SELECT PackageID, PackageName, Price, PackageType 
                     FROM Packages ORDER BY PackageName"
            End If

            Using cmd As New SqlCommand(query, con)
                If cmbPackageType.SelectedValue IsNot Nothing AndAlso cmbPackageType.SelectedValue.ToString() <> "All Types" Then
                    cmd.Parameters.AddWithValue("@PackageType", cmbPackageType.SelectedValue.ToString())
                End If

                Dim dt As New DataTable()
                dt.Load(cmd.ExecuteReader())

                clbPackages.Items.Clear()

                For Each row As DataRow In dt.Rows
                    Dim typeName As String = If(row("PackageType") IsNot DBNull.Value, row("PackageType").ToString(), "")
                    Dim typeObj As PackageType = CreateTypeClass(typeName)

                    Dim pkg As New PackageItem With {
                        .PackageID = CInt(row("PackageID")),
                        .PackageName = row("PackageName").ToString(),
                        .Price = CDec(row("Price")),
                        .TypeClass = typeObj
                    }

                    Dim isChecked As Boolean = selectedPackages.ContainsKey(pkg.PackageID)
                    clbPackages.Items.Add(pkg, isChecked)
                Next
            End Using
        End Using

        UpdateTotalPrice()
    End Sub

    Private Sub clbPackages_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbPackages.ItemCheck
        Me.BeginInvoke(Sub()
                           Dim pkg As PackageItem = CType(clbPackages.Items(e.Index), PackageItem)

                           If e.NewValue = CheckState.Checked Then
                               If Not selectedPackages.ContainsKey(pkg.PackageID) Then
                                   selectedPackages.Add(pkg.PackageID, pkg)
                               End If
                           Else
                               If selectedPackages.ContainsKey(pkg.PackageID) Then
                                   selectedPackages.Remove(pkg.PackageID)
                               End If
                           End If

                           UpdateTotalPrice()
                       End Sub)
    End Sub

    Private Sub UpdateTotalPrice()
        Dim total As Decimal = selectedPackages.Values.Sum(Function(p) p.Price)
        Dim discounted = total - (total * (discountPercent / 100D))
        lblTotalPrice.Text = $"₱{discounted:F2}"
    End Sub

    ' ================================
    ' TIME SLOTS
    ' ================================
    Private Sub GenerateTimeSlots()
        flpTimeSlots.Controls.Clear()

        Dim startTime As DateTime = DateTime.Today.AddHours(8)
        Dim endTime As DateTime = DateTime.Today.AddHours(22)

        While startTime < endTime
            Dim r As New RadioButton()
            r.Text = $"{startTime:hh:mm tt} - {startTime.AddHours(1):hh:mm tt}"
            r.AutoSize = True
            AddHandler r.CheckedChanged, AddressOf TimeSlot_CheckedChanged
            flpTimeSlots.Controls.Add(r)
            startTime = startTime.AddHours(1)
        End While
    End Sub

    Private Sub TimeSlot_CheckedChanged(sender As Object, e As EventArgs)
        Dim r = CType(sender, RadioButton)
        If r.Checked Then selectedTime = r.Text
    End Sub

    ' ================================
    ' PHONE VALIDATION
    ' ================================
    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPhone_TextChanged(sender As Object, e As EventArgs) Handles txtPhone.TextChanged
        Dim digitsOnly = New String(txtPhone.Text.Where(Function(c) Char.IsDigit(c)).ToArray())

        If txtPhone.Text <> digitsOnly Then
            txtPhone.Text = digitsOnly
            txtPhone.SelectionStart = txtPhone.Text.Length
        End If

        If txtPhone.Text.Length > 11 Then
            MessageBox.Show("Phone number must be exactly 11 digits.")
            txtPhone.Text = txtPhone.Text.Substring(0, 11)
            txtPhone.SelectionStart = txtPhone.Text.Length
        End If
    End Sub

    ' ================================
    ' SAVE BOOKING
    ' ================================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If selectedTime = "" Then
            MessageBox.Show("Please select a time slot.")
            Return
        End If

        If cmbTherapist.SelectedValue Is Nothing Then
            MessageBox.Show("Select a therapist.")
            Return
        End If

        If txtPhone.Text.Length <> 11 Then
            MessageBox.Show("Phone must be 11 digits.")
            Return
        End If

        If selectedPackages.Count = 0 Then
            MessageBox.Show("Please select at least one package.")
            Return
        End If

        Dim bookingID As Integer

        Using con As New SqlConnection(connectionString)
            con.Open()

            ' Check for double booking
            Dim checkSql =
                "SELECT COUNT(*) FROM Bookings
                 WHERE TherapistID = @TherapistID
                 AND BookingDate = @BookingDate
                 AND BookingTime = @BookingTime
                 AND Status <> 'Cancelled'"

            Using checkCmd As New SqlCommand(checkSql, con)
                checkCmd.Parameters.AddWithValue("@TherapistID", CInt(cmbTherapist.SelectedValue))
                checkCmd.Parameters.AddWithValue("@BookingDate", dtpBookingDate.Value.Date)
                checkCmd.Parameters.AddWithValue("@BookingTime", selectedTime)

                If CInt(checkCmd.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Therapist already booked in this time slot.")
                    Return
                End If
            End Using

            ' Save booking
            Dim insertSql =
                "INSERT INTO Bookings
                 (LastName, FirstName, MiddleInitial, Block, Street, City, Phone,
                  TherapistID, Status, BookingDate, BookingTime, DiscountPercent)
                 OUTPUT INSERTED.BookingID
                 VALUES
                 (@LastName, @FirstName, @MiddleInitial, @Block, @Street, @City, @Phone,
                  @TherapistID, 'Pending', @BookingDate, @BookingTime, @DiscountPercent)"

            Using cmd As New SqlCommand(insertSql, con)
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                cmd.Parameters.AddWithValue("@MiddleInitial", txtMiddleInitial.Text)
                cmd.Parameters.AddWithValue("@Block", txtBlock.Text)
                cmd.Parameters.AddWithValue("@Street", txtStreet.Text)
                cmd.Parameters.AddWithValue("@City", txtCity.Text)
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
                cmd.Parameters.AddWithValue("@TherapistID", CInt(cmbTherapist.SelectedValue))
                cmd.Parameters.AddWithValue("@BookingDate", dtpBookingDate.Value.Date)
                cmd.Parameters.AddWithValue("@BookingTime", selectedTime)
                cmd.Parameters.AddWithValue("@DiscountPercent", discountPercent)

                bookingID = CInt(cmd.ExecuteScalar())
            End Using

            ' Save selected packages
            For Each p In selectedPackages.Values
                Dim pkgInsert =
                    "INSERT INTO BookingPackages (BookingID, PackageID, PackagePrice)
                     VALUES (@BookingID, @PackageID, @Price)"

                Using cmd2 As New SqlCommand(pkgInsert, con)
                    cmd2.Parameters.AddWithValue("@BookingID", bookingID)
                    cmd2.Parameters.AddWithValue("@PackageID", p.PackageID)
                    cmd2.Parameters.AddWithValue("@Price", p.Price)
                    cmd2.ExecuteNonQuery()
                End Using
            Next

        End Using

        MessageBox.Show("Booking saved successfully.")

        Dim receipt As New Receipt(Me)
        receipt.BookingID = bookingID
        receipt.Show()
        Me.Hide()

    End Sub

    Private Sub Booking_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        refreshTimer.Stop()
        If adminForm IsNot Nothing Then adminForm.Show()
    End Sub

End Class
