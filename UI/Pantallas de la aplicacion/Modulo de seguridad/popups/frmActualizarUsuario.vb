Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text
Imports System.Security.Cryptography
Imports System.Text

Public Class frmActualizarUsuario

    Public idUsuario As Integer
    Public Usuario As New Usuario
    Dim result As DialogResult
    Dim cambio As Boolean


    Private gestorValidaciones As New GestorValidaciones
    Private Sub frmActualizarTipoDeBeca_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim contenedor As Panel = pnlModificarUsuario
        gestorValidaciones.activarValidaciones(contenedor)

        Try

            Usuario = gestorUsuario.consultarUsuario(idUsuario)

            txtNombre1.Text = Usuario.Nombre
            txtNombre2.Text = Usuario.SegundoNombre
            txtApellido1.Text = Usuario.PrimerApellido
            txtApellido2.Text = Usuario.SegundoApellido
            txtCorreo.Text = Usuario.Correo
            txtCedula.Text = Usuario.Cedula
            txtTelefono.Text = Usuario.Telefono

            actualizarComboBox()

            cmbEstado.Text = Usuario.NombreEstado


            If Usuario.Genero = "M" Then

                cmbGenero.Text = "Masculino"
            Else
                cmbGenero.Text = "Femenino"
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub actualizarComboBox()

        Try

            cmbEstado.DataSource = gestorUsuario.consultarEstados
            cmbEstado.DisplayMember = "estado"
            cmbEstado.ValueMember = "id_estado"

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()
        actualizarComboBox()

    End Sub

    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim contenedor As Panel = pnlModificarUsuario

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            agregarUsuario()
        End If

    End Sub

    Private Sub agregarUsuario()

        Dim nombre = txtNombre1.Text
        Dim nombre2 = txtNombre2.Text
        Dim apellido = txtApellido1.Text
        Dim apellido2 = txtApellido2.Text
        Dim correo = txtCorreo.Text
        Dim cedula = txtCedula.Text
        Dim telefono = txtTelefono.Text
        Dim estado
        Dim genero

        Try

            If cmbGenero.Text = "Masculino" Then
                genero = "M"
            Else
                genero = "F"
            End If

            If cambio = True Then
                estado = cmbEstado.SelectedValue
            Else
                estado = Usuario.Estado
            End If

            gestorUsuario.editarUsuario(idUsuario, nombre, apellido, genero, correo, cedula,
                                        estado, nombre2, apellido2, telefono)

            MessageBox.Show(Usuario.Nombre + " " + Usuario.PrimerApellido + " ha sido modificado exitosamente", "Modificar usuario", MessageBoxButtons.OK)
            Me.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub updateEstado(sender As Object, e As EventArgs) Handles cmbEstado.Click

        actualizarComboBox()
        cambio = True

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click


        result = MessageBox.Show("¿Realmente desea modificar la contraseña de este usuario?", "Generar Contraseña", MessageBoxButtons.YesNo)

        Try

            If result = System.Windows.Forms.DialogResult.Yes Then

                Dim contra = Usuario.randomPass(5).ToString

                Dim contra_segura = getSHA1Hash(contra)

                gestorUsuario.editarContraUsuario(idUsuario, contra_segura)
                enviarCorreo(contra, txtCorreo.Text)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        'SE DEBE DE IMPLEMENTAR UNA FORMA DE CONTACTAR AL USUARIO CON SU NUEVA CONTRA!

    End Sub

    Function getSHA1Hash(ByVal strToHash As String) As String

        Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult

    End Function

    Private Sub enviarCorreo(contra As String, correo As String)

        gestorCorreo.enviarCorreo(correo, "BECADEMIC- Nueva Contraseña", "Su contraseña a sido cambiada a " + contra)

    End Sub


End Class