<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        Panel1 = New Panel()
        txtUsername = New TextBox()
        PictureBox1 = New PictureBox()
        Panel2 = New Panel()
        txtPassword = New TextBox()
        PictureBox3 = New PictureBox()
        btnLogin = New Button()
        btnCancel = New Button()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(166, 104)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(156, 156)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(204, 287)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 21)
        Label1.TabIndex = 2
        Label1.Text = "Sign in"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(txtUsername)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(88, 340)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(323, 58)
        Panel1.TabIndex = 3
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.ForeColor = Color.Black
        txtUsername.Location = New Point(51, 21)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(255, 18)
        txtUsername.TabIndex = 4
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(5, 9)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(40, 40)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(txtPassword)
        Panel2.Controls.Add(PictureBox3)
        Panel2.Location = New Point(88, 404)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(323, 58)
        Panel2.TabIndex = 4
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.ForeColor = Color.Black
        txtPassword.Location = New Point(51, 21)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(255, 18)
        txtPassword.TabIndex = 4
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(5, 9)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(40, 40)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 4
        PictureBox3.TabStop = False
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(0), CByte(120), CByte(212))
        btnLogin.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(88, 498)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(323, 45)
        btnLogin.TabIndex = 5
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(0), CByte(120), CByte(212))
        btnCancel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(88, 549)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(323, 45)
        btnCancel.TabIndex = 6
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(240), CByte(244), CByte(247))
        ClientSize = New Size(491, 656)
        Controls.Add(btnCancel)
        Controls.Add(btnLogin)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnCancel As Button

End Class
