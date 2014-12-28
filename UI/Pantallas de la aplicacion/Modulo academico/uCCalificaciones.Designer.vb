<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCCalificaciones
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
        Me.lblTituloPrincipal = New System.Windows.Forms.Label()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvCalificaciones = New System.Windows.Forms.DataGridView()
        Me.colIdCalificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIdUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIdCurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPeriodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAnno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCalificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colComentarios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBuscar = New System.Windows.Forms.Panel()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.cmbCarreras = New System.Windows.Forms.ComboBox()
        Me.txtCarnet = New System.Windows.Forms.MaskedTextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblNotas = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.tblTiposDeBecas.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvCalificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBuscar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTituloPrincipal
        '
        Me.lblTituloPrincipal.AutoSize = True
        Me.lblTituloPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblTituloPrincipal.Location = New System.Drawing.Point(15, 15)
        Me.lblTituloPrincipal.Margin = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblTituloPrincipal.Name = "lblTituloPrincipal"
        Me.lblTituloPrincipal.Size = New System.Drawing.Size(285, 29)
        Me.lblTituloPrincipal.TabIndex = 0
        Me.lblTituloPrincipal.Text = "Administrar calificaciones"
        '
        'tblTiposDeBecas
        '
        Me.tblTiposDeBecas.AutoScroll = True
        Me.tblTiposDeBecas.ColumnCount = 1
        Me.tblTiposDeBecas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTiposDeBecas.Controls.Add(Me.lblTituloPrincipal, 0, 0)
        Me.tblTiposDeBecas.Controls.Add(Me.pnlContenido, 0, 1)
        Me.tblTiposDeBecas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTiposDeBecas.Location = New System.Drawing.Point(0, 0)
        Me.tblTiposDeBecas.Name = "tblTiposDeBecas"
        Me.tblTiposDeBecas.RowCount = 2
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'pnlContenido
        '
        Me.pnlContenido.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(3, 63)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(1101, 690)
        Me.pnlContenido.TabIndex = 4
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.dgvCalificaciones, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlBuscar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1101, 690)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'dgvCalificaciones
        '
        Me.dgvCalificaciones.AllowUserToAddRows = False
        Me.dgvCalificaciones.AllowUserToDeleteRows = False
        Me.dgvCalificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCalificaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIdCalificacion, Me.colIdUsuario, Me.colIdCurso, Me.colCurso, Me.colCodigo, Me.colPeriodo, Me.colAnno, Me.colCalificacion, Me.colComentarios})
        Me.dgvCalificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCalificaciones.Location = New System.Drawing.Point(3, 178)
        Me.dgvCalificaciones.Name = "dgvCalificaciones"
        Me.dgvCalificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCalificaciones.Size = New System.Drawing.Size(1095, 459)
        Me.dgvCalificaciones.TabIndex = 5
        '
        'colIdCalificacion
        '
        Me.colIdCalificacion.HeaderText = "Id calificación"
        Me.colIdCalificacion.Name = "colIdCalificacion"
        Me.colIdCalificacion.Visible = False
        '
        'colIdUsuario
        '
        Me.colIdUsuario.HeaderText = "Id usuario"
        Me.colIdUsuario.Name = "colIdUsuario"
        Me.colIdUsuario.Visible = False
        '
        'colIdCurso
        '
        Me.colIdCurso.HeaderText = "Id curso"
        Me.colIdCurso.Name = "colIdCurso"
        Me.colIdCurso.Visible = False
        '
        'colCurso
        '
        Me.colCurso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCurso.HeaderText = "Curso"
        Me.colCurso.Name = "colCurso"
        Me.colCurso.ReadOnly = True
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        '
        'colPeriodo
        '
        Me.colPeriodo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPeriodo.HeaderText = "Periódo"
        Me.colPeriodo.Name = "colPeriodo"
        Me.colPeriodo.ReadOnly = True
        '
        'colAnno
        '
        Me.colAnno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAnno.HeaderText = "Año"
        Me.colAnno.Name = "colAnno"
        Me.colAnno.ReadOnly = True
        '
        'colCalificacion
        '
        Me.colCalificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colCalificacion.HeaderText = "Calificación"
        Me.colCalificacion.Name = "colCalificacion"
        Me.colCalificacion.ReadOnly = True
        '
        'colComentarios
        '
        Me.colComentarios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colComentarios.HeaderText = "Comentarios"
        Me.colComentarios.Name = "colComentarios"
        Me.colComentarios.ReadOnly = True
        '
        'pnlBuscar
        '
        Me.pnlBuscar.Controls.Add(Me.lblMsg)
        Me.pnlBuscar.Controls.Add(Me.cmbCarreras)
        Me.pnlBuscar.Controls.Add(Me.txtCarnet)
        Me.pnlBuscar.Controls.Add(Me.btnBuscar)
        Me.pnlBuscar.Controls.Add(Me.lblNotas)
        Me.pnlBuscar.Controls.Add(Me.Label2)
        Me.pnlBuscar.Controls.Add(Me.Label1)
        Me.pnlBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBuscar.Location = New System.Drawing.Point(3, 3)
        Me.pnlBuscar.Name = "pnlBuscar"
        Me.pnlBuscar.Size = New System.Drawing.Size(1095, 169)
        Me.pnlBuscar.TabIndex = 0
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMsg.Location = New System.Drawing.Point(551, 28)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 13)
        Me.lblMsg.TabIndex = 21
        '
        'cmbCarreras
        '
        Me.cmbCarreras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCarreras.FormattingEnabled = True
        Me.cmbCarreras.Location = New System.Drawing.Point(205, 70)
        Me.cmbCarreras.Name = "cmbCarreras"
        Me.cmbCarreras.Size = New System.Drawing.Size(340, 28)
        Me.cmbCarreras.TabIndex = 20
        '
        'txtCarnet
        '
        Me.txtCarnet.Location = New System.Drawing.Point(205, 22)
        Me.txtCarnet.Mask = "000000000"
        Me.txtCarnet.Name = "txtCarnet"
        Me.txtCarnet.Size = New System.Drawing.Size(340, 26)
        Me.txtCarnet.TabIndex = 19
        Me.txtCarnet.Tag = "cedula"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.Color.White
        Me.btnBuscar.Location = New System.Drawing.Point(719, 70)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(142, 33)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'lblNotas
        '
        Me.lblNotas.AutoSize = True
        Me.lblNotas.Location = New System.Drawing.Point(11, 129)
        Me.lblNotas.Name = "lblNotas"
        Me.lblNotas.Size = New System.Drawing.Size(125, 20)
        Me.lblNotas.TabIndex = 4
        Me.lblNotas.Text = "Notas por curso:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Carrera:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Carnet de estudiante:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAgregar)
        Me.Panel1.Controls.Add(Me.btnActualizar)
        Me.Panel1.Controls.Add(Me.btnEliminar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 643)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1095, 44)
        Me.Panel1.TabIndex = 6
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Location = New System.Drawing.Point(573, 0)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(174, 44)
        Me.btnAgregar.TabIndex = 26
        Me.btnAgregar.Text = "Agregar calificación"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.Green
        Me.btnActualizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.ForeColor = System.Drawing.Color.White
        Me.btnActualizar.Location = New System.Drawing.Point(747, 0)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(174, 44)
        Me.btnActualizar.TabIndex = 25
        Me.btnActualizar.Text = "Actualizar calificación"
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.DimGray
        Me.btnEliminar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Location = New System.Drawing.Point(921, 0)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(174, 44)
        Me.btnEliminar.TabIndex = 23
        Me.btnEliminar.Text = "Eliminar calificación"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'uCCalificaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCCalificaciones"
        Me.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.tblTiposDeBecas.PerformLayout()
        Me.pnlContenido.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvCalificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBuscar.ResumeLayout(False)
        Me.pnlBuscar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTituloPrincipal As System.Windows.Forms.Label
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlContenido As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlBuscar As System.Windows.Forms.Panel
    Friend WithEvents lblNotas As System.Windows.Forms.Label
    Friend WithEvents dgvCalificaciones As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtCarnet As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmbCarreras As System.Windows.Forms.ComboBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents colIdCalificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIdUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIdCurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPeriodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAnno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCalificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComentarios As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button

End Class
