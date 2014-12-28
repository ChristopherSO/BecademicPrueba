Imports EntitiesLayer
Public Class frmActualizarCarrera

    Public idCarreraActual As Integer
    Private gestorValidaciones As New GestorValidaciones

    Private Sub frmActualizarCarrera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actualizarDatos()
        Dim contenedor As Panel = pnlActualizarCarrera
        gestorValidaciones.activarValidaciones(contenedor)
    End Sub
    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim contenedor As Panel = pnlActualizarCarrera

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            modificarCarrera()
        End If


      

    End Sub

    Public Sub modificarCarrera()

        Dim result As DialogResult

        result = MessageBox.Show("¿Realmente desea editar esta carrera?", "Editar carrera", MessageBoxButtons.YesNo)

        If result = System.Windows.Forms.DialogResult.Yes Then

            Try
                Dim nombre As String = txtNombre.Text
                Dim descripcion As String = txtDescripcion.Text
                Dim icono As String = txtIcono.Text
                Dim color As String = txtColor.Text
                gestorCarrera.editarCarrera(idCarreraActual, nombre, descripcion, icono, color)
                MessageBox.Show("Se ha editado carrera exitosamente", "Modificar carrera", MessageBoxButtons.OK)

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If
    End Sub



    Private Sub actualizarDatos()

        Try

            Dim carrera As New Carrera()
            carrera = CarreraRepository.Instance.GetById(idCarreraActual)
            txtNombre.Text = carrera.Nombre
            txtDescripcion.Text = carrera.Descripcion
            txtIcono.Text = carrera.Icono
            txtColor.Text = carrera.Color

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    
End Class