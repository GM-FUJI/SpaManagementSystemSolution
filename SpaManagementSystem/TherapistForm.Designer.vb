<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TherapistForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnLogout = New Button()
        btnAttendance = New Button()
        btnBookings = New Button()
        btnHistoryofCustomer = New Button()
        Panel1 = New Panel()
        SuspendLayout()
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(31, 448)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(92, 35)
        btnLogout.TabIndex = 3
        btnLogout.Text = "Log Out "
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnAttendance
        ' 
        btnAttendance.Location = New Point(31, 118)
        btnAttendance.Name = "btnAttendance"
        btnAttendance.Size = New Size(92, 38)
        btnAttendance.TabIndex = 4
        btnAttendance.Text = "Attendance"
        btnAttendance.UseVisualStyleBackColor = True
        ' 
        ' btnBookings
        ' 
        btnBookings.Location = New Point(31, 195)
        btnBookings.Name = "btnBookings"
        btnBookings.Size = New Size(92, 39)
        btnBookings.TabIndex = 5
        btnBookings.Text = "Booking"
        btnBookings.UseVisualStyleBackColor = True
        ' 
        ' btnHistoryofCustomer
        ' 
        btnHistoryofCustomer.Location = New Point(31, 286)
        btnHistoryofCustomer.Name = "btnHistoryofCustomer"
        btnHistoryofCustomer.Size = New Size(92, 36)
        btnHistoryofCustomer.TabIndex = 6
        btnHistoryofCustomer.Text = "History"
        btnHistoryofCustomer.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(151, 35)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(850, 526)
        Panel1.TabIndex = 7
        ' 
        ' TherapistForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1032, 604)
        Controls.Add(Panel1)
        Controls.Add(btnHistoryofCustomer)
        Controls.Add(btnBookings)
        Controls.Add(btnAttendance)
        Controls.Add(btnLogout)
        Name = "TherapistForm"
        Text = "TherapistForm"
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnAttendance As Button
    Friend WithEvents btnBookings As Button
    Friend WithEvents btnHistoryofCustomer As Button
    Friend WithEvents Panel1 As Panel
End Class
