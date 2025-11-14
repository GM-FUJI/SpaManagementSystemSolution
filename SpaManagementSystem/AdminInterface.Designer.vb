<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminInterface
    Inherits System.Windows.Forms.Form


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminInterface))
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        btnLogout = New Button()
        grpTax = New GroupBox()
        lblTotalTax = New Label()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        grpPackage = New GroupBox()
        lblTopPackage = New Label()
        Label2 = New Label()
        PictureBox2 = New PictureBox()
        grpTherapist = New GroupBox()
        lblTPTherapist = New Label()
        Label3 = New Label()
        PictureBox3 = New PictureBox()
        pnlWeeklyChart = New Panel()
        pnlDailyChart = New Panel()
        pnlDiscountChart = New Panel()
        grpTax.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        grpPackage.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        grpTherapist.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.ActiveCaption
        Button2.FlatStyle = FlatStyle.Popup
        Button2.Location = New Point(31, 139)
        Button2.Name = "Button2"
        Button2.Size = New Size(107, 32)
        Button2.TabIndex = 1
        Button2.Text = "Therapist"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = SystemColors.ActiveCaption
        Button3.FlatStyle = FlatStyle.Popup
        Button3.Location = New Point(31, 185)
        Button3.Name = "Button3"
        Button3.Size = New Size(107, 36)
        Button3.TabIndex = 2
        Button3.Text = "Package"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = SystemColors.ActiveCaption
        Button4.FlatStyle = FlatStyle.Popup
        Button4.Location = New Point(31, 237)
        Button4.Name = "Button4"
        Button4.Size = New Size(107, 36)
        Button4.TabIndex = 3
        Button4.Text = "History"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = SystemColors.ActiveCaption
        Button5.FlatStyle = FlatStyle.Popup
        Button5.Location = New Point(31, 294)
        Button5.Name = "Button5"
        Button5.Size = New Size(107, 31)
        Button5.TabIndex = 4
        Button5.Text = "Booking"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = SystemColors.ActiveCaption
        btnLogout.FlatStyle = FlatStyle.Popup
        btnLogout.Location = New Point(12, 768)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(107, 36)
        btnLogout.TabIndex = 7
        btnLogout.Text = "Log Out"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' grpTax
        ' 
        grpTax.Controls.Add(lblTotalTax)
        grpTax.Controls.Add(Label1)
        grpTax.Controls.Add(PictureBox1)
        grpTax.Location = New Point(227, 93)
        grpTax.Name = "grpTax"
        grpTax.Size = New Size(306, 105)
        grpTax.TabIndex = 8
        grpTax.TabStop = False
        grpTax.Text = "Tax Group"
        ' 
        ' lblTotalTax
        ' 
        lblTotalTax.AutoSize = True
        lblTotalTax.Font = New Font("Sitka Text", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalTax.Location = New Point(99, 65)
        lblTotalTax.Name = "lblTotalTax"
        lblTotalTax.Size = New Size(130, 23)
        lblTotalTax.TabIndex = 11
        lblTotalTax.Text = "Total Tax: 0.00"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Text", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(88, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(141, 23)
        Label1.TabIndex = 10
        Label1.Text = """Tax to be Paid"""
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(7, 22)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(75, 73)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' grpPackage
        ' 
        grpPackage.Controls.Add(lblTopPackage)
        grpPackage.Controls.Add(Label2)
        grpPackage.Controls.Add(PictureBox2)
        grpPackage.Location = New Point(549, 91)
        grpPackage.Name = "grpPackage"
        grpPackage.Size = New Size(276, 107)
        grpPackage.TabIndex = 10
        grpPackage.TabStop = False
        grpPackage.Text = "Package Group"
        ' 
        ' lblTopPackage
        ' 
        lblTopPackage.AutoSize = True
        lblTopPackage.Font = New Font("Sitka Text", 11.249999F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTopPackage.Location = New Point(87, 55)
        lblTopPackage.Name = "lblTopPackage"
        lblTopPackage.Size = New Size(78, 21)
        lblTopPackage.TabIndex = 11
        lblTopPackage.Text = "Packages"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Text", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(56, 16)
        Label2.Name = "Label2"
        Label2.Size = New Size(186, 23)
        Label2.TabIndex = 11
        Label2.Text = """Top Three Packages"""
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(6, 42)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(75, 73)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' grpTherapist
        ' 
        grpTherapist.Controls.Add(lblTPTherapist)
        grpTherapist.Controls.Add(Label3)
        grpTherapist.Controls.Add(PictureBox3)
        grpTherapist.Location = New Point(837, 93)
        grpTherapist.Name = "grpTherapist"
        grpTherapist.Size = New Size(305, 113)
        grpTherapist.TabIndex = 10
        grpTherapist.TabStop = False
        grpTherapist.Text = "Therapist"
        ' 
        ' lblTPTherapist
        ' 
        lblTPTherapist.AutoSize = True
        lblTPTherapist.Font = New Font("Sitka Text", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTPTherapist.Location = New Point(94, 55)
        lblTPTherapist.Name = "lblTPTherapist"
        lblTPTherapist.Size = New Size(88, 23)
        lblTPTherapist.TabIndex = 13
        lblTPTherapist.Text = "Therapist"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Text", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(6, 16)
        Label3.Name = "Label3"
        Label3.Size = New Size(243, 23)
        Label3.TabIndex = 12
        Label3.Text = """Top Performing Therapists"""
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(6, 42)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(73, 73)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 9
        PictureBox3.TabStop = False
        ' 
        ' pnlWeeklyChart
        ' 
        pnlWeeklyChart.Location = New Point(227, 212)
        pnlWeeklyChart.Name = "pnlWeeklyChart"
        pnlWeeklyChart.Size = New Size(581, 246)
        pnlWeeklyChart.TabIndex = 13
        ' 
        ' pnlDailyChart
        ' 
        pnlDailyChart.Location = New Point(227, 479)
        pnlDailyChart.Name = "pnlDailyChart"
        pnlDailyChart.Size = New Size(581, 238)
        pnlDailyChart.TabIndex = 14
        ' 
        ' pnlDiscountChart
        ' 
        pnlDiscountChart.Location = New Point(843, 215)
        pnlDiscountChart.Name = "pnlDiscountChart"
        pnlDiscountChart.Size = New Size(567, 243)
        pnlDiscountChart.TabIndex = 15
        ' 
        ' AdminInterface
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1456, 828)
        Controls.Add(pnlDiscountChart)
        Controls.Add(pnlDailyChart)
        Controls.Add(pnlWeeklyChart)
        Controls.Add(grpTherapist)
        Controls.Add(grpPackage)
        Controls.Add(grpTax)
        Controls.Add(btnLogout)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        DoubleBuffered = True
        Name = "AdminInterface"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form2"
        grpTax.ResumeLayout(False)
        grpTax.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        grpPackage.ResumeLayout(False)
        grpPackage.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        grpTherapist.ResumeLayout(False)
        grpTherapist.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents grpTax As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents grpPackage As GroupBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents grpTherapist As GroupBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalTax As Label
    Friend WithEvents lblTopPackage As Label
    Friend WithEvents lblTPTherapist As Label
    Friend WithEvents pnlWeeklyChart As Panel
    Friend WithEvents pnlDailyChart As Panel
    Friend WithEvents pnlDiscountChart As Panel
End Class
