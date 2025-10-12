<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Panel1 = New Panel()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.ActiveCaption
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Location = New Point(31, 73)
        Button1.Name = "Button1"
        Button1.Size = New Size(107, 34)
        Button1.TabIndex = 0
        Button1.Text = "Dashboard"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.ActiveCaption
        Button2.FlatStyle = FlatStyle.Popup
        Button2.Location = New Point(31, 134)
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
        Button3.Location = New Point(31, 193)
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
        Button4.Location = New Point(31, 251)
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
        Button5.Location = New Point(31, 306)
        Button5.Name = "Button5"
        Button5.Size = New Size(107, 31)
        Button5.TabIndex = 4
        Button5.Text = "Booking"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Location = New Point(173, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(862, 585)
        Panel1.TabIndex = 5
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1047, 609)
        Controls.Add(Panel1)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "Form2"
        Text = "Form2"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel1 As Panel
End Class
