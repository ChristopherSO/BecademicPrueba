<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCMejoresPromediosTodasCarreras
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.rpvMejorPromedioTodasCarrera = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.pnlParameters = New System.Windows.Forms.Panel()
        Me.tlpHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlCampos = New System.Windows.Forms.Panel()
        Me.lblMsgAnio = New System.Windows.Forms.Label()
        Me.lblMsgPeriodo = New System.Windows.Forms.Label()
        Me.txtAnioFinal = New System.Windows.Forms.TextBox()
        Me.txtAnioInicio = New System.Windows.Forms.TextBox()
        Me.cmbPeriodoFinal = New System.Windows.Forms.ComboBox()
        Me.cmbPeriodoInicio = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPeriodoFinal = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblPeriodoInicio = New System.Windows.Forms.Label()
        Me.lblMsgCantResultado = New System.Windows.Forms.Label()
        Me.txtCantResultado = New System.Windows.Forms.TextBox()
        Me.lblCantResultado = New System.Windows.Forms.Label()
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblMejorPromedioTodasCarrera = New System.Windows.Forms.Label()
        Me.beca_becademicDataSet = New UI.beca_becademicDataSet()
        Me.pa_reporte_mejores_promedios_todas_las_carrerasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pa_reporte_mejores_promedios_todas_las_carrerasTableAdapter = New UI.beca_becademicDataSetTableAdapters.pa_reporte_mejores_promedios_todas_las_carrerasTableAdapter()
        Me.tblTiposDeBecas.SuspendLayout()
        Me.pnlPrincipal.SuspendLayout()
        Me.pnlParameters.SuspendLayout()
        Me.tlpHeader.SuspendLayout()
        Me.pnlCampos.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.beca_becademicDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pa_reporte_mejores_promedios_todas_las_carrerasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblTiposDeBecas
        '
        Me.tblTiposDeBecas.AutoScroll = True
        Me.tblTiposDeBecas.ColumnCount = 1
        Me.tblTiposDeBecas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblTiposDeBecas.Controls.Add(Me.pnlPrincipal, 0, 2)
        Me.tblTiposDeBecas.Controls.Add(Me.pnlParameters, 0, 1)
        Me.tblTiposDeBecas.Controls.Add(Me.pnlHeader, 0, 0)
        Me.tblTiposDeBecas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTiposDeBecas.Location = New System.Drawing.Point(0, 0)
        Me.tblTiposDeBecas.Name = "tblTiposDeBecas"
        Me.tblTiposDeBecas.RowCount = 3
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.rpvMejorPromedioTodasCarrera)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(3, 235)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(1101, 518)
        Me.pnlPrincipal.TabIndex = 0
        '
        'rpvMejorPromedioTodasCarrera
        '
        Me.rpvMejorPromedioTodasCarrera.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "MejoresPromediosCarrerasDataSet"
        ReportDataSource2.Value = Me.pa_reporte_mejores_promedios_todas_las_carrerasBindingSource
        Me.rpvMejorPromedioTodasCarrera.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rpvMejorPromedioTodasCarrera.LocalReport.ReportEmbeddedResource = "UI.ReporteMejoresCarreras.rdlc"
        Me.rpvMejorPromedioTodasCarrera.Location = New System.Drawing.Point(0, 0)
        Me.rpvMejorPromedioTodasCarrera.Name = "rpvMejorPromedioTodasCarrera"
        Me.rpvMejorPromedioTodasCarrera.Size = New System.Drawing.Size(1101, 518)
        Me.rpvMejorPromedioTodasCarrera.TabIndex = 0
        '
        'pnlParameters
        '
        Me.pnlParameters.Controls.Add(Me.tlpHeader)
        Me.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParameters.Location = New System.Drawing.Point(3, 79)
        Me.pnlParameters.Name = "pnlParameters"
        Me.pnlParameters.Size = New System.Drawing.Size(1101, 150)
        Me.pnlParameters.TabIndex = 1
        '
        'tlpHeader
        '
        Me.tlpHeader.ColumnCount = 2
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.4723!))
        Me.tlpHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5277!))
        Me.tlpHeader.Controls.Add(Me.pnlCampos, 0, 0)
        Me.tlpHeader.Controls.Add(Me.pnlButton, 1, 0)
        Me.tlpHeader.Location = New System.Drawing.Point(0, 0)
        Me.tlpHeader.Name = "tlpHeader"
        Me.tlpHeader.RowCount = 1
        Me.tlpHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpHeader.Size = New System.Drawing.Size(1101, 150)
        Me.tlpHeader.TabIndex = 0
        '
        'pnlCampos
        '
        Me.pnlCampos.Controls.Add(Me.lblMsgAnio)
        Me.pnlCampos.Controls.Add(Me.lblMsgPeriodo)
        Me.pnlCampos.Controls.Add(Me.txtAnioFinal)
        Me.pnlCampos.Controls.Add(Me.txtAnioInicio)
        Me.pnlCampos.Controls.Add(Me.cmbPeriodoFinal)
        Me.pnlCampos.Controls.Add(Me.cmbPeriodoInicio)
        Me.pnlCampos.Controls.Add(Me.Label4)
        Me.pnlCampos.Controls.Add(Me.lblPeriodoFinal)
        Me.pnlCampos.Controls.Add(Me.lblFechaInicio)
        Me.pnlCampos.Controls.Add(Me.lblPeriodoInicio)
        Me.pnlCampos.Controls.Add(Me.lblMsgCantResultado)
        Me.pnlCampos.Controls.Add(Me.txtCantResultado)
        Me.pnlCampos.Controls.Add(Me.lblCantResultado)
        Me.pnlCampos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCampos.Location = New System.Drawing.Point(0, 0)
        Me.pnlCampos.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCampos.Name = "pnlCampos"
        Me.pnlCampos.Size = New System.Drawing.Size(885, 150)
        Me.pnlCampos.TabIndex = 0
        '
        'lblMsgAnio
        '
        Me.lblMsgAnio.AutoSize = True
        Me.lblMsgAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgAnio.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMsgAnio.Location = New System.Drawing.Point(295, 73)
        Me.lblMsgAnio.Name = "lblMsgAnio"
        Me.lblMsgAnio.Size = New System.Drawing.Size(0, 15)
        Me.lblMsgAnio.TabIndex = 28
        '
        'lblMsgPeriodo
        '
        Me.lblMsgPeriodo.AutoSize = True
        Me.lblMsgPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgPeriodo.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMsgPeriodo.Location = New System.Drawing.Point(196, 40)
        Me.lblMsgPeriodo.Name = "lblMsgPeriodo"
        Me.lblMsgPeriodo.Size = New System.Drawing.Size(0, 15)
        Me.lblMsgPeriodo.TabIndex = 27
        '
        'txtAnioFinal
        '
        Me.txtAnioFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioFinal.ForeColor = System.Drawing.Color.LightGray
        Me.txtAnioFinal.Location = New System.Drawing.Point(640, 59)
        Me.txtAnioFinal.Name = "txtAnioFinal"
        Me.txtAnioFinal.Size = New System.Drawing.Size(90, 26)
        Me.txtAnioFinal.TabIndex = 26
        Me.txtAnioFinal.Tag = "anio"
        '
        'txtAnioInicio
        '
        Me.txtAnioInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioInicio.ForeColor = System.Drawing.Color.LightGray
        Me.txtAnioInicio.Location = New System.Drawing.Point(199, 62)
        Me.txtAnioInicio.Name = "txtAnioInicio"
        Me.txtAnioInicio.Size = New System.Drawing.Size(90, 26)
        Me.txtAnioInicio.TabIndex = 25
        Me.txtAnioInicio.Tag = "anio"
        '
        'cmbPeriodoFinal
        '
        Me.cmbPeriodoFinal.DisplayMember = "0"
        Me.cmbPeriodoFinal.FormattingEnabled = True
        Me.cmbPeriodoFinal.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbPeriodoFinal.Location = New System.Drawing.Point(640, 12)
        Me.cmbPeriodoFinal.Name = "cmbPeriodoFinal"
        Me.cmbPeriodoFinal.Size = New System.Drawing.Size(200, 28)
        Me.cmbPeriodoFinal.TabIndex = 24
        Me.cmbPeriodoFinal.Text = "(Seleccione una opción)"
        '
        'cmbPeriodoInicio
        '
        Me.cmbPeriodoInicio.DisplayMember = "0"
        Me.cmbPeriodoInicio.FormattingEnabled = True
        Me.cmbPeriodoInicio.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbPeriodoInicio.Location = New System.Drawing.Point(199, 9)
        Me.cmbPeriodoInicio.Name = "cmbPeriodoInicio"
        Me.cmbPeriodoInicio.Size = New System.Drawing.Size(200, 28)
        Me.cmbPeriodoInicio.TabIndex = 23
        Me.cmbPeriodoInicio.Text = "(Seleccione una opción)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(524, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 20)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Año final"
        '
        'lblPeriodoFinal
        '
        Me.lblPeriodoFinal.AutoSize = True
        Me.lblPeriodoFinal.Location = New System.Drawing.Point(524, 15)
        Me.lblPeriodoFinal.Name = "lblPeriodoFinal"
        Me.lblPeriodoFinal.Size = New System.Drawing.Size(96, 20)
        Me.lblPeriodoFinal.TabIndex = 21
        Me.lblPeriodoFinal.Text = "Periodo final"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(17, 62)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(77, 20)
        Me.lblFechaInicio.TabIndex = 20
        Me.lblFechaInicio.Text = "Año inicio"
        '
        'lblPeriodoInicio
        '
        Me.lblPeriodoInicio.AutoSize = True
        Me.lblPeriodoInicio.Location = New System.Drawing.Point(17, 12)
        Me.lblPeriodoInicio.Name = "lblPeriodoInicio"
        Me.lblPeriodoInicio.Size = New System.Drawing.Size(102, 20)
        Me.lblPeriodoInicio.TabIndex = 19
        Me.lblPeriodoInicio.Text = "Periodo inicio"
        '
        'lblMsgCantResultado
        '
        Me.lblMsgCantResultado.AutoSize = True
        Me.lblMsgCantResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgCantResultado.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMsgCantResultado.Location = New System.Drawing.Point(405, 121)
        Me.lblMsgCantResultado.Name = "lblMsgCantResultado"
        Me.lblMsgCantResultado.Size = New System.Drawing.Size(0, 15)
        Me.lblMsgCantResultado.TabIndex = 17
        '
        'txtCantResultado
        '
        Me.txtCantResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantResultado.ForeColor = System.Drawing.Color.LightGray
        Me.txtCantResultado.Location = New System.Drawing.Point(199, 110)
        Me.txtCantResultado.Name = "txtCantResultado"
        Me.txtCantResultado.Size = New System.Drawing.Size(200, 26)
        Me.txtCantResultado.TabIndex = 16
        Me.txtCantResultado.Tag = "num"
        '
        'lblCantResultado
        '
        Me.lblCantResultado.AutoSize = True
        Me.lblCantResultado.Location = New System.Drawing.Point(17, 111)
        Me.lblCantResultado.Name = "lblCantResultado"
        Me.lblCantResultado.Size = New System.Drawing.Size(138, 20)
        Me.lblCantResultado.TabIndex = 11
        Me.lblCantResultado.Text = "Cantidad registros"
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.btnGenerar)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlButton.Location = New System.Drawing.Point(885, 0)
        Me.pnlButton.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(216, 150)
        Me.pnlButton.TabIndex = 1
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.ForestGreen
        Me.btnGenerar.FlatAppearance.BorderSize = 0
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.Location = New System.Drawing.Point(37, 46)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(150, 47)
        Me.btnGenerar.TabIndex = 5
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblMejorPromedioTodasCarrera)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1107, 76)
        Me.pnlHeader.TabIndex = 2
        '
        'lblMejorPromedioTodasCarrera
        '
        Me.lblMejorPromedioTodasCarrera.AutoSize = True
        Me.lblMejorPromedioTodasCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMejorPromedioTodasCarrera.Location = New System.Drawing.Point(293, 20)
        Me.lblMejorPromedioTodasCarrera.Name = "lblMejorPromedioTodasCarrera"
        Me.lblMejorPromedioTodasCarrera.Size = New System.Drawing.Size(534, 29)
        Me.lblMejorPromedioTodasCarrera.TabIndex = 0
        Me.lblMejorPromedioTodasCarrera.Text = "Reporte mejores promedios de todas las carrera"
        '
        'beca_becademicDataSet
        '
        Me.beca_becademicDataSet.DataSetName = "beca_becademicDataSet"
        Me.beca_becademicDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pa_reporte_mejores_promedios_todas_las_carrerasBindingSource
        '
        Me.pa_reporte_mejores_promedios_todas_las_carrerasBindingSource.DataMember = "pa_reporte_mejores_promedios_todas_las_carreras"
        Me.pa_reporte_mejores_promedios_todas_las_carrerasBindingSource.DataSource = Me.beca_becademicDataSet
        '
        'pa_reporte_mejores_promedios_todas_las_carrerasTableAdapter
        '
        Me.pa_reporte_mejores_promedios_todas_las_carrerasTableAdapter.ClearBeforeFill = True
        '
        'uCMejoresPromediosTodasCarreras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCMejoresPromediosTodasCarreras"
        Me.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnlParameters.ResumeLayout(False)
        Me.tlpHeader.ResumeLayout(False)
        Me.pnlCampos.ResumeLayout(False)
        Me.pnlCampos.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.beca_becademicDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pa_reporte_mejores_promedios_todas_las_carrerasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents rpvMejorPromedioTodasCarrera As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents pnlParameters As System.Windows.Forms.Panel
    Friend WithEvents tlpHeader As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblMejorPromedioTodasCarrera As System.Windows.Forms.Label
    Friend WithEvents pnlCampos As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents txtCantResultado As System.Windows.Forms.TextBox
    Friend WithEvents lblCantResultado As System.Windows.Forms.Label
    Friend WithEvents lblMsgCantResultado As System.Windows.Forms.Label
    Friend WithEvents lblMsgPeriodo As System.Windows.Forms.Label
    Friend WithEvents txtAnioFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtAnioInicio As System.Windows.Forms.TextBox
    Friend WithEvents cmbPeriodoFinal As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPeriodoInicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPeriodoFinal As System.Windows.Forms.Label
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblPeriodoInicio As System.Windows.Forms.Label
    Friend WithEvents lblMsgAnio As System.Windows.Forms.Label
    Friend WithEvents pa_reporte_mejores_promedios_todas_las_carrerasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents beca_becademicDataSet As UI.beca_becademicDataSet
    Friend WithEvents pa_reporte_mejores_promedios_todas_las_carrerasTableAdapter As UI.beca_becademicDataSetTableAdapters.pa_reporte_mejores_promedios_todas_las_carrerasTableAdapter

End Class
