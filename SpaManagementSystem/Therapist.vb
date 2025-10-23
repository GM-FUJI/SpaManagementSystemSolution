Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class Therapist

    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;"
    Private refreshTimer As Timer


    Private Sub Therapist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTherapistCombo()
        LoadTherapistGrid()


        refreshTimer = New Timer()
        refreshTimer.Interval = 5000
        AddHandler refreshTimer.Tick, AddressOf RefreshTimer_Tick
        refreshTimer.Start()
    End Sub


    Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs)
        Dim selectedName As String = Nothing
        If cmbTherapist.SelectedItem IsNot Nothing Then
            selectedName = cmbTherapist.SelectedItem.ToString()
        End If
        LoadTherapistGrid(selectedName)
    End Sub


    Private Sub LoadTherapistCombo()
        cmbTherapist.Items.Clear()

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT Name FROM Therapists ORDER BY Name"
            Using cmd As New SqlCommand(query, con)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    cmbTherapist.Items.Add(reader("Name").ToString())
                End While
            End Using
        End Using
    End Sub


    Private Sub LoadTherapistGrid(Optional therapistName As String = Nothing)
        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String
            If String.IsNullOrEmpty(therapistName) Then
                query = "SELECT Name, Status FROM Therapists"
            Else
                query = "SELECT Name, Status FROM Therapists WHERE Name = @name"
            End If

            Dim adapter As New SqlDataAdapter(query, con)
            If Not String.IsNullOrEmpty(therapistName) Then
                adapter.SelectCommand.Parameters.AddWithValue("@name", therapistName)
            End If

            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvTherapist.DataSource = dt
        End Using


        For Each row As DataGridViewRow In dgvTherapist.Rows
            If row.Cells("Status").Value IsNot Nothing Then
                Dim statusText As String = row.Cells("Status").Value.ToString()
                If statusText = "Available" Then
                    row.Cells("Status").Style.ForeColor = Color.Green
                ElseIf statusText = "In Session" Then
                    row.Cells("Status").Style.ForeColor = Color.Orange
                ElseIf statusText = "Unavailable" Then
                    row.Cells("Status").Style.ForeColor = Color.Red
                Else
                    row.Cells("Status").Style.ForeColor = Color.Black
                End If

            End If
        Next
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cmbTherapist.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a therapist to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedTherapist As String = cmbTherapist.SelectedItem.ToString()
        LoadTherapistGrid(selectedTherapist)
    End Sub


    Private Sub Therapist_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If refreshTimer IsNot Nothing Then
            refreshTimer.Stop()
            refreshTimer.Dispose()
        End If
    End Sub

End Class
