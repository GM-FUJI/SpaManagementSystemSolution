Imports Microsoft.Data.SqlClient

Public Class Booking

    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"


    Private Sub Booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTherapists()
        LoadPackages()
    End Sub

    Private Sub LoadTherapists()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT TherapistID, Name FROM Therapists"
            Using cmd As New SqlCommand(query, con)
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
            Dim query As String = "SELECT PackageID, PackageName, Price, Validity FROM Packages"
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

            txtValidity.Text = If(IsDBNull(drv("Validity")), "N/A", drv("Validity").ToString())
        End If
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "INSERT INTO Bookings 
                (ClientName, Block, Street, City, Phone, TherapistID, PackageID, Price, BookingDate)
                VALUES (@Name, @Block, @Street, @City, @Phone, @TherapistID, @PackageID, @Price, @BookingDate)"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Name", txtName.Text)
                cmd.Parameters.AddWithValue("@Block", txtBlock.Text)
                cmd.Parameters.AddWithValue("@Street", txtStreet.Text)
                cmd.Parameters.AddWithValue("@City", txtCity.Text)
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
                cmd.Parameters.AddWithValue("@TherapistID", cmbTherapist.SelectedValue)
                cmd.Parameters.AddWithValue("@PackageID", cmbPackage.SelectedValue)
                cmd.Parameters.AddWithValue("@Price", Decimal.Parse(txtPrice.Text))
                cmd.Parameters.AddWithValue("@BookingDate", dtpBookingDate.Value)

                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Booking saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearForm()
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtName.Clear()
        txtBlock.Clear()
        txtStreet.Clear()
        txtCity.Clear()
        txtPhone.Clear()
        txtPrice.Clear()
        txtValidity.Clear()
        If cmbTherapist.Items.Count > 0 Then cmbTherapist.SelectedIndex = 0
        If cmbPackage.Items.Count > 0 Then cmbPackage.SelectedIndex = 0
        dtpBookingDate.Value = DateTime.Now
    End Sub
End Class
