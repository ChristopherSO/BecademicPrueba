<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCRecuperarContrasena
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
        Me.btnRecuperar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblVolver = New System.Windows.Forms.LinkLabel()
        Me.lblMensajeError = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(19, 27)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(225, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Recuperar contraseña"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(287, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Por favor, ingrese su correo electrónico:"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(25, 173)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(346, 26)
        Me.txtCorreo.TabIndex = 2
        '
        'btnRecuperar
        '
        Me.btnRecuperar.BackColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.btnRecuperar.FlatAppearance.BorderSize = 0
        Me.btnRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecuperar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecuperar.ForeColor = System.Drawing.Color.White
        Me.btnRecuperar.Location = New System.Drawing.Point(213, 259)
        Me.btnRecuperar.Name = "btnRecuperar"
        Me.btnRecuperar.Size = New System.Drawing.Size(158, 50)
        Me.btnRecuperar.TabIndex = 6
        Me.btnRecuperar.Text = "Recuperar"
        Me.btnRecuperar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblVolver)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 345)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(400, 55)
        Me.Panel2.TabIndex = 9
        '
        'lblVolver
        '
        Me.lblVolver.ActiveLinkColor = System.Drawing.Color.Silver
        Me.lblVolver.AutoSize = True
        Me.lblVolver.BackColor = System.Drawing.Color.Transparent
        Me.lblVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVolver.ForeColor = System.Drawing.Color.White
        Me.lblVolver.LinkColor = System.Drawing.Color.White
        Me.lblVolver.Location = New System.Drawing.Point(31, 17)
        Me.lblVolver.Name = "lblVolver"
        Me.lblVolver.Size = New System.Drawing.Size(59, 20)
        Me.lblVolver.TabIndex = 16
        Me.lblVolver.TabStop = True
        Me.lblVolver.Text = "Volver"
        '
        'lblMensajeError
        '
        Me.lblMensajeError.AutoSize = True
        Me.lblMensajeError.ForeColor = System.Drawing.Color.Red
        Me.lblMensajeError.Location = New System.Drawing.Point(165, 202)
        Me.lblMensajeError.Name = "lblMensajeError"
        Me.lblMensajeError.Size = New System.Drawing.Size(0, 20)
        Me.lblMensajeError.TabIndex = 10
        Me.lblMensajeError.Visible = False
        '
        'uCRecuperarContrasena
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblMensajeError)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnRecuperar)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCRecuperarContrasena"
        Me.Size = New System.Drawing.Size(400, 400)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents btnRecuperar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblVolver As System.Windows.Forms.LinkLabel
    Friend WithEvents lblMensajeError As System.Windows.Forms.Label

End Class
