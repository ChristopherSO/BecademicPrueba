<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarCalificacion
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
        Me.pnlAgregarCalificacion = New System.Windows.Forms.Panel()
        Me.lblComentarioAdicionales = New System.Windows.Forms.Label()
        Me.txtComentarioAdicionales = New System.Windows.Forms.TextBox()
        Me.cmbCursos = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAnnio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.lblNombreTipoBeca = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlContenidoPrincipal.SuspendLayout()
        Me.pnlAgregarCalificacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenidoPrincipal
        '
        Me.pnlContenidoPrincipal.Controls.Add(Me.pnlAgregarCalificacion)
        Me.pnlContenidoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenidoPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenidoPrincipal.Name = "pnlContenidoPrincipal"
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(600, 481)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'pnlAgregarCalificacion
        '
        Me.pnlAgregarCalificacion.Controls.Add(Me.lblComentarioAdicionales)
        Me.pnlAgregarCalificacion.Controls.Add(Me.txtComentarioAdicionales)
        Me.pnlAgregarCalificacion.Controls.Add(Me.cmbCursos)
        Me.pnlAgregarCalificacion.Controls.Add(Me.Label1)
        Me.pnlAgregarCalificacion.Controls.Add(Me.txtAnnio)
        Me.pnlAgregarCalificacion.Controls.Add(Me.Label3)
        Me.pnlAgregarCalificacion.Controls.Add(Me.txtPeriodo)
        Me.pnlAgregarCalificacion.Controls.Add(Me.Label2)
        Me.pnlAgregarCalificacion.Controls.Add(Me.txtCalificacion)
        Me.pnlAgregarCalificacion.Controls.Add(Me.lblNombreTipoBeca)
        Me.pnlAgregarCalificacion.Controls.Add(Me.Label4)
        Me.pnlAgregarCalificacion.Controls.Add(Me.btnCancelar)
        Me.pnlAgregarCalificacion.Controls.Add(Me.btnGuardar)
        Me.pnlAgregarCalificacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgregarCalificacion.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarCalificacion.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAgregarCalificacion.Name = "pnlAgregarCalificacion"
        Me.pnlAgregarCalificacion.Size = New System.Drawing.Size(600, 481)
        Me.pnlAgregarCalificacion.TabIndex = 3
        '
        'lblComentarioAdicionales
        '
        Me.lblComentarioAdicionales.AutoSize = True
        Me.lblComentarioAdicionales.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblComentarioAdicionales.Location = New System.Drawing.Point(33, 261)
        Me.lblComentarioAdicionales.Name = "lblComentarioAdicionales"
        Me.lblComentarioAdicionales.Size = New System.Drawing.Size(144, 17)
        Me.lblComentarioAdicionales.TabIndex = 38
        Me.lblComentarioAdicionales.Text = "Comentario adicional:"
        '
        'txtComentarioAdicionales
        '
        Me.txtComentarioAdicionales.Location = New System.Drawing.Point(183, 256)
        Me.txtComentarioAdicionales.Multiline = True
        Me.txtComentarioAdicionales.Name = "txtComentarioAdicionales"
        Me.txtComentarioAdicionales.Size = New System.Drawing.Size(385, 124)
        Me.txtComentarioAdicionales.TabIndex = 37
        Me.txtComentarioAdicionales.Tag = "txtOpcional"
        '
        'cmbCursos
        '
        Me.cmbCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCursos.FormattingEnabled = True
        Me.cmbCursos.Location = New System.Drawing.Point(147, 78)
        Me.cmbCursos.Name = "cmbCursos"
        Me.cmbCursos.Size = New System.Drawing.Size(421, 28)
        Me.cmbCursos.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label1.Location = New System.Drawing.Point(33, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Curso:"
        '
        'txtAnnio
        '
        Me.txtAnnio.Location = New System.Drawing.Point(147, 207)
        Me.txtAnnio.Name = "txtAnnio"
        Me.txtAnnio.Size = New System.Drawing.Size(421, 26)
        Me.txtAnnio.TabIndex = 23
        Me.txtAnnio.Tag = "anio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label3.Location = New System.Drawing.Point(33, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 17)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Año:"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(147, 163)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(421, 26)
        Me.txtPeriodo.TabIndex = 21
        Me.txtPeriodo.Tag = "num"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label2.Location = New System.Drawing.Point(33, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 17)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Periodo:"
        '
        'txtCalificacion
        '
        Me.txtCalificacion.Location = New System.Drawing.Point(147, 118)
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.Size = New System.Drawing.Size(421, 26)
        Me.txtCalificacion.TabIndex = 17
        Me.txtCalificacion.Tag = "num"
        '
        'lblNombreTipoBeca
        '
        Me.lblNombreTipoBeca.AutoSize = True
        Me.lblNombreTipoBeca.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblNombreTipoBeca.Location = New System.Drawing.Point(33, 123)
        Me.lblNombreTipoBeca.Name = "lblNombreTipoBeca"
        Me.lblNombreTipoBeca.Size = New System.Drawing.Size(83, 17)
        Me.lblNombreTipoBeca.TabIndex = 16
        Me.lblNombreTipoBeca.Text = "Calificación:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label4.Location = New System.Drawing.Point(18, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 29)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Agregar calificación"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.DimGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(258, 419)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 47)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.ForestGreen
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(418, 419)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 47)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Agregar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmAgregarCalificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 481)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAgregarCalificacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar calificación"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlAgregarCalificacion.ResumeLayout(False)
        Me.pnlAgregarCalificacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlAgregarCalificacion As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtAnnio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCalificacion As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreTipoBeca As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCursos As System.Windows.Forms.ComboBox
    Friend WithEvents lblComentarioAdicionales As System.Windows.Forms.Label
    Friend WithEvents txtComentarioAdicionales As System.Windows.Forms.TextBox
End Class
