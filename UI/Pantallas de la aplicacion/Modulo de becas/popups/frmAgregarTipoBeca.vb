Imports EntitiesLayer
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

''' <summary>
''' Formulario donde se puede agregar un nuevo tipo de beca.
''' </summary>
Public Class frmAgregarTipoBeca

    Private gestorValidaciones As New GestorValidaciones

    ''' <summary>
    ''' Llama al método agregarTipoBeca que ejecuta la acción agregar un nuevo tipo beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de guardar.</remarks>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim contenedor As Panel = pnlAgregarTipoDeBeca

        If (GestorValidaciones.camposEstanValidos(contenedor)) Then
            agregarTipoDeBeca()
        End If

    End Sub

    ''' <summary>
    ''' Carga el formulario de agregar tipoDeBeca
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    Private Sub frmAgregarTipoBeca_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim contenedor As Panel = pnlAgregarTipoDeBeca
        GestorValidaciones.activarValidaciones(contenedor)

    End Sub

    ''' <summary>
    ''' Método que agrega un nuevo tipo de beca.
    ''' </summary>
    ''' <remarks>Tuvo que habe sido aprobado por las válidaciones para que pueda procesiguir a guarda el nuevo tipo de beca.</remarks>
    Private Sub agregarTipoDeBeca()

        Try

            gestorTipoBeca.agregarTipoBeca(txtNombre.Text, txtDescripcion.Text, txtIcono.Text, txtColor.Text, False, 10)
            MessageBox.Show("Se ha agregado un nuevo tipo de beca exitosamente", "Agregar tipo de beca", MessageBoxButtons.OK)
            Me.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    ''' <summary>
    ''' Cancela la operación de agregar tipo de beca.
    ''' </summary>
    ''' <param name="sender">sender de tipo Object</param>
    ''' <param name="e">e de tipo EventArgs</param>
    ''' <remarks>Tiene que presionar el botón de cancelar.</remarks>
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub
End Class