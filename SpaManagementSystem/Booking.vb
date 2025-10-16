Imports Microsoft.Data.SqlClient

Public Class Booking

    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    Private Sub Booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGenders()
        LoadPackages()
    End Sub

    ' -------------------- GENDER COMBO --------------------
    Private Sub LoadGenders()
        cmbGender.Items.Clear()
        cmbGender.Items.Add("Male")
        cmbGender.Items.Add("Female")
    End Sub

    Private Sub cmbGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGender.SelectedIndexChanged
        If cmbGender.SelectedItem IsNot Nothing Then
            LoadTherapistsByGender(cmbGender.SelectedItem.ToString())
        End If
    End Sub

    ' -------------------- THERAPISTS --------------------
    Private Sub LoadTherapistsByGender(gender As String)
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT TherapistID, Name, Status FROM Therapists WHERE Gender = @Gender"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Gender", gender)
                Dim dt As New DataTable()
                dt.Load(cmd.ExecuteReader())

                ' Add Availability to display
                dt.Columns.Add("Display", GetType(String))
                For Each row As DataRow In dt.Rows
                    row("Display") = $"{row("Name")} - {row("Status")}"
                Next

                cmbTherapist.DataSource = dt
                cmbTherapist.DisplayMember = "Display"
                cmbTherapist.ValueMember = "TherapistID"
            End Using
        End Using
    End Sub

    ' -------------------- PACKAGES --------------------
    Private Sub LoadPackages()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT PackageID, PackageName, Price FROM Packages"
            Using cmd As New SqlCommand(query, con)
                Dim dt As New DataTable()
                dt.Load(cmd.ExecuteReader())
                cmbPackage.DataSource = dt
                cmbPackage.DisplayMember = "PackageName"
                cmbPackage.ValueMember = "PackageID"
            End Using
        End Using
    End Sub

    Private Sub cmbPackage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPackage.SelectedIndexChanged
        If cmbPackage.SelectedItem IsNot Nothing Then
            Dim drv As DataRowView = CType(cmbPackage.SelectedItem, DataRowView)
            txtPrice.Text = drv("Price").ToString()
        End If
    End Sub

    ' -------------------- SAVE BOOKING --------------------
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim bookingTime As String = txtBookingTime.Text.Trim()
        If String.IsNullOrEmpty(bookingTime) Then
            MessageBox.Show("Please enter the booking time (e.g. 10:00 AM).", "Missing Time", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cmbGender.SelectedItem Is Nothing OrElse cmbTherapist.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a therapist gender and therapist.", "Missing Therapist", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "INSERT INTO Bookings 
                (LastName, FirstName, MiddleInitial, Block, Street, City, Phone, TherapistID, PackageID, Price, BookingDate, BookingTime)
                VALUES (@LastName, @FirstName, @MiddleInitial, @Block, @Street, @City, @Phone, @TherapistID, @PackageID, @Price, @BookingDate, @BookingTime)"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                cmd.Parameters.AddWithValue("@MiddleInitial", txtMiddleInitial.Text)
                cmd.Parameters.AddWithValue("@Block", txtBlock.Text)
                cmd.Parameters.AddWithValue("@Street", txtStreet.Text)
                cmd.Parameters.AddWithValue("@City", txtCity.Text)
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
                cmd.Parameters.AddWithValue("@TherapistID", cmbTherapist.SelectedValue)
                cmd.Parameters.AddWithValue("@PackageID", cmbPackage.SelectedValue)
                cmd.Parameters.AddWithValue("@Price", Decimal.Parse(txtPrice.Text))
                cmd.Parameters.AddWithValue("@BookingDate", dtpBookingDate.Value)
                cmd.Parameters.AddWithValue("@BookingTime", bookingTime)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Booking saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearForm()
    End Sub

    ' -------------------- CLEAR FORM --------------------
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtLastName.Clear()
        txtFirstName.Clear()
        txtMiddleInitial.Clear()
        txtBlock.Clear()
        txtStreet.Clear()
        txtCity.Clear()
        txtPhone.Clear()
        txtPrice.Clear()
        txtBookingTime.Clear()
        cmbGender.SelectedIndex = -1
        cmbTherapist.DataSource = Nothing
        If cmbPackage.Items.Count > 0 Then cmbPackage.SelectedIndex = 0
        dtpBookingDate.Value = DateTime.Now
    End Sub

End Class
