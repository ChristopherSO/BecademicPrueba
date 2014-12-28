Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text
Imports System.Security.Cryptography
Imports System.Text

Public Class frmAgregarUsuario

    Private gestorValidaciones As New GestorValidaciones
    Private Sub frmAgregarUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim contenedor As Panel = pnlAgregarUsuario
        gestorValidaciones.activarValidaciones(contenedor)

        actualizarComboBox()
        cmbGenero.Text = "Masculino"

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

        Dim contenedor As Panel = pnlAgregarUsuario

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            agregarUsuario()
        End If

    End Sub

    Private Sub agregarUsuario()

        Dim Usuario As New Usuario

        Dim nombre As String = txtNombre1.Text
        Dim nombre_2 As String = txtNombre2.Text
        Dim apellido1 As String = txtApellido1.Text
        Dim genero As String
        Dim correo As String = txtCorreo.Text
        Dim contra As String = Usuario.randomPass(5).ToString
        Dim cedula As Integer = Convert.ToInt32(txtCedula.Text)
        Dim estado As Integer = cmbEstado.SelectedValue
        Dim apellido2 As String = txtApellido2.Text
        Dim telefono As String = txtTelefono.Text

        Dim contra_segura = getSHA1Hash(contra)

        Try

            If cmbGenero.Text = "Masculino" Then
                genero = "M"
            Else
                genero = "F"
            End If


            gestorUsuario.agregarUsuario(nombre, apellido1, genero, correo, contra_segura, cedula, estado, nombre_2, apellido2, telefono)
            MessageBox.Show("Nuevo usuario agregado exitosamente", "Registrar usuarios", MessageBoxButtons.OK)
            enviarCorreo(correo, contra)
            limpiarText()


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

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

    Private Sub limpiarText()

        txtNombre1.Clear()
        txtNombre2.Clear()
        txtApellido1.Clear()
        txtCorreo.Clear()
        txtCedula.Clear()
        cmbEstado.Refresh()
        txtApellido2.Clear()
        txtTelefono.Clear()

    End Sub

    Private Sub enviarCorreo(pcorreo As String, pcontra As String)

        gestorCorreo.enviarCorreo(pcorreo, "BECADEMIC- Bienvenido \|T|/", "Gracias por utilizar nuestro sistema de becas, su clave de acceso es " + pcontra)

    End Sub

End Class