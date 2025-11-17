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
        GroupBox1 = New GroupBox()
        lblBookingpDay = New Label()
        Label67 = New Label()
        PictureBox4 = New PictureBox()
        PictureBox5 = New PictureBox()
        PictureBox6 = New PictureBox()
        Label5 = New Label()
        Label4 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        grpTax.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        grpPackage.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        grpTherapist.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.MediumOrchid
        Button2.FlatStyle = FlatStyle.Popup
        Button2.Location = New Point(31, 204)
        Button2.Name = "Button2"
        Button2.Size = New Size(107, 32)
        Button2.TabIndex = 1
        Button2.Text = "Therapist"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.MediumOrchid
        Button3.FlatStyle = FlatStyle.Popup
        Button3.Location = New Point(31, 268)
        Button3.Name = "Button3"
        Button3.Size = New Size(107, 36)
        Button3.TabIndex = 2
        Button3.Text = "Package"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.MediumOrchid
        Button4.FlatStyle = FlatStyle.Popup
        Button4.Location = New Point(31, 327)
        Button4.Name = "Button4"
        Button4.Size = New Size(107, 36)
        Button4.TabIndex = 3
        Button4.Text = "History"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.MediumOrchid
        Button5.FlatStyle = FlatStyle.Popup
        Button5.Location = New Point(31, 405)
        Button5.Name = "Button5"
        Button5.Size = New Size(107, 35)
        Button5.TabIndex = 4
        Button5.Text = "Booking"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.MediumOrchid
        btnLogout.FlatStyle = FlatStyle.Popup
        btnLogout.Location = New Point(31, 677)
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
        grpTax.Location = New Point(171, 91)
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
        grpPackage.Location = New Point(585, 212)
        grpPackage.Name = "grpPackage"
        grpPackage.Size = New Size(394, 238)
        grpPackage.TabIndex = 10
        grpPackage.TabStop = False
        grpPackage.Text = "Package Group"
        ' 
        ' lblTopPackage
        ' 
        lblTopPackage.AutoSize = True
        lblTopPackage.Font = New Font("Sitka Text", 11.249999F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTopPackage.Location = New Point(87, 44)
        lblTopPackage.Name = "lblTopPackage"
        lblTopPackage.Size = New Size(78, 21)
        lblTopPackage.TabIndex = 11
        lblTopPackage.Text = "Packages"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Text", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(84, 18)
        Label2.Name = "Label2"
        Label2.Size = New Size(186, 23)
        Label2.TabIndex = 11
        Label2.Text = """Top Three Packages"""
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(6, 19)
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
        grpTherapist.Location = New Point(782, 91)
        grpTherapist.Name = "grpTherapist"
        grpTherapist.Size = New Size(282, 107)
        grpTherapist.TabIndex = 10
        grpTherapist.TabStop = False
        grpTherapist.Text = "Therapist"
        ' 
        ' lblTPTherapist
        ' 
        lblTPTherapist.AutoSize = True
        lblTPTherapist.Font = New Font("Sitka Text", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTPTherapist.Location = New Point(85, 44)
        lblTPTherapist.Name = "lblTPTherapist"
        lblTPTherapist.Size = New Size(88, 23)
        lblTPTherapist.TabIndex = 13
        lblTPTherapist.Text = "Therapist"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Text", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(39, 2)
        Label3.Name = "Label3"
        Label3.Size = New Size(243, 23)
        Label3.TabIndex = 12
        Label3.Text = """Top Performing Therapists"""
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(6, 28)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(73, 73)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 9
        PictureBox3.TabStop = False
        ' 
        ' pnlWeeklyChart
        ' 
        pnlWeeklyChart.AutoScroll = True
        pnlWeeklyChart.AutoSizeMode = AutoSizeMode.GrowAndShrink
        pnlWeeklyChart.Location = New Point(171, 212)
        pnlWeeklyChart.Name = "pnlWeeklyChart"
        pnlWeeklyChart.Size = New Size(392, 238)
        pnlWeeklyChart.TabIndex = 13
        ' 
        ' pnlDailyChart
        ' 
        pnlDailyChart.Location = New Point(171, 474)
        pnlDailyChart.Name = "pnlDailyChart"
        pnlDailyChart.Size = New Size(392, 239)
        pnlDailyChart.TabIndex = 14
        ' 
        ' pnlDiscountChart
        ' 
        pnlDiscountChart.Location = New Point(587, 475)
        pnlDiscountChart.Name = "pnlDiscountChart"
        pnlDiscountChart.Size = New Size(392, 238)
        pnlDiscountChart.TabIndex = 15
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lblBookingpDay)
        GroupBox1.Controls.Add(Label67)
        GroupBox1.Controls.Add(PictureBox4)
        GroupBox1.Location = New Point(494, 98)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(267, 98)
        GroupBox1.TabIndex = 12
        GroupBox1.TabStop = False
        GroupBox1.Text = "Tax Group"
        ' 
        ' lblBookingpDay
        ' 
        lblBookingpDay.AutoSize = True
        lblBookingpDay.Font = New Font("Sitka Text", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblBookingpDay.Location = New Point(97, 58)
        lblBookingpDay.Name = "lblBookingpDay"
        lblBookingpDay.Size = New Size(80, 23)
        lblBookingpDay.TabIndex = 11
        lblBookingpDay.Text = "Booking:"
        ' 
        ' Label67
        ' 
        Label67.AutoSize = True
        Label67.Font = New Font("Sitka Text", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label67.Location = New Point(88, 19)
        Label67.Name = "Label67"
        Label67.Size = New Size(141, 23)
        Label67.TabIndex = 10
        Label67.Text = "Booking Per Day"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), Image)
        PictureBox4.Location = New Point(7, 22)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(75, 73)
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.TabIndex = 9
        PictureBox4.TabStop = False
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), Image)
        PictureBox5.Location = New Point(1034, 12)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(57, 50)
        PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox5.TabIndex = 16
        PictureBox5.TabStop = False
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Image)
        PictureBox6.Location = New Point(12, 16)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(139, 124)
        PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox6.TabIndex = 19
        PictureBox6.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(195, 43)
        Label5.Name = "Label5"
        Label5.Size = New Size(368, 25)
        Label5.TabIndex = 18
        Label5.Text = "To your salon performance  at a glance "
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Yu Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(171, 16)
        Label4.Name = "Label4"
        Label4.Size = New Size(123, 27)
        Label4.TabIndex = 17
        Label4.Text = "WELCOME"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Gold
        Panel1.Location = New Point(157, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(10, 757)
        Panel1.TabIndex = 20
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.MediumOrchid
        Panel2.Location = New Point(171, 68)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(920, 17)
        Panel2.TabIndex = 21
        ' 
        ' AdminInterface
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1103, 760)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(PictureBox6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(PictureBox5)
        Controls.Add(GroupBox1)
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
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
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
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents lblBookingpDay As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
