Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class Package

    Private adminForm As AdminInterface
    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    ' ✅ Constructor that accepts AdminInterface as the parent form
    Public Sub New(admin As AdminInterface)
        InitializeComponent()
        adminForm = admin
    End Sub

    ' -------------------- FORM LOAD --------------------
    Private Sub Package_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPackages()
        LoadPackageNames()
    End Sub

    ' -------------------- LOAD PACKAGES INTO GRID --------------------
    Private Sub LoadPackages()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT PackageID, PackageName, Price FROM Packages"
                Dim cmd As New SqlCommand(query, conn)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvPackages.DataSource = dt
            End Using

            With dgvPackages
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
            End With

        Catch ex As Exception
            MessageBox.Show("Error loading packages: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' -------------------- LOAD PACKAGE NAMES INTO COMBOBOX --------------------
    Private Sub LoadPackageNames()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT PackageName FROM Packages"
                Dim cmd As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                cmbSearchPackage.Items.Clear()
                While reader.Read()
                    cmbSearchPackage.Items.Add(reader("PackageName").ToString())
                End While
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading package names: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' -------------------- ADD PACKAGE --------------------
    Private Sub btnAddPackage_Click(sender As Object, e As EventArgs) Handles btnAddPackage.Click
        If String.IsNullOrWhiteSpace(txtPName.Text) OrElse String.IsNullOrWhiteSpace(txtPrice.Text) Then
            MessageBox.Show("Please fill in all package fields.", "Missing Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using con As New SqlConnection(connectionString)
                Dim query As String = "INSERT INTO Packages (PackageName, Price) VALUES (@Name, @Price)"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Name", txtPName.Text)
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text)
                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Package added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtPName.Clear()
            txtPrice.Clear()
            LoadPackages()
            LoadPackageNames()

        Catch ex As Exception
            MessageBox.Show("Error adding package: " & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' -------------------- DELETE PACKAGE --------------------
    Private Sub btnDeletePackage_Click(sender As Object, e As EventArgs) Handles btnDeletePackage.Click
        If String.IsNullOrWhiteSpace(cmbSearchPackage.Text) Then
            MessageBox.Show("Please select a package to delete.", "Missing Selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedPackage As String = cmbSearchPackage.Text
        Try
            Using con As New SqlConnection(connectionString)
                Dim checkQuery As String = "SELECT COUNT(*) FROM Packages WHERE PackageName = @Name"
                Using checkCmd As New SqlCommand(checkQuery, con)
                    checkCmd.Parameters.AddWithValue("@Name", selectedPackage)
                    con.Open()
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    con.Close()

                    If count = 0 Then
                        MessageBox.Show("Package not found.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                Dim confirm = MessageBox.Show($"Are you sure you want to delete package: {selectedPackage}?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If confirm = DialogResult.No Then Return

                Dim deleteQuery As String = "DELETE FROM Packages WHERE PackageName = @Name"
                Using deleteCmd As New SqlCommand(deleteQuery, con)
                    deleteCmd.Parameters.AddWithValue("@Name", selectedPackage)
                    con.Open()
                    deleteCmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Package deleted successfully!", "Deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadPackages()
            LoadPackageNames()
            cmbSearchPackage.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error deleting package: " & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' -------------------- FORM CLOSED --------------------
    Private Sub Package_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If adminForm IsNot Nothing Then
            adminForm.Show()
        End If
    End Sub

End Class
