Imports EntitiesLayer
Public Class frmAdministrarDirectoresCarrera

    Public idCarreraActual As Integer
    Public idDirectorActual As Integer
    Dim row As Integer
    Private gestorValidaciones As New GestorValidaciones
    Private Sub onfrmAdministrarDirectoresCarrera_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim contenedor As Panel = pnlAdministrarDirectores
        gestorValidaciones.activarValidaciones(contenedor)
        Me.Dock = DockStyle.Fill
        actualizarCmbDirectores()
        actualizarDatagrid()
    End Sub

    Private Sub onCancelar(sender As Object, e As EventArgs)

        Me.Close()

    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If (cmbListaDirectores.Text = "Seleccione un director académico a asignar...") Then

            MessageBox.Show("Debe seleccionar un director académico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            Try

                Dim idUsuario As Integer = cmbListaDirectores.SelectedValue
                gestorCarrera.agregarDirectorACarrera(idUsuario, idCarreraActual)
                MessageBox.Show("Se ha asignado un director académico", "Información", MessageBoxButtons.OK)
                actualizarDatagrid()
            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try


        End If


    End Sub

    Private Sub actualizarCmbDirectores()

        Try
            cmbListaDirectores.DataSource = gestorCarrera.consultarDirectoresAcademicos()
            cmbListaDirectores.ValueMember = "Id"
            cmbListaDirectores.DisplayMember = "Nombre"




        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub actualizarDatagrid()
        cmbListaDirectores.Text = "(Seleccione un director académico a asignar...)"

        Try

            Dim lstDirectoresAsignados As IEnumerable = gestorCarrera.consultarDirectoresPorCarrera(idCarreraActual)
            dgvDirectores.Rows.Clear()
            For Each usuario As Usuario In lstDirectoresAsignados
                dgvDirectores.Rows.Add(usuario.Id, usuario.Nombre, usuario.PrimerApellido)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub onDgvDirectores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDirectores.CellClick
        Dim row As Integer
        row = dgvDirectores.CurrentRow.Index
        idDirectorActual = dgvDirectores.Item(0, row).Value
    End Sub

    Private Sub onBtnBorrarAsignacion_Click(sender As Object, e As EventArgs) Handles btnBorrarAsignacion.Click

        Dim result As DialogResult

        result = MessageBox.Show("¿Realmente desea quitar el director académico de la carrera?", "Quitar director de  carrera", MessageBoxButtons.YesNo)

        If result = System.Windows.Forms.DialogResult.Yes Then
            Try
                gestorCarrera.eliminarDirectorDeCarrera(idCarreraActual, idDirectorActual)
                actualizarDatagrid()
                MessageBox.Show("Se ha eliminado el director académico de la carrera exitosamente", "Información", MessageBoxButtons.OK)
            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub
End Class