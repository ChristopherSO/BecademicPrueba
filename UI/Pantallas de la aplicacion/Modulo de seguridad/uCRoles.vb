Imports EntitiesLayer

Public Class uCRoles

    Dim Rol As New RolUsuario
    Dim row As Integer
    Dim idRol As Integer
    Dim nombreRol As String
    Dim result As DialogResult
    Public Sub onControlLoad() Handles MyBase.Load

        Me.Dock = DockStyle.Fill
        ActualizarTabla()

        btnAgregar.Visible = gestorAuth.tieneElPermiso(31)
        btnModificar.Visible = gestorAuth.tieneElPermiso(33)
        btnEliminar.Visible = gestorAuth.tieneElPermiso(34)

    End Sub

    Private Sub gridListaDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridListaDatos.CellClick


        row = gridListaDatos.CurrentRow.Index
        idRol = gridListaDatos.Item(0, row).Value
        nombreRol = gridListaDatos.Item(1, row).Value

    End Sub

    Private Sub ActualizarTabla()

        Try

            Dim listaRoles As IEnumerable = gestorRol.consultarRoles
            gridListaDatos.Rows.Clear()

            For Each Rol As RolUsuario In listaRoles
                gridListaDatos.Rows.Add(Rol.Id, Rol.Nombre, Rol.Descripcion, Rol.NombreFase)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        Try

            If idRol > 0 Then

                frmActualizarRol.idRol = idRol
                frmActualizarRol.nombreRol = nombreRol
                frmActualizarRol.ShowDialog(Me)
                ActualizarTabla()

            Else

                MessageBox.Show("Por favor, seleccione un Rol primero", "Roles", MessageBoxButtons.OK)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If nombreRol <> "Administrador" And nombreRol <> "Estudiante" And nombreRol <> "Director académico" Then

            Try

                result = MessageBox.Show("¿Realmente desea borrar este rol?", "Eliminar Rol", MessageBoxButtons.YesNo)

                If result = System.Windows.Forms.DialogResult.Yes Then

                    gestorRol.eliminarRol(idRol)
                    ActualizarTabla()

                End If

            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try

        Else

            MessageBox.Show("El rol " & nombreRol & " no puede ser eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        Dim frmAgregarRol = New frmAgregarRol()

        Try

            frmAgregarRol.ShowDialog(Me)
            ActualizarTabla()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub



    Private Sub onCellContenteClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridListaDatos.CellContentClick

        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 Then

            Select Case senderGrid.Columns.Item(e.ColumnIndex).Name

                Case "colPermisos"
                    frmPermisosAsignados.idRol = idRol
                    frmPermisosAsignados.nombreRol = nombreRol
                    frmPermisosAsignados.ShowDialog(Me)

            End Select

        End If

    End Sub

End Class
