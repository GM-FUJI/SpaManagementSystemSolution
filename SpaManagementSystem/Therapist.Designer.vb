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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Therapist))
        lblStatus = New Label()
        dgvTherapist = New DataGridView()
        cmbTherapist = New ComboBox()
        btnSearch = New Button()
        btnDeleteTherapist = New Button()
        cmbSearchTherapist = New ComboBox()
        btnAddTherapist = New Button()
        cmbStatus = New ComboBox()
        txtTname = New TextBox()
        cmbGender = New ComboBox()
        CType(dgvTherapist, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
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
        ' dgvTherapist
        ' 
        dgvTherapist.AllowUserToAddRows = False
        dgvTherapist.AllowUserToDeleteRows = False
        dgvTherapist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTherapist.BackgroundColor = Color.White
        dgvTherapist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTherapist.Location = New Point(44, 356)
        dgvTherapist.Name = "dgvTherapist"
        dgvTherapist.ReadOnly = True
        dgvTherapist.Size = New Size(568, 374)
        dgvTherapist.TabIndex = 8
        ' 
        ' cmbTherapist
        ' 
        cmbTherapist.FormattingEnabled = True
        cmbTherapist.Location = New Point(60, 144)
        cmbTherapist.Name = "cmbTherapist"
        cmbTherapist.Size = New Size(233, 23)
        cmbTherapist.TabIndex = 15
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(60, 190)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(123, 32)
        btnSearch.TabIndex = 17
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnDeleteTherapist
        ' 
        btnDeleteTherapist.Location = New Point(680, 356)
        btnDeleteTherapist.Name = "btnDeleteTherapist"
        btnDeleteTherapist.Size = New Size(148, 38)
        btnDeleteTherapist.TabIndex = 6
        btnDeleteTherapist.Text = "Delete Therapist"
        btnDeleteTherapist.UseVisualStyleBackColor = True
        ' 
        ' cmbSearchTherapist
        ' 
        cmbSearchTherapist.FormattingEnabled = True
        cmbSearchTherapist.Location = New Point(812, 318)
        cmbSearchTherapist.Name = "cmbSearchTherapist"
        cmbSearchTherapist.Size = New Size(228, 23)
        cmbSearchTherapist.TabIndex = 5
        ' 
        ' btnAddTherapist
        ' 
        btnAddTherapist.Location = New Point(680, 211)
        btnAddTherapist.Name = "btnAddTherapist"
        btnAddTherapist.Size = New Size(138, 36)
        btnAddTherapist.TabIndex = 3
        btnAddTherapist.Text = "Add Therapist"
        btnAddTherapist.UseVisualStyleBackColor = True
        ' 
        ' cmbStatus
        ' 
        cmbStatus.FormattingEnabled = True
        cmbStatus.Location = New Point(812, 172)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New Size(228, 23)
        cmbStatus.TabIndex = 2
        ' 
        ' txtTname
        ' 
        txtTname.Location = New Point(812, 106)
        txtTname.Name = "txtTname"
        txtTname.Size = New Size(228, 23)
        txtTname.TabIndex = 2
        ' 
        ' cmbGender
        ' 
        cmbGender.FormattingEnabled = True
        cmbGender.Location = New Point(812, 138)
        cmbGender.Name = "cmbGender"
        cmbGender.Size = New Size(228, 23)
        cmbGender.TabIndex = 2
        ' 
        ' Therapist
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1257, 821)
        Controls.Add(btnDeleteTherapist)
        Controls.Add(cmbSearchTherapist)
        Controls.Add(btnAddTherapist)
        Controls.Add(btnSearch)
        Controls.Add(cmbTherapist)
        Controls.Add(dgvTherapist)
        Controls.Add(cmbStatus)
        Controls.Add(lblStatus)
        Controls.Add(cmbGender)
        Controls.Add(txtTname)
        Name = "Therapist"
        Text = "Therapist"
        CType(dgvTherapist, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents dgvTherapist As DataGridView
    Friend WithEvents cmbTherapist As ComboBox
    Friend WithEvents lblStatusTitle As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnDeleteTherapist As Button
    Friend WithEvents cmbSearchTherapist As ComboBox
    Friend WithEvents btnAddTherapist As Button
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents txtTname As TextBox
    Friend WithEvents cmbGender As ComboBox

End Class
