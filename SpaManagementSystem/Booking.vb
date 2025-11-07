Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class Booking
    Private adminForm As Form
    Private connectionString As String =
        "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
    Private selectedTime As String = ""

    Public Sub New(Optional admin As Form = Nothing)
        InitializeComponent()
        Me.adminForm = admin
    End Sub

    Private Sub Booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGenders()
        LoadPackages()
        GenerateTimeSlots()
    End Sub

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

    Private Sub LoadPackages()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query = "SELECT PackageID, PackageName, Price FROM Packages"
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(selectedTime) Then
            MessageBox.Show("Please select a booking time.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cmbTherapist.SelectedValue Is Nothing Or cmbPackage.SelectedValue Is Nothing Then
            MessageBox.Show("Please select therapist and package.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()


                Dim bookingQuery As String =
                    "INSERT INTO Bookings
                     (LastName, FirstName, MiddleInitial, Block, Street, City, Phone,
                      TherapistID, PackageID, Price, Status, BookingDate, BookingTime)
                     OUTPUT INSERTED.BookingID
                     VALUES
                     (@LastName, @FirstName, @MiddleInitial, @Block, @Street, @City, @Phone,
                      @TherapistID, @PackageID, @Price, 'Pending', @BookingDate, @BookingTime)"

                Dim bookingID As Integer
                Using cmd As New SqlCommand(bookingQuery, con)
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim())
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim())
                    cmd.Parameters.AddWithValue("@MiddleInitial", txtMiddleInitial.Text.Trim())
                    cmd.Parameters.AddWithValue("@Block", txtBlock.Text.Trim())
                    cmd.Parameters.AddWithValue("@Street", txtStreet.Text.Trim())
                    cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@TherapistID", CInt(cmbTherapist.SelectedValue))
                    cmd.Parameters.AddWithValue("@PackageID", CInt(cmbPackage.SelectedValue))
                    cmd.Parameters.AddWithValue("@Price", Decimal.Parse(txtPrice.Text))
                    cmd.Parameters.AddWithValue("@BookingDate", dtpBookingDate.Value.Date)
                    cmd.Parameters.AddWithValue("@BookingTime", selectedTime)

                    bookingID = CInt(cmd.ExecuteScalar())
                End Using


                Dim pointsQuery As String =
                    "INSERT INTO PointsSystem (TherapistID, BookingID, PointsEarned)
                     VALUES (@TherapistID, @BookingID, 50)"

                Using cmdPoints As New SqlCommand(pointsQuery, con)
                    cmdPoints.Parameters.AddWithValue("@TherapistID", CInt(cmbTherapist.SelectedValue))
                    cmdPoints.Parameters.AddWithValue("@BookingID", bookingID)
                    cmdPoints.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Booking saved and therapist earned 50 points!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearForm()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        cmbGender.SelectedIndex = -1
        cmbTherapist.DataSource = Nothing
        cmbPackage.SelectedIndex = -1
        selectedTime = ""
        dtpBookingDate.Value = DateTime.Now
        GenerateTimeSlots()
    End Sub

    Private Sub Booking_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If adminForm IsNot Nothing Then adminForm.Show()
    End Sub
End Class
