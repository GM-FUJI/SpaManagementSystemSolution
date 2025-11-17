<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TherapistInterface
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TherapistInterface))
        btnLogout = New Button()
        btnBookings = New Button()
        btnHistoryofCustomer = New Button()
        btnTimeIn = New Button()
        btnTimeOut = New Button()
        btnDoneSession = New Button()
        Guna2AnimateWindow1 = New Guna.UI2.WinForms.Guna2AnimateWindow(components)
        GroupBox1 = New GroupBox()
        Label1 = New Label()
        GroupBox2 = New GroupBox()
        Label3 = New Label()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        lblTherapist = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        GroupBox3 = New GroupBox()
        lblEarnings = New Label()
        Label6 = New Label()
        GroupBox4 = New GroupBox()
        lblPointsEarn = New Label()
        Label7 = New Label()
        Label8 = New Label()
        dgvList = New DataGridView()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        GroupBox4.SuspendLayout()
        CType(dgvList, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.MediumOrchid
        btnLogout.Location = New Point(12, 510)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(110, 35)
        btnLogout.TabIndex = 3
        btnLogout.Text = "Log Out "
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' btnBookings
        ' 
        btnBookings.BackColor = Color.MediumOrchid
        btnBookings.Location = New Point(12, 157)
        btnBookings.Name = "btnBookings"
        btnBookings.Size = New Size(111, 38)
        btnBookings.TabIndex = 5
        btnBookings.Text = "Booking"
        btnBookings.UseVisualStyleBackColor = False
        ' 
        ' btnHistoryofCustomer
        ' 
        btnHistoryofCustomer.BackColor = Color.MediumOrchid
        btnHistoryofCustomer.Location = New Point(13, 220)
        btnHistoryofCustomer.Name = "btnHistoryofCustomer"
        btnHistoryofCustomer.Size = New Size(110, 36)
        btnHistoryofCustomer.TabIndex = 6
        btnHistoryofCustomer.Text = "History"
        btnHistoryofCustomer.UseVisualStyleBackColor = False
        ' 
        ' btnTimeIn
        ' 
        btnTimeIn.Location = New Point(37, 65)
        btnTimeIn.Name = "btnTimeIn"
        btnTimeIn.Size = New Size(142, 40)
        btnTimeIn.TabIndex = 7
        btnTimeIn.Text = "Time in"
        btnTimeIn.UseVisualStyleBackColor = True
        ' 
        ' btnTimeOut
        ' 
        btnTimeOut.Location = New Point(37, 120)
        btnTimeOut.Name = "btnTimeOut"
        btnTimeOut.Size = New Size(142, 40)
        btnTimeOut.TabIndex = 8
        btnTimeOut.Text = "Time Out"
        btnTimeOut.UseVisualStyleBackColor = True
        ' 
        ' btnDoneSession
        ' 
        btnDoneSession.Location = New Point(34, 87)
        btnDoneSession.Name = "btnDoneSession"
        btnDoneSession.Size = New Size(144, 39)
        btnDoneSession.TabIndex = 9
        btnDoneSession.Text = "Done Session"
        btnDoneSession.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(btnTimeIn)
        GroupBox1.Controls.Add(btnTimeOut)
        GroupBox1.Location = New Point(180, 90)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(211, 202)
        GroupBox1.TabIndex = 10
        GroupBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(43, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(130, 30)
        Label1.TabIndex = 11
        Label1.Text = "Attendance"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(btnDoneSession)
        GroupBox2.Location = New Point(421, 90)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(211, 202)
        GroupBox2.TabIndex = 12
        GroupBox2.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(67, 65)
        Label3.Name = "Label3"
        Label3.Size = New Size(73, 18)
        Label3.TabIndex = 12
        Label3.Text = "Click Here!"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Sitka Text", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(29, 19)
        Label2.Name = "Label2"
        Label2.Size = New Size(162, 30)
        Label2.TabIndex = 11
        Label2.Text = "Done Session?"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(31, 27)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(74, 69)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 13
        PictureBox1.TabStop = False
        ' 
        ' lblTherapist
        ' 
        lblTherapist.AutoSize = True
        lblTherapist.Font = New Font("Sitka Text", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTherapist.Location = New Point(43, 113)
        lblTherapist.Name = "lblTherapist"
        lblTherapist.Size = New Size(52, 19)
        lblTherapist.TabIndex = 14
        lblTherapist.Text = "Label4"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Yu Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(167, 9)
        Label4.Name = "Label4"
        Label4.Size = New Size(123, 27)
        Label4.TabIndex = 18
        Label4.Text = "WELCOME"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(180, 36)
        Label5.Name = "Label5"
        Label5.Size = New Size(368, 25)
        Label5.TabIndex = 19
        Label5.Text = "To your salon performance  at a glance "
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.MediumOrchid
        Panel1.Location = New Point(146, -3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(15, 606)
        Panel1.TabIndex = 20
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.MediumOrchid
        Panel2.Location = New Point(161, 64)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(866, 10)
        Panel2.TabIndex = 21
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(lblEarnings)
        GroupBox3.Controls.Add(Label6)
        GroupBox3.Location = New Point(676, 80)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(197, 99)
        GroupBox3.TabIndex = 22
        GroupBox3.TabStop = False
        GroupBox3.Text = "GroupBox3"
        ' 
        ' lblEarnings
        ' 
        lblEarnings.AutoSize = True
        lblEarnings.Location = New Point(15, 55)
        lblEarnings.Name = "lblEarnings"
        lblEarnings.Size = New Size(77, 15)
        lblEarnings.TabIndex = 1
        lblEarnings.Text = "labelEarnings"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Sitka Text", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(15, 19)
        Label6.Name = "Label6"
        Label6.Size = New Size(98, 19)
        Label6.TabIndex = 0
        Label6.Text = "Daily Earnings"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(lblPointsEarn)
        GroupBox4.Controls.Add(Label7)
        GroupBox4.Location = New Point(676, 193)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(197, 99)
        GroupBox4.TabIndex = 23
        GroupBox4.TabStop = False
        GroupBox4.Text = "GroupBox4"
        ' 
        ' lblPointsEarn
        ' 
        lblPointsEarn.AutoSize = True
        lblPointsEarn.Location = New Point(15, 68)
        lblPointsEarn.Name = "lblPointsEarn"
        lblPointsEarn.Size = New Size(32, 15)
        lblPointsEarn.TabIndex = 2
        lblPointsEarn.Text = "label"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Sitka Text", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(15, 27)
        Label7.Name = "Label7"
        Label7.Size = New Size(134, 19)
        Label7.TabIndex = 1
        Label7.Text = "Total Points Earned:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Sitka Text", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(180, 319)
        Label8.Name = "Label8"
        Label8.Size = New Size(122, 23)
        Label8.TabIndex = 24
        Label8.Text = "Customer List"
        ' 
        ' dgvList
        ' 
        dgvList.BackgroundColor = Color.White
        dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvList.Location = New Point(180, 349)
        dgvList.Name = "dgvList"
        dgvList.Size = New Size(693, 234)
        dgvList.TabIndex = 25
        ' 
        ' TherapistInterface
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(890, 604)
        Controls.Add(dgvList)
        Controls.Add(Label8)
        Controls.Add(GroupBox4)
        Controls.Add(GroupBox3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(lblTherapist)
        Controls.Add(PictureBox1)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(btnHistoryofCustomer)
        Controls.Add(btnBookings)
        Controls.Add(btnLogout)
        Name = "TherapistInterface"
        StartPosition = FormStartPosition.CenterScreen
        Text = "TherapistForm"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        CType(dgvList, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnBookings As Button
    Friend WithEvents btnHistoryofCustomer As Button
    Friend WithEvents btnTimeIn As Button
    Friend WithEvents btnTimeOut As Button
    Friend WithEvents btnDoneSession As Button
    Friend WithEvents Guna2AnimateWindow1 As Guna.UI2.WinForms.Guna2AnimateWindow
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTherapist As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblEarnings As Label
    Friend WithEvents lblPointsEarn As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dgvList As DataGridView
End Class
