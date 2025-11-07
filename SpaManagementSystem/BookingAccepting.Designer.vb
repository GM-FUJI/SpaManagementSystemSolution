<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookingAccepting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BookingAccepting))
        dgvBookings = New DataGridView()
        btnAccept = New Button()
        btnDelete = New Button()
        CType(dgvBookings, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvBookings
        ' 
        dgvBookings.BackgroundColor = Color.White
        dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBookings.Location = New Point(51, 195)
        dgvBookings.MultiSelect = False
        dgvBookings.Name = "dgvBookings"
        dgvBookings.ReadOnly = True
        dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBookings.Size = New Size(1156, 300)
        dgvBookings.TabIndex = 0
        ' 
        ' btnAccept
        ' 
        btnAccept.Location = New Point(1011, 519)
        btnAccept.Name = "btnAccept"
        btnAccept.Size = New Size(103, 37)
        btnAccept.TabIndex = 1
        btnAccept.Text = "Accept"
        btnAccept.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(1120, 519)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(104, 37)
        btnDelete.TabIndex = 2
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' BookingAccepting
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(1260, 590)
        Controls.Add(btnDelete)
        Controls.Add(btnAccept)
        Controls.Add(dgvBookings)
        DoubleBuffered = True
        Name = "BookingAccepting"
        StartPosition = FormStartPosition.CenterScreen
        Text = "BookingAccepting"
        CType(dgvBookings, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvBookings As DataGridView
    Friend WithEvents btnAccept As Button
    Friend WithEvents btnDelete As Button
End Class
