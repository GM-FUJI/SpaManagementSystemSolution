<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TherapistInterface
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
        btnBookings = New Button()
        btnHistoryofCustomer = New Button()
        btnTimeIn = New Button()
        btnTimeOut = New Button()
        btnDoneSession = New Button()
        SuspendLayout()
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(31, 186)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(92, 35)
        btnLogout.TabIndex = 3
        btnLogout.Text = "Log Out "
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnBookings
        ' 
        btnBookings.Location = New Point(31, 64)
        btnBookings.Name = "btnBookings"
        btnBookings.Size = New Size(92, 39)
        btnBookings.TabIndex = 5
        btnBookings.Text = "Booking"
        btnBookings.UseVisualStyleBackColor = True
        ' 
        ' btnHistoryofCustomer
        ' 
        btnHistoryofCustomer.Location = New Point(31, 126)
        btnHistoryofCustomer.Name = "btnHistoryofCustomer"
        btnHistoryofCustomer.Size = New Size(92, 36)
        btnHistoryofCustomer.TabIndex = 6
        btnHistoryofCustomer.Text = "History"
        btnHistoryofCustomer.UseVisualStyleBackColor = True
        ' 
        ' btnTimeIn
        ' 
        btnTimeIn.Location = New Point(227, 63)
        btnTimeIn.Name = "btnTimeIn"
        btnTimeIn.Size = New Size(142, 40)
        btnTimeIn.TabIndex = 7
        btnTimeIn.Text = "Time in"
        btnTimeIn.UseVisualStyleBackColor = True
        ' 
        ' btnTimeOut
        ' 
        btnTimeOut.Location = New Point(407, 62)
        btnTimeOut.Name = "btnTimeOut"
        btnTimeOut.Size = New Size(142, 40)
        btnTimeOut.TabIndex = 8
        btnTimeOut.Text = "Time Out"
        btnTimeOut.UseVisualStyleBackColor = True
        ' 
        ' btnDoneSession
        ' 
        btnDoneSession.Location = New Point(795, 62)
        btnDoneSession.Name = "btnDoneSession"
        btnDoneSession.Size = New Size(144, 39)
        btnDoneSession.TabIndex = 9
        btnDoneSession.Text = "Done Session"
        btnDoneSession.UseVisualStyleBackColor = True
        ' 
        ' TherapistInterface
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1032, 604)
        Controls.Add(btnDoneSession)
        Controls.Add(btnTimeOut)
        Controls.Add(btnTimeIn)
        Controls.Add(btnHistoryofCustomer)
        Controls.Add(btnBookings)
        Controls.Add(btnLogout)
        Name = "TherapistInterface"
        StartPosition = FormStartPosition.CenterScreen
        Text = "TherapistForm"
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnBookings As Button
    Friend WithEvents btnHistoryofCustomer As Button
    Friend WithEvents btnTimeIn As Button
    Friend WithEvents btnTimeOut As Button
    Friend WithEvents btnDoneSession As Button
End Class
