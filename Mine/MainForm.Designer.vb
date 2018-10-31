<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		Me.hb = New System.Windows.Forms.PictureBox
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
		Me.menuGame = New System.Windows.Forms.ToolStripMenuItem
		Me.menuNew = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
		Me.menuS = New System.Windows.Forms.ToolStripMenuItem
		Me.menuM = New System.Windows.Forms.ToolStripMenuItem
		Me.menuB = New System.Windows.Forms.ToolStripMenuItem
		Me.menuC = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
		Me.menuExit = New System.Windows.Forms.ToolStripMenuItem
		Me.帮助HToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.menuHowPlay = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
		Me.menuAbout = New System.Windows.Forms.ToolStripMenuItem
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.btnNewGame = New System.Windows.Forms.Button
		Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
		Me.labMineCount = New System.Windows.Forms.Label
		Me.labTimer = New System.Windows.Forms.Label
		Me.menuRanking = New System.Windows.Forms.ToolStripMenuItem
		Me.menuViewRanking = New System.Windows.Forms.ToolStripMenuItem
		Me.menuClearRanking = New System.Windows.Forms.ToolStripMenuItem
		CType(Me.hb, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.MenuStrip1.SuspendLayout()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'hb
		'
		Me.hb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.hb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.hb.Location = New System.Drawing.Point(12, 71)
		Me.hb.Name = "hb"
		Me.hb.Size = New System.Drawing.Size(411, 183)
		Me.hb.TabIndex = 0
		Me.hb.TabStop = False
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuGame, Me.帮助HToolStripMenuItem, Me.menuRanking})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(435, 24)
		Me.MenuStrip1.TabIndex = 2
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'menuGame
		'
		Me.menuGame.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuNew, Me.ToolStripMenuItem1, Me.menuS, Me.menuM, Me.menuB, Me.menuC, Me.ToolStripMenuItem2, Me.menuExit})
		Me.menuGame.Name = "menuGame"
		Me.menuGame.Size = New System.Drawing.Size(59, 20)
		Me.menuGame.Text = "游戏(&G)"
		'
		'menuNew
		'
		Me.menuNew.Name = "menuNew"
		Me.menuNew.ShortcutKeyDisplayString = ""
		Me.menuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
		Me.menuNew.Size = New System.Drawing.Size(165, 22)
		Me.menuNew.Text = "新游戏(&N)"
		'
		'ToolStripMenuItem1
		'
		Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
		Me.ToolStripMenuItem1.Size = New System.Drawing.Size(162, 6)
		'
		'menuS
		'
		Me.menuS.Checked = True
		Me.menuS.CheckState = System.Windows.Forms.CheckState.Checked
		Me.menuS.Name = "menuS"
		Me.menuS.Size = New System.Drawing.Size(165, 22)
		Me.menuS.Text = "小(9x9)"
		'
		'menuM
		'
		Me.menuM.Name = "menuM"
		Me.menuM.Size = New System.Drawing.Size(165, 22)
		Me.menuM.Text = "中(16x16)"
		'
		'menuB
		'
		Me.menuB.Name = "menuB"
		Me.menuB.Size = New System.Drawing.Size(165, 22)
		Me.menuB.Text = "大(30x16)"
		'
		'menuC
		'
		Me.menuC.Name = "menuC"
		Me.menuC.Size = New System.Drawing.Size(165, 22)
		Me.menuC.Text = "定制..."
		'
		'ToolStripMenuItem2
		'
		Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
		Me.ToolStripMenuItem2.Size = New System.Drawing.Size(162, 6)
		'
		'menuExit
		'
		Me.menuExit.Name = "menuExit"
		Me.menuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
		Me.menuExit.Size = New System.Drawing.Size(165, 22)
		Me.menuExit.Text = "退出(&E)"
		'
		'帮助HToolStripMenuItem
		'
		Me.帮助HToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
		Me.帮助HToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuHowPlay, Me.ToolStripMenuItem3, Me.menuAbout})
		Me.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem"
		Me.帮助HToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.帮助HToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
		Me.帮助HToolStripMenuItem.Text = "帮助(&H)"
		Me.帮助HToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
		'
		'menuHowPlay
		'
		Me.menuHowPlay.Name = "menuHowPlay"
		Me.menuHowPlay.Size = New System.Drawing.Size(112, 22)
		Me.menuHowPlay.Text = "玩法(&F)"
		'
		'ToolStripMenuItem3
		'
		Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
		Me.ToolStripMenuItem3.Size = New System.Drawing.Size(109, 6)
		'
		'menuAbout
		'
		Me.menuAbout.Name = "menuAbout"
		Me.menuAbout.Size = New System.Drawing.Size(112, 22)
		Me.menuAbout.Text = "关于(&A)"
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 3
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.btnNewGame, 1, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.labMineCount, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.labTimer, 2, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 27)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(411, 40)
		Me.TableLayoutPanel1.TabIndex = 4
		'
		'btnNewGame
		'
		Me.btnNewGame.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnNewGame.ImageIndex = 0
		Me.btnNewGame.ImageList = Me.ImageList
		Me.btnNewGame.Location = New System.Drawing.Point(187, 3)
		Me.btnNewGame.Name = "btnNewGame"
		Me.btnNewGame.Size = New System.Drawing.Size(37, 34)
		Me.btnNewGame.TabIndex = 0
		Me.btnNewGame.UseVisualStyleBackColor = True
		'
		'ImageList
		'
		Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
		Me.ImageList.Images.SetKeyName(0, "1")
		Me.ImageList.Images.SetKeyName(1, "2")
		Me.ImageList.Images.SetKeyName(2, "3")
		Me.ImageList.Images.SetKeyName(3, "4")
		'
		'labMineCount
		'
		Me.labMineCount.Anchor = System.Windows.Forms.AnchorStyles.Left
		Me.labMineCount.BackColor = System.Drawing.Color.White
		Me.labMineCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.labMineCount.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labMineCount.ForeColor = System.Drawing.Color.Navy
		Me.labMineCount.Location = New System.Drawing.Point(3, 7)
		Me.labMineCount.Name = "labMineCount"
		Me.labMineCount.Size = New System.Drawing.Size(100, 25)
		Me.labMineCount.TabIndex = 1
		Me.labMineCount.Text = "Label1"
		Me.labMineCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'labTimer
		'
		Me.labTimer.Anchor = System.Windows.Forms.AnchorStyles.Right
		Me.labTimer.BackColor = System.Drawing.Color.White
		Me.labTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.labTimer.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.labTimer.ForeColor = System.Drawing.Color.Navy
		Me.labTimer.Location = New System.Drawing.Point(308, 7)
		Me.labTimer.Name = "labTimer"
		Me.labTimer.Size = New System.Drawing.Size(100, 25)
		Me.labTimer.TabIndex = 2
		Me.labTimer.Text = "Label1"
		Me.labTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'menuRanking
		'
		Me.menuRanking.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuViewRanking, Me.menuClearRanking})
		Me.menuRanking.Name = "menuRanking"
		Me.menuRanking.Size = New System.Drawing.Size(71, 20)
		Me.menuRanking.Text = "排行榜(&R)"
		'
		'menuViewRanking
		'
		Me.menuViewRanking.Name = "menuViewRanking"
		Me.menuViewRanking.Size = New System.Drawing.Size(152, 22)
		Me.menuViewRanking.Text = "查看(&V)"
		'
		'menuClearRanking
		'
		Me.menuClearRanking.Name = "menuClearRanking"
		Me.menuClearRanking.Size = New System.Drawing.Size(152, 22)
		Me.menuClearRanking.Text = "清除(&C)"
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(435, 266)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.Controls.Add(Me.hb)
		Me.Controls.Add(Me.MenuStrip1)
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Name = "MainForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "扫雷"
		CType(Me.hb, System.ComponentModel.ISupportInitialize).EndInit()
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents hb As System.Windows.Forms.PictureBox
	Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
	Friend WithEvents menuGame As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents menuNew As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents menuS As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents menuM As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents menuB As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents menuExit As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents 帮助HToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents menuHowPlay As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents menuAbout As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents menuC As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents btnNewGame As System.Windows.Forms.Button
	Friend WithEvents labMineCount As System.Windows.Forms.Label
	Friend WithEvents labTimer As System.Windows.Forms.Label
	Friend WithEvents ImageList As System.Windows.Forms.ImageList
	Friend WithEvents menuRanking As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents menuViewRanking As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents menuClearRanking As System.Windows.Forms.ToolStripMenuItem

End Class
