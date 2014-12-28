Public Class frmAgregarCalificacion

    Public idUsuario As Integer
    Private gestorValidaciones As New GestorValidaciones

    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim contenedor As Panel = pnlAgregarCalificacion

        If (GestorValidaciones.camposEstanValidos(contenedor)) Then
            agregarCalificacion()
        End If

    End Sub

    Private Sub frmAgregarCalificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim contenedor As Panel = pnlAgregarCalificacion
        gestorValidaciones.activarValidaciones(contenedor)
        llenarCamposComboBox()

    End Sub

    Private Sub agregarCalificacion()

        Try

            gestorCalificaciones.agregarCalificacion(idUsuario, cmbCursos.SelectedValue, txtCalificacion.Text, txtPeriodo.Text, txtAnnio.Text, txtComentarioAdicionales.Text)
            MessageBox.Show("Se ha agregado una nueva calificación exitosamente", "Agregar Calificación", MessageBoxButtons.OK)
            Me.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    Private Sub llenarCamposComboBox()

        Try

            cmbCursos.DataSource = gestorCurso.consultarCursos()
            cmbCursos.DisplayMember = "Nombre"
            cmbCursos.ValueMember = "Id"

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

End Class