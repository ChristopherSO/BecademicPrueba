Public Class frmAgregarDirectorCarrera

    Public Sub onControlLoad() Handles MyBase.Load

        Me.Dock = DockStyle.Fill

        DataGridView1.Rows.Add("Programación 1", "BISOFT-01")
        DataGridView1.Rows.Add("Programación 2", "BISOFT-02")
        DataGridView1.Rows.Add("Patrones", "BISOFT-05")

    End Sub

    Private Sub onCellContenteClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 Then

            Select Case senderGrid.Columns.Item(e.ColumnIndex).Name

                Case "colAccionBorrar"
                    MessageBox.Show("¿Realmente desea desasignar este curso?", "Desasignar curso", MessageBoxButtons.YesNo)

            End Select

        End If

    End Sub

End Class