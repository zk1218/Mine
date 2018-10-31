Public Class frmOption

	Private Sub txtColCount_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColCount.ValueChanged, txtRowCount.ValueChanged
		txtMineCount.Maximum = txtColCount.Value * txtRowCount.Value - 10
	End Sub

End Class