<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facilities
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
        GroupBoxTherapist = New GroupBox()
        lblTname = New Label()
        lblGender = New Label()
        cmbGender = New ComboBox()
        txtTname = New TextBox()
        lblStatus = New Label()
        cmbStatus = New ComboBox()
        btnAddTherapist = New Button()
        Label2 = New Label()
        GroupBoxPackage = New GroupBox()
        lblPName = New Label()
        txtPName = New TextBox()
        lblPrice = New Label()
        txtPrice = New TextBox()
        btnAddPackage = New Button()
        lblSearchT = New Label()
        cmbSearchTherapist = New ComboBox()
        btnDeleteTherapist = New Button()
        Label3 = New Label()
        cmbSearchPackage = New ComboBox()
        btnDeletePackage = New Button()
        GroupBoxTherapist.SuspendLayout()
        GroupBoxPackage.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(142, 21)
        Label1.TabIndex = 0
        Label1.Text = "Therapist Section"
        ' 
        ' GroupBoxTherapist
        ' 
        GroupBoxTherapist.Controls.Add(btnDeleteTherapist)
        GroupBoxTherapist.Controls.Add(cmbSearchTherapist)
        GroupBoxTherapist.Controls.Add(lblSearchT)
        GroupBoxTherapist.Controls.Add(btnAddTherapist)
        GroupBoxTherapist.Controls.Add(cmbStatus)
        GroupBoxTherapist.Controls.Add(lblStatus)
        GroupBoxTherapist.Controls.Add(txtTname)
        GroupBoxTherapist.Controls.Add(cmbGender)
        GroupBoxTherapist.Controls.Add(lblGender)
        GroupBoxTherapist.Controls.Add(lblTname)
        GroupBoxTherapist.Location = New Point(12, 53)
        GroupBoxTherapist.Name = "GroupBoxTherapist"
        GroupBoxTherapist.Size = New Size(527, 156)
        GroupBoxTherapist.TabIndex = 1
        GroupBoxTherapist.TabStop = False
        GroupBoxTherapist.Text = "Therapist"
        ' 
        ' lblTname
        ' 
        lblTname.AutoSize = True
        lblTname.Location = New Point(6, 27)
        lblTname.Name = "lblTname"
        lblTname.Size = New Size(93, 15)
        lblTname.TabIndex = 2
        lblTname.Text = "Therapist Name:"
        ' 
        ' lblGender
        ' 
        lblGender.AutoSize = True
        lblGender.Location = New Point(6, 60)
        lblGender.Name = "lblGender"
        lblGender.Size = New Size(48, 15)
        lblGender.TabIndex = 2
        lblGender.Text = "Gender:"
        ' 
        ' cmbGender
        ' 
        cmbGender.FormattingEnabled = True
        cmbGender.Location = New Point(60, 60)
        cmbGender.Name = "cmbGender"
        cmbGender.Size = New Size(86, 23)
        cmbGender.TabIndex = 2
        ' 
        ' txtTname
        ' 
        txtTname.Location = New Point(105, 27)
        txtTname.Name = "txtTname"
        txtTname.Size = New Size(100, 23)
        txtTname.TabIndex = 2
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(6, 89)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(39, 15)
        lblStatus.TabIndex = 2
        lblStatus.Text = "Status"
        ' 
        ' cmbStatus
        ' 
        cmbStatus.FormattingEnabled = True
        cmbStatus.Location = New Point(60, 89)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New Size(121, 23)
        cmbStatus.TabIndex = 2
        ' 
        ' btnAddTherapist
        ' 
        btnAddTherapist.Location = New Point(18, 118)
        btnAddTherapist.Name = "btnAddTherapist"
        btnAddTherapist.Size = New Size(104, 23)
        btnAddTherapist.TabIndex = 3
        btnAddTherapist.Text = "Add Therapist"
        btnAddTherapist.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(18, 230)
        Label2.Name = "Label2"
        Label2.Size = New Size(135, 21)
        Label2.TabIndex = 2
        Label2.Text = "Package Section"
        ' 
        ' GroupBoxPackage
        ' 
        GroupBoxPackage.Controls.Add(btnDeletePackage)
        GroupBoxPackage.Controls.Add(cmbSearchPackage)
        GroupBoxPackage.Controls.Add(Label3)
        GroupBoxPackage.Controls.Add(btnAddPackage)
        GroupBoxPackage.Controls.Add(txtPrice)
        GroupBoxPackage.Controls.Add(lblPrice)
        GroupBoxPackage.Controls.Add(txtPName)
        GroupBoxPackage.Controls.Add(lblPName)
        GroupBoxPackage.Location = New Point(12, 275)
        GroupBoxPackage.Name = "GroupBoxPackage"
        GroupBoxPackage.Size = New Size(537, 164)
        GroupBoxPackage.TabIndex = 3
        GroupBoxPackage.TabStop = False
        GroupBoxPackage.Text = "Package"
        ' 
        ' lblPName
        ' 
        lblPName.AutoSize = True
        lblPName.Location = New Point(13, 29)
        lblPName.Name = "lblPName"
        lblPName.Size = New Size(89, 15)
        lblPName.TabIndex = 4
        lblPName.Text = "Package Name:"
        ' 
        ' txtPName
        ' 
        txtPName.Location = New Point(105, 29)
        txtPName.Name = "txtPName"
        txtPName.Size = New Size(100, 23)
        txtPName.TabIndex = 5
        ' 
        ' lblPrice
        ' 
        lblPrice.AutoSize = True
        lblPrice.Location = New Point(18, 70)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(36, 15)
        lblPrice.TabIndex = 4
        lblPrice.Text = "Price:"
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(60, 67)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(100, 23)
        txtPrice.TabIndex = 6
        ' 
        ' btnAddPackage
        ' 
        btnAddPackage.Location = New Point(27, 117)
        btnAddPackage.Name = "btnAddPackage"
        btnAddPackage.Size = New Size(95, 23)
        btnAddPackage.TabIndex = 7
        btnAddPackage.Text = "Add Package"
        btnAddPackage.UseVisualStyleBackColor = True
        ' 
        ' lblSearchT
        ' 
        lblSearchT.AutoSize = True
        lblSearchT.Location = New Point(274, 27)
        lblSearchT.Name = "lblSearchT"
        lblSearchT.Size = New Size(96, 15)
        lblSearchT.TabIndex = 4
        lblSearchT.Text = "Search Therapist:"
        ' 
        ' cmbSearchTherapist
        ' 
        cmbSearchTherapist.FormattingEnabled = True
        cmbSearchTherapist.Location = New Point(392, 24)
        cmbSearchTherapist.Name = "cmbSearchTherapist"
        cmbSearchTherapist.Size = New Size(84, 23)
        cmbSearchTherapist.TabIndex = 5
        ' 
        ' btnDeleteTherapist
        ' 
        btnDeleteTherapist.Location = New Point(392, 60)
        btnDeleteTherapist.Name = "btnDeleteTherapist"
        btnDeleteTherapist.Size = New Size(112, 23)
        btnDeleteTherapist.TabIndex = 6
        btnDeleteTherapist.Text = "Delete Therapist"
        btnDeleteTherapist.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(274, 29)
        Label3.Name = "Label3"
        Label3.Size = New Size(92, 15)
        Label3.TabIndex = 8
        Label3.Text = "Search Package:"
        ' 
        ' cmbSearchPackage
        ' 
        cmbSearchPackage.FormattingEnabled = True
        cmbSearchPackage.Location = New Point(392, 29)
        cmbSearchPackage.Name = "cmbSearchPackage"
        cmbSearchPackage.Size = New Size(84, 23)
        cmbSearchPackage.TabIndex = 9
        ' 
        ' btnDeletePackage
        ' 
        btnDeletePackage.Location = New Point(392, 67)
        btnDeletePackage.Name = "btnDeletePackage"
        btnDeletePackage.Size = New Size(112, 23)
        btnDeletePackage.TabIndex = 10
        btnDeletePackage.Text = "Delete Package"
        btnDeletePackage.UseVisualStyleBackColor = True
        ' 
        ' Facilities
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 511)
        Controls.Add(GroupBoxPackage)
        Controls.Add(Label2)
        Controls.Add(GroupBoxTherapist)
        Controls.Add(Label1)
        Name = "Facilities"
        Text = "Facilities"
        GroupBoxTherapist.ResumeLayout(False)
        GroupBoxTherapist.PerformLayout()
        GroupBoxPackage.ResumeLayout(False)
        GroupBoxPackage.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBoxTherapist As GroupBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtTname As TextBox
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents lblGender As Label
    Friend WithEvents lblTname As Label
    Friend WithEvents btnAddTherapist As Button
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBoxPackage As GroupBox
    Friend WithEvents lblPName As Label
    Friend WithEvents btnAddPackage As Button
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents txtPName As TextBox
    Friend WithEvents btnDeleteTherapist As Button
    Friend WithEvents cmbSearchTherapist As ComboBox
    Friend WithEvents lblSearchT As Label
    Friend WithEvents btnDeletePackage As Button
    Friend WithEvents cmbSearchPackage As ComboBox
    Friend WithEvents Label3 As Label
End Class
