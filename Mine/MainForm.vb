Public Class MainForm

	Dim dButton As Integer
	Private WithEvents m As MineGame

	'Private Const mineLine As Integer = 40

	Private colCount As Integer = 9
	Private rowCount As Integer = 9
	Private hasMineCount As Integer = 10

	Private config As StatConfig

	Private timer As Timer
	Private gameTime As Int64

	Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		With config
			.ColCount = colCount
			.RowCount = rowCount
			.MineCount = hasMineCount
			Me.WindowState = FormWindowState.Normal
			.FormRect = New Rectangle(Me.Location, Me.Size)
			.SaveConfig()
		End With
	End Sub

	Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		config = New StatConfig
		colCount = config.ColCount
		rowCount = config.RowCount
		hasMineCount = config.MineCount
		Me.Size = config.FormRect.Size
		Me.Location = config.FormRect.Location

		timer = New Timer
		timer.Interval = 1000
		AddHandler timer.Tick, AddressOf TimerEventProcessor
		timer.Stop()

		NewGame()
	End Sub

	''' <summary>
	''' 开始一个新游戏
	''' </summary>
	''' <remarks></remarks>
	Private Sub NewGame()

		timer.Stop()

		Dim blockWidth As Single = hb.Width / colCount
		Dim blockHeight As Single = hb.Height / rowCount

		m = New MineGame(colCount, rowCount, blockWidth, blockHeight, hasMineCount)

		dButton = 0

		Dim minWidth As Integer = colCount * 20 + hb.Left * 2
		Dim minHeight As Integer = rowCount * 20 + hb.Top * 2

		Me.MinimumSize = New Size(minWidth, minHeight)
		'Me.Size = Me.MinimumSize

		labMineCount.Text = m.MarkedBlockCount.ToString + " / " + m.mineCount.ToString
		labTimer.Text = "000"
		gameTime = 0
		btnNewGame.ImageIndex = 0

		hb.Enabled = True
		hb.Refresh()
		hb.Focus()

	End Sub

	''' <summary>
	''' 当前光标下的雷
	''' </summary>
	''' <remarks></remarks>
	Private currentMine As Block = Nothing

	Private Sub hb_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles hb.MouseDown

		btnNewGame.ImageIndex = 1

		Dim item As Block = m.GetBlockAtPoint(New Point(e.X, e.Y))
		If item Is Nothing Then Exit Sub
		item.Opening = True

		currentMine = item

		If dButton = 1 Then
			m.SetAroundBlocksStat(item, True)
		End If

		dButton += 1

		hb.Refresh()
	End Sub

	Private Sub hb_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles hb.MouseUp
		btnNewGame.ImageIndex = 0

		Dim item As Block
		If currentMine Is Nothing Then
			item = m.GetBlockAtPoint(New Point(e.X, e.Y))
			If item Is Nothing Then Exit Sub
		Else
			item = currentMine
			currentMine = Nothing
		End If

		item.Opening = False

		If dButton = 2 Then
			m.SetAroundBlocksStat(item, False)
			m.OpenAroundBlocks(item)
			dButton = 0
		ElseIf dButton = 1 Then
			Select Case e.Button
				Case Windows.Forms.MouseButtons.Left
					If item.State <> Block.EBlockState.Mark Then item.State = Block.EBlockState.Opened
				Case Windows.Forms.MouseButtons.Right
					Select Case item.State
						Case Block.EBlockState.General
							item.State = Block.EBlockState.Mark
						Case Block.EBlockState.Mark
							item.State = Block.EBlockState.Question
						Case Block.EBlockState.Question
							item.State = Block.EBlockState.General
					End Select
					UpdateMsg()
			End Select
		End If

		dButton -= 1

		If dButton < 0 Then dButton = 0

		currentMine = Nothing

		hb.Refresh()
	End Sub

	''' <summary>
	''' 更新消息显示区域的内容
	''' </summary>
	''' <remarks></remarks>
	Public Sub UpdateMsg()
		labMineCount.Text = m.MarkedBlockCount.ToString + " / " + m.mineCount.ToString
		labTimer.Text = Format(gameTime, "000")
	End Sub

	Public Sub TimerEventProcessor(ByVal sender As Object, ByVal e As EventArgs)
		gameTime += 1
		UpdateMsg()
	End Sub

	Private Sub m_GameStart() Handles m.GameStart
		timer.Start()
	End Sub

	Private Sub GameStop()
		hb.Refresh()
		hb.Enabled = False
		timer.Stop()
		UpdateMsg()
	End Sub

	Private Sub m_GameWin() Handles m.GameWin
		GameStop()

		btnNewGame.ImageIndex = 2

		Dim rankingIndex As Integer = -1

		rankingIndex = IIf(colCount = 9 AndAlso rowCount = 9 AndAlso hasMineCount = 10, 0, rankingIndex)
		rankingIndex = IIf(colCount = 16 AndAlso rowCount = 16 AndAlso hasMineCount = 40, 1, rankingIndex)
		rankingIndex = IIf(colCount = 30 AndAlso rowCount = 16 AndAlso hasMineCount = 99, 2, rankingIndex)

		If rankingIndex = -1 Then Exit Sub

		With config.RankIng(rankingIndex)
			If .Time > gameTime Then
				Dim n As String = InputBox("新记录！请输入姓名：", "输入姓名", .Name)
				If Not String.IsNullOrEmpty(n) Then
					.Name = Microsoft.VisualBasic.Left(n, 10)
					.Time = gameTime
				End If
			End If
		End With
	End Sub

	Private Sub m_GameOver() Handles m.GameOver
		GameStop()
		btnNewGame.ImageIndex = 3
	End Sub

	Private Sub hb_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles hb.Paint
		m.Print(e.Graphics, hb.Width - 4, hb.Height - 4)
	End Sub

	Private Sub menuS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuS.Click
		colCount = 9
		rowCount = 9
		hasMineCount = 10
		NewGame()
	End Sub

	Private Sub menuM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuM.Click
		colCount = 16
		rowCount = 16
		hasMineCount = 40
		NewGame()
	End Sub

	Private Sub menuB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuB.Click
		colCount = 30
		rowCount = 16
		hasMineCount = 99
		NewGame()
	End Sub

	Private Sub menuC_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuC.Click
		With frmOption
			.txtColCount.Value = colCount
			.txtRowCount.Value = rowCount
			.txtMineCount.Value = hasMineCount
			.txtMineCount.Maximum = .txtColCount.Value * .txtRowCount.Value - 10
			If .ShowDialog = Windows.Forms.DialogResult.OK Then
				colCount = .txtColCount.Value
				rowCount = .txtRowCount.Value
				hasMineCount = .txtMineCount.Value
				NewGame()
			End If
		End With
	End Sub

	Private Sub menuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuExit.Click
		Close()
	End Sub

	Private Sub menuHowPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuHowPlay.Click
		Dim helpFile As String = "C:\WINDOWS\Help\winmine.chm"
		If IO.File.Exists(helpFile) Then
			System.Diagnostics.Process.Start(helpFile)
		Else
			MsgBox("地球人都知道！", MsgBoxStyle.Information)
		End If
	End Sub

	Private Sub menuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAbout.Click
		MsgBox("扫雷 1.0.0.0 VB.Net 2.0 版" + vbCrLf + vbCrLf + "作者：张凯" + vbCrLf + vbCrLf + "http://www.zhangkai.net.cn/", MsgBoxStyle.Information, My.Application.Info.ProductName)
	End Sub

	Private Sub menuGame_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles menuGame.MouseDown
		menuS.Checked = colCount = 9 AndAlso rowCount = 9 AndAlso hasMineCount = 10
		menuM.Checked = colCount = 16 AndAlso rowCount = 16 AndAlso hasMineCount = 40
		menuB.Checked = colCount = 30 AndAlso rowCount = 16 AndAlso hasMineCount = 99
		menuC.Checked = Not (menuS.Checked Or menuM.Checked Or menuB.Checked)
	End Sub

	Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
		hb.Refresh()
	End Sub

	Private Sub btnNewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click
		NewGame()
		hb.Focus()
	End Sub

	Private Sub menuClearRanking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuClearRanking.Click

		If MsgBox("确实要清除吗？", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "确认") <> MsgBoxResult.Yes Then Exit Sub

		For i As Integer = 0 To 2
			config.RankIng(i).Name = String.Empty
			config.RankIng(i).Time = 999
		Next
	End Sub

	Private Sub menuViewRanking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuViewRanking.Click
		Dim msgStr As String = String.Empty
		For i As Integer = 0 To 2
			msgStr += (i + 1).ToString + ". " + Choose(i + 1, "初级", "中级", "高级") + "    "
			msgStr += config.RankIng(i).Name + " : "
			msgStr += config.RankIng(i).Time.ToString("000 秒")
			msgStr += vbCrLf
		Next

		MsgBox(msgStr, MsgBoxStyle.Information, "排行榜")
	End Sub
End Class
