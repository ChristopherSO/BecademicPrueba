Imports EntitiesLayer
Public Class uCCarreras

    Private idLineaSeleccionada As Integer
    Public Sub onControlLoad() Handles MyBase.Load

        Me.Dock = DockStyle.Fill
        actualizardatagrid()

        txtAgregarCarrera.Visible = gestorAuth.tieneElPermiso(15)
        btnModificar.Visible = gestorAuth.tieneElPermiso(16)
        btnBorrar.Visible = gestorAuth.tieneElPermiso(17)

    End Sub

    Private Sub actualizardatagrid()

        Try
            Dim listaCarrera As IEnumerable = gestorCarrera.consultarCarreras
            gridListaDatos.Rows.Clear()
            For Each carrera As Carrera In listaCarrera
                gridListaDatos.Rows.Add(carrera.Id, carrera.Nombre, carrera.Descripcion, carrera.Icono, carrera.Color)
            Next
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub onGridListaDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridListaDatos.CellClick
        Dim row As Integer
        row = gridListaDatos.CurrentRow.Index
        idLineaSeleccionada = gridListaDatos.Item(0, row).Value
    End Sub

    Private Sub onBtnAgregarCarrera_Click(sender As Object, e As EventArgs) Handles txtAgregarCarrera.Click

        Dim frmAgregarCarrera = New frmAgregarCarrera()

        Try
            frmAgregarCarrera.ShowDialog(Me)
            actualizardatagrid()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


    Private Sub onbBtnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        Dim result As DialogResult

        If idLineaSeleccionada > 0 Then

            result = MessageBox.Show("¿Realmente desea borrar esta carrera?", "Borrar carrera", MessageBoxButtons.YesNo)
            If result = System.Windows.Forms.DialogResult.Yes Then
                Try
                    gestorCarrera.eliminarCarrera(idLineaSeleccionada)
                    actualizardatagrid()
                    MessageBox.Show("Se ha eliminado la carrera exitosamente", "Eliminar carrera", MessageBoxButtons.OK)
                Catch ex As Exception

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            End If

        Else

            MessageBox.Show("Por favor seleccione una carrera primero", "Carreras", MessageBoxButtons.OK)

        End If

        

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        If idLineaSeleccionada > 0 Then

            frmActualizarCarrera.idCarreraActual = idLineaSeleccionada
            frmActualizarCarrera.ShowDialog(Me)
            actualizardatagrid()

        Else

            MessageBox.Show("Por favor seleccione una carrera primero", "Carreras", MessageBoxButtons.OK)

        End If
        
    End Sub

    Private Sub btnAsignarCursoCarrera_Click(sender As Object, e As EventArgs) Handles btnAdministrarCursos.Click

        If idLineaSeleccionada > 0 Then

            frmAdministrarCursosCarrera.idCarreraActual = idLineaSeleccionada
            frmAdministrarCursosCarrera.ShowDialog(Me)

        Else

            MessageBox.Show("Por favor seleccione una carrera primero", "Carreras", MessageBoxButtons.OK)

        End If
        
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdministrarDirectores.Click

        If idLineaSeleccionada > 0 Then

            frmAdministrarDirectoresCarrera.idCarreraActual = idLineaSeleccionada
            frmAdministrarDirectoresCarrera.ShowDialog(Me)

        Else

            MessageBox.Show("Por favor seleccione una carrera primero", "Carreras", MessageBoxButtons.OK)

        End If
        
    End Sub


End Class
