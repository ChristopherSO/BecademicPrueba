Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

''' <summary>
''' Formulario donde se puede editar un tipo de beca.
''' </summary>
''' <remarks>Para editar el tipo de beca previamente se tuvo que haber seleccionado en el uCTiposDeBecas.</remarks>
Public Class frmActualizarTipoDeBeca

    Public idTipoBeca As Integer
    Private gestorValidaciones As New GestorValidaciones

    ''' <summary>
    ''' Carga los datos en los textbox de un tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Para que carge los datos tuvo que haber sido seleccionado previamente.</remarks>
    Private Sub frmActualizarTipoDeBeca_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim contenedor As Panel = pnlModificarTipoDeBeca
        gestorValidaciones.activarValidaciones(contenedor)
        llenarCampos()

    End Sub

    ''' <summary>
    ''' Llena los campos de los textBox.
    ''' </summary>
    ''' <remarks>Método llamado desde el frmActualizarTipoDeBeca_Load().</remarks>
    Private Sub llenarCampos()

        Try

            Dim tipoBeca As TipoBeca = gestorTipoBeca.consultarTipoBecaById(idTipoBeca)
            txtNombre.Text = tipoBeca.Nombre
            txtDescripcion.Text = tipoBeca.Descripcion
            txtIcono.Text = tipoBeca.Icono
            txtColor.Text = tipoBeca.Color

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    ''' <summary>
    ''' Cancela la operación de actualizar el tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de cancelar.</remarks>
    Private Sub onCancelar(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub

    ''' <summary>
    ''' Llama al método modificarTipoBeca que ejecuta la acción de la modificación.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de guardar.</remarks>
    Private Sub onGuardar(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim contenedor As Panel = pnlModificarTipoDeBeca

        If (gestorValidaciones.camposEstanValidos(contenedor)) Then
            modificarTipoBeca()
        End If

    End Sub

    ''' <summary>
    ''' Guarda la información del tipo de beca.
    ''' </summary>
    ''' <remarks>Para poder agregar primero tuvo que haber sido aprobado por las válidaciones.</remarks>
    Private Sub modificarTipoBeca()

        Dim result As DialogResult

        Try
            result = MessageBox.Show("¿Realmente desea editar este tipo de beca?", "Editar tipo de beca", MessageBoxButtons.YesNo)

            If result = System.Windows.Forms.DialogResult.Yes Then

                gestorTipoBeca.editarTipoBeca(idTipoBeca, txtNombre.Text, txtDescripcion.Text, txtIcono.Text, txtColor.Text, False, 10)
                MessageBox.Show("Se ha editado el tipo de beca exitosamente", "Modificar tipo de beca", MessageBoxButtons.OK)
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

End Class