<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCLogin
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblRecuperarContraseña = New System.Windows.Forms.LinkLabel()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(30, 27)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(296, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Software de gestión de becas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre de usuario"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(38, 119)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(323, 26)
        Me.txtCorreo.TabIndex = 2
        '
        'txtContrasena
        '
        Me.txtContrasena.Location = New System.Drawing.Point(38, 203)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.Size = New System.Drawing.Size(323, 26)
        Me.txtContrasena.TabIndex = 4
        Me.txtContrasena.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Contraseña"
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnIngresar.FlatAppearance.BorderSize = 0
        Me.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIngresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.ForeColor = System.Drawing.Color.White
        Me.btnIngresar.Location = New System.Drawing.Point(211, 267)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(150, 50)
        Me.btnIngresar.TabIndex = 6
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblRecuperarContraseña)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 345)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(400, 55)
        Me.Panel2.TabIndex = 8
        '
        'lblRecuperarContraseña
        '
        Me.lblRecuperarContraseña.ActiveLinkColor = System.Drawing.Color.Silver
        Me.lblRecuperarContraseña.AutoSize = True
        Me.lblRecuperarContraseña.BackColor = System.Drawing.Color.Transparent
        Me.lblRecuperarContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecuperarContraseña.ForeColor = System.Drawing.Color.White
        Me.lblRecuperarContraseña.LinkColor = System.Drawing.Color.White
        Me.lblRecuperarContraseña.Location = New System.Drawing.Point(31, 17)
        Me.lblRecuperarContraseña.Name = "lblRecuperarContraseña"
        Me.lblRecuperarContraseña.Size = New System.Drawing.Size(188, 20)
        Me.lblRecuperarContraseña.TabIndex = 15
        Me.lblRecuperarContraseña.TabStop = True
        Me.lblRecuperarContraseña.Text = "Recuperar contraseña"
        '
        'uCLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.txtContrasena)
        Me.Controls.Add(Me.txtCorreo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCLogin"
        Me.Size = New System.Drawing.Size(400, 400)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents txtContrasena As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblRecuperarContraseña As System.Windows.Forms.LinkLabel

End Class
