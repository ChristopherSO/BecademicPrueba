<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCTiposDeBecas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnAgregarTipoBeca = New System.Windows.Forms.Button()
        Me.pnlAgregarTipoDeBeca = New System.Windows.Forms.Panel()
        Me.lblFiltrar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvTipoBecas = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIcono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.btnEliminarTipoBeca = New System.Windows.Forms.Button()
        Me.btnModificarTipoBeca = New System.Windows.Forms.Button()
        Me.btnAsignarCarrera = New System.Windows.Forms.Button()
        Me.btnAsignarRequisito = New System.Windows.Forms.Button()
        Me.btnAsignarBeneficio = New System.Windows.Forms.Button()
        Me.lblTituloPrincipal = New System.Windows.Forms.Label()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlAgregarTipoDeBeca.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvTipoBecas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblTiposDeBecas.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAgregarTipoBeca
        '
        Me.btnAgregarTipoBeca.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregarTipoBeca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarTipoBeca.ForeColor = System.Drawing.Color.White
        Me.btnAgregarTipoBeca.Location = New System.Drawing.Point(23, 31)
        Me.btnAgregarTipoBeca.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnAgregarTipoBeca.Name = "btnAgregarTipoBeca"
        Me.btnAgregarTipoBeca.Size = New System.Drawing.Size(174, 47)
        Me.btnAgregarTipoBeca.TabIndex = 3
        Me.btnAgregarTipoBeca.Text = "Agregar tipo de beca"
        Me.btnAgregarTipoBeca.UseVisualStyleBackColor = False
        '
        'pnlAgregarTipoDeBeca
        '
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.lblFiltrar)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.Panel1)
        Me.pnlAgregarTipoDeBeca.Controls.Add(Me.txtBusqueda)
        Me.pnlAgregarTipoDeBeca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgregarTipoDeBeca.Location = New System.Drawing.Point(0, 65)
        Me.pnlAgregarTipoDeBeca.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAgregarTipoDeBeca.Name = "pnlAgregarTipoDeBeca"
        Me.pnlAgregarTipoDeBeca.Size = New System.Drawing.Size(1107, 330)
        Me.pnlAgregarTipoDeBeca.TabIndex = 2
        '
        'lblFiltrar
        '
        Me.lblFiltrar.AutoSize = True
        Me.lblFiltrar.Location = New System.Drawing.Point(20, 9)
        Me.lblFiltrar.Name = "lblFiltrar"
        Me.lblFiltrar.Size = New System.Drawing.Size(49, 20)
        Me.lblFiltrar.TabIndex = 10
        Me.lblFiltrar.Text = "Filtrar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvTipoBecas)
        Me.Panel1.Location = New System.Drawing.Point(0, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1107, 298)
        Me.Panel1.TabIndex = 10
        '
        'dgvTipoBecas
        '
        Me.dgvTipoBecas.AllowUserToAddRows = False
        Me.dgvTipoBecas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.dgvTipoBecas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTipoBecas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvTipoBecas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipoBecas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNombre, Me.colDescripcion, Me.colIcono, Me.colColor})
        Me.dgvTipoBecas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTipoBecas.Location = New System.Drawing.Point(0, 0)
        Me.dgvTipoBecas.Margin = New System.Windows.Forms.Padding(25, 3, 25, 3)
        Me.dgvTipoBecas.Name = "dgvTipoBecas"
        Me.dgvTipoBecas.ReadOnly = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.dgvTipoBecas.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTipoBecas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTipoBecas.ShowCellErrors = False
        Me.dgvTipoBecas.ShowCellToolTips = False
        Me.dgvTipoBecas.ShowEditingIcon = False
        Me.dgvTipoBecas.ShowRowErrors = False
        Me.dgvTipoBecas.Size = New System.Drawing.Size(1107, 298)
        Me.dgvTipoBecas.TabIndex = 1
        '
        'colId
        '
        Me.colId.HeaderText = "ID"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Visible = False
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'colDescripcion
        '
        Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        '
        'colIcono
        '
        Me.colIcono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colIcono.HeaderText = "Icono"
        Me.colIcono.Name = "colIcono"
        Me.colIcono.ReadOnly = True
        '
        'colColor
        '
        Me.colColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colColor.HeaderText = "Color"
        Me.colColor.Name = "colColor"
        Me.colColor.ReadOnly = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtBusqueda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBusqueda.Location = New System.Drawing.Point(75, 3)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(175, 26)
        Me.txtBusqueda.TabIndex = 9
        '
        'btnEliminarTipoBeca
        '
        Me.btnEliminarTipoBeca.BackColor = System.Drawing.Color.DimGray
        Me.btnEliminarTipoBeca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarTipoBeca.ForeColor = System.Drawing.Color.White
        Me.btnEliminarTipoBeca.Location = New System.Drawing.Point(443, 31)
        Me.btnEliminarTipoBeca.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnEliminarTipoBeca.Name = "btnEliminarTipoBeca"
        Me.btnEliminarTipoBeca.Size = New System.Drawing.Size(169, 47)
        Me.btnEliminarTipoBeca.TabIndex = 8
        Me.btnEliminarTipoBeca.Text = "Eliminar tipo de beca"
        Me.btnEliminarTipoBeca.UseVisualStyleBackColor = False
        '
        'btnModificarTipoBeca
        '
        Me.btnModificarTipoBeca.BackColor = System.Drawing.Color.Green
        Me.btnModificarTipoBeca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModificarTipoBeca.ForeColor = System.Drawing.Color.White
        Me.btnModificarTipoBeca.Location = New System.Drawing.Point(232, 31)
        Me.btnModificarTipoBeca.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnModificarTipoBeca.Name = "btnModificarTipoBeca"
        Me.btnModificarTipoBeca.Size = New System.Drawing.Size(174, 47)
        Me.btnModificarTipoBeca.TabIndex = 7
        Me.btnModificarTipoBeca.Text = "Modificar tipo de beca"
        Me.btnModificarTipoBeca.UseVisualStyleBackColor = False
        '
        'btnAsignarCarrera
        '
        Me.btnAsignarCarrera.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.btnAsignarCarrera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsignarCarrera.ForeColor = System.Drawing.Color.White
        Me.btnAsignarCarrera.Location = New System.Drawing.Point(443, 115)
        Me.btnAsignarCarrera.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnAsignarCarrera.Name = "btnAsignarCarrera"
        Me.btnAsignarCarrera.Size = New System.Drawing.Size(169, 47)
        Me.btnAsignarCarrera.TabIndex = 6
        Me.btnAsignarCarrera.Text = "Carreras asociadas"
        Me.btnAsignarCarrera.UseVisualStyleBackColor = False
        '
        'btnAsignarRequisito
        '
        Me.btnAsignarRequisito.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.btnAsignarRequisito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsignarRequisito.ForeColor = System.Drawing.Color.White
        Me.btnAsignarRequisito.Location = New System.Drawing.Point(27, 115)
        Me.btnAsignarRequisito.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnAsignarRequisito.Name = "btnAsignarRequisito"
        Me.btnAsignarRequisito.Size = New System.Drawing.Size(170, 47)
        Me.btnAsignarRequisito.TabIndex = 5
        Me.btnAsignarRequisito.Text = "Requisitos asociados"
        Me.btnAsignarRequisito.UseVisualStyleBackColor = False
        '
        'btnAsignarBeneficio
        '
        Me.btnAsignarBeneficio.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.btnAsignarBeneficio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsignarBeneficio.ForeColor = System.Drawing.Color.White
        Me.btnAsignarBeneficio.Location = New System.Drawing.Point(232, 115)
        Me.btnAsignarBeneficio.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnAsignarBeneficio.Name = "btnAsignarBeneficio"
        Me.btnAsignarBeneficio.Size = New System.Drawing.Size(170, 47)
        Me.btnAsignarBeneficio.TabIndex = 4
        Me.btnAsignarBeneficio.Text = "Beneficio asociados"
        Me.btnAsignarBeneficio.UseVisualStyleBackColor = False
        '
        'lblTituloPrincipal
        '
        Me.lblTituloPrincipal.AutoSize = True
        Me.lblTituloPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblTituloPrincipal.Location = New System.Drawing.Point(15, 15)
        Me.lblTituloPrincipal.Margin = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblTituloPrincipal.Name = "lblTituloPrincipal"
        Me.lblTituloPrincipal.Size = New System.Drawing.Size(297, 29)
        Me.lblTituloPrincipal.TabIndex = 0
        Me.lblTituloPrincipal.Text = "Administrar tipos de becas"
        '
        'tblTiposDeBecas
        '
        Me.tblTiposDeBecas.AutoScroll = True
        Me.tblTiposDeBecas.ColumnCount = 1
        Me.tblTiposDeBecas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTiposDeBecas.Controls.Add(Me.lblTituloPrincipal, 0, 0)
        Me.tblTiposDeBecas.Controls.Add(Me.pnlAgregarTipoDeBeca, 0, 2)
        Me.tblTiposDeBecas.Controls.Add(Me.Panel2, 0, 3)
        Me.tblTiposDeBecas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTiposDeBecas.Location = New System.Drawing.Point(0, 0)
        Me.tblTiposDeBecas.Name = "tblTiposDeBecas"
        Me.tblTiposDeBecas.RowCount = 4
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 330.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnAsignarCarrera)
        Me.Panel2.Controls.Add(Me.btnEliminarTipoBeca)
        Me.Panel2.Controls.Add(Me.btnModificarTipoBeca)
        Me.Panel2.Controls.Add(Me.btnAgregarTipoBeca)
        Me.Panel2.Controls.Add(Me.btnAsignarRequisito)
        Me.Panel2.Controls.Add(Me.btnAsignarBeneficio)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 398)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1101, 355)
        Me.Panel2.TabIndex = 3
        '
        'uCTiposDeBecas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCTiposDeBecas"
        Me.Size = New System.Drawing.Size(1107, 756)
        Me.pnlAgregarTipoDeBeca.ResumeLayout(False)
        Me.pnlAgregarTipoDeBeca.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvTipoBecas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.tblTiposDeBecas.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAgregarTipoBeca As System.Windows.Forms.Button
    Friend WithEvents pnlAgregarTipoDeBeca As System.Windows.Forms.Panel
    Friend WithEvents lblTituloPrincipal As System.Windows.Forms.Label
    Friend WithEvents dgvTipoBecas As System.Windows.Forms.DataGridView
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEliminarTipoBeca As System.Windows.Forms.Button
    Friend WithEvents btnModificarTipoBeca As System.Windows.Forms.Button
    Friend WithEvents btnAsignarCarrera As System.Windows.Forms.Button
    Friend WithEvents btnAsignarRequisito As System.Windows.Forms.Button
    Friend WithEvents btnAsignarBeneficio As System.Windows.Forms.Button
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIcono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblFiltrar As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

End Class
