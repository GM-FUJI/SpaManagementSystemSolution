<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class History
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
        Label1 = New System.Windows.Forms.Label()
        txtSearch = New TextBox()
        btnSearch = New Button()
        dgvHistory = New DataGridView()
        btnUpdate = New Button()
        btnDelete = New Button()
        CType(dgvHistory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Viner Hand ITC", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(326, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(131, 26)
        Label1.TabIndex = 0
        Label1.Text = "History Report"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(21, 90)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(157, 23)
        txtSearch.TabIndex = 2
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(218, 90)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 3
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' dgvHistory
        ' 
        dgvHistory.BackgroundColor = Color.White
        dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvHistory.Location = New Point(21, 135)
        dgvHistory.Name = "dgvHistory"
        dgvHistory.ReadOnly = True
        dgvHistory.RowHeadersVisible = False
        dgvHistory.Size = New Size(820, 291)
        dgvHistory.TabIndex = 4
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(69, 456)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(143, 35)
        btnUpdate.TabIndex = 5
        btnUpdate.Text = "Updated Selected"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(256, 456)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(155, 35)
        btnDelete.TabIndex = 6
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' History
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(896, 527)
        Controls.Add(btnDelete)
        Controls.Add(btnUpdate)
        Controls.Add(dgvHistory)
        Controls.Add(btnSearch)
        Controls.Add(txtSearch)
        Controls.Add(Label1)
        Name = "History"
        Text = "History"
        CType(dgvHistory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents dgvHistory As DataGridView
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
End Class
