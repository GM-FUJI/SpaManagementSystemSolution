<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookingofCustomers
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
        Label1 = New Label()
        dgvBookings = New DataGridView()
        lblTherapistName = New Label()
        AcceptBtn = New DataGridViewButtonColumn()
        DeleteBtn = New DataGridViewButtonColumn()
        CType(dgvBookings, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Showcard Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(292, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(209, 23)
        Label1.TabIndex = 0
        Label1.Text = "List of Customers"
        ' 
        ' dgvBookings
        ' 
        dgvBookings.BackgroundColor = Color.White
        dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBookings.Columns.AddRange(New DataGridViewColumn() {AcceptBtn, DeleteBtn})
        dgvBookings.Location = New Point(12, 202)
        dgvBookings.Name = "dgvBookings"
        dgvBookings.Size = New Size(816, 270)
        dgvBookings.TabIndex = 1
        ' 
        ' lblTherapistName
        ' 
        lblTherapistName.AutoSize = True
        lblTherapistName.Location = New Point(12, 56)
        lblTherapistName.Name = "lblTherapistName"
        lblTherapistName.Size = New Size(77, 15)
        lblTherapistName.TabIndex = 2
        lblTherapistName.Text = "Logged in as:"
        ' 
        ' AcceptBtn
        ' 
        AcceptBtn.HeaderText = "Accept"
        AcceptBtn.Name = "AcceptBtn"
        AcceptBtn.UseColumnTextForButtonValue = True
        ' 
        ' DeleteBtn
        ' 
        DeleteBtn.HeaderText = "Delete"
        DeleteBtn.Name = "DeleteBtn"
        DeleteBtn.UseColumnTextForButtonValue = True
        ' 
        ' BookingofCustomers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(840, 494)
        Controls.Add(lblTherapistName)
        Controls.Add(dgvBookings)
        Controls.Add(Label1)
        Name = "BookingofCustomers"
        Text = "BookingofCustomers"
        CType(dgvBookings, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvBookings As DataGridView
    Friend WithEvents lblTherapistName As Label
    Friend WithEvents AcceptBtn As DataGridViewButtonColumn
    Friend WithEvents DeleteBtn As DataGridViewButtonColumn
End Class
