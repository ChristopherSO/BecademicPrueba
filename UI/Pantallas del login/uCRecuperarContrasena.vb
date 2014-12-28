Imports EntitiesLayer

Public Class uCRecuperarContrasena

    Dim validacionCorreo As Boolean = False
    Dim Usuario As New Usuario

    Public Sub onControlLoad() Handles MyBase.Load

        Me.Dock = DockStyle.Fill

    End Sub

    Private Sub onRecuperar(sender As Object, e As EventArgs) Handles btnRecuperar.Click
        If (validacionCorreo = False) Then
            validarCorreo()
        End If

        If (validacionCorreo = True) Then

            Dim contra As String = Usuario.randomPass(5).ToString
            Dim contra_segura = getSHA1Hash(contra)
            Dim correo = txtCorreo.Text
            lblMensajeError.Visible = False
            gestorUsuario.editarContraCorreo(correo, contra_segura)
            gestorCorreo.enviarCorreo(correo, "BECADEMIC- Nueva Contraseña", "Su contraseña a sido cambiada a " + contra)
            MessageBox.Show("Una nueva contraseña le ha sido enviada por correo electrónico.", "Becademic", MessageBoxButtons.OK)
            txtCorreo.Clear()

        End If

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

    Private Sub onVolver(sender As Object, e As EventArgs) Handles lblVolver.Click

        Login.cambiarPantalla(New uCLogin)

    End Sub

    Public Sub validarCorreo()

        Dim correoInvalido As Boolean = False
        Dim lstCorreo As IEnumerable = gestorUsuario.consultarUsuario
        For Each correo As Usuario In lstCorreo
            If (correo.Correo = txtCorreo.Text) Then
                'MsgBox("Una nueva contaseña le ha sido enviada por correo electrónico.")
                correoInvalido = True
                validacionCorreo = True
            End If
        Next
        If (correoInvalido = False And txtCorreo.Text = "") Then
            lblMensajeError.Text = "*Por favor ingresar su correo."
            lblMensajeError.Visible = True
        Else
            lblMensajeError.Text = "*El correo ingresado no existe."
            lblMensajeError.Visible = True
        End If

    End Sub
End Class
