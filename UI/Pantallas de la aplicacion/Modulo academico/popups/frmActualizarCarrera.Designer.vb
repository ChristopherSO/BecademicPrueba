<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActualizarCarrera
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
        Me.pnlActualizarCarrera = New System.Windows.Forms.Panel()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIcono = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombreTipoBeca = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlContenidoPrincipal.SuspendLayout()
        Me.pnlActualizarCarrera.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenidoPrincipal
        '
        Me.pnlContenidoPrincipal.Controls.Add(Me.pnlActualizarCarrera)
        Me.pnlContenidoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenidoPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenidoPrincipal.Name = "pnlContenidoPrincipal"
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(599, 376)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'pnlActualizarCarrera
        '
        Me.pnlActualizarCarrera.Controls.Add(Me.txtColor)
        Me.pnlActualizarCarrera.Controls.Add(Me.Label3)
        Me.pnlActualizarCarrera.Controls.Add(Me.txtIcono)
        Me.pnlActualizarCarrera.Controls.Add(Me.Label2)
        Me.pnlActualizarCarrera.Controls.Add(Me.txtDescripcion)
        Me.pnlActualizarCarrera.Controls.Add(Me.Label1)
        Me.pnlActualizarCarrera.Controls.Add(Me.txtNombre)
        Me.pnlActualizarCarrera.Controls.Add(Me.lblNombreTipoBeca)
        Me.pnlActualizarCarrera.Controls.Add(Me.Label4)
        Me.pnlActualizarCarrera.Controls.Add(Me.btnCancelar)
        Me.pnlActualizarCarrera.Controls.Add(Me.btnGuardar)
        Me.pnlActualizarCarrera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlActualizarCarrera.Location = New System.Drawing.Point(0, 0)
        Me.pnlActualizarCarrera.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlActualizarCarrera.Name = "pnlActualizarCarrera"
        Me.pnlActualizarCarrera.Size = New System.Drawing.Size(599, 376)
        Me.pnlActualizarCarrera.TabIndex = 3
        '
        'txtColor
        '
        Me.txtColor.Location = New System.Drawing.Point(138, 250)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(421, 26)
        Me.txtColor.TabIndex = 23
        Me.txtColor.Tag = "txtopcional"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label3.Location = New System.Drawing.Point(24, 255)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 17)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Color:"
        '
        'txtIcono
        '
        Me.txtIcono.Location = New System.Drawing.Point(138, 215)
        Me.txtIcono.Name = "txtIcono"
        Me.txtIcono.Size = New System.Drawing.Size(421, 26)
        Me.txtIcono.TabIndex = 21
        Me.txtIcono.Tag = "txtopcional"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label2.Location = New System.Drawing.Point(24, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 17)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Icono:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(138, 103)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(421, 106)
        Me.txtDescripcion.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label1.Location = New System.Drawing.Point(24, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Descripción:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(138, 68)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(421, 26)
        Me.txtNombre.TabIndex = 17
        '
        'lblNombreTipoBeca
        '
        Me.lblNombreTipoBeca.AutoSize = True
        Me.lblNombreTipoBeca.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombreTipoBeca.Location = New System.Drawing.Point(24, 73)
        Me.lblNombreTipoBeca.Name = "lblNombreTipoBeca"
        Me.lblNombreTipoBeca.Size = New System.Drawing.Size(62, 17)
        Me.lblNombreTipoBeca.TabIndex = 16
        Me.lblNombreTipoBeca.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label4.Location = New System.Drawing.Point(18, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(194, 29)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Modificar carrera"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.DimGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(409, 305)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 47)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(229, 305)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 47)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmActualizarCarrera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 376)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmActualizarCarrera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modificar carrera"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlActualizarCarrera.ResumeLayout(False)
        Me.pnlActualizarCarrera.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlActualizarCarrera As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIcono As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreTipoBeca As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
