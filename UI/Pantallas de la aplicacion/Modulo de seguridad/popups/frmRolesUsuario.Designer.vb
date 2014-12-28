<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRolesUsuario
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlContenidoPrincipal = New System.Windows.Forms.Panel()
        Me.pnlRolesUsuario = New System.Windows.Forms.Panel()
        Me.cmbRol = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gridListaDatos = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInterv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblSubTitulo = New System.Windows.Forms.Label()
        Me.btnRemover = New System.Windows.Forms.Button()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlContenidoPrincipal.SuspendLayout()
        Me.pnlRolesUsuario.SuspendLayout()
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenidoPrincipal
        '
        Me.pnlContenidoPrincipal.Controls.Add(Me.pnlRolesUsuario)
        Me.pnlContenidoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenidoPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenidoPrincipal.Name = "pnlContenidoPrincipal"
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(759, 395)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'pnlRolesUsuario
        '
        Me.pnlRolesUsuario.Controls.Add(Me.btnSalir)
        Me.pnlRolesUsuario.Controls.Add(Me.cmbRol)
        Me.pnlRolesUsuario.Controls.Add(Me.Label1)
        Me.pnlRolesUsuario.Controls.Add(Me.gridListaDatos)
        Me.pnlRolesUsuario.Controls.Add(Me.lblSubTitulo)
        Me.pnlRolesUsuario.Controls.Add(Me.btnRemover)
        Me.pnlRolesUsuario.Controls.Add(Me.btnAsignar)
        Me.pnlRolesUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRolesUsuario.Location = New System.Drawing.Point(0, 0)
        Me.pnlRolesUsuario.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlRolesUsuario.Name = "pnlRolesUsuario"
        Me.pnlRolesUsuario.Size = New System.Drawing.Size(759, 395)
        Me.pnlRolesUsuario.TabIndex = 3
        '
        'cmbRol
        '
        Me.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRol.FormattingEnabled = True
        Me.cmbRol.Location = New System.Drawing.Point(20, 338)
        Me.cmbRol.Name = "cmbRol"
        Me.cmbRol.Size = New System.Drawing.Size(201, 28)
        Me.cmbRol.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 305)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Asignar otro rol"
        '
        'gridListaDatos
        '
        Me.gridListaDatos.AllowUserToAddRows = False
        Me.gridListaDatos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.gridListaDatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridListaDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridListaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridListaDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNombre, Me.colInterv, Me.btnDescripcion})
        Me.gridListaDatos.Location = New System.Drawing.Point(18, 15)
        Me.gridListaDatos.Name = "gridListaDatos"
        Me.gridListaDatos.ReadOnly = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.gridListaDatos.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridListaDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridListaDatos.Size = New System.Drawing.Size(707, 257)
        Me.gridListaDatos.TabIndex = 15
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
        'colInterv
        '
        Me.colInterv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colInterv.HeaderText = "Intervenciónes"
        Me.colInterv.Name = "colInterv"
        Me.colInterv.ReadOnly = True
        '
        'btnDescripcion
        '
        Me.btnDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.btnDescripcion.HeaderText = "Descripción"
        Me.btnDescripcion.Name = "btnDescripcion"
        Me.btnDescripcion.ReadOnly = True
        Me.btnDescripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'lblSubTitulo
        '
        Me.lblSubTitulo.AutoSize = True
        Me.lblSubTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lblSubTitulo.Location = New System.Drawing.Point(15, 15)
        Me.lblSubTitulo.Margin = New System.Windows.Forms.Padding(15, 15, 0, 0)
        Me.lblSubTitulo.Name = "lblSubTitulo"
        Me.lblSubTitulo.Size = New System.Drawing.Size(0, 29)
        Me.lblSubTitulo.TabIndex = 14
        '
        'btnRemover
        '
        Me.btnRemover.BackColor = System.Drawing.Color.Green
        Me.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemover.ForeColor = System.Drawing.Color.White
        Me.btnRemover.Location = New System.Drawing.Point(428, 328)
        Me.btnRemover.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnRemover.Name = "btnRemover"
        Me.btnRemover.Size = New System.Drawing.Size(150, 47)
        Me.btnRemover.TabIndex = 13
        Me.btnRemover.Text = "Remover"
        Me.btnRemover.UseVisualStyleBackColor = False
        '
        'btnAsignar
        '
        Me.btnAsignar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsignar.ForeColor = System.Drawing.Color.White
        Me.btnAsignar.Location = New System.Drawing.Point(250, 328)
        Me.btnAsignar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(150, 47)
        Me.btnAsignar.TabIndex = 12
        Me.btnAsignar.Text = "Asignar"
        Me.btnAsignar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.DimGray
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Location = New System.Drawing.Point(597, 328)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(150, 47)
        Me.btnSalir.TabIndex = 23
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'frmRolesUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 395)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmRolesUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Roles de Usuario"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlRolesUsuario.ResumeLayout(False)
        Me.pnlRolesUsuario.PerformLayout()
        CType(Me.gridListaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlRolesUsuario As System.Windows.Forms.Panel
    Friend WithEvents btnRemover As System.Windows.Forms.Button
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents lblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents cmbRol As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gridListaDatos As System.Windows.Forms.DataGridView
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInterv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
