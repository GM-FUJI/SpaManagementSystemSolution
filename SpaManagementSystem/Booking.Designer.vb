<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Booking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Booking))
        Title = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Time = New Label()
        txtLastName = New TextBox()
        txtBlock = New TextBox()
        txtStreet = New TextBox()
        txtCity = New TextBox()
        txtPhone = New TextBox()
        cmbTherapist = New ComboBox()
        cmbPackage = New ComboBox()
        txtPrice = New TextBox()
        Label11 = New Label()
        dtpBookingDate = New DateTimePicker()
        btnSave = New Button()
        btnClear = New Button()
        Label12 = New Label()
        Label13 = New Label()
        txtFirstName = New TextBox()
        txtMiddleInitial = New TextBox()
        Label9 = New Label()
        cmbGender = New ComboBox()
        Label10 = New Label()
        Label14 = New Label()
        Label15 = New Label()
        Label16 = New Label()
        Label20 = New Label()
        Label21 = New Label()
        flpTimeSlots = New FlowLayoutPanel()
        Label18 = New Label()
        Label17 = New Label()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Title
        ' 
        Title.AutoSize = True
        Title.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Title.Location = New Point(303, 199)
        Title.Name = "Title"
        Title.Size = New Size(178, 22)
        Title.TabIndex = 0
        Title.Text = "Spa Booking Form"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(20, 370)
        Label2.Name = "Label2"
        Label2.Size = New Size(63, 15)
        Label2.TabIndex = 1
        Label2.Text = "Last Name"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(20, 449)
        Label1.Name = "Label1"
        Label1.Size = New Size(36, 15)
        Label1.TabIndex = 2
        Label1.Text = "Block"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(152, 449)
        Label3.Name = "Label3"
        Label3.Size = New Size(37, 15)
        Label3.TabIndex = 3
        Label3.Text = "Street"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(284, 449)
        Label4.Name = "Label4"
        Label4.Size = New Size(28, 15)
        Label4.TabIndex = 4
        Label4.Text = "City"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(20, 505)
        Label5.Name = "Label5"
        Label5.Size = New Size(86, 15)
        Label5.TabIndex = 5
        Label5.Text = "Phone number"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(472, 394)
        Label6.Name = "Label6"
        Label6.Size = New Size(92, 15)
        Label6.TabIndex = 6
        Label6.Text = "Select Therapist:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(472, 464)
        Label7.Name = "Label7"
        Label7.Size = New Size(88, 15)
        Label7.TabIndex = 7
        Label7.Text = "Select Package:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(718, 496)
        Label8.Name = "Label8"
        Label8.Size = New Size(33, 15)
        Label8.TabIndex = 8
        Label8.Text = "Price"
        ' 
        ' Time
        ' 
        Time.AutoSize = True
        Time.Location = New Point(12, 579)
        Time.Name = "Time"
        Time.Size = New Size(80, 15)
        Time.TabIndex = 9
        Time.Text = "Booking Time"
        ' 
        ' txtLastName
        ' 
        txtLastName.Location = New Point(20, 344)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(113, 23)
        txtLastName.TabIndex = 10
        ' 
        ' txtBlock
        ' 
        txtBlock.Location = New Point(20, 423)
        txtBlock.Name = "txtBlock"
        txtBlock.Size = New Size(113, 23)
        txtBlock.TabIndex = 11
        ' 
        ' txtStreet
        ' 
        txtStreet.Location = New Point(152, 423)
        txtStreet.Name = "txtStreet"
        txtStreet.Size = New Size(116, 23)
        txtStreet.TabIndex = 12
        ' 
        ' txtCity
        ' 
        txtCity.Location = New Point(285, 423)
        txtCity.Name = "txtCity"
        txtCity.Size = New Size(116, 23)
        txtCity.TabIndex = 13
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(20, 479)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(113, 23)
        txtPhone.TabIndex = 14
        ' 
        ' cmbTherapist
        ' 
        cmbTherapist.FormattingEnabled = True
        cmbTherapist.Location = New Point(570, 362)
        cmbTherapist.Name = "cmbTherapist"
        cmbTherapist.Size = New Size(121, 23)
        cmbTherapist.TabIndex = 15
        ' 
        ' cmbPackage
        ' 
        cmbPackage.FormattingEnabled = True
        cmbPackage.Location = New Point(582, 461)
        cmbPackage.Name = "cmbPackage"
        cmbPackage.Size = New Size(121, 23)
        cmbPackage.TabIndex = 16
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(718, 461)
        txtPrice.Name = "txtPrice"
        txtPrice.ReadOnly = True
        txtPrice.Size = New Size(100, 23)
        txtPrice.TabIndex = 17
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(472, 579)
        Label11.Name = "Label11"
        Label11.Size = New Size(78, 15)
        Label11.TabIndex = 20
        Label11.Text = "Booking Date"
        ' 
        ' dtpBookingDate
        ' 
        dtpBookingDate.Location = New Point(472, 606)
        dtpBookingDate.Name = "dtpBookingDate"
        dtpBookingDate.Size = New Size(200, 23)
        dtpBookingDate.TabIndex = 21
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(12, 810)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(113, 23)
        btnSave.TabIndex = 22
        btnSave.Text = "Save Booking"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(152, 810)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 23)
        btnClear.TabIndex = 23
        btnClear.Text = "Clear Form"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(152, 370)
        Label12.Name = "Label12"
        Label12.Size = New Size(61, 15)
        Label12.TabIndex = 24
        Label12.Text = "FirstName"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(285, 370)
        Label13.Name = "Label13"
        Label13.Size = New Size(76, 15)
        Label13.TabIndex = 25
        Label13.Text = "Middle Initial"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(152, 344)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(116, 23)
        txtFirstName.TabIndex = 26
        ' 
        ' txtMiddleInitial
        ' 
        txtMiddleInitial.Location = New Point(284, 344)
        txtMiddleInitial.Name = "txtMiddleInitial"
        txtMiddleInitial.Size = New Size(116, 23)
        txtMiddleInitial.TabIndex = 27
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(464, 333)
        Label9.Name = "Label9"
        Label9.Size = New Size(82, 15)
        Label9.TabIndex = 29
        Label9.Text = "Select Gender:"
        ' 
        ' cmbGender
        ' 
        cmbGender.FormattingEnabled = True
        cmbGender.Location = New Point(570, 333)
        cmbGender.Name = "cmbGender"
        cmbGender.Size = New Size(121, 23)
        cmbGender.TabIndex = 30
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(172, 236)
        Label10.Name = "Label10"
        Label10.Size = New Size(452, 21)
        Label10.TabIndex = 31
        Label10.Text = "Please fill out this form completely to book your spa reservation"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(20, 284)
        Label14.Name = "Label14"
        Label14.Size = New Size(155, 21)
        Label14.TabIndex = 32
        Label14.Text = "Personal Information"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(20, 314)
        Label15.Name = "Label15"
        Label15.Size = New Size(43, 17)
        Label15.TabIndex = 33
        Label15.Text = "Name"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(20, 394)
        Label16.Name = "Label16"
        Label16.Size = New Size(56, 17)
        Label16.TabIndex = 34
        Label16.Text = "Address"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label20.Location = New Point(12, 520)
        Label20.Name = "Label20"
        Label20.Size = New Size(143, 21)
        Label20.TabIndex = 38
        Label20.Text = "Reservation Details"
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label21.Location = New Point(12, 550)
        Label21.Name = "Label21"
        Label21.Size = New Size(152, 17)
        Label21.TabIndex = 39
        Label21.Text = "Preferred Date and Time"
        ' 
        ' flpTimeSlots
        ' 
        flpTimeSlots.AutoScroll = True
        flpTimeSlots.Location = New Point(12, 606)
        flpTimeSlots.Name = "flpTimeSlots"
        flpTimeSlots.Size = New Size(342, 188)
        flpTimeSlots.TabIndex = 40
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(464, 296)
        Label18.Name = "Label18"
        Label18.Size = New Size(74, 21)
        Label18.TabIndex = 41
        Label18.Text = "Therapist"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(472, 423)
        Label17.Name = "Label17"
        Label17.Size = New Size(66, 21)
        Label17.TabIndex = 42
        Label17.Text = "Package"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(-16, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(880, 184)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 43
        PictureBox1.TabStop = False
        ' 
        ' Booking
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(852, 845)
        Controls.Add(PictureBox1)
        Controls.Add(Label17)
        Controls.Add(Label18)
        Controls.Add(flpTimeSlots)
        Controls.Add(Label21)
        Controls.Add(Label20)
        Controls.Add(Label16)
        Controls.Add(Label15)
        Controls.Add(Label14)
        Controls.Add(Label10)
        Controls.Add(cmbGender)
        Controls.Add(Label9)
        Controls.Add(txtMiddleInitial)
        Controls.Add(txtFirstName)
        Controls.Add(Label13)
        Controls.Add(Label12)
        Controls.Add(btnClear)
        Controls.Add(btnSave)
        Controls.Add(dtpBookingDate)
        Controls.Add(Label11)
        Controls.Add(txtPrice)
        Controls.Add(cmbPackage)
        Controls.Add(cmbTherapist)
        Controls.Add(txtPhone)
        Controls.Add(txtCity)
        Controls.Add(txtStreet)
        Controls.Add(txtBlock)
        Controls.Add(txtLastName)
        Controls.Add(Time)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(Label2)
        Controls.Add(Title)
        Name = "Booking"
        Text = "Booking"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Title As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Time As System.Windows.Forms.Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtBlock As TextBox
    Friend WithEvents txtStreet As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents cmbTherapist As ComboBox
    Friend WithEvents cmbPackage As ComboBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpBookingDate As DateTimePicker
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtMiddleInitial As TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents flpTimeSlots As FlowLayoutPanel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
