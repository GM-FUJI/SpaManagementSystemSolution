Imports Microsoft.Data.SqlClient
Imports System.Data
Public Class Package
    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

    Private Sub Package(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPackages()
    End Sub
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
End Class