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
        txtBookingTime = New TextBox()
        Label9 = New Label()
        cmbGender = New ComboBox()
        SuspendLayout()
        ' 
        ' Title
        ' 
        Title.AutoSize = True
        Title.Font = New Font("Showcard Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Title.Location = New Point(313, 9)
        Title.Name = "Title"
        Title.Size = New Size(167, 18)
        Title.TabIndex = 0
        Title.Text = "Spa Booking Form"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(18, 45)
        Label2.Name = "Label2"
        Label2.Size = New Size(63, 15)
        Label2.TabIndex = 1
        Label2.Text = "Last Name"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(31, 140)
        Label1.Name = "Label1"
        Label1.Size = New Size(36, 15)
        Label1.TabIndex = 2
        Label1.Text = "Block"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(30, 173)
        Label3.Name = "Label3"
        Label3.Size = New Size(37, 15)
        Label3.TabIndex = 3
        Label3.Text = "Street"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(25, 209)
        Label4.Name = "Label4"
        Label4.Size = New Size(28, 15)
        Label4.TabIndex = 4
        Label4.Text = "City"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 235)
        Label5.Name = "Label5"
        Label5.Size = New Size(86, 15)
        Label5.TabIndex = 5
        Label5.Text = "Phone number"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(12, 317)
        Label6.Name = "Label6"
        Label6.Size = New Size(55, 15)
        Label6.TabIndex = 6
        Label6.Text = "Therapist"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(20, 360)
        Label7.Name = "Label7"
        Label7.Size = New Size(51, 15)
        Label7.TabIndex = 7
        Label7.Text = "Package"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(25, 395)
        Label8.Name = "Label8"
        Label8.Size = New Size(33, 15)
        Label8.TabIndex = 8
        Label8.Text = "Price"
        ' 
        ' Time
        ' 
        Time.AutoSize = True
        Time.Location = New Point(20, 432)
        Time.Name = "Time"
        Time.Size = New Size(80, 15)
        Time.TabIndex = 9
        Time.Text = "Booking Time"
        ' 
        ' txtLastName
        ' 
        txtLastName.Location = New Point(104, 45)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(100, 23)
        txtLastName.TabIndex = 10
        ' 
        ' txtBlock
        ' 
        txtBlock.Location = New Point(104, 141)
        txtBlock.Name = "txtBlock"
        txtBlock.Size = New Size(100, 23)
        txtBlock.TabIndex = 11
        ' 
        ' txtStreet
        ' 
        txtStreet.Location = New Point(113, 170)
        txtStreet.Name = "txtStreet"
        txtStreet.Size = New Size(100, 23)
        txtStreet.TabIndex = 12
        ' 
        ' txtCity
        ' 
        txtCity.Location = New Point(113, 201)
        txtCity.Name = "txtCity"
        txtCity.Size = New Size(100, 23)
        txtCity.TabIndex = 13
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(113, 232)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(100, 23)
        txtPhone.TabIndex = 14
        ' 
        ' cmbTherapist
        ' 
        cmbTherapist.FormattingEnabled = True
        cmbTherapist.Location = New Point(83, 309)
        cmbTherapist.Name = "cmbTherapist"
        cmbTherapist.Size = New Size(121, 23)
        cmbTherapist.TabIndex = 15
        ' 
        ' cmbPackage
        ' 
        cmbPackage.FormattingEnabled = True
        cmbPackage.Location = New Point(77, 352)
        cmbPackage.Name = "cmbPackage"
        cmbPackage.Size = New Size(121, 23)
        cmbPackage.TabIndex = 16
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(77, 392)
        txtPrice.Name = "txtPrice"
        txtPrice.ReadOnly = True
        txtPrice.Size = New Size(100, 23)
        txtPrice.TabIndex = 17
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(20, 477)
        Label11.Name = "Label11"
        Label11.Size = New Size(78, 15)
        Label11.TabIndex = 20
        Label11.Text = "Booking Date"
        ' 
        ' dtpBookingDate
        ' 
        dtpBookingDate.Location = New Point(122, 469)
        dtpBookingDate.Name = "dtpBookingDate"
        dtpBookingDate.Size = New Size(200, 23)
        dtpBookingDate.TabIndex = 21
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(18, 514)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(113, 23)
        btnSave.TabIndex = 22
        btnSave.Text = "Save Booking"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(180, 514)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 23)
        btnClear.TabIndex = 23
        btnClear.Text = "Clear Form"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(18, 80)
        Label12.Name = "Label12"
        Label12.Size = New Size(61, 15)
        Label12.TabIndex = 24
        Label12.Text = "FirstName"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(20, 113)
        Label13.Name = "Label13"
        Label13.Size = New Size(76, 15)
        Label13.TabIndex = 25
        Label13.Text = "Middle Initial"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(104, 77)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(100, 23)
        txtFirstName.TabIndex = 26
        ' 
        ' txtMiddleInitial
        ' 
        txtMiddleInitial.Location = New Point(104, 110)
        txtMiddleInitial.Name = "txtMiddleInitial"
        txtMiddleInitial.Size = New Size(100, 23)
        txtMiddleInitial.TabIndex = 27
        ' 
        ' txtBookingTime
        ' 
        txtBookingTime.Location = New Point(122, 424)
        txtBookingTime.Name = "txtBookingTime"
        txtBookingTime.Size = New Size(100, 23)
        txtBookingTime.TabIndex = 28
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(12, 277)
        Label9.Name = "Label9"
        Label9.Size = New Size(82, 15)
        Label9.TabIndex = 29
        Label9.Text = "Select Gender:"
        ' 
        ' cmbGender
        ' 
        cmbGender.FormattingEnabled = True
        cmbGender.Location = New Point(104, 274)
        cmbGender.Name = "cmbGender"
        cmbGender.Size = New Size(121, 23)
        cmbGender.TabIndex = 30
        ' 
        ' Booking
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(901, 560)
        Controls.Add(cmbGender)
        Controls.Add(Label9)
        Controls.Add(txtBookingTime)
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
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Title As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Time As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtBlock As TextBox
    Friend WithEvents txtStreet As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents cmbTherapist As ComboBox
    Friend WithEvents cmbPackage As ComboBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpBookingDate As DateTimePicker
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtMiddleInitial As TextBox
    Friend WithEvents txtBookingTime As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbGender As ComboBox
End Class
