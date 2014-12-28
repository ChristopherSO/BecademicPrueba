Imports EntitiesLayer
Public Class frmPermisosAsignados

    Public idRol As Integer
    Public nombreRol As String
    Dim idPermiso As Integer
    Dim Permiso As PermisoRol
    Dim row As Integer
    Dim result As DialogResult

    Private Sub frmPermisosAsignados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTitulo.Text = "Permisos de " + nombreRol
        ActualizarTabla()
        actualizarComboBox()


    End Sub


    Private Sub ActualizarTabla()

        Try

            Dim listaPermiso As IEnumerable = gestorPermiso.consultarPermisoRol(idRol)

            gridListaDatos.Rows.Clear()

            For Each Permiso As PermisoRol In listaPermiso
                gridListaDatos.Rows.Add(Permiso.Id, Permiso.Nombre, Permiso.Descripcion, Permiso.Categoria)
            Next

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub gridListaDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridListaDatos.CellClick

        row = gridListaDatos.CurrentRow.Index
        idPermiso = gridListaDatos.Item(0, row).Value

    End Sub
    Private Sub actualizarComboBox()

        Try

            cmbPerm.DataSource = gestorPermiso.getPermisoList()
            cmbPerm.DisplayMember = "nombre"
            cmbPerm.ValueMember = "id_permiso"

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click

        Dim perm As Integer = cmbPerm.SelectedValue
        Dim lstActual As New ArrayList
        Dim rw As Integer = 0

        Try

            For Each index As DataGridViewRow In gridListaDatos.Rows

                lstActual.Add(gridListaDatos.Item(0, rw).Value)
                rw = rw + 1

            Next

            If (lstActual.Contains(perm)) Then

                MessageBox.Show("Este permiso ya pertenece a este rol", "Asignar Permiso", MessageBoxButtons.OK)

            Else

                gestorPermiso.asignarPermisoRol(perm, idRol)

                ActualizarTabla()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub btnRemover_Click(sender As Object, e As EventArgs) Handles btnRemover.Click

        Try

            result = MessageBox.Show("¿Realmente desea remover este permiso al rol?", "Remover Permiso", MessageBoxButtons.YesNo)

            If result = System.Windows.Forms.DialogResult.Yes Then

                gestorPermiso.removerPermisoRol(idPermiso, idRol)
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