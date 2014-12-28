Imports EntitiesLayer
Public Class uCUsuarios

    Dim row As Integer
    Dim idUsuario As Integer
    Dim nombreUsuario As String
    Dim result As DialogResult

    Public Sub onControlLoad() Handles MyBase.Load

        Me.Dock = DockStyle.Fill

        ActualizarTabla()

        btnAgregar.Visible = gestorAuth.tieneElPermiso(27)
        btnModificar.Visible = gestorAuth.tieneElPermiso(28)
        btnEliminar.Visible = gestorAuth.tieneElPermiso(29)

    End Sub

    Private Sub gridListaDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridListaDatos.CellClick

        row = gridListaDatos.CurrentRow.Index
        idUsuario = gridListaDatos.Item(0, row).Value
        nombreUsuario = gridListaDatos.Item(1, row).Value


    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        Dim frmAgregarUsuario = New frmAgregarUsuario()

        Try

            frmAgregarUsuario.ShowDialog(Me)
            ActualizarTabla()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If idUsuario = gestorAuth.UsuarioActual.Id Then

            MessageBox.Show("No se puede borrar un usuario en sesión ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            borrarUsuario()

        End If


    End Sub

    Private Sub borrarUsuario()

        Try

            If idUsuario > 0 Then

                result = MessageBox.Show("¿Realmente desea borrar este usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo)

                If result = System.Windows.Forms.DialogResult.Yes Then

                    gestorUsuario.eliminarUsuario(idUsuario)
                    ActualizarTabla()

                End If

            Else

                MessageBox.Show("Por favor seleccione un usuario primero", "Usuarios", MessageBoxButtons.OK)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        Try

            If idUsuario > 0 Then

                frmActualizarUsuario.idUsuario = idUsuario
                frmActualizarUsuario.ShowDialog(Me)
                ActualizarTabla()

            Else

                MessageBox.Show("Por favor seleccione un Usuario primero", "Usuarios", MessageBoxButtons.OK)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub ActualizarTabla()

        Try

            Dim listaUsuarios As IEnumerable = gestorUsuario.consultarUsuario
            gridListaDatos.Rows.Clear()

            For Each Usuario As Usuario In listaUsuarios
                gridListaDatos.Rows.Add(Usuario.Id, Usuario.Nombre, Usuario.SegundoNombre, Usuario.PrimerApellido,
                                        Usuario.SegundoApellido, Usuario.Correo, Usuario.Genero, Usuario.Telefono,
                                        Usuario.NombreEstado)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub onCellContenteClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridListaDatos.CellContentClick

        Dim estadoUsuario = gridListaDatos.Item(8, row).Value
        Dim senderGrid = DirectCast(sender, DataGridView)



        Try

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
               e.RowIndex >= 0 Then

                Select Case senderGrid.Columns.Item(e.ColumnIndex).Name

                    Case "colVerRol"

                        If estadoUsuario.Contains("Postulante") OrElse estadoUsuario.Contains("postulante") Then

                            MessageBox.Show("No se puede asignar roles a un postulante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Else

                            frmRolesUsuario.idUsuario = idUsuario
                            frmRolesUsuario.nombreUsuario = nombreUsuario
                            frmRolesUsuario.ShowDialog(Me)

                        End If
                End Select

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


End Class
