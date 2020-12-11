<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.pwdBox = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.usrBox = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblRegister = New System.Windows.Forms.Label()
        Me.lblForgot = New System.Windows.Forms.Label()
        Me.checkRicordami = New System.Windows.Forms.CheckBox()
        Me.eyeSetting = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.Logo = New System.Windows.Forms.PictureBox()
        CType(Me.eyeSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.pwdBox, Me.usrBox})
        Me.ShapeContainer1.Size = New System.Drawing.Size(281, 376)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'pwdBox
        '
        Me.pwdBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.pwdBox.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.pwdBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.pwdBox.CornerRadius = 3
        Me.pwdBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pwdBox.Location = New System.Drawing.Point(44, 186)
        Me.pwdBox.Name = "pwdBox"
        Me.pwdBox.SelectionColor = System.Drawing.Color.Transparent
        Me.pwdBox.Size = New System.Drawing.Size(199, 32)
        '
        'usrBox
        '
        Me.usrBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.usrBox.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.usrBox.BorderColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.usrBox.CornerRadius = 3
        Me.usrBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.usrBox.Location = New System.Drawing.Point(44, 138)
        Me.usrBox.Name = "usrBox"
        Me.usrBox.SelectionColor = System.Drawing.Color.Transparent
        Me.usrBox.Size = New System.Drawing.Size(199, 32)
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.txtUsername.Location = New System.Drawing.Point(47, 142)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(194, 25)
        Me.txtUsername.TabIndex = 2
        Me.txtUsername.Text = "Username"
        Me.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.txtPassword.Location = New System.Drawing.Point(47, 190)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(194, 25)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.Text = "Password"
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.lblLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLogin.Font = New System.Drawing.Font("Calibri", 15.0!)
        Me.lblLogin.ForeColor = System.Drawing.Color.White
        Me.lblLogin.Location = New System.Drawing.Point(45, 262)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Padding = New System.Windows.Forms.Padding(72, 5, 72, 5)
        Me.lblLogin.Size = New System.Drawing.Size(198, 34)
        Me.lblLogin.TabIndex = 0
        Me.lblLogin.Text = "Login"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(290, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 6
        '
        'lblRegister
        '
        Me.lblRegister.AutoSize = True
        Me.lblRegister.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRegister.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegister.ForeColor = System.Drawing.Color.White
        Me.lblRegister.Location = New System.Drawing.Point(190, 310)
        Me.lblRegister.Name = "lblRegister"
        Me.lblRegister.Size = New System.Drawing.Size(52, 13)
        Me.lblRegister.TabIndex = 8
        Me.lblRegister.Text = "Registrati"
        '
        'lblForgot
        '
        Me.lblForgot.AutoSize = True
        Me.lblForgot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblForgot.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForgot.ForeColor = System.Drawing.Color.White
        Me.lblForgot.Location = New System.Drawing.Point(44, 310)
        Me.lblForgot.Name = "lblForgot"
        Me.lblForgot.Size = New System.Drawing.Size(117, 13)
        Me.lblForgot.TabIndex = 9
        Me.lblForgot.Text = "Password dimenticata?"
        '
        'checkRicordami
        '
        Me.checkRicordami.AutoSize = True
        Me.checkRicordami.ForeColor = System.Drawing.Color.White
        Me.checkRicordami.Location = New System.Drawing.Point(45, 226)
        Me.checkRicordami.Name = "checkRicordami"
        Me.checkRicordami.Size = New System.Drawing.Size(73, 17)
        Me.checkRicordami.TabIndex = 10
        Me.checkRicordami.Text = "Ricordami"
        Me.checkRicordami.UseVisualStyleBackColor = True
        '
        'eyeSetting
        '
        Me.eyeSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.eyeSetting.Image = CType(resources.GetObject("eyeSetting.Image"), System.Drawing.Image)
        Me.eyeSetting.Location = New System.Drawing.Point(218, 192)
        Me.eyeSetting.Name = "eyeSetting"
        Me.eyeSetting.Size = New System.Drawing.Size(25, 22)
        Me.eyeSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.eyeSetting.TabIndex = 11
        Me.eyeSetting.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(253, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(25, 25)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnClose.TabIndex = 7
        Me.btnClose.TabStop = False
        '
        'Logo
        '
        Me.Logo.Image = CType(resources.GetObject("Logo.Image"), System.Drawing.Image)
        Me.Logo.Location = New System.Drawing.Point(100, 30)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(85, 70)
        Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Logo.TabIndex = 3
        Me.Logo.TabStop = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(281, 376)
        Me.ControlBox = False
        Me.Controls.Add(Me.eyeSetting)
        Me.Controls.Add(Me.checkRicordami)
        Me.Controls.Add(Me.lblForgot)
        Me.Controls.Add(Me.lblRegister)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblLogin)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Logo)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.eyeSetting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents usrBox As PowerPacks.RectangleShape
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Logo As PictureBox
    Friend WithEvents pwdBox As PowerPacks.RectangleShape
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblLogin As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents lblRegister As Label
    Friend WithEvents lblForgot As Label
    Friend WithEvents checkRicordami As CheckBox
    Friend WithEvents eyeSetting As PictureBox
End Class
