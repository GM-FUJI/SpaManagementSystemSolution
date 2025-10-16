Imports Microsoft.Data.SqlClient

Public Class Facilities

    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"


    '
    Private Sub Facilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbGender.Items.AddRange(New String() {"Male", "Female"})
        cmbStatus.Items.AddRange(New String() {"Available", "Unavailable"})


        LoadTherapistNames()
        LoadPackageNames()
    End Sub



    Private Sub LoadTherapistNames()
        cmbSearchTherapist.Items.Clear()

        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT Name FROM Therapists ORDER BY Name"
            Dim cmd As New SqlCommand(query, con)

            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbSearchTherapist.Items.Add(reader("Name").ToString())
            End While
            con.Close()
        End Using
    End Sub

    Private Sub LoadPackageNames()
        cmbSearchPackage.Items.Clear()

        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT PackageName FROM Packages ORDER BY PackageName"
            Dim cmd As New SqlCommand(query, con)

            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbSearchPackage.Items.Add(reader("PackageName").ToString())
            End While
            con.Close()
        End Using
    End Sub



    Private Sub btnAddTherapist_Click(sender As Object, e As EventArgs) Handles btnAddTherapist.Click
        If txtTname.Text = "" Or cmbGender.Text = "" Or cmbStatus.Text = "" Then
            MessageBox.Show("Please fill in all therapist fields.")
            Return
        End If

        Using con As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO Therapists (Name, Gender, Status) VALUES (@Name, @Gender, @Status)"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Name", txtTname.Text)
            cmd.Parameters.AddWithValue("@Gender", cmbGender.Text)
            cmd.Parameters.AddWithValue("@Status", cmbStatus.Text)

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using

        MessageBox.Show("Therapist added successfully!")

        txtTname.Clear()
        cmbGender.SelectedIndex = -1
        cmbStatus.SelectedIndex = -1


        LoadTherapistNames()
    End Sub

    Private Sub btnDeleteTherapist_Click(sender As Object, e As EventArgs) Handles btnDeleteTherapist.Click
        If cmbSearchTherapist.Text = "" Then
            MessageBox.Show("Please select a therapist to delete.")
            Return
        End If

        Dim selectedName As String = cmbSearchTherapist.Text

        Using con As New SqlConnection(connectionString)
            Dim checkQuery As String = "SELECT COUNT(*) FROM Therapists WHERE Name = @Name"
            Dim checkCmd As New SqlCommand(checkQuery, con)
            checkCmd.Parameters.AddWithValue("@Name", selectedName)

            con.Open()
            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            con.Close()

            If count = 0 Then
                MessageBox.Show("Therapist not found.")
                Return
            End If

            Dim confirm = MessageBox.Show($"Are you sure you want to delete therapist: {selectedName}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirm = DialogResult.No Then Return

            Dim deleteQuery As String = "DELETE FROM Therapists WHERE Name = @Name"
            Dim deleteCmd As New SqlCommand(deleteQuery, con)
            deleteCmd.Parameters.AddWithValue("@Name", selectedName)

            con.Open()
            deleteCmd.ExecuteNonQuery()
            con.Close()
        End Using

        MessageBox.Show("Therapist deleted successfully!")


        LoadTherapistNames()
        cmbSearchTherapist.SelectedIndex = -1
    End Sub



    Private Sub btnAddPackage_Click(sender As Object, e As EventArgs) Handles btnAddPackage.Click
        If txtPName.Text = "" Or txtPrice.Text = "" Then
            MessageBox.Show("Please fill in all package fields.")
            Return
        End If

        Using con As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO Packages (PackageName, Price) VALUES (@Name, @Price)"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Name", txtPName.Text)
            cmd.Parameters.AddWithValue("@Price", txtPrice.Text)

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using

        MessageBox.Show("Package added successfully!")

        txtPName.Clear()
        txtPrice.Clear()


        LoadPackageNames()
    End Sub

    Private Sub btnDeletePackage_Click(sender As Object, e As EventArgs) Handles btnDeletePackage.Click
        If cmbSearchPackage.Text = "" Then
            MessageBox.Show("Please select a package to delete.")
            Return
        End If

        Dim selectedPackage As String = cmbSearchPackage.Text

        Using con As New SqlConnection(connectionString)
            Dim checkQuery As String = "SELECT COUNT(*) FROM Packages WHERE PackageName = @Name"
            Dim checkCmd As New SqlCommand(checkQuery, con)
            checkCmd.Parameters.AddWithValue("@Name", selectedPackage)

            con.Open()
            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            con.Close()

            If count = 0 Then
                MessageBox.Show("Package not found.")
                Return
            End If

            Dim confirm = MessageBox.Show($"Are you sure you want to delete package: {selectedPackage}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirm = DialogResult.No Then Return

            Dim deleteQuery As String = "DELETE FROM Packages WHERE PackageName = @Name"
            Dim deleteCmd As New SqlCommand(deleteQuery, con)
            deleteCmd.Parameters.AddWithValue("@Name", selectedPackage)

            con.Open()
            deleteCmd.ExecuteNonQuery()
            con.Close()
        End Using

        MessageBox.Show("Package deleted successfully!")


        LoadPackageNames()
        cmbSearchPackage.SelectedIndex = -1
    End Sub

End Class
