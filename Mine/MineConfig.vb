Public Class StatConfig

	Private configFileName As String

	Private _colCount As Integer
	Public Property ColCount() As Integer
		Get
			Return _colCount
		End Get
		Set(ByVal value As Integer)
			If value >= 5 AndAlso value <= 40 Then _colCount = value
		End Set
	End Property

	Private _rowCount As Integer
	Public Property RowCount() As Integer
		Get
			Return _rowCount
		End Get
		Set(ByVal value As Integer)
			If value >= 5 AndAlso value <= 30 Then _rowCount = value
		End Set
	End Property

	Private _mineCount As Integer
	Public Property MineCount() As Integer
		Get
			If _mineCount >= _colCount * _rowCount Then _mineCount = 0
			Return _mineCount
		End Get
		Set(ByVal value As Integer)
			If value >= 5 AndAlso value <= 1000 Then _mineCount = value
		End Set
	End Property

	Private _formRect As Rectangle
	Public Property FormRect() As Rectangle
		Get
			Return _formRect
		End Get
		Set(ByVal value As Rectangle)
			_formRect = value
		End Set
	End Property

	Private _ranking(2) As RankingItem
	Public Property RankIng(ByVal index As Integer) As RankingItem
		Get
			Return _ranking(index)
		End Get
		Set(ByVal value As RankingItem)
			_ranking(index) = value
		End Set
	End Property

	Public Sub New()
		_colCount = 9
		_rowCount = 9
		_mineCount = 10

		For i As Integer = 0 To 2
			_ranking(i) = New RankingItem
		Next

		configFileName = IO.Path.GetDirectoryName(Application.ExecutablePath)
		If Microsoft.VisualBasic.Right(configFileName, 1) <> "\" Then configFileName += "\"
		configFileName += "config.xml"

		ReadConfig()

		If _formRect.X < 0 Then _formRect.X = 0
		If _formRect.X > Screen.PrimaryScreen.Bounds.Width Then _formRect.X = 0
		If _formRect.Y < 0 Then _formRect.Y = 0
		If _formRect.Y > Screen.PrimaryScreen.Bounds.Height Then _formRect.Y = 0

		If _formRect.Width <= 0 Then _formRect.Width = 300
		If _formRect.Width > Screen.PrimaryScreen.Bounds.Width Then _formRect.Width = 300
		If _formRect.Height <= 0 Then _formRect.Height = 350
		If _formRect.Height > Screen.PrimaryScreen.Bounds.Height Then _formRect.Height = 350
	End Sub

	''' <summary>
	''' 从配置文件中读取配置
	''' </summary>
	''' <remarks></remarks>
	Private Sub ReadConfig()
		If IO.File.Exists(configFileName) Then
			Dim configXMLDocument As New Xml.XmlDocument
			Try
				configXMLDocument.Load(configFileName)
				Dim stateNode As Xml.XmlNode = configXMLDocument.SelectSingleNode("config/state")
				If stateNode IsNot Nothing Then
					Me._colCount = GetIntegerFromAttrib(stateNode, "colcount")
					Me._rowCount = GetIntegerFromAttrib(stateNode, "rowcount")
					Me._mineCount = GetIntegerFromAttrib(stateNode, "minecount")
					Me._formRect.X = GetIntegerFromAttrib(stateNode, "formleft")
					Me._formRect.Y = GetIntegerFromAttrib(stateNode, "formtop")
					Me._formRect.Width = GetIntegerFromAttrib(stateNode, "formwidth")
					Me._formRect.Height = GetIntegerFromAttrib(stateNode, "formheight")
				End If

				GetRanking(configXMLDocument)

			Catch ex As Exception

			End Try
		End If
	End Sub

	Private Function GetIntegerFromAttrib(ByVal node As Xml.XmlNode, ByVal name As String) As Integer
		Dim attrib As Xml.XmlAttribute = node.Attributes.ItemOf(name)
		If attrib IsNot Nothing AndAlso IsNumeric(attrib.Value) Then
			Return CInt(attrib.Value)
		End If
		Return 0
	End Function

	Private Sub GetRanking(ByVal xmldoc As Xml.XmlDocument)
		For i As Integer = 0 To 2
			Dim rankingNode As Xml.XmlNode = xmldoc.SelectSingleNode("config/rankings/ranking" + i.ToString)
			If rankingNode IsNot Nothing Then
				Dim attrib As Xml.XmlAttribute = rankingNode.Attributes.ItemOf("name")
				If attrib IsNot Nothing Then
					Me._ranking(i).Name = attrib.Value
					Me._ranking(i).Time = GetIntegerFromAttrib(rankingNode, "time")
				End If
			End If
		Next
	End Sub

	Public Sub SaveConfig()
		Try

			Dim x As New Xml.XmlTextWriter(configFileName, System.Text.Encoding.UTF8)
			x.Formatting = Xml.Formatting.Indented
			x.WriteStartDocument()
			x.WriteStartElement("config")

			x.WriteStartElement("state")

			x.WriteStartAttribute("colcount")
			x.WriteValue(Me._colCount)
			x.WriteEndAttribute()

			x.WriteStartAttribute("rowcount")
			x.WriteValue(Me._rowCount)
			x.WriteEndAttribute()

			x.WriteStartAttribute("minecount")
			x.WriteValue(Me._mineCount)
			x.WriteEndAttribute()

			x.WriteStartAttribute("formleft")
			x.WriteValue(Me._formRect.X)
			x.WriteEndAttribute()

			x.WriteStartAttribute("formtop")
			x.WriteValue(Me._formRect.Y)
			x.WriteEndAttribute()

			x.WriteStartAttribute("formwidth")
			x.WriteValue(Me._formRect.Width)
			x.WriteEndAttribute()

			x.WriteStartAttribute("formheight")
			x.WriteValue(Me._formRect.Height)
			x.WriteEndAttribute()

			x.WriteEndElement()

			x.WriteStartElement("rankings")

			For i As Integer = 0 To 2
				x.WriteStartElement("ranking" + i.ToString)
				If Not String.IsNullOrEmpty(Me._ranking(i).Name) Then
					x.WriteStartAttribute("name")
					x.WriteValue(Me._ranking(i).Name)
					x.WriteEndAttribute()
					x.WriteStartAttribute("time")
					x.WriteValue(Me._ranking(i).Time)
					x.WriteEndAttribute()
				End If
				x.WriteEndElement()
			Next

			x.WriteEndElement()

			x.WriteEndElement()
			x.WriteEndDocument()

			x.Flush()
			x.Close()

		Catch
		End Try
	End Sub
End Class

Public Class RankingItem

	Private _name As String
	Public Property Name() As String
		Get
			Return _name
		End Get
		Set(ByVal value As String)
			_name = value
		End Set
	End Property

	Private _time As Integer = 999
	Public Property Time() As Integer
		Get
			Return _time
		End Get
		Set(ByVal value As Integer)
			_time = value
		End Set
	End Property

	Public Sub New()
		_name = String.Empty
	End Sub

	Public Sub New(ByVal name As String, ByVal time As Integer)
		_name = name
		_time = time
	End Sub
End Class
