<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceiptForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReceiptForm))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        PictureBox1 = New PictureBox()
        Label6 = New Label()
        lblFullname = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        dgvDescription = New DataGridView()
        lblTotal = New Label()
        Label17 = New Label()
        Label18 = New Label()
        Label19 = New Label()
        lblFullAdd = New Label()
        lblReceiptNo = New Label()
        lblReceiptDate = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvDescription, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(108, 15)
        Label1.TabIndex = 0
        Label1.Text = "Your Company Inc."
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 49)
        Label2.Name = "Label2"
        Label2.Size = New Size(99, 15)
        Label2.TabIndex = 1
        Label2.Text = "1234 Customer St"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 79)
        Label3.Name = "Label3"
        Label3.Size = New Size(90, 15)
        Label3.TabIndex = 2
        Label3.Text = "Company Town"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Sitka Text", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(396, 147)
        Label4.Name = "Label4"
        Label4.Size = New Size(253, 35)
        Label4.TabIndex = 3
        Label4.Text = "MASSAGE THERAPY"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Sitka Text", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(519, 182)
        Label5.Name = "Label5"
        Label5.Size = New Size(120, 35)
        Label5.TabIndex = 4
        Label5.Text = "RECEIPT"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(491, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(158, 132)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(12, 241)
        Label6.Name = "Label6"
        Label6.Size = New Size(61, 18)
        Label6.TabIndex = 6
        Label6.Text = "Billed to:"
        ' 
        ' lblFullname
        ' 
        lblFullname.AutoSize = True
        lblFullname.Font = New Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFullname.Location = New Point(12, 270)
        lblFullname.Name = "lblFullname"
        lblFullname.Size = New Size(156, 23)
        lblFullname.TabIndex = 7
        lblFullname.Text = "CUSTOMER NAME"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(14, 312)
        Label8.Name = "Label8"
        Label8.Size = New Size(59, 18)
        Label8.TabIndex = 8
        Label8.Text = "Address:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(396, 241)
        Label9.Name = "Label9"
        Label9.Size = New Size(66, 18)
        Label9.TabIndex = 9
        Label9.Text = "Receipt #:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(396, 275)
        Label10.Name = "Label10"
        Label10.Size = New Size(85, 18)
        Label10.TabIndex = 10
        Label10.Text = "Receipt Date:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(14, 367)
        Label11.Name = "Label11"
        Label11.Size = New Size(120, 15)
        Label11.TabIndex = 11
        Label11.Text = "Package Description"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(263, 367)
        Label12.Name = "Label12"
        Label12.Size = New Size(35, 15)
        Label12.TabIndex = 12
        Label12.Text = "Price"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(-16, 382)
        Label13.Name = "Label13"
        Label13.Size = New Size(797, 15)
        Label13.TabIndex = 13
        Label13.Text = "______________________________________________________________________________________________________________________________________________________________"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(-5, 652)
        Label14.Name = "Label14"
        Label14.Size = New Size(797, 15)
        Label14.TabIndex = 14
        Label14.Text = "______________________________________________________________________________________________________________________________________________________________"
        ' 
        ' dgvDescription
        ' 
        dgvDescription.BackgroundColor = Color.White
        dgvDescription.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDescription.Location = New Point(12, 400)
        dgvDescription.Name = "dgvDescription"
        dgvDescription.Size = New Size(627, 249)
        dgvDescription.TabIndex = 15
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotal.Location = New Point(474, 681)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(70, 23)
        lblTotal.TabIndex = 18
        lblTotal.Text = "TOTAL:"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(14, 726)
        Label17.Name = "Label17"
        Label17.Size = New Size(40, 15)
        Label17.TabIndex = 19
        Label17.Text = "Notes"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(12, 757)
        Label18.Name = "Label18"
        Label18.Size = New Size(344, 15)
        Label18.TabIndex = 20
        Label18.Text = "Thank you for your purchase! All sales are final after 30 days. "
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.Location = New Point(14, 783)
        Label19.Name = "Label19"
        Label19.Size = New Size(345, 15)
        Label19.TabIndex = 21
        Label19.Text = "Please retain this receipt for warranty or exchange purposes."
        ' 
        ' lblFullAdd
        ' 
        lblFullAdd.AutoSize = True
        lblFullAdd.Location = New Point(14, 340)
        lblFullAdd.Name = "lblFullAdd"
        lblFullAdd.Size = New Size(41, 15)
        lblFullAdd.TabIndex = 22
        lblFullAdd.Text = "Label7"
        ' 
        ' lblReceiptNo
        ' 
        lblReceiptNo.AutoSize = True
        lblReceiptNo.Location = New Point(474, 244)
        lblReceiptNo.Name = "lblReceiptNo"
        lblReceiptNo.Size = New Size(41, 15)
        lblReceiptNo.TabIndex = 23
        lblReceiptNo.Text = "Label7"
        ' 
        ' lblReceiptDate
        ' 
        lblReceiptDate.AutoSize = True
        lblReceiptDate.Location = New Point(487, 278)
        lblReceiptDate.Name = "lblReceiptDate"
        lblReceiptDate.Size = New Size(41, 15)
        lblReceiptDate.TabIndex = 24
        lblReceiptDate.Text = "Label7"
        ' 
        ' ReceiptForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(661, 858)
        Controls.Add(lblReceiptDate)
        Controls.Add(lblReceiptNo)
        Controls.Add(lblFullAdd)
        Controls.Add(Label19)
        Controls.Add(Label18)
        Controls.Add(Label17)
        Controls.Add(lblTotal)
        Controls.Add(dgvDescription)
        Controls.Add(Label14)
        Controls.Add(Label13)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(lblFullname)
        Controls.Add(Label6)
        Controls.Add(PictureBox1)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "ReceiptForm"
        Text = "ReceiptForm"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvDescription, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblFullname As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents dgvDescription As DataGridView
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblFullAdd As Label
    Friend WithEvents lblReceiptNo As Label
    Friend WithEvents lblReceiptDate As Label
End Class
