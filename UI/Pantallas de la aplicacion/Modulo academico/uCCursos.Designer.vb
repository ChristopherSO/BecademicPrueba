<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCCursos
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTituloPrincipal = New System.Windows.Forms.Label()
        Me.gridListaDatos = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCreditos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.flwBotones = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.flwBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTituloPrincipal
        '
        Me.lblTituloPrincipal.AutoSize = True
        Me.lblTituloPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblTituloPrincipal.Location = New System.Drawing.Point(15, 15)
        Me.lblTituloPrincipal.Margin = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblTituloPrincipal.Name = "lblTituloPrincipal"
        Me.lblTituloPrincipal.Size = New System.Drawing.Size(211, 29)
        Me.lblTituloPrincipal.TabIndex = 0
        Me.lblTituloPrincipal.Text = "Administrar cursos"
        '
        'gridListaDatos
        '
        Me.gridListaDatos.AllowUserToAddRows = False
        Me.gridListaDatos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.gridListaDatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridListaDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridListaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridListaDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNombre, Me.colCodigo, Me.colPrecio, Me.colCreditos})
        Me.gridListaDatos.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridListaDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaDatos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridListaDatos.Location = New System.Drawing.Point(25, 25)
        Me.gridListaDatos.Margin = New System.Windows.Forms.Padding(15)
        Me.gridListaDatos.MultiSelect = False
        Me.gridListaDatos.Name = "gridListaDatos"
        Me.gridListaDatos.ReadOnly = True
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.gridListaDatos.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gridListaDatos.RowTemplate.Height = 50
        Me.gridListaDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridListaDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridListaDatos.ShowCellErrors = False
        Me.gridListaDatos.ShowCellToolTips = False
        Me.gridListaDatos.ShowEditingIcon = False
        Me.gridListaDatos.ShowRowErrors = False
        Me.gridListaDatos.Size = New System.Drawing.Size(1057, 338)
        Me.gridListaDatos.TabIndex = 1
        '
        'colId
        '
        Me.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colId.HeaderText = "ID"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Visible = False
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colNombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'colCodigo
        '
        Me.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCodigo.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 84
        '
        'colPrecio
        '
        Me.colPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colPrecio.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPrecio.HeaderText = "Precio"
        Me.colPrecio.Name = "colPrecio"
        Me.colPrecio.ReadOnly = True
        Me.colPrecio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPrecio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colPrecio.Width = 59
        '
        'colCreditos
        '
        Me.colCreditos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.colCreditos.DefaultCellStyle = DataGridViewCellStyle5
        Me.colCreditos.HeaderText = "Creditos"
        Me.colCreditos.Name = "colCreditos"
        Me.colCreditos.ReadOnly = True
        Me.colCreditos.Width = 93
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Location = New System.Drawing.Point(10, 20)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(187, 47)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar curso"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTituloPrincipal)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1107, 60)
        Me.pnlTitulo.TabIndex = 3
        '
        'pnlContenido
        '
        Me.pnlContenido.Controls.Add(Me.gridListaDatos)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlContenido.Location = New System.Drawing.Point(0, 60)
        Me.pnlContenido.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Padding = New System.Windows.Forms.Padding(25)
        Me.pnlContenido.Size = New System.Drawing.Size(1107, 388)
        Me.pnlContenido.TabIndex = 4
        '
        'pnlFooter
        '
        Me.pnlFooter.Controls.Add(Me.flwBotones)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFooter.Location = New System.Drawing.Point(0, 448)
        Me.pnlFooter.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(1107, 91)
        Me.pnlFooter.TabIndex = 5
        '
        'flwBotones
        '
        Me.flwBotones.Controls.Add(Me.btnAgregar)
        Me.flwBotones.Controls.Add(Me.btnActualizar)
        Me.flwBotones.Controls.Add(Me.btnEliminar)
        Me.flwBotones.Dock = System.Windows.Forms.DockStyle.Top
        Me.flwBotones.Location = New System.Drawing.Point(0, 0)
        Me.flwBotones.Name = "flwBotones"
        Me.flwBotones.Size = New System.Drawing.Size(1107, 91)
        Me.flwBotones.TabIndex = 4
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.Green
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.ForeColor = System.Drawing.Color.White
        Me.btnActualizar.Location = New System.Drawing.Point(217, 20)
        Me.btnActualizar.Margin = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(187, 47)
        Me.btnActualizar.TabIndex = 4
        Me.btnActualizar.Text = "Modificar curso"
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.DimGray
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Location = New System.Drawing.Point(424, 20)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(187, 47)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.Text = "Eliminar curso"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'uCCursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlContenido)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCCursos"
        Me.Size = New System.Drawing.Size(1107, 756)
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlFooter.ResumeLayout(False)
        Me.flwBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTituloPrincipal As System.Windows.Forms.Label
    Friend WithEvents gridListaDatos As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlContenido As System.Windows.Forms.Panel
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents flwBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreditos As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
