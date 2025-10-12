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
        Label1 = New Label()
        Label2 = New Label()
        cmbTherapist = New ComboBox()
        lblStatusTitle = New Label()
        lblStatus = New Label()
        btnTimeIn = New Button()
        btnTimeOut = New Button()
        Label4 = New Label()
        dgvTherapist = New DataGridView()
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
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(37, 100)
        Label2.Name = "Label2"
        Label2.Size = New Size(111, 20)
        Label2.TabIndex = 1
        Label2.Text = "Select Therapist:"
        ' 
        ' cmbTherapist
        ' 
        cmbTherapist.FormattingEnabled = True
        cmbTherapist.Location = New Point(154, 100)
        cmbTherapist.Name = "cmbTherapist"
        cmbTherapist.Size = New Size(97, 23)
        cmbTherapist.TabIndex = 2
        ' 
        ' lblStatusTitle
        ' 
        lblStatusTitle.AutoSize = True
        lblStatusTitle.Font = New Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatusTitle.Location = New Point(37, 143)
        lblStatusTitle.Name = "lblStatusTitle"
        lblStatusTitle.Size = New Size(100, 20)
        lblStatusTitle.TabIndex = 3
        lblStatusTitle.Text = "Current Status:"
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
        ' btnTimeIn
        ' 
        btnTimeIn.Location = New Point(37, 184)
        btnTimeIn.Name = "btnTimeIn"
        btnTimeIn.Size = New Size(75, 23)
        btnTimeIn.TabIndex = 5
        btnTimeIn.Text = "Time In"
        btnTimeIn.UseVisualStyleBackColor = True
        ' 
        ' btnTimeOut
        ' 
        btnTimeOut.Location = New Point(154, 184)
        btnTimeOut.Name = "btnTimeOut"
        btnTimeOut.Size = New Size(75, 23)
        btnTimeOut.TabIndex = 6
        btnTimeOut.Text = "Time Out"
        btnTimeOut.UseVisualStyleBackColor = True
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
        dgvTherapist.Location = New Point(78, 245)
        dgvTherapist.Name = "dgvTherapist"
        dgvTherapist.ReadOnly = True
        dgvTherapist.Size = New Size(613, 261)
        dgvTherapist.TabIndex = 8
        ' 
        ' Therapist
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1021, 580)
        Controls.Add(dgvTherapist)
        Controls.Add(Label4)
        Controls.Add(btnTimeOut)
        Controls.Add(btnTimeIn)
        Controls.Add(lblStatus)
        Controls.Add(lblStatusTitle)
        Controls.Add(cmbTherapist)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Therapist"
        Text = "Therapist"
        CType(dgvTherapist, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnTimeIn As Button
    Friend WithEvents btnTimeOut As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvTherapist As DataGridView
    Friend WithEvents cmbTherapist As ComboBox
    Friend WithEvents lblStatusTitle As Label
    Friend WithEvents lblStatus As Label

End Class
