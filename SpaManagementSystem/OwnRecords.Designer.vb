<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OwnRecords
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OwnRecords))
        dgvOwnRecords = New DataGridView()
        CType(dgvOwnRecords, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvOwnRecords
        ' 
        dgvOwnRecords.BackgroundColor = Color.White
        dgvOwnRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOwnRecords.Location = New Point(52, 202)
        dgvOwnRecords.Name = "dgvOwnRecords"
        dgvOwnRecords.Size = New Size(1160, 339)
        dgvOwnRecords.TabIndex = 0
        ' 
        ' OwnRecords
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1262, 590)
        Controls.Add(dgvOwnRecords)
        Name = "OwnRecords"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OwnRecords"
        CType(dgvOwnRecords, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvOwnRecords As DataGridView
End Class
