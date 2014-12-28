<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCInicio
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.lblApellido2 = New System.Windows.Forms.Label()
        Me.lblApellido1 = New System.Windows.Forms.Label()
        Me.lblNombre2 = New System.Windows.Forms.Label()
        Me.lblNombre1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.MaskedTextBox()
        Me.txtCedula = New System.Windows.Forms.MaskedTextBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.txtApellido2 = New System.Windows.Forms.TextBox()
        Me.txtApellido1 = New System.Windows.Forms.TextBox()
        Me.txtNombre2 = New System.Windows.Forms.TextBox()
        Me.txtNombre1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtNewPass = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCambiarPass = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtConfPass = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(32, 24)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(91, 24)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Mi Perfil:"
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblTelefono.Location = New System.Drawing.Point(33, 329)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(68, 17)
        Me.lblTelefono.TabIndex = 39
        Me.lblTelefono.Text = "Teléfono:"
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblCorreo.Location = New System.Drawing.Point(34, 286)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(55, 17)
        Me.lblCorreo.TabIndex = 38
        Me.lblCorreo.Text = "Correo:"
        '
        'lblApellido2
        '
        Me.lblApellido2.AutoSize = True
        Me.lblApellido2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblApellido2.Location = New System.Drawing.Point(33, 244)
        Me.lblApellido2.Name = "lblApellido2"
        Me.lblApellido2.Size = New System.Drawing.Size(123, 17)
        Me.lblApellido2.TabIndex = 37
        Me.lblApellido2.Text = "Segundo Apellido:"
        '
        'lblApellido1
        '
        Me.lblApellido1.AutoSize = True
        Me.lblApellido1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblApellido1.Location = New System.Drawing.Point(33, 201)
        Me.lblApellido1.Name = "lblApellido1"
        Me.lblApellido1.Size = New System.Drawing.Size(107, 17)
        Me.lblApellido1.TabIndex = 36
        Me.lblApellido1.Text = "Primer Apellido:"
        '
        'lblNombre2
        '
        Me.lblNombre2.AutoSize = True
        Me.lblNombre2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombre2.Location = New System.Drawing.Point(33, 154)
        Me.lblNombre2.Name = "lblNombre2"
        Me.lblNombre2.Size = New System.Drawing.Size(123, 17)
        Me.lblNombre2.TabIndex = 35
        Me.lblNombre2.Text = "Segundo Nombre:"
        '
        'lblNombre1
        '
        Me.lblNombre1.AutoSize = True
        Me.lblNombre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombre1.Location = New System.Drawing.Point(33, 113)
        Me.lblNombre1.Name = "lblNombre1"
        Me.lblNombre1.Size = New System.Drawing.Size(107, 17)
        Me.lblNombre1.TabIndex = 34
        Me.lblNombre1.Text = "Primer Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label3.Location = New System.Drawing.Point(33, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Cédula:"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(181, 324)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(190, 26)
        Me.txtTelefono.TabIndex = 53
        Me.txtTelefono.Tag = "telOpcional"
        '
        'txtCedula
        '
        Me.txtCedula.Location = New System.Drawing.Point(181, 63)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.ReadOnly = True
        Me.txtCedula.Size = New System.Drawing.Size(190, 26)
        Me.txtCedula.TabIndex = 52
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(181, 281)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.ReadOnly = True
        Me.txtCorreo.Size = New System.Drawing.Size(190, 26)
        Me.txtCorreo.TabIndex = 51
        Me.txtCorreo.Tag = "correo"
        '
        'txtApellido2
        '
        Me.txtApellido2.Location = New System.Drawing.Point(181, 239)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.ReadOnly = True
        Me.txtApellido2.Size = New System.Drawing.Size(190, 26)
        Me.txtApellido2.TabIndex = 50
        Me.txtApellido2.Tag = "txtopcional"
        '
        'txtApellido1
        '
        Me.txtApellido1.Location = New System.Drawing.Point(181, 196)
        Me.txtApellido1.Name = "txtApellido1"
        Me.txtApellido1.ReadOnly = True
        Me.txtApellido1.Size = New System.Drawing.Size(190, 26)
        Me.txtApellido1.TabIndex = 49
        Me.txtApellido1.Tag = "txt"
        '
        'txtNombre2
        '
        Me.txtNombre2.Location = New System.Drawing.Point(181, 154)
        Me.txtNombre2.Name = "txtNombre2"
        Me.txtNombre2.ReadOnly = True
        Me.txtNombre2.Size = New System.Drawing.Size(190, 26)
        Me.txtNombre2.TabIndex = 48
        Me.txtNombre2.Tag = "txtopcional"
        '
        'txtNombre1
        '
        Me.txtNombre1.Location = New System.Drawing.Point(181, 108)
        Me.txtNombre1.Name = "txtNombre1"
        Me.txtNombre1.ReadOnly = True
        Me.txtNombre1.Size = New System.Drawing.Size(190, 26)
        Me.txtNombre1.TabIndex = 47
        Me.txtNombre1.Tag = "txt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(534, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 24)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Cambiar Contraseña:"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(660, 68)
        Me.txtPass.MaxLength = 20
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(183, 26)
        Me.txtPass.TabIndex = 55
        Me.txtPass.UseSystemPasswordChar = True
        '
        'txtNewPass
        '
        Me.txtNewPass.Location = New System.Drawing.Point(660, 113)
        Me.txtNewPass.MaxLength = 20
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPass.Size = New System.Drawing.Size(183, 26)
        Me.txtNewPass.TabIndex = 56
        Me.txtNewPass.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label2.Location = New System.Drawing.Point(526, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 17)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Contraseña Actual:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label4.Location = New System.Drawing.Point(526, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 17)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Nueva Contraseña:"
        '
        'btnCambiarPass
        '
        Me.btnCambiarPass.BackColor = System.Drawing.Color.ForestGreen
        Me.btnCambiarPass.FlatAppearance.BorderSize = 0
        Me.btnCambiarPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCambiarPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambiarPass.ForeColor = System.Drawing.Color.White
        Me.btnCambiarPass.Location = New System.Drawing.Point(529, 201)
        Me.btnCambiarPass.Name = "btnCambiarPass"
        Me.btnCambiarPass.Size = New System.Drawing.Size(127, 43)
        Me.btnCambiarPass.TabIndex = 59
        Me.btnCambiarPass.Text = "Cambiar"
        Me.btnCambiarPass.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label5.Location = New System.Drawing.Point(526, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Confirmar:"
        '
        'txtConfPass
        '
        Me.txtConfPass.Location = New System.Drawing.Point(660, 154)
        Me.txtConfPass.MaxLength = 20
        Me.txtConfPass.Name = "txtConfPass"
        Me.txtConfPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfPass.Size = New System.Drawing.Size(183, 26)
        Me.txtConfPass.TabIndex = 60
        Me.txtConfPass.UseSystemPasswordChar = True
        '
        'uCInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtConfPass)
        Me.Controls.Add(Me.btnCambiarPass)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNewPass)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.txtCedula)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.txtApellido2)
        Me.Controls.Add(Me.txtApellido1)
        Me.Controls.Add(Me.txtNombre2)
        Me.Controls.Add(Me.txtNombre1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTelefono)
        Me.Controls.Add(Me.lblCorreo)
        Me.Controls.Add(Me.lblApellido2)
        Me.Controls.Add(Me.lblApellido1)
        Me.Controls.Add(Me.lblNombre2)
        Me.Controls.Add(Me.lblNombre1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCInicio"
        Me.Size = New System.Drawing.Size(921, 702)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents lblCorreo As System.Windows.Forms.Label
    Friend WithEvents lblApellido2 As System.Windows.Forms.Label
    Friend WithEvents lblApellido1 As System.Windows.Forms.Label
    Friend WithEvents lblNombre2 As System.Windows.Forms.Label
    Friend WithEvents lblNombre1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents txtApellido2 As System.Windows.Forms.TextBox
    Friend WithEvents txtApellido1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPass As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCambiarPass As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtConfPass As System.Windows.Forms.TextBox

End Class
