Imports Microsoft.Data.SqlClient
Imports System.Windows.Forms

Public Class Therapist

    Private adminForm As AdminInterface
    Private connectionString As String = "Server=DESKTOP-UKNIJ8J\SQLEXPRESS;Database=SpaManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;"
    Private refreshTimer As Timer

    Public Sub New(admin As AdminInterface)
        InitializeComponent()
        adminForm = admin
    End Sub

    Private Sub Therapist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboBoxOptions()
        LoadTherapistNames()
        LoadTherapistGrid()

        refreshTimer = New Timer()
        refreshTimer.Interval = 5000
        AddHandler refreshTimer.Tick, AddressOf RefreshTimer_Tick
        refreshTimer.Start()
    End Sub

    ' -------------------- COMBOBOX OPTIONS --------------------
    Private Sub LoadComboBoxOptions()
        cmbGender.Items.Clear()
        cmbGender.Items.AddRange(New String() {"Male", "Female"})

        cmbStatus.Items.Clear()
        cmbStatus.Items.AddRange(New String() {"Available", "In Session", "Unavailable"})
    End Sub

    Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs)
        Dim selectedName As String = Nothing
        If cmbTherapist.SelectedItem IsNot Nothing Then
            selectedName = cmbTherapist.SelectedItem.ToString()
        End If
        LoadTherapistGrid(selectedName)
    End Sub

    Private Sub LoadTherapistNames()
        cmbTherapist.Items.Clear()
        cmbSearchTherapist.Items.Clear()

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT Name FROM Therapists ORDER BY Name"
            Using cmd As New SqlCommand(query, con)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim name = reader("Name").ToString()
                    cmbTherapist.Items.Add(name)
                    cmbSearchTherapist.Items.Add(name)
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
                Select Case statusText
                    Case "Available"
                        row.Cells("Status").Style.ForeColor = Color.Green
                    Case "In Session"
                        row.Cells("Status").Style.ForeColor = Color.Orange
                    Case "Unavailable"
                        row.Cells("Status").Style.ForeColor = Color.Red
                    Case Else
                        row.Cells("Status").Style.ForeColor = Color.Black
                End Select
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

    ' -------------------- ADD THERAPIST & USER --------------------
    Private Sub btnAddTherapist_Click(sender As Object, e As EventArgs) Handles btnAddTherapist.Click
        If String.IsNullOrWhiteSpace(txtTname.Text) OrElse
           String.IsNullOrWhiteSpace(cmbGender.Text) OrElse
           String.IsNullOrWhiteSpace(cmbStatus.Text) Then

            MessageBox.Show("Please fill in all therapist fields.", "Missing Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' Start transaction to insert into both tables
                Using transaction = con.BeginTransaction()
                    ' 1️⃣ Insert into Therapists
                    Dim therapistQuery As String = "INSERT INTO Therapists (Name, Gender, Status) VALUES (@Name, @Gender, @Status)"
                    Using therapistCmd As New SqlCommand(therapistQuery, con, transaction)
                        therapistCmd.Parameters.AddWithValue("@Name", txtTname.Text)
                        therapistCmd.Parameters.AddWithValue("@Gender", cmbGender.Text)
                        therapistCmd.Parameters.AddWithValue("@Status", cmbStatus.Text)
                        therapistCmd.ExecuteNonQuery()
                    End Using

                    ' 2️⃣ Insert into Users with default password "12345"
                    Dim userQuery As String = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)"
                    Using userCmd As New SqlCommand(userQuery, con, transaction)
                        userCmd.Parameters.AddWithValue("@Username", txtTname.Text) ' therapist name as username
                        userCmd.Parameters.AddWithValue("@Password", "12345")        ' default password
                        userCmd.Parameters.AddWithValue("@Role", "Therapist")        ' role
                        userCmd.ExecuteNonQuery()
                    End Using

                    transaction.Commit()
                End Using
            End Using

            MessageBox.Show("Therapist and user account added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear input fields
            txtTname.Clear()
            cmbGender.SelectedIndex = -1
            cmbStatus.SelectedIndex = -1
            LoadTherapistNames()
            LoadTherapistGrid()

        Catch ex As Exception
            MessageBox.Show("Error adding therapist and user account: " & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' -------------------- DELETE THERAPIST --------------------
    Private Sub btnDeleteTherapist_Click(sender As Object, e As EventArgs) Handles btnDeleteTherapist.Click
        If String.IsNullOrWhiteSpace(cmbSearchTherapist.Text) Then
            MessageBox.Show("Please select a therapist to delete.", "Missing Selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedName As String = cmbSearchTherapist.Text
        Try
            Using con As New SqlConnection(connectionString)
                Dim checkQuery As String = "SELECT COUNT(*) FROM Therapists WHERE Name = @Name"
                Using checkCmd As New SqlCommand(checkQuery, con)
                    checkCmd.Parameters.AddWithValue("@Name", selectedName)
                    con.Open()
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    con.Close()

                    If count = 0 Then
                        MessageBox.Show("Therapist not found.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                Dim confirm = MessageBox.Show($"Are you sure you want to delete therapist: {selectedName}?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If confirm = DialogResult.No Then Return

                Dim deleteQuery As String = "DELETE FROM Therapists WHERE Name = @Name"
                Using deleteCmd As New SqlCommand(deleteQuery, con)
                    deleteCmd.Parameters.AddWithValue("@Name", selectedName)
                    con.Open()
                    deleteCmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Therapist deleted successfully!", "Deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadTherapistNames()
            LoadTherapistGrid()
            cmbSearchTherapist.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error deleting therapist: " & ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' -------------------- FORM EVENTS --------------------
    Private Sub Therapist_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If refreshTimer IsNot Nothing Then
            refreshTimer.Stop()
            refreshTimer.Dispose()
        End If
    End Sub

    Private Sub Therapist_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If adminForm IsNot Nothing Then
            adminForm.Show()
        End If
    End Sub

End Class
