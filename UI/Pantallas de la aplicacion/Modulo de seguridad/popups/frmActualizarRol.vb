Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text
Public Class frmActualizarRol

    Public idRol As Integer
    Public nombreRol As String
    Dim result As DialogResult
    Dim Rol As RolUsuario
    Dim cambio As Boolean

    Private gestorValidaciones As New GestorValidaciones
    Private Sub frmActualizarRol_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblSubTitulo.Text = "Modificar " + nombreRol

        Dim contenedor As Panel = pnlAgregarTipoDeBeca
        gestorValidaciones.activarValidaciones(contenedor)

        Try

            Rol = gestorRol.consultarRol(idRol)

            If nombreRol <> "Administrador" And nombreRol <> "Estudiante" And nombreRol <> "Director académico" Then

                txtNombre.Text = Rol.Nombre
                txtNombre.ReadOnly = False

            Else

                txtNombre.Text = Rol.Nombre
                txtNombre.ReadOnly = True

            End If

            txtDescripcion.Text = Rol.Descripcion

            actualizarComboBox()

            cmbFase.Text = Rol.NombreFase
            

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim contenedor As Panel = pnlAgregarTipoDeBeca

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            agregarRol()
        End If

    End Sub

    Private Sub agregarRol()

        Dim nombre = txtNombre.Text
        Dim descrip = txtDescripcion.Text
        Dim fase

        Try

            If cambio = True Then
                fase = cmbFase.SelectedValue
            Else
                fase = Rol.Intervencion
            End If

            gestorRol.editarRol(idRol, nombre, descrip, fase)

            MessageBox.Show(Rol.Nombre + " ha sido modificado exitosamente", "Modificar rol", MessageBoxButtons.OK)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Me.Close()

    End Sub


    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

    Private Sub updateFases(sender As Object, e As EventArgs) Handles cmbFase.Click

        actualizarComboBox()
        cambio = True

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

End Class