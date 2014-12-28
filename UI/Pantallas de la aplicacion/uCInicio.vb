Imports EntitiesLayer

Public Class uCInicio

    Private id_usuario As Integer

    Private Sub uCInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try


            txtNombre1.Text = gestorAuth.UsuarioActual.Nombre
            txtNombre2.Text = gestorAuth.UsuarioActual.SegundoNombre
            txtApellido1.Text = gestorAuth.UsuarioActual.PrimerApellido
            txtApellido2.Text = gestorAuth.UsuarioActual.SegundoApellido
            txtCorreo.Text = gestorAuth.UsuarioActual.Correo
            txtCedula.Text = gestorAuth.UsuarioActual.Cedula
            txtTelefono.Text = gestorAuth.UsuarioActual.Telefono
            id_usuario = gestorAuth.UsuarioActual.Id


        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub btnCambiarPass_Click(sender As Object, e As EventArgs) Handles btnCambiarPass.Click

        cambiarPass()

    End Sub

    Private Sub cambiarPass()

        Dim old_pass = txtPass.Text
        Dim new_pass = txtNewPass.Text
        Dim result As Integer


        Try

            If txtNewPass.Text = txtConfPass.Text Then

                Dim old_pass_secure = getSHA1Hash(old_pass)
                Dim new_pass_secure = getSHA1Hash(new_pass)

                result = gestorUsuario.cambiarPropiaContra(id_usuario, old_pass_secure, new_pass_secure)

                If result = 0 Then

                    MessageBox.Show("Contraseña modificada exitosamente", "Becademic", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiarTxt()
                Else

                    MessageBox.Show("La contraseña proporcionada es incorrecta o la nueva es invalida", "Becademic", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    limpiarTxt()
                End If

            Else

                MessageBox.Show("Las nuevas contraseña no con coinciden ", "Becademic", MessageBoxButtons.OK, MessageBoxIcon.Error)
                limpiarTxt()

            End If


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

    Private Sub limpiarTxt()

        txtPass.Clear()
        txtNewPass.Clear()
        txtConfPass.Clear()

    End Sub

End Class
