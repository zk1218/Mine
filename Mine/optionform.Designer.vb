<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOption
	Inherits System.Windows.Forms.Form

	'Form 重写 Dispose，以清理组件列表。
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso components IsNot Nothing Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Windows 窗体设计器所必需的
	Private components As System.ComponentModel.IContainer

	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器修改它。
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.btnOK = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.Label1 = New System.Windows.Forms.Label
		Me.txtColCount = New System.Windows.Forms.NumericUpDown
		Me.Label2 = New System.Windows.Forms.Label
		Me.txtRowCount = New System.Windows.Forms.NumericUpDown
		Me.txtMineCount = New System.Windows.Forms.NumericUpDown
		Me.Label3 = New System.Windows.Forms.Label
		Me.TableLayoutPanel1.SuspendLayout()
		CType(Me.txtColCount, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtRowCount, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtMineCount, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'btnOK
		'
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.btnOK.Location = New System.Drawing.Point(27, 98)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 23)
		Me.btnOK.TabIndex = 0
		Me.btnOK.Text = "确定(&O)"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.btnCancel.Location = New System.Drawing.Point(108, 98)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 1
		Me.btnCancel.Text = "取消(&C)"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.5!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.5!))
		Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.txtColCount, 1, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
		Me.TableLayoutPanel1.Controls.Add(Me.txtRowCount, 1, 1)
		Me.TableLayoutPanel1.Controls.Add(Me.txtMineCount, 1, 2)
		Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 3
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(171, 80)
		Me.TableLayoutPanel1.TabIndex = 2
		'
		'Label1
		'
		Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(7, 7)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(53, 12)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "列数(&C):"
		'
		'txtColCount
		'
		Me.txtColCount.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.txtColCount.Location = New System.Drawing.Point(70, 3)
		Me.txtColCount.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
		Me.txtColCount.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
		Me.txtColCount.Name = "txtColCount"
		Me.txtColCount.Size = New System.Drawing.Size(98, 21)
		Me.txtColCount.TabIndex = 1
		Me.txtColCount.Value = New Decimal(New Integer() {5, 0, 0, 0})
		'
		'Label2
		'
		Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Label2.AutoSize = True
		Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.Label2.Location = New System.Drawing.Point(7, 33)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(53, 12)
		Me.Label2.TabIndex = 0
		Me.Label2.Text = "行数(&R):"
		'
		'txtRowCount
		'
		Me.txtRowCount.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.txtRowCount.Location = New System.Drawing.Point(70, 29)
		Me.txtRowCount.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
		Me.txtRowCount.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
		Me.txtRowCount.Name = "txtRowCount"
		Me.txtRowCount.Size = New System.Drawing.Size(98, 21)
		Me.txtRowCount.TabIndex = 1
		Me.txtRowCount.Value = New Decimal(New Integer() {5, 0, 0, 0})
		'
		'txtMineCount
		'
		Me.txtMineCount.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.txtMineCount.Location = New System.Drawing.Point(70, 55)
		Me.txtMineCount.Maximum = New Decimal(New Integer() {890, 0, 0, 0})
		Me.txtMineCount.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
		Me.txtMineCount.Name = "txtMineCount"
		Me.txtMineCount.Size = New System.Drawing.Size(98, 21)
		Me.txtMineCount.TabIndex = 1
		Me.txtMineCount.Value = New Decimal(New Integer() {5, 0, 0, 0})
		'
		'Label3
		'
		Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(7, 60)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(53, 12)
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "雷数(&M):"
		'
		'frmOption
		'
		Me.AcceptButton = Me.btnOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(194, 130)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmOption"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "自定义"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.TableLayoutPanel1.PerformLayout()
		CType(Me.txtColCount, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtRowCount, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtMineCount, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents btnOK As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtColCount As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtRowCount As System.Windows.Forms.NumericUpDown
	Friend WithEvents txtMineCount As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
