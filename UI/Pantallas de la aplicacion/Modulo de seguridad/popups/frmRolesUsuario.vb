Imports EntitiesLayer

Public Class frmRolesUsuario

    Public idUsuario As Integer
    Public nombreUsuario As String
    Dim idRol As Integer
    Dim Rol As New RolUsuario
    Dim row As Integer
    Dim result As DialogResult

    Private Sub frmActualizarRol_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblSubTitulo.Text = "Roles de " + nombreUsuario
        ActualizarTabla()
        actualizarComboBox()

    End Sub

    Private Sub gridListaDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridListaDatos.CellClick

        row = gridListaDatos.CurrentRow.Index
        idRol = gridListaDatos.Item(0, row).Value

    End Sub

    Private Sub ActualizarTabla()

        Try

            Dim listaRoles As IEnumerable = gestorRol.consultarRolesUsuario(idUsuario)
            gridListaDatos.Rows.Clear()

            For Each Rol As RolUsuario In listaRoles
                gridListaDatos.Rows.Add(Rol.Id, Rol.Nombre, Rol.Intervencion, Rol.Descripcion)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub actualizarComboBox()

        Try

            cmbRol.DataSource = gestorRol.getRolList
            cmbRol.DisplayMember = "nombre"
            cmbRol.ValueMember = "id_rol"

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub onRemover(sender As Object, e As EventArgs) Handles btnRemover.Click

        result = MessageBox.Show("¿Realmente desea remover este rol al usuario?", "Remover Rol", MessageBoxButtons.YesNo)

        Try

            If result = System.Windows.Forms.DialogResult.Yes Then

                gestorRol.removerRolUsuario(idRol, idUsuario)
                ActualizarTabla()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub onAsignar(sender As Object, e As EventArgs) Handles btnAsignar.Click

        Dim rol As Integer = cmbRol.SelectedValue
        Dim lstActual As New ArrayList
        Dim rw As Integer = 0

        Try

            For Each index As DataGridViewRow In gridListaDatos.Rows

                lstActual.Add(gridListaDatos.Item(0, rw).Value)
                rw = rw + 1

            Next

            If (lstActual.Contains(rol)) Then

                MessageBox.Show("Este rol ya pertenece a este usuario", "Asignar Rol", MessageBoxButtons.OK)

            Else

                gestorRol.asignarRolUsuario(rol, idUsuario)
                ActualizarTabla()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.Close()

    End Sub


End Class