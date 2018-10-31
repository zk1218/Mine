''' <summary>
''' �����е�ש����
''' </summary>
''' <remarks>һ��ʵ������һ��ש�飬��ש���¿������ף�Ҳ����û��</remarks>
Public Class Block

	''' <summary>
	''' ש��״̬ö��
	''' </summary>
	''' <remarks></remarks>
	Public Enum EBlockState
		''' <summary>
		''' ����
		''' </summary>
		''' <remarks></remarks>
		General

		''' <summary>
		''' �Ѿ���
		''' </summary>
		''' <remarks></remarks>
		Opened

		''' <summary>
		''' ���
		''' </summary>
		''' <remarks></remarks>
		Mark

		''' <summary>
		''' �ʺ�
		''' </summary>
		''' <remarks></remarks>
		Question
	End Enum

	''' <summary>
	'''״̬�����¼�
	''' </summary>
	''' <param name="sender">�������¼���ש��</param>
	''' <param name="oldState">����ǰ��״̬</param>
	''' <param name="newState">���ĺ��״̬</param>
	''' <remarks>��ʵ����״̬���Է����ı�ʱ����</remarks>
	Public Event StateChange(ByVal sender As Block, ByVal oldState As EBlockState, ByVal newState As EBlockState)

	Private _existMine As Boolean
	''' <summary>
	''' ���û򷵻ظ�ש�����Ƿ��������
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ExistMine() As Boolean
		Get
			Return _existMine
		End Get
		Set(ByVal value As Boolean)
			_existMine = True
		End Set
	End Property

	Private _aroundMineCount As Integer
	''' <summary>
	''' ���û򷵻�����Χ�׵�����
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks>����ש�鷭�������ʾ����</remarks>
	Public Property AroundMineCount() As Integer
		Get
			Return _aroundMineCount
		End Get
		Set(ByVal value As Integer)
			_aroundMineCount = value
		End Set
	End Property


	Private _blockRect As RectangleF
	''' <summary>
	''' ���û򷵻�ש���λ�úʹ�С
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BlockRect() As RectangleF
		Get
			Return _blockRect
		End Get
		Set(ByVal value As RectangleF)
			_blockRect = value
		End Set
	End Property

	Private _colIndex As Integer
	''' <summary>
	''' ���û򷵻�����������
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ColIndex() As Integer
		Get
			Return _colIndex
		End Get
		Set(ByVal value As Integer)
			_colIndex = value
		End Set
	End Property

	Private _rowIndex As Integer
	''' <summary>
	''' ���û򷵻�����������
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property RowIndex() As Integer
		Get
			Return _rowIndex
		End Get
		Set(ByVal value As Integer)
			_rowIndex = value
		End Set
	End Property

	Private _state As EBlockState
	''' <summary>
	''' ���û򷵻�״̬
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks>���ø����Խ����� StateChange �¼�</remarks>
	Public Property State() As EBlockState
		Get
			Return _state
		End Get
		Set(ByVal value As EBlockState)
			If _state <> value Then
				Dim oldState As EBlockState = _state
				_state = value
				RaiseEvent StateChange(Me, oldState, value)
			End If
		End Set
	End Property

	Private _opening As Boolean
	''' <summary>
	''' ���û򷵻ذ���״̬
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks>�����Ա�ʾ��ֻ��ש��İ���״̬��ֻ��Ϊʵ����ʾЧ�����裬�� State ���Ե�״̬�޹�</remarks>
	Public Property Opening() As Boolean
		Get
			Return _opening
		End Get
		Set(ByVal value As Boolean)
			_opening = value
		End Set
	End Property

	''' <summary>
	''' ����ש�飬������������������
	''' </summary>
	''' <remarks>�÷�������Ϸ����ʱ���ã�������״̬�����¼����Ա�������ѭ������</remarks>
	Public Sub Pong()
		Me._state = EBlockState.Opened
	End Sub

	''' <summary>
	''' ���Ϊ��
	''' </summary>
	''' <remarks>�÷�������Ϸ����ʱ���ã�������״̬�����¼����Ա�������ѭ������</remarks>
	Public Sub Mark()
		Me._state = EBlockState.Mark
	End Sub

	''' <summary>
	''' ������Ļ��
	''' </summary>
	''' <param name="gValue"></param>
	''' <remarks></remarks>
	Public Sub Print(ByVal gValue As Graphics)
		Dim left As Single = _blockRect.Left
		Dim top As Integer = _blockRect.Top

		Dim upLeft As PointF = _blockRect.Location
		Dim upRight As New PointF(_blockRect.Left + _blockRect.Width, _blockRect.Top)
		Dim bottomLeft As New PointF(_blockRect.Left, _blockRect.Top + _blockRect.Height)
		Dim bottomRight As New PointF(_blockRect.Left + _blockRect.Width, _blockRect.Top + _blockRect.Height)

		Dim blockBackground As Brush = New Drawing2D.LinearGradientBrush(BlockRect, Color.Ivory, Color.Gray, Drawing2D.LinearGradientMode.ForwardDiagonal)
		Dim leftPen As Pen = Pens.White
		Dim topPen As Pen = Pens.White
		Dim rightPen As Pen = Pens.Black
		Dim bottomPen As Pen = Pens.Black

		If Me.Opening Then
			blockBackground = Brushes.Goldenrod
			leftPen = Pens.Black
			topPen = Pens.Black
			rightPen = Pens.White
			bottomPen = Pens.White
		Else
			Select Case _state
				Case EBlockState.Opened
					If _existMine Then
						blockBackground = New Drawing2D.LinearGradientBrush(BlockRect, Color.Red, Color.Ivory, Drawing2D.LinearGradientMode.ForwardDiagonal)
					Else
						blockBackground = New Drawing2D.LinearGradientBrush(BlockRect, Color.Goldenrod, Color.Ivory, Drawing2D.LinearGradientMode.ForwardDiagonal)
					End If
					leftPen = Pens.Black
					topPen = Pens.Black
					rightPen = Pens.White
					bottomPen = Pens.White
				Case EBlockState.Mark
					blockBackground = New Drawing2D.LinearGradientBrush(BlockRect, Color.Ivory, Color.Green, Drawing2D.LinearGradientMode.ForwardDiagonal)
				Case EBlockState.Question
					blockBackground = New Drawing2D.LinearGradientBrush(BlockRect, Color.Ivory, Color.Yellow, Drawing2D.LinearGradientMode.ForwardDiagonal)
			End Select
		End If

		gValue.FillRectangle(blockBackground, BlockRect)

		gValue.DrawLine(leftPen, upLeft, upRight)
		gValue.DrawLine(topPen, upLeft, bottomLeft)
		gValue.DrawLine(rightPen, upRight, bottomRight)
		gValue.DrawLine(bottomPen, bottomLeft, bottomRight)

		Dim fontName As String = "Webdings"
		Dim fontColor As Brush = Brushes.Black

		Dim drawString As String = String.Empty
		Select Case _state
			Case EBlockState.Opened
				If Me._existMine Then
					drawString = "+"
				Else
					drawString = IIf(Me._aroundMineCount > 0, _aroundMineCount.ToString, String.Empty)
					fontName = "Arial Black" ' "Verdana"
					fontColor = Choose(Me._aroundMineCount, Brushes.Blue, Brushes.Green, Brushes.Red, Brushes.Navy, Brushes.Maroon, Brushes.Teal, Brushes.Black, Brushes.Gray)
				End If
			Case EBlockState.Mark
				drawString = "~"
			Case EBlockState.Question
				drawString = "s"
		End Select

		If Not String.IsNullOrEmpty(drawString) Then
			Dim drawFormat As New StringFormat
			drawFormat.Alignment = StringAlignment.Center
			drawFormat.LineAlignment = StringAlignment.Center
			Dim fontSize As Single = Me._blockRect.Width
			If Me._blockRect.Width > Me._blockRect.Height Then fontSize = Me._blockRect.Height
			fontSize /= 2
			If fontSize < 9 Then fontSize = 9
			gValue.DrawString(drawString, New Font(fontName, fontSize), fontColor, BlockRect, drawFormat)
		End If
	End Sub
End Class