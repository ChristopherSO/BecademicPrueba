<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarUsuario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlContenidoPrincipal = New System.Windows.Forms.Panel()
        Me.pnlAgregarUsuario = New System.Windows.Forms.Panel()
        Me.txtTelefono = New System.Windows.Forms.MaskedTextBox()
        Me.txtCedula = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbGenero = New System.Windows.Forms.ComboBox()
        Me.lblGenero = New System.Windows.Forms.Label()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.txtApellido2 = New System.Windows.Forms.TextBox()
        Me.lblApellido2 = New System.Windows.Forms.Label()
        Me.txtApellido1 = New System.Windows.Forms.TextBox()
        Me.lblApellido1 = New System.Windows.Forms.Label()
        Me.txtNombre2 = New System.Windows.Forms.TextBox()
        Me.lblNombre2 = New System.Windows.Forms.Label()
        Me.txtNombre1 = New System.Windows.Forms.TextBox()
        Me.lblNombre1 = New System.Windows.Forms.Label()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlContenidoPrincipal.SuspendLayout()
        Me.pnlAgregarUsuario.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenidoPrincipal
        '
        Me.pnlContenidoPrincipal.Controls.Add(Me.pnlAgregarUsuario)
        Me.pnlContenidoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenidoPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenidoPrincipal.Name = "pnlContenidoPrincipal"
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(927, 427)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'pnlAgregarUsuario
        '
        Me.pnlAgregarUsuario.Controls.Add(Me.txtTelefono)
        Me.pnlAgregarUsuario.Controls.Add(Me.txtCedula)
        Me.pnlAgregarUsuario.Controls.Add(Me.Label3)
        Me.pnlAgregarUsuario.Controls.Add(Me.cmbEstado)
        Me.pnlAgregarUsuario.Controls.Add(Me.lblEstado)
        Me.pnlAgregarUsuario.Controls.Add(Me.cmbGenero)
        Me.pnlAgregarUsuario.Controls.Add(Me.lblGenero)
        Me.pnlAgregarUsuario.Controls.Add(Me.lblTelefono)
        Me.pnlAgregarUsuario.Controls.Add(Me.txtCorreo)
        Me.pnlAgregarUsuario.Controls.Add(Me.lblCorreo)
        Me.pnlAgregarUsuario.Controls.Add(Me.txtApellido2)
        Me.pnlAgregarUsuario.Controls.Add(Me.lblApellido2)
        Me.pnlAgregarUsuario.Controls.Add(Me.txtApellido1)
        Me.pnlAgregarUsuario.Controls.Add(Me.lblApellido1)
        Me.pnlAgregarUsuario.Controls.Add(Me.txtNombre2)
        Me.pnlAgregarUsuario.Controls.Add(Me.lblNombre2)
        Me.pnlAgregarUsuario.Controls.Add(Me.txtNombre1)
        Me.pnlAgregarUsuario.Controls.Add(Me.lblNombre1)
        Me.pnlAgregarUsuario.Controls.Add(Me.lblSubTitulo)
        Me.pnlAgregarUsuario.Controls.Add(Me.btnCancelar)
        Me.pnlAgregarUsuario.Controls.Add(Me.btnGuardar)
        Me.pnlAgregarUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgregarUsuario.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarUsuario.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAgregarUsuario.Name = "pnlAgregarUsuario"
        Me.pnlAgregarUsuario.Size = New System.Drawing.Size(927, 427)
        Me.pnlAgregarUsuario.TabIndex = 3
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(181, 330)
        Me.txtTelefono.Mask = "0000-0000"
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(386, 26)
        Me.txtTelefono.TabIndex = 44
        Me.txtTelefono.Tag = "telOpcional"
        '
        'txtCedula
        '
        Me.txtCedula.Location = New System.Drawing.Point(181, 73)
        Me.txtCedula.Mask = "000000000"
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(386, 26)
        Me.txtCedula.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label3.Location = New System.Drawing.Point(32, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Cédula:"
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(680, 109)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(219, 28)
        Me.cmbEstado.TabIndex = 40
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblEstado.Location = New System.Drawing.Point(594, 114)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(56, 17)
        Me.lblEstado.TabIndex = 39
        Me.lblEstado.Text = "Estado:"
        '
        'cmbGenero
        '
        Me.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGenero.FormattingEnabled = True
        Me.cmbGenero.Items.AddRange(New Object() {"Masculino", "Femenino"})
        Me.cmbGenero.Location = New System.Drawing.Point(680, 68)
        Me.cmbGenero.Name = "cmbGenero"
        Me.cmbGenero.Size = New System.Drawing.Size(219, 28)
        Me.cmbGenero.TabIndex = 36
        '
        'lblGenero
        '
        Me.lblGenero.AutoSize = True
        Me.lblGenero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblGenero.Location = New System.Drawing.Point(594, 73)
        Me.lblGenero.Name = "lblGenero"
        Me.lblGenero.Size = New System.Drawing.Size(60, 17)
        Me.lblGenero.TabIndex = 35
        Me.lblGenero.Text = "Género:"
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblTelefono.Location = New System.Drawing.Point(32, 330)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(68, 17)
        Me.lblTelefono.TabIndex = 33
        Me.lblTelefono.Text = "Teléfono:"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(181, 282)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(386, 26)
        Me.txtCorreo.TabIndex = 32
        Me.txtCorreo.Tag = "correo"
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblCorreo.Location = New System.Drawing.Point(32, 287)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(55, 17)
        Me.lblCorreo.TabIndex = 31
        Me.lblCorreo.Text = "Correo:"
        '
        'txtApellido2
        '
        Me.txtApellido2.Location = New System.Drawing.Point(181, 240)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.Size = New System.Drawing.Size(386, 26)
        Me.txtApellido2.TabIndex = 30
        Me.txtApellido2.Tag = "txtOpcional"
        '
        'lblApellido2
        '
        Me.lblApellido2.AutoSize = True
        Me.lblApellido2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblApellido2.Location = New System.Drawing.Point(32, 245)
        Me.lblApellido2.Name = "lblApellido2"
        Me.lblApellido2.Size = New System.Drawing.Size(123, 17)
        Me.lblApellido2.TabIndex = 29
        Me.lblApellido2.Text = "Segundo Apellido:"
        '
        'txtApellido1
        '
        Me.txtApellido1.Location = New System.Drawing.Point(181, 197)
        Me.txtApellido1.Name = "txtApellido1"
        Me.txtApellido1.Size = New System.Drawing.Size(386, 26)
        Me.txtApellido1.TabIndex = 28
        Me.txtApellido1.Tag = "txt"
        '
        'lblApellido1
        '
        Me.lblApellido1.AutoSize = True
        Me.lblApellido1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblApellido1.Location = New System.Drawing.Point(32, 202)
        Me.lblApellido1.Name = "lblApellido1"
        Me.lblApellido1.Size = New System.Drawing.Size(107, 17)
        Me.lblApellido1.TabIndex = 27
        Me.lblApellido1.Text = "Primer Apellido:"
        '
        'txtNombre2
        '
        Me.txtNombre2.Location = New System.Drawing.Point(181, 155)
        Me.txtNombre2.Name = "txtNombre2"
        Me.txtNombre2.Size = New System.Drawing.Size(386, 26)
        Me.txtNombre2.TabIndex = 26
        Me.txtNombre2.Tag = "txtOpcional"
        '
        'lblNombre2
        '
        Me.lblNombre2.AutoSize = True
        Me.lblNombre2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombre2.Location = New System.Drawing.Point(32, 160)
        Me.lblNombre2.Name = "lblNombre2"
        Me.lblNombre2.Size = New System.Drawing.Size(123, 17)
        Me.lblNombre2.TabIndex = 25
        Me.lblNombre2.Text = "Segundo Nombre:"
        '
        'txtNombre1
        '
        Me.txtNombre1.Location = New System.Drawing.Point(181, 114)
        Me.txtNombre1.Name = "txtNombre1"
        Me.txtNombre1.Size = New System.Drawing.Size(386, 26)
        Me.txtNombre1.TabIndex = 24
        Me.txtNombre1.Tag = "txt"
        '
        'lblNombre1
        '
        Me.lblNombre1.AutoSize = True
        Me.lblNombre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombre1.Location = New System.Drawing.Point(32, 119)
        Me.lblNombre1.Name = "lblNombre1"
        Me.lblNombre1.Size = New System.Drawing.Size(107, 17)
        Me.lblNombre1.TabIndex = 23
        Me.lblNombre1.Text = "Primer Nombre:"
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblSubTitulo.Location = New System.Drawing.Point(18, 18)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(184, 29)
        Me.lblSubTitulo.TabIndex = 22
        Me.lblSubTitulo.Text = "Agregar usuario"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.DimGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(765, 356)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 47)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Salir"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(597, 356)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 47)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmAgregarUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 427)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAgregarUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar usuario"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlAgregarUsuario.ResumeLayout(False)
        Me.pnlAgregarUsuario.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlAgregarUsuario As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbGenero As System.Windows.Forms.ComboBox
    Friend WithEvents lblGenero As System.Windows.Forms.Label
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents lblCorreo As System.Windows.Forms.Label
    Friend WithEvents txtApellido2 As System.Windows.Forms.TextBox
    Friend WithEvents lblApellido2 As System.Windows.Forms.Label
    Friend WithEvents txtApellido1 As System.Windows.Forms.TextBox
    Friend WithEvents lblApellido1 As System.Windows.Forms.Label
    Friend WithEvents txtNombre2 As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre1 As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre1 As System.Windows.Forms.Label
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCedula As System.Windows.Forms.MaskedTextBox
End Class
