Imports EntitiesLayer

Public Class uCCursos

    Public Sub onControlLoad() Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        ActualizarTabla()
    End Sub

    Private Sub ActualizarTabla()
        Dim listaCursos As IEnumerable = gestorCurso.consultarCursos
        gridListaDatos.Rows.Clear()
        For Each curso As Curso In listaCursos
            gridListaDatos.Rows.Add(curso.Id, curso.Nombre, curso.Codigo, curso.Precio, curso.CantidadCreditos)
        Next
    End Sub

    Private Sub onClickAgregarCurso(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmAgregarCurso.ShowDialog(Me)
        ActualizarTabla()
    End Sub

    Private Sub onClickActualizarCurso(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If gridListaDatos.SelectedRows.Count > 0 Then
            frmActualizarCurso.ID = CType(gridListaDatos.SelectedRows.Item(0).Cells(0).Value, Integer)
            frmActualizarCurso.ShowDialog(Me)
            ActualizarTabla()
        Else
            MessageBox.Show("Debe primero seleccionar una fila que desee actualizar", "Becademic mensaje", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub onClickEliminarCurso(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("¿Realmente desea borrar este curso?", "Borrar curso", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            gestorCurso.eliminarCurso(CType(gridListaDatos.SelectedRows.Item(0).Cells(0).Value, Integer))
            MessageBox.Show("El curso " & gridListaDatos.SelectedRows.Item(0).Cells(1).Value & " ha sido eliminado exitosamente")
            ActualizarTabla()
        End If
    End Sub

End Class
