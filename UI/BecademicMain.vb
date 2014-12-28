Imports EntitiesLayer

Public Class BecademicMain

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Login.Close()

        Try

            lblBienvenida.Text = "Bienvenido, " & gestorAuth.UsuarioActual.Nombre & " " & gestorAuth.UsuarioActual.PrimerApellido

            'Permisos de Módulo Beca
            If Not gestorAuth.tieneElPermiso(1) Then
                trvwMenuPrincipal.Nodes("btnModuloBecas").Nodes("btnTiposDeBecas").Remove()
            End If

            If Not gestorAuth.tieneElPermiso(6) Then
                trvwMenuPrincipal.Nodes("btnModuloBecas").Nodes("btnBeneficios").Remove()
            End If

            If Not gestorAuth.tieneElPermiso(10) Then
                trvwMenuPrincipal.Nodes("btnModuloBecas").Nodes("btnRequisitos").Remove()
            End If

            'Permisos de Módulo Académico

            If Not gestorAuth.tieneElPermiso(14) Then
                trvwMenuPrincipal.Nodes("btnModuloAcademico").Nodes("btnCarreras").Remove()
            End If

            If Not gestorAuth.tieneElPermiso(18) Then
                trvwMenuPrincipal.Nodes("btnModuloAcademico").Nodes("btnCursos").Remove()
            End If

            If Not gestorAuth.tieneElPermiso(22) Then
                trvwMenuPrincipal.Nodes("btnModuloAcademico").Nodes("btnCalificaciones").Remove()
            End If

            'Permisos de Módulo Seguridad

            If Not gestorAuth.tieneElPermiso(26) Then
                trvwMenuPrincipal.Nodes("btnSeguridad").Nodes("btnUsuarios").Remove()
            End If

            If Not gestorAuth.tieneElPermiso(30) Then
                trvwMenuPrincipal.Nodes("btnSeguridad").Nodes("btnRoles").Remove()
            End If

            'De aqui en adelante permisos de reporte

            If Not gestorAuth.tieneElPermiso(35) Then
                trvwMenuPrincipal.Nodes("btnReportes").Nodes("btnHistorialAcademico").Remove()
            End If

            If Not gestorAuth.tieneElPermiso(38) Then
                trvwMenuPrincipal.Nodes("btnReportes").Nodes("btnProforma").Remove()
            End If

            If Not gestorAuth.tieneElPermiso(39) Then
                trvwMenuPrincipal.Nodes("btnReportes").Nodes("btnPromediosGenerales").Remove()
            End If

            If Not gestorAuth.tieneElPermiso(42) Then
                trvwMenuPrincipal.Nodes("btnReportes").Nodes("btnMejoresPromedios").Remove()
            End If

            'De aqui en adelante permisos de reporte

            'If Not gestorAuth.tieneElPermiso(45) Then
            '    trvwMenuPrincipal.Nodes("btnConfiguracion").Remove()
            'End If

            'Controla las opciones que se van a ver.


            If trvwMenuPrincipal.Nodes("btnModuloBecas").Nodes.Count = 0 Then
                trvwMenuPrincipal.Nodes("btnModuloBecas").Remove()
            End If

            If trvwMenuPrincipal.Nodes("btnModuloAcademico").Nodes.Count = 0 Then
                trvwMenuPrincipal.Nodes("btnModuloAcademico").Remove()
            End If

            If trvwMenuPrincipal.Nodes("btnSeguridad").Nodes.Count = 0 Then
                trvwMenuPrincipal.Nodes("btnSeguridad").Remove()
            End If

            If trvwMenuPrincipal.Nodes("btnReportes").Nodes.Count = 0 Then
                trvwMenuPrincipal.Nodes("btnReportes").Remove()
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        cambiarPantalla(New uCInicio)

    End Sub

    Private Sub onOpcionSeleccionada(sender As Object, e As TreeViewEventArgs) Handles trvwMenuPrincipal.AfterSelect

        Select Case trvwMenuPrincipal.SelectedNode.Name

            Case "btnVerPerfil"
                cambiarPantalla(New uCInicio)
            Case "btnTiposDeBecas"
                cambiarPantalla(New uCTiposDeBecas)
            Case "btnBeneficios"
                cambiarPantalla(New uCBeneficios)
            Case "btnRequisitos"
                cambiarPantalla(New uCRequisitos)
            Case "btnCarreras"
                cambiarPantalla(New uCCarreras)
            Case "btnCursos"
                cambiarPantalla(New uCCursos)
            Case "btnCalificaciones"
                cambiarPantalla(New uCCalificaciones)
            Case "btnDeCarreras"
                cambiarPantalla(New uCPromedioGeneralesCarreras)
            Case "btnDeCursos"
                cambiarPantalla(New uCPromedioGeneralesCursos)
            Case "btnPorCarrera"
                cambiarPantalla(New uCMejoresPromediosXCarrera)
            Case "btnTodasCarreras"
                cambiarPantalla(New uCMejoresPromediosTodasCarreras)
            Case "btnHistorialAcademico"
                cambiarPantalla(New uCHistorialAcademico)
            Case "btnProforma"
                cambiarPantalla(New uCProforma)
            Case "btnUsuarios"
                cambiarPantalla(New uCUsuarios)
            Case "btnRoles"
                cambiarPantalla(New uCRoles)
                'Case "btnConfiguracion"
                '    cambiarPantalla(New uCConfiguraciones)

        End Select

    End Sub

    Private Sub cambiarPantalla(pantalla As UserControl)
        pnlContenido.Controls.Clear()
        pnlContenido.Controls.Add(pantalla)
        pnlContenido.Refresh()
    End Sub

    Private Sub onCerrarSesion(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click

        Try

            If MessageBox.Show("¿Realmente desea salir de esta sesión?", "Cerrar sesión", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then

                gestorAuth.limpiar()
                Login.Show()
                Close()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

End Class
