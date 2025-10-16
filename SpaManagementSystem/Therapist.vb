Imports System.Data.SqlClient

Public Class Therapist

    ' Your SQL Server connection string
    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;"

    ' -----------------------------
    ' Load data when form opens
    ' -----------------------------
    Private Sub Therapist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill gender combo
        cmbGender.Items.Clear()
        cmbGender.Items.Add("Male")
        cmbGender.Items.Add("Female")

        ' Select default gender
        cmbGender.SelectedIndex = 0
    End Sub


    ' --------------------------------
    ' When Gender ComboBox changes
    ' --------------------------------
    Private Sub cmbGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGender.SelectedIndexChanged
        Dim selectedGender As String = cmbGender.SelectedItem.ToString()
        LoadTherapistGrid(selectedGender)
        LoadTherapistCombo(selectedGender)
    End Sub


    ' --------------------------------
    ' Load therapists into DataGridView
    ' --------------------------------
    Private Sub LoadTherapistGrid(gender As String)
        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "SELECT Name, Status FROM Therapists WHERE Gender = @gender"
            Dim adapter As New SqlDataAdapter(query, con)
            adapter.SelectCommand.Parameters.AddWithValue("@gender", gender)

            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvTherapist.DataSource = dt
        End Using

        ' Color status text
        For Each row As DataGridViewRow In dgvTherapist.Rows
            If row.Cells("Status").Value IsNot Nothing Then
                Dim statusText As String = row.Cells("Status").Value.ToString()
                If statusText = "Available" Then
                    row.Cells("Status").Style.ForeColor = Color.Green
                Else
                    row.Cells("Status").Style.ForeColor = Color.Red
                End If
            End If
        Next
    End Sub


    ' --------------------------------
    ' Load therapists into ComboBox
    ' --------------------------------
    Private Sub LoadTherapistCombo(gender As String)
        cmbTherapist.Items.Clear()

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "SELECT Name FROM Therapists WHERE Gender = @gender"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@gender", gender)

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbTherapist.Items.Add(reader("Name").ToString())
            End While
        End Using
    End Sub


    ' --------------------------------
    ' Example Button: Time In
    ' --------------------------------
    Private Sub btnTimeIn_Click(sender As Object, e As EventArgs) Handles btnTimeIn.Click
        If cmbTherapist.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a therapist first.")
            Return
        End If

        UpdateTherapistStatus(cmbTherapist.SelectedItem.ToString(), "Available")
    End Sub


    ' --------------------------------
    ' Example Button: Time Out
    ' --------------------------------
    Private Sub btnTimeOut_Click(sender As Object, e As EventArgs) Handles btnTimeOut.Click
        If cmbTherapist.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a therapist first.")
            Return
        End If

        UpdateTherapistStatus(cmbTherapist.SelectedItem.ToString(), "Unavailable")
    End Sub


    ' --------------------------------
    ' Update therapist status in DB
    ' --------------------------------
    Private Sub UpdateTherapistStatus(name As String, status As String)
        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "UPDATE Therapists SET Status = @status WHERE Name = @name"
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@status", status)
            cmd.Parameters.AddWithValue("@name", name)
            cmd.ExecuteNonQuery()
        End Using

        ' Refresh grid
        Dim selectedGender As String = cmbGender.SelectedItem.ToString()
        LoadTherapistGrid(selectedGender)
    End Sub

End Class
