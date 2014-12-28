Imports EntitiesLayer
Public Class uCRequisitos

    Private idRequisito As Integer
    Dim row As Integer
    Public Sub onControlLoad() Handles MyBase.Load

        Me.Dock = DockStyle.Fill
        actualizardatagrid()

        idRequisito = 0

        btnAgregarRequisito.Visible = gestorAuth.tieneElPermiso(11)
        btnActualizarRequisito.Visible = gestorAuth.tieneElPermiso(12)
        btnBorrarRequisito.Visible = gestorAuth.tieneElPermiso(13)

    End Sub


    Public Sub actualizardatagrid()
        Try
            Dim lstRequisito As IEnumerable = gestorRequisito.consultarRequisitos
            gridListaDatos.Rows.Clear()
            For Each requisito As Requisito In lstRequisito
                gridListaDatos.Rows.Add(requisito.Id, requisito.TipoRequisito.Nombre, requisito.Nombre, requisito.Descripcion)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnAgregarRequisito_Click_1(sender As Object, e As EventArgs) Handles btnAgregarRequisito.Click

        Try

            Dim formularioAgregar As frmAgregarRequisito = New frmAgregarRequisito
            formularioAgregar.ShowDialog(Me)
            actualizardatagrid()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnActualizarRequisito_Click_1(sender As Object, e As EventArgs) Handles btnActualizarRequisito.Click


        If idRequisito = 0 Then

            MessageBox.Show("Seleccione un requisito ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Try
                row = gridListaDatos.CurrentRow.Index
                frmActualizarRequisito.ID = CType(gridListaDatos.Item(0, row).Value, Integer)
                frmActualizarRequisito.ShowDialog(Me)
                actualizardatagrid()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub btnBorrarRequisito_Click_1(sender As Object, e As EventArgs) Handles btnBorrarRequisito.Click

        Dim result As DialogResult
        Dim row As Integer

        If idRequisito = 0 Then

            MessageBox.Show("Seleccione un requisito ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Try
                result = MessageBox.Show("¿Realmente desea borrar este requisito?", "Borrar requisito", MessageBoxButtons.YesNo)
                If result = System.Windows.Forms.DialogResult.Yes Then
                    row = gridListaDatos.CurrentRow.Index
                    gestorRequisito.eliminarRequisito(CInt(gridListaDatos.Item(0, row).Value))
                    actualizardatagrid()
                    idRequisito = 0
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub gridListaDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridListaDatos.CellClick

        idRequisito = gridListaDatos.Item(0, row).Value


    End Sub

End Class
