Imports Microsoft.Data.SqlClient

Public Class Therapist

    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"

d DataGridView

    Private Sub LoadTherapistGrid()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT Name, Status FROM Therapists"
            Dim adapter As New SqlDataAdapter(query, con)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvTherapist.DataSource = dt
        End Using


        For Each row As DataGridViewRow In dgvTherapist.Rows
            If row.Cells("Status").Value IsNot Nothing Then
                If row.Cells("Status").Value.ToString() = "Available" Then
                    row.Cells("Status").Style.ForeColor = Color.Green
                Else
                    row.Cells("Status").Style.ForeColor = Color.Red
                End If
            End If
        Next
    End Sub




    Private Sub LoadTherapistCombo()
        cmbTherapist.Items.Clear()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT Name FROM Therapists"
            Dim cmd As New SqlCommand(query, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbTherapist.Items.Add(reader("Name").ToString())
            End While
        End Using
    End Sub


    Private Sub cmbTherapist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTherapist.SelectedIndexChanged
        Dim selectedName As String = cmbTherapist.SelectedItem.ToString()

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT Status FROM Therapists WHERE Name=@name"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@name", selectedName)

            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                lblStatus.Text = result.ToString()
            End If
        End Using
    End Sub



    Private Sub btnTimeIn_Click(sender As Object, e As EventArgs) Handles btnTimeIn.Click
        If cmbTherapist.SelectedItem IsNot Nothing Then
            UpdateTherapistStatus(cmbTherapist.SelectedItem.ToString(), "Available")
        Else
            MessageBox.Show("Please select a therapist first.")
        End If
    End Sub


    Private Sub btnTimeOut_Click(sender As Object, e As EventArgs) Handles btnTimeOut.Click
        If cmbTherapist.SelectedItem IsNot Nothing Then
            UpdateTherapistStatus(cmbTherapist.SelectedItem.ToString(), "Unavailable")
        Else
            MessageBox.Show("Please select a therapist first.")
        End If
    End Sub


    Private Sub UpdateTherapistStatus(name As String, newStatus As String)

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "UPDATE Therapists SET Status=@status WHERE Name=@name"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@status", newStatus)
            cmd.Parameters.AddWithValue("@name", name)
            cmd.ExecuteNonQuery()
        End Using


        LoadTherapistGrid()


        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT Status FROM Therapists WHERE Name=@name"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@name", name)
            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                lblStatus.Text = result.ToString()
            End If
        End Using
    End Sub


    Private Sub Therapist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTherapistGrid()
        LoadTherapistCombo()
    End Sub

End Class
