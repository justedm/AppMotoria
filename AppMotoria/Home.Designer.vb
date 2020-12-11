<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.topBar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.lblLogout = New System.Windows.Forms.Label()
        Me.panelLogout = New System.Windows.Forms.Panel()
        Me.imgLogout = New System.Windows.Forms.PictureBox()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabCalcoli = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabDati = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panelCalcoli = New System.Windows.Forms.Panel()
        Me.lblCalcoli = New System.Windows.Forms.Label()
        Me.imgCalcoli = New System.Windows.Forms.PictureBox()
        Me.panelDati = New System.Windows.Forms.Panel()
        Me.imgDati = New System.Windows.Forms.PictureBox()
        Me.lblDati = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.panelLogout.SuspendLayout()
        CType(Me.imgLogout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl.SuspendLayout()
        Me.tabCalcoli.SuspendLayout()
        Me.tabDati.SuspendLayout()
        Me.panelCalcoli.SuspendLayout()
        CType(Me.imgCalcoli, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelDati.SuspendLayout()
        CType(Me.imgDati, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2, Me.topBar})
        Me.ShapeContainer1.Size = New System.Drawing.Size(800, 450)
        Me.ShapeContainer1.TabIndex = 9
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.RectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape2.BorderWidth = 2
        Me.RectangleShape2.Location = New System.Drawing.Point(-2, 33)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.Size = New System.Drawing.Size(171, 418)
        '
        'topBar
        '
        Me.topBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.topBar.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.topBar.BorderWidth = 2
        Me.topBar.Location = New System.Drawing.Point(-2, -2)
        Me.topBar.Name = "topBar"
        Me.topBar.SelectionColor = System.Drawing.Color.Transparent
        Me.topBar.Size = New System.Drawing.Size(804, 35)
        '
        'lblLogout
        '
        Me.lblLogout.AutoSize = True
        Me.lblLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogout.ForeColor = System.Drawing.Color.White
        Me.lblLogout.Location = New System.Drawing.Point(47, 5)
        Me.lblLogout.Name = "lblLogout"
        Me.lblLogout.Size = New System.Drawing.Size(68, 24)
        Me.lblLogout.TabIndex = 12
        Me.lblLogout.Text = "Logout"
        '
        'panelLogout
        '
        Me.panelLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.panelLogout.Controls.Add(Me.lblLogout)
        Me.panelLogout.Controls.Add(Me.imgLogout)
        Me.panelLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panelLogout.Location = New System.Drawing.Point(1, 416)
        Me.panelLogout.Name = "panelLogout"
        Me.panelLogout.Size = New System.Drawing.Size(165, 34)
        Me.panelLogout.TabIndex = 11
        '
        'imgLogout
        '
        Me.imgLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.imgLogout.Image = Global.AppMotoria.My.Resources.Resources.logout
        Me.imgLogout.Location = New System.Drawing.Point(11, 2)
        Me.imgLogout.Name = "imgLogout"
        Me.imgLogout.Size = New System.Drawing.Size(30, 30)
        Me.imgLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgLogout.TabIndex = 10
        Me.imgLogout.TabStop = False
        '
        'tabControl
        '
        Me.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tabControl.Controls.Add(Me.tabCalcoli)
        Me.tabControl.Controls.Add(Me.tabDati)
        Me.tabControl.Location = New System.Drawing.Point(166, 29)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.RightToLeftLayout = True
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(638, 425)
        Me.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabControl.TabIndex = 13
        '
        'tabCalcoli
        '
        Me.tabCalcoli.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.tabCalcoli.Controls.Add(Me.Label1)
        Me.tabCalcoli.Location = New System.Drawing.Point(4, 25)
        Me.tabCalcoli.Name = "tabCalcoli"
        Me.tabCalcoli.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCalcoli.Size = New System.Drawing.Size(630, 396)
        Me.tabCalcoli.TabIndex = 0
        Me.tabCalcoli.Text = "tabCalcoli"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "tabCalcoli"
        '
        'tabDati
        '
        Me.tabDati.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.tabDati.Controls.Add(Me.Label2)
        Me.tabDati.Location = New System.Drawing.Point(4, 25)
        Me.tabDati.Name = "tabDati"
        Me.tabDati.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDati.Size = New System.Drawing.Size(630, 396)
        Me.tabDati.TabIndex = 1
        Me.tabDati.Text = "tabDati"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "tabDati"
        '
        'panelCalcoli
        '
        Me.panelCalcoli.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.panelCalcoli.Controls.Add(Me.lblCalcoli)
        Me.panelCalcoli.Controls.Add(Me.imgCalcoli)
        Me.panelCalcoli.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panelCalcoli.Location = New System.Drawing.Point(0, 180)
        Me.panelCalcoli.Name = "panelCalcoli"
        Me.panelCalcoli.Size = New System.Drawing.Size(165, 34)
        Me.panelCalcoli.TabIndex = 13
        '
        'lblCalcoli
        '
        Me.lblCalcoli.AutoSize = True
        Me.lblCalcoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalcoli.ForeColor = System.Drawing.Color.White
        Me.lblCalcoli.Location = New System.Drawing.Point(47, 6)
        Me.lblCalcoli.Name = "lblCalcoli"
        Me.lblCalcoli.Size = New System.Drawing.Size(66, 24)
        Me.lblCalcoli.TabIndex = 12
        Me.lblCalcoli.Text = "Calcoli"
        '
        'imgCalcoli
        '
        Me.imgCalcoli.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.imgCalcoli.Image = Global.AppMotoria.My.Resources.Resources.calcolatore
        Me.imgCalcoli.Location = New System.Drawing.Point(11, 2)
        Me.imgCalcoli.Name = "imgCalcoli"
        Me.imgCalcoli.Size = New System.Drawing.Size(30, 30)
        Me.imgCalcoli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgCalcoli.TabIndex = 10
        Me.imgCalcoli.TabStop = False
        '
        'panelDati
        '
        Me.panelDati.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.panelDati.Controls.Add(Me.imgDati)
        Me.panelDati.Controls.Add(Me.lblDati)
        Me.panelDati.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panelDati.Location = New System.Drawing.Point(0, 220)
        Me.panelDati.Name = "panelDati"
        Me.panelDati.Size = New System.Drawing.Size(165, 34)
        Me.panelDati.TabIndex = 14
        '
        'imgDati
        '
        Me.imgDati.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.imgDati.Image = Global.AppMotoria.My.Resources.Resources.dati
        Me.imgDati.Location = New System.Drawing.Point(10, 2)
        Me.imgDati.Name = "imgDati"
        Me.imgDati.Size = New System.Drawing.Size(30, 30)
        Me.imgDati.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgDati.TabIndex = 10
        Me.imgDati.TabStop = False
        '
        'lblDati
        '
        Me.lblDati.AutoSize = True
        Me.lblDati.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDati.ForeColor = System.Drawing.Color.White
        Me.lblDati.Location = New System.Drawing.Point(47, 5)
        Me.lblDati.Name = "lblDati"
        Me.lblDati.Size = New System.Drawing.Size(41, 24)
        Me.lblDati.TabIndex = 12
        Me.lblDati.Text = "Dati"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Image = Global.AppMotoria.My.Resources.Resources.close
        Me.btnClose.Location = New System.Drawing.Point(772, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnClose.TabIndex = 8
        Me.btnClose.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.PictureBox2.Image = Global.AppMotoria.My.Resources.Resources.logo
        Me.PictureBox2.Location = New System.Drawing.Point(37, 63)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(85, 70)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.panelCalcoli)
        Me.Controls.Add(Me.panelDati)
        Me.Controls.Add(Me.panelLogout)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.panelLogout.ResumeLayout(False)
        Me.panelLogout.PerformLayout()
        CType(Me.imgLogout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl.ResumeLayout(False)
        Me.tabCalcoli.ResumeLayout(False)
        Me.tabCalcoli.PerformLayout()
        Me.tabDati.ResumeLayout(False)
        Me.tabDati.PerformLayout()
        Me.panelCalcoli.ResumeLayout(False)
        Me.panelCalcoli.PerformLayout()
        CType(Me.imgCalcoli, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelDati.ResumeLayout(False)
        Me.panelDati.PerformLayout()
        CType(Me.imgDati, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As PictureBox
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents topBar As PowerPacks.RectangleShape
    Friend WithEvents RectangleShape2 As PowerPacks.RectangleShape
    Friend WithEvents imgLogout As PictureBox
    Friend WithEvents lblLogout As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents panelLogout As Panel
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabCalcoli As TabPage
    Friend WithEvents tabDati As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents panelCalcoli As Panel
    Friend WithEvents lblCalcoli As Label
    Friend WithEvents imgCalcoli As PictureBox
    Friend WithEvents panelDati As Panel
    Friend WithEvents lblDati As Label
    Friend WithEvents imgDati As PictureBox
End Class
