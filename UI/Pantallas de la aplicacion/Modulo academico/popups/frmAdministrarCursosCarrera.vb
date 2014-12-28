Imports EntitiesLayer
Public Class frmAdministrarCursosCarrera

    Public idCarreraActual As Integer
    Public idCursoActual As Integer
    Public idCursoPrimerDGV As Integer
    Dim row1 As Integer
    Dim row2 As Integer

    Private gestorValidaciones As New GestorValidaciones
    Private Sub frmAgregarCursoCarrera_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim contenedor As Panel = pnlAdministrarCursos
        gestorValidaciones.activarValidaciones(contenedor)
        Me.Dock = DockStyle.Fill
        actualizarDgvCursos()
        actualizarDatagrid()
    End Sub

    Private Sub onCancelar(sender As Object, e As EventArgs)

        Me.Close()

    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnAsignar.Click

        Dim contenedor As Panel = pnlContenidoPrincipal

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            Try

                Dim periodo As Integer = txtPeriodo.Text
                gestorCarrera.agregarCursoACarrera(idCursoActual, idCarreraActual, periodo)
                MessageBox.Show("Se ha asignado el curso a la carrera", "Información", MessageBoxButtons.OK)
                actualizarDatagrid()
            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try
        End If

    End Sub

    Private Sub onDgvCursos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCursos.CellClick
        Dim row1 As Integer
        row1 = dgvCursos.CurrentRow.Index
        idCursoActual = dgvCursos.Item(0, row1).Value
    End Sub



    Private Sub actualizarDgvCursos()

        Try

            Dim lstCursos As IEnumerable = gestorCurso.consultarCursos()
            dgvCursos.Rows.Clear()
            For Each curso As Curso In lstCursos
                dgvCursos.Rows.Add(curso.Id, curso.Nombre)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    Public Sub actualizarDatagrid()

        Try

            Dim lstCursosAsignados As IEnumerable = gestorCarrera.consultarCursosPorCarrera(idCarreraActual)
            dgvCursosAsignados.Rows.Clear()
            For Each curso As Curso In lstCursosAsignados
                dgvCursosAsignados.Rows.Add(curso.Id, curso.Nombre)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try


    End Sub

    Private Sub onDgvCursosAsignados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCursosAsignados.CellClick
        Dim row2 As Integer
        row2 = dgvCursosAsignados.CurrentRow.Index
        idCursoPrimerDGV = dgvCursosAsignados.Item(0, row2).Value
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnBorrarAsignacion_Click(sender As Object, e As EventArgs) Handles btnBorrarAsignacion.Click
        Dim result As DialogResult

        result = MessageBox.Show("¿Realmente desea quitar el curso?", "Quitar curso de una carrera", MessageBoxButtons.YesNo)

        If result = System.Windows.Forms.DialogResult.Yes Then
            Try
                gestorCarrera.eliminarCursoDeCarrera(idCursoPrimerDGV, idCarreraActual)
                actualizarDatagrid()
                MessageBox.Show("Se ha eliminado el curso de la carrera exitosamente", "Información", MessageBoxButtons.OK)
            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try
        End If
    End Sub
End Class