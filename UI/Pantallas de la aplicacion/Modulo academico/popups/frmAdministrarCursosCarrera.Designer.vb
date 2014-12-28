<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdministrarCursosCarrera
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlContenidoPrincipal = New System.Windows.Forms.Panel()
        Me.pnlAdministrarCursos = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnBorrarAsignacion = New System.Windows.Forms.Button()
        Me.dgvCursos = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPeriodo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCursosAsignados = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.pnlContenidoPrincipal.SuspendLayout()
        Me.pnlAdministrarCursos.SuspendLayout()
        CType(Me.dgvCursos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCursosAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenidoPrincipal
        '
        Me.pnlContenidoPrincipal.Controls.Add(Me.pnlAdministrarCursos)
        Me.pnlContenidoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenidoPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenidoPrincipal.Name = "pnlContenidoPrincipal"
        Me.pnlContenidoPrincipal.Size = New System.Drawing.Size(1052, 436)
        Me.pnlContenidoPrincipal.TabIndex = 0
        '
        'pnlAdministrarCursos
        '
        Me.pnlAdministrarCursos.Controls.Add(Me.btnCancelar)
        Me.pnlAdministrarCursos.Controls.Add(Me.btnBorrarAsignacion)
        Me.pnlAdministrarCursos.Controls.Add(Me.dgvCursos)
        Me.pnlAdministrarCursos.Controls.Add(Me.txtPeriodo)
        Me.pnlAdministrarCursos.Controls.Add(Me.Label1)
        Me.pnlAdministrarCursos.Controls.Add(Me.dgvCursosAsignados)
        Me.pnlAdministrarCursos.Controls.Add(Me.Label2)
        Me.pnlAdministrarCursos.Controls.Add(Me.lbl)
        Me.pnlAdministrarCursos.Controls.Add(Me.btnAsignar)
        Me.pnlAdministrarCursos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAdministrarCursos.Location = New System.Drawing.Point(0, 0)
        Me.pnlAdministrarCursos.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAdministrarCursos.Name = "pnlAdministrarCursos"
        Me.pnlAdministrarCursos.Size = New System.Drawing.Size(1052, 436)
        Me.pnlAdministrarCursos.TabIndex = 3
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.DimGray
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(881, 355)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 47)
        Me.btnCancelar.TabIndex = 28
        Me.btnCancelar.Text = "Salir"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnBorrarAsignacion
        '
        Me.btnBorrarAsignacion.BackColor = System.Drawing.Color.Green
        Me.btnBorrarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrarAsignacion.ForeColor = System.Drawing.Color.White
        Me.btnBorrarAsignacion.Location = New System.Drawing.Point(709, 355)
        Me.btnBorrarAsignacion.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnBorrarAsignacion.Name = "btnBorrarAsignacion"
        Me.btnBorrarAsignacion.Size = New System.Drawing.Size(150, 47)
        Me.btnBorrarAsignacion.TabIndex = 27
        Me.btnBorrarAsignacion.Text = "Remover"
        Me.btnBorrarAsignacion.UseVisualStyleBackColor = False
        '
        'dgvCursos
        '
        Me.dgvCursos.AllowUserToAddRows = False
        Me.dgvCursos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.dgvCursos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCursos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCursos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvCursos.Location = New System.Drawing.Point(534, 60)
        Me.dgvCursos.Name = "dgvCursos"
        Me.dgvCursos.ReadOnly = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.dgvCursos.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCursos.Size = New System.Drawing.Size(497, 259)
        Me.dgvCursos.TabIndex = 26
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(25, 376)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(290, 26)
        Me.txtPeriodo.TabIndex = 25
        Me.txtPeriodo.Tag = "num"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label1.Location = New System.Drawing.Point(22, 344)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Periodo:"
        '
        'dgvCursosAsignados
        '
        Me.dgvCursosAsignados.AllowUserToAddRows = False
        Me.dgvCursosAsignados.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.dgvCursosAsignados.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCursosAsignados.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCursosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCursosAsignados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNombre})
        Me.dgvCursosAsignados.Location = New System.Drawing.Point(25, 60)
        Me.dgvCursosAsignados.Name = "dgvCursosAsignados"
        Me.dgvCursosAsignados.ReadOnly = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.dgvCursosAsignados.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCursosAsignados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCursosAsignados.Size = New System.Drawing.Size(479, 259)
        Me.dgvCursosAsignados.TabIndex = 23
        '
        'colId
        '
        Me.colId.HeaderText = "Id"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label2.Location = New System.Drawing.Point(22, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 17)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Cursos Asignados:"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lbl.Location = New System.Drawing.Point(531, 26)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(49, 17)
        Me.lbl.TabIndex = 16
        Me.lbl.Text = "Curso:"
        '
        'btnAsignar
        '
        Me.btnAsignar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsignar.ForeColor = System.Drawing.Color.White
        Me.btnAsignar.Location = New System.Drawing.Point(534, 355)
        Me.btnAsignar.Margin = New System.Windows.Forms.Padding(135, 10, 3, 15)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(150, 47)
        Me.btnAsignar.TabIndex = 12
        Me.btnAsignar.Text = "Asignar"
        Me.btnAsignar.UseVisualStyleBackColor = False
        '
        'frmAdministrarCursosCarrera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 436)
        Me.Controls.Add(Me.pnlContenidoPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAdministrarCursosCarrera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Administrar cursos de carrera"
        Me.pnlContenidoPrincipal.ResumeLayout(False)
        Me.pnlAdministrarCursos.ResumeLayout(False)
        Me.pnlAdministrarCursos.PerformLayout()
        CType(Me.dgvCursos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCursosAsignados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenidoPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlAdministrarCursos As System.Windows.Forms.Panel
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents dgvCursosAsignados As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents dgvCursos As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnBorrarAsignacion As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
