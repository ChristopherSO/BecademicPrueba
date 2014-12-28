Public Class uCLogin

    Public Sub onControlLoad() Handles MyBase.Load

        Me.Dock = DockStyle.Fill

    End Sub

    Private Sub onIngresar(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Try

            Dim clave = getSHA1Hash(txtContrasena.Text)

            If (gestorAuth.validarIngreso(txtCorreo.Text, clave)) Then

                If gestorAuth.UsuarioActual.Estado = 1 Then

                    BecademicMain.Show()

                Else

                    MessageBox.Show("Los postulantes o usuarios inactivos no pueden ingresar", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            Else

                MessageBox.Show("Usuario o contraseña invalidos", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

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

    Private Sub onRecuperarContrasena(sender As Object, e As EventArgs) Handles lblRecuperarContraseña.Click

        Login.cambiarPantalla(New uCRecuperarContrasena)

    End Sub

End Class
