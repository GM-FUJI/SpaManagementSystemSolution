<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Receipt
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
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        Label15 = New Label()
        Label16 = New Label()
        Label17 = New Label()
        Label18 = New Label()
        Label19 = New Label()
        Label20 = New Label()
        Label21 = New Label()
        Label22 = New Label()
        Label23 = New Label()
        lblClientName = New Label()
        lblReceiptNo = New Label()
        lblDate = New Label()
        lblService = New Label()
        lblPrice = New Label()
        lblSubtotal = New Label()
        lblDiscount = New Label()
        lblTax = New Label()
        lblTotal = New Label()
        dgvPackages = New DataGridView()
        CType(dgvPackages, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 62)
        Label1.Name = "Label1"
        Label1.Size = New Size(111, 15)
        Label1.TabIndex = 0
        Label1.Text = " Your Company Inc."
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 90)
        Label2.Name = "Label2"
        Label2.Size = New Size(99, 15)
        Label2.TabIndex = 1
        Label2.Text = "123 Company St, "
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 119)
        Label3.Name = "Label3"
        Label3.Size = New Size(141, 15)
        Label3.TabIndex = 2
        Label3.Text = "Company Town, ST 12345"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Sitka Text", 21.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(345, 139)
        Label4.Name = "Label4"
        Label4.Size = New Size(306, 42)
        Label4.TabIndex = 3
        Label4.Text = "MASSAGE THERAPY"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Sitka Text", 21.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(496, 181)
        Label5.Name = "Label5"
        Label5.Size = New Size(144, 42)
        Label5.TabIndex = 4
        Label5.Text = "RECEIPT"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(12, 248)
        Label6.Name = "Label6"
        Label6.Size = New Size(60, 15)
        Label6.TabIndex = 5
        Label6.Text = " Billed To:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(13, 294)
        Label7.Name = "Label7"
        Label7.Size = New Size(59, 15)
        Label7.TabIndex = 6
        Label7.Text = "Receipt #:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(13, 320)
        Label8.Name = "Label8"
        Label8.Size = New Size(76, 15)
        Label8.TabIndex = 7
        Label8.Text = "Receipt Date:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(12, 367)
        Label10.Name = "Label10"
        Label10.Size = New Size(101, 15)
        Label10.TabIndex = 9
        Label10.Text = "Description Servie"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(331, 367)
        Label11.Name = "Label11"
        Label11.Size = New Size(33, 15)
        Label11.TabIndex = 10
        Label11.Text = "Price"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(-8, 380)
        Label13.Name = "Label13"
        Label13.Size = New Size(1007, 15)
        Label13.TabIndex = 12
        Label13.Text = "________________________________________________________________________________________________________________________________________________________________________________________________________"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(-146, 555)
        Label14.Name = "Label14"
        Label14.Size = New Size(1007, 15)
        Label14.TabIndex = 13
        Label14.Text = "________________________________________________________________________________________________________________________________________________________________________________________________________"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(12, 582)
        Label15.Name = "Label15"
        Label15.Size = New Size(57, 15)
        Label15.TabIndex = 14
        Label15.Text = " Subtotal:"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(13, 607)
        Label16.Name = "Label16"
        Label16.Size = New Size(57, 15)
        Label16.TabIndex = 15
        Label16.Text = "Discount:"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(17, 632)
        Label17.Name = "Label17"
        Label17.Size = New Size(27, 15)
        Label17.TabIndex = 16
        Label17.Text = "Tax:"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(-135, 666)
        Label18.Name = "Label18"
        Label18.Size = New Size(1007, 15)
        Label18.TabIndex = 17
        Label18.Text = "________________________________________________________________________________________________________________________________________________________________________________________________________"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(521, 729)
        Label19.Name = "Label19"
        Label19.Size = New Size(42, 15)
        Label19.TabIndex = 18
        Label19.Text = "TOTAL:"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.Location = New Point(17, 696)
        Label20.Name = "Label20"
        Label20.Size = New Size(40, 15)
        Label20.TabIndex = 19
        Label20.Text = "Notes"
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Location = New Point(17, 711)
        Label21.Name = "Label21"
        Label21.Size = New Size(161, 15)
        Label21.TabIndex = 20
        Label21.Text = "Thank you for your purchase!"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Location = New Point(17, 739)
        Label22.Name = "Label22"
        Label22.Size = New Size(166, 15)
        Label22.TabIndex = 21
        Label22.Text = "All sales are final after 30 days."
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Location = New Point(17, 765)
        Label23.Name = "Label23"
        Label23.Size = New Size(241, 15)
        Label23.TabIndex = 22
        Label23.Text = "For support, contact support@example.com"
        ' 
        ' lblClientName
        ' 
        lblClientName.AutoSize = True
        lblClientName.Location = New Point(96, 248)
        lblClientName.Name = "lblClientName"
        lblClientName.Size = New Size(0, 15)
        lblClientName.TabIndex = 23
        ' 
        ' lblReceiptNo
        ' 
        lblReceiptNo.AutoSize = True
        lblReceiptNo.Location = New Point(78, 294)
        lblReceiptNo.Name = "lblReceiptNo"
        lblReceiptNo.Size = New Size(0, 15)
        lblReceiptNo.TabIndex = 24
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Location = New Point(96, 320)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(0, 15)
        lblDate.TabIndex = 25
        ' 
        ' lblService
        ' 
        lblService.AutoSize = True
        lblService.Location = New Point(17, 414)
        lblService.Name = "lblService"
        lblService.Size = New Size(0, 15)
        lblService.TabIndex = 26
        ' 
        ' lblPrice
        ' 
        lblPrice.AutoSize = True
        lblPrice.Location = New Point(331, 414)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(0, 15)
        lblPrice.TabIndex = 27
        ' 
        ' lblSubtotal
        ' 
        lblSubtotal.AutoSize = True
        lblSubtotal.Location = New Point(82, 582)
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Size = New Size(0, 15)
        lblSubtotal.TabIndex = 28
        ' 
        ' lblDiscount
        ' 
        lblDiscount.AutoSize = True
        lblDiscount.Location = New Point(76, 607)
        lblDiscount.Name = "lblDiscount"
        lblDiscount.Size = New Size(0, 15)
        lblDiscount.TabIndex = 29
        ' 
        ' lblTax
        ' 
        lblTax.AutoSize = True
        lblTax.Location = New Point(78, 632)
        lblTax.Name = "lblTax"
        lblTax.Size = New Size(0, 15)
        lblTax.TabIndex = 30
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(579, 729)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(0, 15)
        lblTotal.TabIndex = 31
        ' 
        ' dgvPackages
        ' 
        dgvPackages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPackages.Location = New Point(13, 402)
        dgvPackages.Name = "dgvPackages"
        dgvPackages.Size = New Size(240, 150)
        dgvPackages.TabIndex = 32
        ' 
        ' Receipt
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(675, 814)
        Controls.Add(dgvPackages)
        Controls.Add(lblTotal)
        Controls.Add(lblTax)
        Controls.Add(lblDiscount)
        Controls.Add(lblSubtotal)
        Controls.Add(lblPrice)
        Controls.Add(lblService)
        Controls.Add(lblDate)
        Controls.Add(lblReceiptNo)
        Controls.Add(lblClientName)
        Controls.Add(Label23)
        Controls.Add(Label22)
        Controls.Add(Label21)
        Controls.Add(Label20)
        Controls.Add(Label19)
        Controls.Add(Label18)
        Controls.Add(Label17)
        Controls.Add(Label16)
        Controls.Add(Label15)
        Controls.Add(Label14)
        Controls.Add(Label13)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Receipt"
        Text = "Receipt"
        CType(dgvPackages, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lblClientName As Label
    Friend WithEvents lblReceiptNo As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblService As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents lblDiscount As Label
    Friend WithEvents lblTax As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvPackages As DataGridView
End Class
