<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uCPromedioGeneralesCursos
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.pa_reporte_promedios_generales_de_cursosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.beca_becademicDataSet = New UI.beca_becademicDataSet()
        Me.tblTiposDeBecas = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.rpvPromediosGeneralesCursos = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.pnlParameters = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
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
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblPromedioGeneralCurso = New System.Windows.Forms.Label()
        Me.pa_reporte_promedios_generales_de_cursosTableAdapter = New UI.beca_becademicDataSetTableAdapters.pa_reporte_promedios_generales_de_cursosTableAdapter()
        CType(Me.pa_reporte_promedios_generales_de_cursosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.beca_becademicDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblTiposDeBecas.SuspendLayout()
        Me.pnlPrincipal.SuspendLayout()
        Me.pnlParameters.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlCampos.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pa_reporte_promedios_generales_de_cursosBindingSource
        '
        Me.pa_reporte_promedios_generales_de_cursosBindingSource.DataMember = "pa_reporte_promedios_generales_de_cursos"
        Me.pa_reporte_promedios_generales_de_cursosBindingSource.DataSource = Me.beca_becademicDataSet
        '
        'beca_becademicDataSet
        '
        Me.beca_becademicDataSet.DataSetName = "beca_becademicDataSet"
        Me.beca_becademicDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tblTiposDeBecas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblTiposDeBecas.Size = New System.Drawing.Size(1107, 756)
        Me.tblTiposDeBecas.TabIndex = 2
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.rpvPromediosGeneralesCursos)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(3, 192)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(1101, 561)
        Me.pnlPrincipal.TabIndex = 0
        '
        'rpvPromediosGeneralesCursos
        '
        Me.rpvPromediosGeneralesCursos.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource3.Name = "PromediosGeneralesCursosDataSet"
        ReportDataSource3.Value = Me.pa_reporte_promedios_generales_de_cursosBindingSource
        Me.rpvPromediosGeneralesCursos.LocalReport.DataSources.Add(ReportDataSource3)
        Me.rpvPromediosGeneralesCursos.LocalReport.ReportEmbeddedResource = "UI.ReportePromedioGeneralCursos.rdlc"
        Me.rpvPromediosGeneralesCursos.Location = New System.Drawing.Point(0, 0)
        Me.rpvPromediosGeneralesCursos.Name = "rpvPromediosGeneralesCursos"
        Me.rpvPromediosGeneralesCursos.Size = New System.Drawing.Size(1101, 561)
        Me.rpvPromediosGeneralesCursos.TabIndex = 0
        '
        'pnlParameters
        '
        Me.pnlParameters.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParameters.Location = New System.Drawing.Point(3, 79)
        Me.pnlParameters.Name = "pnlParameters"
        Me.pnlParameters.Size = New System.Drawing.Size(1101, 107)
        Me.pnlParameters.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.4723!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5277!))
        Me.TableLayoutPanel1.Controls.Add(Me.pnlCampos, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlButton, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1101, 107)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.pnlCampos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCampos.Location = New System.Drawing.Point(0, 0)
        Me.pnlCampos.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCampos.Name = "pnlCampos"
        Me.pnlCampos.Size = New System.Drawing.Size(885, 107)
        Me.pnlCampos.TabIndex = 0
        '
        'lblMsgAnio
        '
        Me.lblMsgAnio.AutoSize = True
        Me.lblMsgAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgAnio.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMsgAnio.Location = New System.Drawing.Point(126, 92)
        Me.lblMsgAnio.Name = "lblMsgAnio"
        Me.lblMsgAnio.Size = New System.Drawing.Size(0, 15)
        Me.lblMsgAnio.TabIndex = 11
        '
        'lblMsgPeriodo
        '
        Me.lblMsgPeriodo.AutoSize = True
        Me.lblMsgPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgPeriodo.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMsgPeriodo.Location = New System.Drawing.Point(126, 46)
        Me.lblMsgPeriodo.Name = "lblMsgPeriodo"
        Me.lblMsgPeriodo.Size = New System.Drawing.Size(0, 15)
        Me.lblMsgPeriodo.TabIndex = 10
        '
        'txtAnioFinal
        '
        Me.txtAnioFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioFinal.ForeColor = System.Drawing.Color.LightGray
        Me.txtAnioFinal.Location = New System.Drawing.Point(623, 61)
        Me.txtAnioFinal.Name = "txtAnioFinal"
        Me.txtAnioFinal.Size = New System.Drawing.Size(90, 26)
        Me.txtAnioFinal.TabIndex = 9
        Me.txtAnioFinal.Tag = "anio"
        '
        'txtAnioInicio
        '
        Me.txtAnioInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioInicio.ForeColor = System.Drawing.Color.LightGray
        Me.txtAnioInicio.Location = New System.Drawing.Point(129, 66)
        Me.txtAnioInicio.Name = "txtAnioInicio"
        Me.txtAnioInicio.Size = New System.Drawing.Size(90, 26)
        Me.txtAnioInicio.TabIndex = 8
        Me.txtAnioInicio.Tag = "anio"
        '
        'cmbPeriodoFinal
        '
        Me.cmbPeriodoFinal.DisplayMember = "0"
        Me.cmbPeriodoFinal.FormattingEnabled = True
        Me.cmbPeriodoFinal.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbPeriodoFinal.Location = New System.Drawing.Point(623, 14)
        Me.cmbPeriodoFinal.Name = "cmbPeriodoFinal"
        Me.cmbPeriodoFinal.Size = New System.Drawing.Size(200, 28)
        Me.cmbPeriodoFinal.TabIndex = 7
        Me.cmbPeriodoFinal.Text = "(Seleccione una opción)"
        '
        'cmbPeriodoInicio
        '
        Me.cmbPeriodoInicio.FormattingEnabled = True
        Me.cmbPeriodoInicio.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbPeriodoInicio.Location = New System.Drawing.Point(129, 15)
        Me.cmbPeriodoInicio.Name = "cmbPeriodoInicio"
        Me.cmbPeriodoInicio.Size = New System.Drawing.Size(200, 28)
        Me.cmbPeriodoInicio.TabIndex = 6
        Me.cmbPeriodoInicio.Text = "(Seleccione una opción)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(507, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Año final"
        '
        'lblPeriodoFinal
        '
        Me.lblPeriodoFinal.AutoSize = True
        Me.lblPeriodoFinal.Location = New System.Drawing.Point(507, 17)
        Me.lblPeriodoFinal.Name = "lblPeriodoFinal"
        Me.lblPeriodoFinal.Size = New System.Drawing.Size(96, 20)
        Me.lblPeriodoFinal.TabIndex = 2
        Me.lblPeriodoFinal.Text = "Periodo final"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(20, 67)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(77, 20)
        Me.lblFechaInicio.TabIndex = 1
        Me.lblFechaInicio.Text = "Año inicio"
        '
        'lblPeriodoInicio
        '
        Me.lblPeriodoInicio.AutoSize = True
        Me.lblPeriodoInicio.Location = New System.Drawing.Point(20, 17)
        Me.lblPeriodoInicio.Name = "lblPeriodoInicio"
        Me.lblPeriodoInicio.Size = New System.Drawing.Size(102, 20)
        Me.lblPeriodoInicio.TabIndex = 0
        Me.lblPeriodoInicio.Text = "Periodo inicio"
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.btnGenerar)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlButton.Location = New System.Drawing.Point(885, 0)
        Me.pnlButton.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(216, 107)
        Me.pnlButton.TabIndex = 1
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.ForestGreen
        Me.btnGenerar.FlatAppearance.BorderSize = 0
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.Location = New System.Drawing.Point(40, 30)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(150, 47)
        Me.btnGenerar.TabIndex = 5
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblPromedioGeneralCurso)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1107, 76)
        Me.pnlHeader.TabIndex = 2
        '
        'lblPromedioGeneralCurso
        '
        Me.lblPromedioGeneralCurso.AutoSize = True
        Me.lblPromedioGeneralCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPromedioGeneralCurso.Location = New System.Drawing.Point(332, 20)
        Me.lblPromedioGeneralCurso.Name = "lblPromedioGeneralCurso"
        Me.lblPromedioGeneralCurso.Size = New System.Drawing.Size(453, 29)
        Me.lblPromedioGeneralCurso.TabIndex = 0
        Me.lblPromedioGeneralCurso.Text = "Reporte promedios generales de cursos "
        '
        'pa_reporte_promedios_generales_de_cursosTableAdapter
        '
        Me.pa_reporte_promedios_generales_de_cursosTableAdapter.ClearBeforeFill = True
        '
        'uCPromedioGeneralesCursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tblTiposDeBecas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "uCPromedioGeneralesCursos"
        Me.Size = New System.Drawing.Size(1107, 756)
        CType(Me.pa_reporte_promedios_generales_de_cursosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.beca_becademicDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblTiposDeBecas.ResumeLayout(False)
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnlParameters.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlCampos.ResumeLayout(False)
        Me.pnlCampos.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblTiposDeBecas As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents rpvPromediosGeneralesCursos As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents pnlParameters As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblPromedioGeneralCurso As System.Windows.Forms.Label
    Friend WithEvents pnlCampos As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPeriodoFinal As System.Windows.Forms.Label
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblPeriodoInicio As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodoFinal As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPeriodoInicio As System.Windows.Forms.ComboBox
    Friend WithEvents txtAnioFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtAnioInicio As System.Windows.Forms.TextBox
    Friend WithEvents pa_reporte_promedios_generales_de_cursosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents beca_becademicDataSet As UI.beca_becademicDataSet
    Friend WithEvents pa_reporte_promedios_generales_de_cursosTableAdapter As UI.beca_becademicDataSetTableAdapters.pa_reporte_promedios_generales_de_cursosTableAdapter
    Friend WithEvents lblMsgAnio As System.Windows.Forms.Label
    Friend WithEvents lblMsgPeriodo As System.Windows.Forms.Label

End Class
