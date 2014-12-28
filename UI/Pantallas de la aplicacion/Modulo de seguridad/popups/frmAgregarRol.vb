Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text
Public Class frmAgregarRol

    Public idRol As Integer
    Dim nombreRol As String
    Dim result As DialogResult
    Dim Rol As RolUsuario
    Dim cambio As Boolean

    Private gestorValidaciones As New GestorValidaciones
    Private Sub frmActualizarRol_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim contenedor As Panel = pnlAgregarRol
        gestorValidaciones.activarValidaciones(contenedor)
        actualizarComboBox()


    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim contenedor As Panel = pnlAgregarRol

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            agregarRol()
        End If



    End Sub

    Private Sub agregarRol()

        Dim nombre As String = txtNombre.Text
        Dim descripcion As String = txtDescripcion.Text
        Dim fase As String = cmbFase.SelectedValue

        Try

            gestorRol.agregarRol(nombre, descripcion, fase)
            MessageBox.Show("Nuevo rol agregado exitosamente", "Registrar Rol", MessageBoxButtons.OK)
            limpiarText()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

    Private Sub actualizarComboBox()

        Try

            cmbFase.DataSource = gestorRol.consultarFases
            cmbFase.DisplayMember = "nombre_fase"
            cmbFase.ValueMember = "id_intervencion"

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub limpiarText()

        txtNombre.Clear()
        txtDescripcion.Clear()
        cmbFase.Refresh()

    End Sub

End Class