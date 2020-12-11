<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Register))
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.usrBox = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.pwdConfirmBox = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.pwdBox = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.lblRegister = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtPasswordConfirm = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.eyePassword = New System.Windows.Forms.PictureBox()
        Me.eyeConfirmPassword = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eyePassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eyeConfirmPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Image = Global.AppMotoria.My.Resources.Resources.close
        Me.btnClose.Location = New System.Drawing.Point(253, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnClose.TabIndex = 8
        Me.btnClose.TabStop = False
        '
        'Logo
        '
        Me.Logo.Image = Global.AppMotoria.My.Resources.Resources.logo
        Me.Logo.Location = New System.Drawing.Point(100, 30)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(85, 70)
        Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Logo.TabIndex = 9
        Me.Logo.TabStop = False
        '
        'usrBox
        '
        Me.usrBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.usrBox.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.usrBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.usrBox.CornerRadius = 3
        Me.usrBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.usrBox.Location = New System.Drawing.Point(44, 132)
        Me.usrBox.Name = "usrBox"
        Me.usrBox.SelectionColor = System.Drawing.Color.Transparent
        Me.usrBox.Size = New System.Drawing.Size(199, 32)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.pwdConfirmBox, Me.pwdBox, Me.usrBox})
        Me.ShapeContainer1.Size = New System.Drawing.Size(281, 376)
        Me.ShapeContainer1.TabIndex = 10
        Me.ShapeContainer1.TabStop = False
        '
        'pwdConfirmBox
        '
        Me.pwdConfirmBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.pwdConfirmBox.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.pwdConfirmBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.pwdConfirmBox.CornerRadius = 3
        Me.pwdConfirmBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pwdConfirmBox.Location = New System.Drawing.Point(44, 216)
        Me.pwdConfirmBox.Name = "pwdConfirmBox"
        Me.pwdConfirmBox.SelectionColor = System.Drawing.Color.Transparent
        Me.pwdConfirmBox.Size = New System.Drawing.Size(199, 32)
        '
        'pwdBox
        '
        Me.pwdBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.pwdBox.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.pwdBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.pwdBox.CornerRadius = 3
        Me.pwdBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pwdBox.Location = New System.Drawing.Point(44, 174)
        Me.pwdBox.Name = "pwdBox"
        Me.pwdBox.SelectionColor = System.Drawing.Color.Transparent
        Me.pwdBox.Size = New System.Drawing.Size(199, 32)
        '
        'lblRegister
        '
        Me.lblRegister.AutoSize = True
        Me.lblRegister.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.lblRegister.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRegister.Font = New System.Drawing.Font("Calibri", 15.0!)
        Me.lblRegister.ForeColor = System.Drawing.Color.White
        Me.lblRegister.Location = New System.Drawing.Point(44, 274)
        Me.lblRegister.Name = "lblRegister"
        Me.lblRegister.Padding = New System.Windows.Forms.Padding(56, 5, 56, 5)
        Me.lblRegister.Size = New System.Drawing.Size(200, 34)
        Me.lblRegister.TabIndex = 11
        Me.lblRegister.Text = "Registrati"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.txtUsername.Location = New System.Drawing.Point(47, 136)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(194, 25)
        Me.txtUsername.TabIndex = 12
        Me.txtUsername.Text = "Username"
        Me.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.txtPassword.Location = New System.Drawing.Point(47, 178)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(194, 25)
        Me.txtPassword.TabIndex = 13
        Me.txtPassword.Text = "Password"
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPasswordConfirm
        '
        Me.txtPasswordConfirm.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.txtPasswordConfirm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPasswordConfirm.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordConfirm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.txtPasswordConfirm.Location = New System.Drawing.Point(47, 220)
        Me.txtPasswordConfirm.Name = "txtPasswordConfirm"
        Me.txtPasswordConfirm.Size = New System.Drawing.Size(194, 25)
        Me.txtPasswordConfirm.TabIndex = 14
        Me.txtPasswordConfirm.Text = "Conferma Password"
        Me.txtPasswordConfirm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(287, 0)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 16
        '
        'eyePassword
        '
        Me.eyePassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.eyePassword.Image = Global.AppMotoria.My.Resources.Resources.eye
        Me.eyePassword.Location = New System.Drawing.Point(216, 180)
        Me.eyePassword.Name = "eyePassword"
        Me.eyePassword.Size = New System.Drawing.Size(25, 22)
        Me.eyePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.eyePassword.TabIndex = 17
        Me.eyePassword.TabStop = False
        '
        'eyeConfirmPassword
        '
        Me.eyeConfirmPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.eyeConfirmPassword.Image = Global.AppMotoria.My.Resources.Resources.eye
        Me.eyeConfirmPassword.Location = New System.Drawing.Point(216, 221)
        Me.eyeConfirmPassword.Name = "eyeConfirmPassword"
        Me.eyeConfirmPassword.Size = New System.Drawing.Size(25, 22)
        Me.eyeConfirmPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.eyeConfirmPassword.TabIndex = 18
        Me.eyeConfirmPassword.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(129, 312)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Login"
        '
        'Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(281, 376)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.eyeConfirmPassword)
        Me.Controls.Add(Me.eyePassword)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtPasswordConfirm)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblRegister)
        Me.Controls.Add(Me.Logo)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register"
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eyePassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eyeConfirmPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As PictureBox
    Friend WithEvents Logo As PictureBox
    Friend WithEvents usrBox As PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents pwdConfirmBox As PowerPacks.RectangleShape
    Friend WithEvents pwdBox As PowerPacks.RectangleShape
    Friend WithEvents lblRegister As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtPasswordConfirm As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents eyePassword As PictureBox
    Friend WithEvents eyeConfirmPassword As PictureBox
    Friend WithEvents Label1 As Label
End Class
