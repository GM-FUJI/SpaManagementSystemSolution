<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Therapist
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
        Label1 = New System.Windows.Forms.Label()
        lblStatus = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        dgvTherapist = New DataGridView()
        cmbTherapist = New ComboBox()
        Label3 = New System.Windows.Forms.Label()
        btnSearch = New Button()
        CType(dgvTherapist, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(375, 46)
        Label1.Name = "Label1"
        Label1.Size = New Size(229, 19)
        Label1.TabIndex = 0
        Label1.Text = "Therapist Availability"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatus.Location = New Point(154, 143)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(0, 21)
        lblStatus.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(417, 223)
        Label4.Name = "Label4"
        Label4.Size = New Size(148, 19)
        Label4.TabIndex = 7
        Label4.Text = "Therapist List"
        ' 
        ' dgvTherapist
        ' 
        dgvTherapist.AllowUserToAddRows = False
        dgvTherapist.AllowUserToDeleteRows = False
        dgvTherapist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTherapist.BackgroundColor = Color.White
        dgvTherapist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTherapist.Location = New Point(65, 283)
        dgvTherapist.Name = "dgvTherapist"
        dgvTherapist.ReadOnly = True
        dgvTherapist.Size = New Size(613, 261)
        dgvTherapist.TabIndex = 8
        ' 
        ' cmbTherapist
        ' 
        cmbTherapist.FormattingEnabled = True
        cmbTherapist.Location = New Point(169, 114)
        cmbTherapist.Name = "cmbTherapist"
        cmbTherapist.Size = New Size(121, 23)
        cmbTherapist.TabIndex = 15
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(35, 117)
        Label3.Name = "Label3"
        Label3.Size = New Size(111, 20)
        Label3.TabIndex = 16
        Label3.Text = "Select Therapist:"
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(169, 156)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 17
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' Therapist
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1021, 580)
        Controls.Add(btnSearch)
        Controls.Add(Label3)
        Controls.Add(cmbTherapist)
        Controls.Add(dgvTherapist)
        Controls.Add(Label4)
        Controls.Add(lblStatus)
        Controls.Add(Label1)
        Name = "Therapist"
        Text = "Therapist"
        CType(dgvTherapist, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvTherapist As DataGridView
    Friend WithEvents cmbTherapist As ComboBox
    Friend WithEvents lblStatusTitle As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnSearch As Button

End Class
