<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Attendance
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
        btnTimeIn = New Button()
        btnTimeOut = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' btnTimeIn
        ' 
        btnTimeIn.Location = New Point(206, 164)
        btnTimeIn.Name = "btnTimeIn"
        btnTimeIn.Size = New Size(142, 40)
        btnTimeIn.TabIndex = 2
        btnTimeIn.Text = "Time in"
        btnTimeIn.UseVisualStyleBackColor = True
        ' 
        ' btnTimeOut
        ' 
        btnTimeOut.Location = New Point(398, 164)
        btnTimeOut.Name = "btnTimeOut"
        btnTimeOut.Size = New Size(142, 40)
        btnTimeOut.TabIndex = 3
        btnTimeOut.Text = "Time Out"
        btnTimeOut.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Showcard Gothic", 72F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(90, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(649, 119)
        Label1.TabIndex = 4
        Label1.Text = "ATTENDANCE"
        ' 
        ' Attendance
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(btnTimeOut)
        Controls.Add(btnTimeIn)
        Name = "Attendance"
        Text = "label"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTimeIn As Button
    Friend WithEvents btnTimeOut As Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
