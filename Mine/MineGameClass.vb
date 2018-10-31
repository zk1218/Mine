Public Class MineGame

	'�����¼�
	Public Event GameStart()
	Public Event GameOver()
	Public Event GameWin()

	Private _blockWidth As Single
	Private _blockHeight As Single

	''' <summary>
	''' ש�� List
	''' </summary>
	''' <remarks></remarks>
	Private blockList As List(Of Block)

	''' <summary>
	''' �� List
	''' </summary>
	''' <remarks></remarks>
	Private mineList As List(Of Block)

	''' <summary>
	''' �׵�����
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
	''' �Ѿ�������ש�������
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
	''' �Ѿ����Ϊ�׵�ש�������
	''' </summary>
	''' <remarks></remarks>
	Public ReadOnly Property MarkedBlockCount() As Integer
		Get
			Return _markedBlockCount
		End Get
	End Property

	''' <summary>
	''' δ���Ϊ�׵�ש�������
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
	''' ש�������
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
	''' ש�������
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
	''' ש������
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
	''' ש��״̬�����¼�����
	''' </summary>
	''' <remarks></remarks>
	Private Sub BlockStatChange(ByVal sender As Block, ByVal oldStat As Block.EBlockState, ByVal newStat As Block.EBlockState)
		If oldStat <> Block.EBlockState.Mark AndAlso newStat = Block.EBlockState.Mark Then Me._markedBlockCount += 1
		If oldStat = Block.EBlockState.Mark AndAlso newStat <> Block.EBlockState.Mark Then Me._markedBlockCount -= 1

		If oldStat <> Block.EBlockState.Opened AndAlso newStat = Block.EBlockState.Opened Then Me._openedBlockCount += 1

		'�Ѿ�������ש��Ϊ1����ʾ��Ϸ��ʼ�������������������� GameStart �¼�
		If Me._openedBlockCount = 1 Then

			createMine(sender)

			RaiseEvent GameStart()
		End If

		If oldStat <> Block.EBlockState.Opened AndAlso newStat = Block.EBlockState.Opened Then
			If sender.ExistMine Then

				'�������е���
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

		'�Ѿ�������ש�����׵�����֮�͵�ש���������ʾ�Ѿ�Ӯ��
		If Me._openedBlockCount + Me._mineCount = BlockCount Then
			'������е���
			For Each item As Block In mineList
				item.Mark()
			Next
			Me._markedBlockCount = mineList.Count
			RaiseEvent GameWin()
			Exit Sub
		End If
	End Sub

	''' <summary>
	''' ����
	''' </summary>
	''' <param name="colCount">����</param>
	''' <param name="rowCount">����</param>
	''' <param name="blockWidth">����ש����</param>
	''' <param name="blockHeight">����ש��߶�</param>
	''' <param name="mineCount">������</param>
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
	''' �����������
	''' </summary>
	''' <param name="firstBlock">�״ε����ש��</param>
	Private Sub createMine(ByVal firstBlock As Block)

		Dim maxID As Integer = blockList.Count - 1
		Dim arrIndex(maxID) As Integer
		For I As Integer = 0 To maxID
			arrIndex(I) = I
		Next

		'ϴ���㷨�� ID ����
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

		'�״ε����ש�鼰����Χ��ש�飬ȷ����һ�ε��ʱ��Щש���²���������
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

		'������Χ������
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
	''' ����ָ��ש�������ש�� List
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
	''' ����ָ��ש����Χδ���Ϊ�׵�ש��
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
	''' ����ָ��ש����Χש�����ʾ״̬
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
	''' ����ָ�����е�ש��
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
	''' ����ָ�������ש��
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
	''' ����ָ��ש���λ�ü���С
	''' </summary>
	''' <param name="block"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function GetBlockRect(ByVal block As Block) As RectangleF
		Return New RectangleF(New PointF(_blockWidth * block.ColIndex, _blockHeight * block.RowIndex), New Size(_blockWidth - 1.5, _blockHeight - 1.5))
	End Function

	''' <summary>
	''' ������Ļ��
	''' </summary>
	''' <param name="g">����</param>
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