<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Package
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Package))
        dgvPackages = New DataGridView()
        btnDeletePackage = New Button()
        cmbSearchPackage = New ComboBox()
        btnAddPackage = New Button()
        txtPrice = New TextBox()
        txtPName = New TextBox()
        CType(dgvPackages, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvPackages
        ' 
        dgvPackages.BackgroundColor = Color.White
        dgvPackages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPackages.Location = New Point(46, 358)
        dgvPackages.Name = "dgvPackages"
        dgvPackages.Size = New Size(986, 420)
        dgvPackages.TabIndex = 1
        ' 
        ' btnDeletePackage
        ' 
        btnDeletePackage.Location = New Point(884, 242)
        btnDeletePackage.Name = "btnDeletePackage"
        btnDeletePackage.Size = New Size(130, 36)
        btnDeletePackage.TabIndex = 10
        btnDeletePackage.Text = "Delete Package"
        btnDeletePackage.UseVisualStyleBackColor = True
        ' 
        ' cmbSearchPackage
        ' 
        cmbSearchPackage.FormattingEnabled = True
        cmbSearchPackage.Location = New Point(846, 202)
        cmbSearchPackage.Name = "cmbSearchPackage"
        cmbSearchPackage.Size = New Size(168, 23)
        cmbSearchPackage.TabIndex = 9
        ' 
        ' btnAddPackage
        ' 
        btnAddPackage.Location = New Point(178, 261)
        btnAddPackage.Name = "btnAddPackage"
        btnAddPackage.Size = New Size(131, 33)
        btnAddPackage.TabIndex = 7
        btnAddPackage.Text = "Add Package"
        btnAddPackage.UseVisualStyleBackColor = True
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(189, 218)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(163, 23)
        txtPrice.TabIndex = 6
        ' 
        ' txtPName
        ' 
        txtPName.Location = New Point(189, 173)
        txtPName.Name = "txtPName"
        txtPName.Size = New Size(227, 23)
        txtPName.TabIndex = 5
        ' 
        ' Package
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1073, 818)
        Controls.Add(btnDeletePackage)
        Controls.Add(cmbSearchPackage)
        Controls.Add(dgvPackages)
        Controls.Add(btnAddPackage)
        Controls.Add(txtPName)
        Controls.Add(txtPrice)
        Name = "Package"
        Text = "Package"
        CType(dgvPackages, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents dgvPackages As DataGridView
    Friend WithEvents btnDeletePackage As Button
    Friend WithEvents cmbSearchPackage As ComboBox
    Friend WithEvents btnAddPackage As Button
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtPName As TextBox
End Class
