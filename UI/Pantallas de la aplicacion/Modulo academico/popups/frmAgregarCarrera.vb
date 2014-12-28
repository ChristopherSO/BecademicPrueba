Public Class frmAgregarCarrera

    Private gestorValidaciones As New GestorValidaciones
    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim contenedor As Panel = pnlAgregarCarrera

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            agregarCarrera()
        End If

    End Sub

    Private Sub agregarCarrera()

        Try
            Dim nombre As String = txtNombre.Text
            Dim descripcion As String = txtDescripcion.Text
            Dim icono As String = txtIcono.Text
            Dim color As String = txtColor.Text
            gestorCarrera.agregarCarrera(nombre, descripcion, icono, color)
            MessageBox.Show("Nueva carrera agregada exitosamente", "Ingreso de carrera", MessageBoxButtons.OK)
            Me.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub frmAgregarCarrera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim contenedor As Panel = pnlAgregarCarrera
        gestorValidaciones.activarValidaciones(contenedor)
    End Sub
End Class