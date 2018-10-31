Public Class MineGame

	'定义事件
	Public Event GameStart()
	Public Event GameOver()
	Public Event GameWin()

	Private _blockWidth As Single
	Private _blockHeight As Single

	''' <summary>
	''' 砖块 List
	''' </summary>
	''' <remarks></remarks>
	Private blockList As List(Of Block)

	''' <summary>
	''' 雷 List
	''' </summary>
	''' <remarks></remarks>
	Private mineList As List(Of Block)

	''' <summary>
	''' 雷的数量
	''' </summary>
	''' <remarks></remarks>
	Private _mineCount As Integer
	Public ReadOnly Property mineCount() As Integer
		Get
			Return _mineCount
		End Get
	End Property

	Private _openedBlockCount As Integer
	''' <summary>
	''' 已经翻开的砖块的数量
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property OpenedBlockCount() As Integer
		Get
			Return _openedBlockCount
		End Get
	End Property

	Private _markedBlockCount As Integer
	''' <summary>
	''' 已经标记为雷的砖块的数量
	''' </summary>
	''' <remarks></remarks>
	Public ReadOnly Property MarkedBlockCount() As Integer
		Get
			Return _markedBlockCount
		End Get
	End Property

	''' <summary>
	''' 未标记为雷的砖块的数量
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property NoMarkedBlockCount() As Integer
		Get
			Return _mineCount - _markedBlockCount
		End Get
	End Property

	Private _colCount As Integer
	''' <summary>
	''' 砖块的列数
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property ColCount() As Integer
		Get
			Return _colCount
		End Get
	End Property

	Private _rowCount As Integer
	''' <summary>
	''' 砖块的行数
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property RowCount() As Integer
		Get
			Return _rowCount
		End Get
	End Property

	''' <summary>
	''' 砖块总数
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property BlockCount() As Integer
		Get
			Return _colCount * _rowCount
		End Get
	End Property

	''' <summary>
	''' 砖块状态更改事件过程
	''' </summary>
	''' <remarks></remarks>
	Private Sub BlockStatChange(ByVal sender As Block, ByVal oldStat As Block.EBlockState, ByVal newStat As Block.EBlockState)
		If oldStat <> Block.EBlockState.Mark AndAlso newStat = Block.EBlockState.Mark Then Me._markedBlockCount += 1
		If oldStat = Block.EBlockState.Mark AndAlso newStat <> Block.EBlockState.Mark Then Me._markedBlockCount -= 1

		If oldStat <> Block.EBlockState.Opened AndAlso newStat = Block.EBlockState.Opened Then Me._openedBlockCount += 1

		'已经翻开的砖块为1，表示游戏开始，则生成雷区，并引发 GameStart 事件
		If Me._openedBlockCount = 1 Then

			createMine(sender)

			RaiseEvent GameStart()
		End If

		If oldStat <> Block.EBlockState.Opened AndAlso newStat = Block.EBlockState.Opened Then
			If sender.ExistMine Then

				'引爆所有的雷
				For Each item As Block In mineList
					item.Pong()
				Next

				RaiseEvent GameOver()
				Exit Sub
			End If

			If sender.AroundMineCount = 0 Then
				Dim aroundMines As List(Of Block) = GetAroundBlocks(sender)
				For Each mine As Block In aroundMines
					mine.State = Block.EBlockState.Opened
				Next
			End If
		End If

		'已经翻开的砖块与雷的数量之和等砖块总数则表示已经赢了
		If Me._openedBlockCount + Me._mineCount = BlockCount Then
			'标记所有的雷
			For Each item As Block In mineList
				item.Mark()
			Next
			Me._markedBlockCount = mineList.Count
			RaiseEvent GameWin()
			Exit Sub
		End If
	End Sub

	''' <summary>
	''' 构建
	''' </summary>
	''' <param name="colCount">列数</param>
	''' <param name="rowCount">行数</param>
	''' <param name="blockWidth">单个砖块宽度</param>
	''' <param name="blockHeight">单个砖块高度</param>
	''' <param name="mineCount">雷数量</param>
	''' <remarks></remarks>
	Public Sub New(ByVal colCount As Integer, ByVal rowCount As Integer, ByVal blockWidth As Single, ByVal blockHeight As Single, ByVal mineCount As Integer)

		Me._colCount = colCount
		Me._rowCount = rowCount
		Me._blockWidth = blockWidth
		Me._blockHeight = blockHeight

		blockList = New List(Of Block)
		mineList = New List(Of Block)

		For I As Integer = 0 To _rowCount - 1
			For J As Integer = 0 To _colCount - 1
				Dim block As New Block
				block.ColIndex = J
				block.RowIndex = I
				block.BlockRect = GetBlockRect(block) ' New RectangleF(New PointF(blockWidthValue * J, blockHeightValue * I), New Size(blockWidthValue, blockHeightValue))
				AddHandler block.StateChange, AddressOf BlockStatChange
				blockList.Add(block)
			Next
		Next

		If mineCount > 0 AndAlso mineCount < colCount * rowCount Then
			_mineCount = mineCount
		Else
			_mineCount = colCount * rowCount / 5
		End If


	End Sub

	''' <summary>
	''' 生成随机雷区
	''' </summary>
	''' <param name="firstBlock">首次点击的砖块</param>
	Private Sub createMine(ByVal firstBlock As Block)

		Dim maxID As Integer = blockList.Count - 1
		Dim arrIndex(maxID) As Integer
		For I As Integer = 0 To maxID
			arrIndex(I) = I
		Next

		'洗牌算法将 ID 打乱
		Dim r As New Random
		For I As Integer = 0 To Me._colCount * Me._rowCount * 100
			Dim id1 As Integer = r.Next(maxID)
			Dim id2 As Integer = r.Next(maxID)
			If id1 <> id2 Then
				arrIndex(id2) = arrIndex(id1) + arrIndex(id2)
				arrIndex(id1) = arrIndex(id2) - arrIndex(id1)
				arrIndex(id2) = arrIndex(id2) - arrIndex(id1)
			End If
		Next

		'首次点击的砖块及其周围的砖块，确保第一次点击时这些砖块下不会生成雷
		Dim _firstAndAroundBlocks As List(Of Block) = GetAroundBlocks(firstBlock)
		_firstAndAroundBlocks.Add(firstBlock)

		Dim _pos As Integer
		For i As Integer = 0 To maxID
			Dim _block As Block = blockList.Item(arrIndex(i))
			If _firstAndAroundBlocks.IndexOf(_block) < 0 Then
				_block.ExistMine = True
				mineList.Add(_block)
				_pos += 1
				If _pos = _mineCount Then Exit For
			End If
		Next

		'计算周围雷数量
		For Each blockItem As Block In blockList
			Dim aroundBlockList As List(Of Block) = Me.GetAroundBlocks(blockItem)
			Dim aroundMineCount As Integer = 0
			For Each b As Block In aroundBlockList
				If b.ExistMine Then aroundMineCount += 1
			Next
			blockItem.AroundMineCount = aroundMineCount
		Next
	End Sub

	''' <summary>
	''' 返回指定砖块的四周砖块 List
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetAroundBlocks(ByVal block As Block) As List(Of Block)
		Dim aroundBlocks As New List(Of Block)
		For I As Integer = block.ColIndex - 1 To block.ColIndex + 1
			For J As Integer = block.RowIndex - 1 To block.RowIndex + 1
				Dim currentBlock As Block = GetBlockAtColRow(I, J)
				If currentBlock IsNot Nothing AndAlso currentBlock IsNot block Then aroundBlocks.Add(currentBlock)
			Next
		Next
		Return aroundBlocks
	End Function

	''' <summary>
	''' 翻开指定砖块周围未标记为雷的砖块
	''' </summary>
	''' <param name="block"></param>
	''' <remarks></remarks>
	Public Sub OpenAroundBlocks(ByVal block As Block)
		If block.State <> block.EBlockState.Opened Then Exit Sub
		If block.AroundMineCount > 0 Then
			Dim markCount As Integer = 0
			Dim aroundMines As List(Of Block) = GetAroundBlocks(block)
			For Each mine As Block In aroundMines
				If mine.State = block.EBlockState.Mark Then markCount += 1
			Next

			If markCount = block.AroundMineCount Then
				For Each mine As Block In aroundMines
					If mine.State <> block.EBlockState.Mark Then
						mine.State = block.EBlockState.Opened
					End If
				Next
			End If
		End If
	End Sub

	''' <summary>
	''' 设置指定砖块周围砖块的显示状态
	''' </summary>
	''' <param name="block"></param>
	''' <param name="opening"></param>
	''' <remarks></remarks>
	Public Sub SetAroundBlocksStat(ByVal block As Block, ByVal opening As Boolean)
		Dim aroundMines As List(Of Block) = GetAroundBlocks(block)
		For Each m As Block In aroundMines
			If m.State = block.EBlockState.General OrElse m.State = block.EBlockState.Question Then m.Opening = opening
		Next
	End Sub

	''' <summary>
	''' 返回指定行列的砖块
	''' </summary>
	''' <param name="colIndex"></param>
	''' <param name="rowIndex"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetBlockAtColRow(ByVal colIndex As Integer, ByVal rowIndex As Integer) As Block
		If colIndex < 0 Then Return Nothing
		If rowIndex < 0 Then Return Nothing
		If colIndex > Me._colCount - 1 Then Return Nothing
		If rowIndex > Me._rowCount - 1 Then Return Nothing

		Dim itemIndex As Integer = Me._colCount * rowIndex + colIndex
		If itemIndex < blockList.Count Then
			Return Me.blockList(itemIndex)
		Else
			Return Nothing
		End If
	End Function

	''' <summary>
	''' 返回指定坐标的砖块
	''' </summary>
	''' <param name="p"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetBlockAtPoint(ByVal p As Point) As Block
		If p.X > Me._blockWidth * Me._colCount Then Return Nothing
		If p.Y > Me._blockHeight * Me._rowCount Then Return Nothing

		Dim colIndex As Integer = Math.Floor(p.X / Me._blockWidth)
		Dim rowIndex As Integer = Math.Floor(p.Y / Me._blockHeight)

		Dim itemIndex As Integer = Me._colCount * rowIndex + colIndex
		If itemIndex < blockList.Count Then
			Return Me.blockList(itemIndex)
		Else
			Return Nothing
		End If
	End Function

	''' <summary>
	''' 返回指定砖块的位置及大小
	''' </summary>
	''' <param name="block"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function GetBlockRect(ByVal block As Block) As RectangleF
		Return New RectangleF(New PointF(_blockWidth * block.ColIndex, _blockHeight * block.RowIndex), New Size(_blockWidth - 1.5, _blockHeight - 1.5))
	End Function

	''' <summary>
	''' 画到屏幕上
	''' </summary>
	''' <param name="g">画板</param>
	''' <remarks></remarks>
	Public Sub Print(ByVal g As Graphics, ByVal gWidth As Integer, ByVal gHeight As Integer)

		Me._blockWidth = gWidth / Me.ColCount
		Me._blockHeight = gHeight / Me.RowCount

		For Each block As Block In blockList
			block.BlockRect = GetBlockRect(block)
			block.Print(g)
		Next
	End Sub

End Class