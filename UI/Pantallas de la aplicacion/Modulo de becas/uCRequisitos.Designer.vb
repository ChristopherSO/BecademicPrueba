<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCRequisitos
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblTituloPrincipal = New System.Windows.Forms.Label()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCreditos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlAgregarRequisito = New System.Windows.Forms.Panel()
        Me.btnBorrarRequisito = New System.Windows.Forms.Button()
        Me.btnActualizarRequisito = New System.Windows.Forms.Button()
        Me.btnAgregarRequisito = New System.Windows.Forms.Button()
        Me.gridListaDatos = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipoRequisito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tblTiposDeBecas.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAgregarRequisito.SuspendLayout()
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTituloPrincipal
        '
        Me.lblTituloPrincipal.AutoSize = True
        Me.lblTituloPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblTituloPrincipal.Location = New System.Drawing.Point(15, 15)
        Me.lblTituloPrincipal.Margin = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblTituloPrincipal.Name = "lblTituloPrincipal"
        Me.lblTituloPrincipal.Size = New System.Drawing.Size(350, 29)
        Me.lblTituloPrincipal.TabIndex = 0
        Me.lblTituloPrincipal.Text = "Administrar requisitos de becas"
        '
        'tblTiposDeBecas
        '
        Me.tblTiposDeBecas.AutoScroll = True
        Me.tblTiposDeBecas.ColumnCount = 1
        Me.tblTiposDeBecas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTiposDeBecas.Controls.Add(Me.DataGridView1, 0, 3)
        Me.tblTiposDeBecas.Controls.Add(Me.pnlAgregarRequisito, 0, 2)
        Me.tblTiposDeBecas.Controls.Add(Me.gridListaDatos, 0, 1)
        Me.tblTiposDeBecas.Controls.Add(Me.lblTituloPrincipal, 0, 0)
        Me.tblTiposDeBecas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTiposDeBecas.Location = New System.Drawing.Point(0, 0)
        Me.tblTiposDeBecas.Margin = New System.Windows.Forms.Padding(0)
        Me.tblTiposDeBecas.Name = "tblTiposDeBecas"
        Me.tblTiposDeBecas.RowCount = 4
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 380.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.colCodigo, Me.colPrecio, Me.colCreditos})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(15, 813)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(15)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.RowTemplate.Height = 50
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowCellErrors = False
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(1077, 1)
        Me.DataGridView1.TabIndex = 5
        Me.DataGridView1.UseWaitCursor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
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
        'pnlAgregarRequisito
        '
        Me.pnlAgregarRequisito.Controls.Add(Me.btnBorrarRequisito)
        Me.pnlAgregarRequisito.Controls.Add(Me.btnActualizarRequisito)
        Me.pnlAgregarRequisito.Controls.Add(Me.btnAgregarRequisito)
        Me.pnlAgregarRequisito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgregarRequisito.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlAgregarRequisito.Location = New System.Drawing.Point(0, 418)
        Me.pnlAgregarRequisito.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAgregarRequisito.Name = "pnlAgregarRequisito"
        Me.pnlAgregarRequisito.Size = New System.Drawing.Size(1107, 380)
        Me.pnlAgregarRequisito.TabIndex = 4
        '
        'btnBorrarRequisito
        '
        Me.btnBorrarRequisito.BackColor = System.Drawing.Color.DimGray
        Me.btnBorrarRequisito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrarRequisito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrarRequisito.ForeColor = System.Drawing.Color.White
        Me.btnBorrarRequisito.Location = New System.Drawing.Point(403, 8)
        Me.btnBorrarRequisito.Margin = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.btnBorrarRequisito.Name = "btnBorrarRequisito"
        Me.btnBorrarRequisito.Size = New System.Drawing.Size(174, 47)
        Me.btnBorrarRequisito.TabIndex = 8
        Me.btnBorrarRequisito.Text = "Borrar requisito"
        Me.btnBorrarRequisito.UseVisualStyleBackColor = False
        '
        'btnActualizarRequisito
        '
        Me.btnActualizarRequisito.BackColor = System.Drawing.Color.Green
        Me.btnActualizarRequisito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizarRequisito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizarRequisito.ForeColor = System.Drawing.Color.White
        Me.btnActualizarRequisito.Location = New System.Drawing.Point(209, 8)
        Me.btnActualizarRequisito.Margin = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.btnActualizarRequisito.Name = "btnActualizarRequisito"
        Me.btnActualizarRequisito.Size = New System.Drawing.Size(174, 47)
        Me.btnActualizarRequisito.TabIndex = 7
        Me.btnActualizarRequisito.Text = "Modificar requisito"
        Me.btnActualizarRequisito.UseVisualStyleBackColor = False
        '
        'btnAgregarRequisito
        '
        Me.btnAgregarRequisito.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregarRequisito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarRequisito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarRequisito.ForeColor = System.Drawing.Color.White
        Me.btnAgregarRequisito.Location = New System.Drawing.Point(15, 8)
        Me.btnAgregarRequisito.Margin = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.btnAgregarRequisito.Name = "btnAgregarRequisito"
        Me.btnAgregarRequisito.Size = New System.Drawing.Size(174, 47)
        Me.btnAgregarRequisito.TabIndex = 6
        Me.btnAgregarRequisito.Text = "Agregar requisito"
        Me.btnAgregarRequisito.UseVisualStyleBackColor = False
        '
        'gridListaDatos
        '
        Me.gridListaDatos.AllowUserToAddRows = False
        Me.gridListaDatos.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        Me.gridListaDatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.gridListaDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridListaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridListaDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colTipoRequisito, Me.colNombre, Me.colDescripcion})
        Me.gridListaDatos.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridListaDatos.DefaultCellStyle = DataGridViewCellStyle8
        Me.gridListaDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaDatos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridListaDatos.Location = New System.Drawing.Point(15, 72)
        Me.gridListaDatos.Margin = New System.Windows.Forms.Padding(15)
        Me.gridListaDatos.MultiSelect = False
        Me.gridListaDatos.Name = "gridListaDatos"
        Me.gridListaDatos.ReadOnly = True
        Me.gridListaDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridListaDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridListaDatos.ShowCellErrors = False
        Me.gridListaDatos.ShowCellToolTips = False
        Me.gridListaDatos.ShowEditingIcon = False
        Me.gridListaDatos.ShowRowErrors = False
        Me.gridListaDatos.Size = New System.Drawing.Size(1077, 331)
        Me.gridListaDatos.TabIndex = 1
        '
        'colId
        '
        Me.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colId.HeaderText = "Id"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Visible = False
        '
        'colTipoRequisito
        '
        Me.colTipoRequisito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTipoRequisito.HeaderText = "Tipo requisito"
        Me.colTipoRequisito.Name = "colTipoRequisito"
        Me.colTipoRequisito.ReadOnly = True
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
        Me.colDescripcion.HeaderText = "Descripcion"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        '
        'uCRequisitos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCRequisitos"
        Me.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.tblTiposDeBecas.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAgregarRequisito.ResumeLayout(False)
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTituloPrincipal As System.Windows.Forms.Label
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlAgregarRequisito As System.Windows.Forms.Panel
    Friend WithEvents btnBorrarRequisito As System.Windows.Forms.Button
    Friend WithEvents btnActualizarRequisito As System.Windows.Forms.Button
    Friend WithEvents btnAgregarRequisito As System.Windows.Forms.Button
    Friend WithEvents gridListaDatos As System.Windows.Forms.DataGridView
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipoRequisito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
