<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BecademicMain
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ver perfil")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tipos de becas")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Beneficios")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Requisitos")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Módulo de becas", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Carreras")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cursos")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Calificaciones")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Módulo académico", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("De carreras")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("De cursos")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Promedios generales", New System.Windows.Forms.TreeNode() {TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Por carrera")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Todas las carreras")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mejores promedios", New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode14})
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Historial académico")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proforma")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Módulo de reportes", New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode15, TreeNode16, TreeNode17})
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Usuarios")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Roles")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Módulo de seguridad", New System.Windows.Forms.TreeNode() {TreeNode19, TreeNode20})
        Me.tblPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlEncabezado2 = New System.Windows.Forms.Panel()
        Me.tblHeaderMain = New System.Windows.Forms.TableLayoutPanel()
        Me.lblBienvenida = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCerrarSesion = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.spltMain = New System.Windows.Forms.SplitContainer()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.trvwMenuPrincipal = New System.Windows.Forms.TreeView()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.tblPrincipal.SuspendLayout()
        Me.pnlEncabezado2.SuspendLayout()
        Me.tblHeaderMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.spltMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spltMain.Panel1.SuspendLayout()
        Me.spltMain.Panel2.SuspendLayout()
        Me.spltMain.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tblPrincipal
        '
        Me.tblPrincipal.ColumnCount = 1
        Me.tblPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblPrincipal.Controls.Add(Me.pnlEncabezado2, 0, 0)
        Me.tblPrincipal.Controls.Add(Me.pnlMain, 0, 1)
        Me.tblPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tblPrincipal.Margin = New System.Windows.Forms.Padding(0)
        Me.tblPrincipal.Name = "tblPrincipal"
        Me.tblPrincipal.RowCount = 2
        Me.tblPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.tblPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblPrincipal.Size = New System.Drawing.Size(1210, 736)
        Me.tblPrincipal.TabIndex = 0
        '
        'pnlEncabezado2
        '
        Me.pnlEncabezado2.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.pnlEncabezado2.Controls.Add(Me.tblHeaderMain)
        Me.pnlEncabezado2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEncabezado2.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado2.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlEncabezado2.Name = "pnlEncabezado2"
        Me.pnlEncabezado2.Size = New System.Drawing.Size(1210, 76)
        Me.pnlEncabezado2.TabIndex = 0
        '
        'tblHeaderMain
        '
        Me.tblHeaderMain.ColumnCount = 4
        Me.tblHeaderMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189.0!))
        Me.tblHeaderMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblHeaderMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 224.0!))
        Me.tblHeaderMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185.0!))
        Me.tblHeaderMain.Controls.Add(Me.lblBienvenida, 2, 0)
        Me.tblHeaderMain.Controls.Add(Me.Panel1, 3, 0)
        Me.tblHeaderMain.Controls.Add(Me.Panel2, 0, 0)
        Me.tblHeaderMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblHeaderMain.Location = New System.Drawing.Point(0, 0)
        Me.tblHeaderMain.Margin = New System.Windows.Forms.Padding(4)
        Me.tblHeaderMain.Name = "tblHeaderMain"
        Me.tblHeaderMain.RowCount = 1
        Me.tblHeaderMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblHeaderMain.Size = New System.Drawing.Size(1210, 76)
        Me.tblHeaderMain.TabIndex = 1
        '
        'lblBienvenida
        '
        Me.lblBienvenida.AutoSize = True
        Me.lblBienvenida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBienvenida.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBienvenida.ForeColor = System.Drawing.Color.White
        Me.lblBienvenida.Location = New System.Drawing.Point(805, 0)
        Me.lblBienvenida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBienvenida.Name = "lblBienvenida"
        Me.lblBienvenida.Size = New System.Drawing.Size(216, 76)
        Me.lblBienvenida.TabIndex = 1
        Me.lblBienvenida.Text = "Bienvenido, Roger Quiros."
        Me.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCerrarSesion)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1028, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(179, 70)
        Me.Panel1.TabIndex = 2
        '
        'btnCerrarSesion
        '
        Me.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.btnCerrarSesion.FlatAppearance.BorderSize = 0
        Me.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarSesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarSesion.ForeColor = System.Drawing.Color.White
        Me.btnCerrarSesion.Location = New System.Drawing.Point(16, 14)
        Me.btnCerrarSesion.Name = "btnCerrarSesion"
        Me.btnCerrarSesion.Size = New System.Drawing.Size(154, 43)
        Me.btnCerrarSesion.TabIndex = 0
        Me.btnCerrarSesion.Text = "Cerrar sesión"
        Me.btnCerrarSesion.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(183, 70)
        Me.Panel2.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.UI.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(10, 14)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 38)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.AutoScrollMargin = New System.Drawing.Size(10, 10)
        Me.pnlMain.BackColor = System.Drawing.SystemColors.Control
        Me.pnlMain.Controls.Add(Me.spltMain)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 76)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1210, 660)
        Me.pnlMain.TabIndex = 3
        '
        'spltMain
        '
        Me.spltMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spltMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.spltMain.Location = New System.Drawing.Point(0, 0)
        Me.spltMain.Margin = New System.Windows.Forms.Padding(0)
        Me.spltMain.Name = "spltMain"
        '
        'spltMain.Panel1
        '
        Me.spltMain.Panel1.Controls.Add(Me.pnlMenu)
        Me.spltMain.Panel1MinSize = 189
        '
        'spltMain.Panel2
        '
        Me.spltMain.Panel2.Controls.Add(Me.pnlContenido)
        Me.spltMain.Size = New System.Drawing.Size(1210, 660)
        Me.spltMain.SplitterDistance = 189
        Me.spltMain.SplitterWidth = 8
        Me.spltMain.TabIndex = 1
        '
        'pnlMenu
        '
        Me.pnlMenu.Controls.Add(Me.trvwMenuPrincipal)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(189, 660)
        Me.pnlMenu.TabIndex = 0
        '
        'trvwMenuPrincipal
        '
        Me.trvwMenuPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.trvwMenuPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.trvwMenuPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvwMenuPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvwMenuPrincipal.ForeColor = System.Drawing.Color.Gainsboro
        Me.trvwMenuPrincipal.Indent = 15
        Me.trvwMenuPrincipal.ItemHeight = 35
        Me.trvwMenuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.trvwMenuPrincipal.Margin = New System.Windows.Forms.Padding(4)
        Me.trvwMenuPrincipal.Name = "trvwMenuPrincipal"
        TreeNode1.Name = "btnVerPerfil"
        TreeNode1.Text = "Ver perfil"
        TreeNode2.Checked = True
        TreeNode2.Name = "btnTiposDeBecas"
        TreeNode2.Text = "Tipos de becas"
        TreeNode3.Name = "btnBeneficios"
        TreeNode3.Text = "Beneficios"
        TreeNode4.Name = "btnRequisitos"
        TreeNode4.Text = "Requisitos"
        TreeNode5.Name = "btnModuloBecas"
        TreeNode5.Text = "Módulo de becas"
        TreeNode6.Name = "btnCarreras"
        TreeNode6.Text = "Carreras"
        TreeNode7.Name = "btnCursos"
        TreeNode7.Text = "Cursos"
        TreeNode8.Name = "btnCalificaciones"
        TreeNode8.Text = "Calificaciones"
        TreeNode9.Name = "btnModuloAcademico"
        TreeNode9.Text = "Módulo académico"
        TreeNode10.Name = "btnDeCarreras"
        TreeNode10.Text = "De carreras"
        TreeNode11.Name = "btnDeCursos"
        TreeNode11.Text = "De cursos"
        TreeNode12.Name = "btnPromediosGenerales"
        TreeNode12.Text = "Promedios generales"
        TreeNode13.Name = "btnPorCarrera"
        TreeNode13.Text = "Por carrera"
        TreeNode14.Name = "btnTodasCarreras"
        TreeNode14.Text = "Todas las carreras"
        TreeNode15.Name = "btnMejoresPromedios"
        TreeNode15.Text = "Mejores promedios"
        TreeNode16.Name = "btnHistorialAcademico"
        TreeNode16.Text = "Historial académico"
        TreeNode17.Name = "btnProforma"
        TreeNode17.Text = "Proforma"
        TreeNode18.Name = "btnReportes"
        TreeNode18.Text = "Módulo de reportes"
        TreeNode19.Name = "btnUsuarios"
        TreeNode19.Text = "Usuarios"
        TreeNode20.Name = "btnRoles"
        TreeNode20.Text = "Roles"
        TreeNode21.Name = "btnSeguridad"
        TreeNode21.Text = "Módulo de seguridad"
        Me.trvwMenuPrincipal.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode5, TreeNode9, TreeNode18, TreeNode21})
        Me.trvwMenuPrincipal.ShowLines = False
        Me.trvwMenuPrincipal.Size = New System.Drawing.Size(189, 660)
        Me.trvwMenuPrincipal.TabIndex = 0
        '
        'pnlContenido
        '
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenido.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(1013, 660)
        Me.pnlContenido.TabIndex = 0
        '
        'BecademicMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1210, 736)
        Me.Controls.Add(Me.tblPrincipal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "BecademicMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Becademic"
        Me.tblPrincipal.ResumeLayout(False)
        Me.pnlEncabezado2.ResumeLayout(False)
        Me.tblHeaderMain.ResumeLayout(False)
        Me.tblHeaderMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.spltMain.Panel1.ResumeLayout(False)
        Me.spltMain.Panel2.ResumeLayout(False)
        CType(Me.spltMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spltMain.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlEncabezado2 As System.Windows.Forms.Panel
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents trvwMenuPrincipal As System.Windows.Forms.TreeView
    Friend WithEvents spltMain As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents pnlContenido As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tblHeaderMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblBienvenida As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrarSesion As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

End Class
