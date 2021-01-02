Imports System.Runtime.InteropServices
Imports System.Data.OleDb
Public Class Register

    'Booleans for eye setting
    Dim pwdShow = False
    Dim pwdConfShow = False
    Dim secretCodeShow = False

#Region "Movimento form"
    Public Const WM_NCLBUTTONDOWN As Integer = 161
    Public Const HT_CAPTION As Integer = 2

    <DllImport("User32")> Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer

    End Function

    <DllImport("User32")> Private Shared Function ReleaseCapture() As Boolean

    End Function
    Private Sub Login_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If (e.Button = MouseButtons.Left) Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub Logo_MouseDown(sender As Object, e As MouseEventArgs) Handles Logo.MouseDown
        If (e.Button = MouseButtons.Left) Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
#End Region

#Region "Close button"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        End
    End Sub
    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        btnClose.Image = My.Resources.ResourceManager.GetObject("close_red")
    End Sub
    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.Image = My.Resources.ResourceManager.GetObject("close")
    End Sub
#End Region

#Region "Form load"
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()
        eyePassword.Visible = False
        eyeConfirmPassword.Visible = False

        lblMsgUsername.Visible = False
        lblMsgPassword.Visible = False
        lblPMsgPasswordConfirm.Visible = False
        lblMsgLogin.Visible = False
    End Sub
#End Region

#Region "Inserimento Dati"
    Private Sub usrBox_Click(sender As Object, e As EventArgs) Handles usrBox.Click
        txtUsername.Select()
    End Sub

    Private Sub pwdBox_Click(sender As Object, e As EventArgs) Handles pwdBox.Click
        txtPassword.Select()
    End Sub

    Private Sub pwdConfirmBox_Click(sender As Object, e As EventArgs) Handles pwdConfirmBox.Click
        txtPasswordConfirm.Select()
    End Sub

    Private Sub txtUsername_Enter(sender As Object, e As EventArgs) Handles txtUsername.Enter
        If txtUsername.Text = "Username" Then
            txtUsername.ForeColor = Color.FromArgb(224, 224, 224)
            txtUsername.Clear()
        End If
        If lblMsgLogin.Visible = True Then lblMsgLogin.Visible = False
    End Sub
    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        lblMsgUsername.Visible = False
    End Sub
    Private Sub txtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        If txtUsername.Text = "" Then
            txtUsername.Text = "Username"
            txtUsername.ForeColor = Color.FromArgb(207, 207, 207)
        End If
    End Sub
    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        If txtPassword.Text = "Password" Then
            txtPassword.ForeColor = Color.FromArgb(224, 224, 224)
            txtPassword.Clear()
            txtPassword.UseSystemPasswordChar = True
        End If
        If lblMsgLogin.Visible = True Then lblMsgLogin.Visible = False
    End Sub
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text <> "" Then
            eyePassword.Visible = True
        End If
        lblMsgPassword.Visible = False
    End Sub
    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        If txtPassword.Text = "" Then
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.FromArgb(207, 207, 207)
            txtPassword.UseSystemPasswordChar = False
            eyePassword.Visible = False
        End If
    End Sub

    Private Sub txtPasswordConfirm_Enter(sender As Object, e As EventArgs) Handles txtPasswordConfirm.Enter
        If txtPasswordConfirm.Text = "Conferma Password" Then
            txtPasswordConfirm.ForeColor = Color.FromArgb(224, 224, 224)
            txtPasswordConfirm.Clear()
            txtPasswordConfirm.UseSystemPasswordChar = True
        End If
        If lblMsgLogin.Visible = True Then lblMsgLogin.Visible = False
    End Sub
    Private Sub txtPasswordConfirm_TextChanged(sender As Object, e As EventArgs) Handles txtPasswordConfirm.TextChanged
        If txtPasswordConfirm.Text <> "" Then
            eyeConfirmPassword.Visible = True
        End If
        lblPMsgPasswordConfirm.Visible = False
    End Sub
    Private Sub txtPasswordConfirm_Leave(sender As Object, e As EventArgs) Handles txtPasswordConfirm.Leave
        If txtPasswordConfirm.Text = "" Then
            txtPasswordConfirm.Text = "Conferma Password"
            txtPasswordConfirm.ForeColor = Color.FromArgb(207, 207, 207)
            txtPasswordConfirm.UseSystemPasswordChar = False
            eyeConfirmPassword.Visible = False
        End If
    End Sub
#End Region

#Region "Register button"

    Private Sub lblRegister_Click(sender As Object, e As EventArgs) Handles lblRegister.Click

        Dim username = txtUsername.Text.Trim
        Dim password = txtPassword.Text.Trim
        Dim passwordConfirm = txtPasswordConfirm.Text.Trim


        If (username <> "" And username <> "Username") Then
            If (password <> "" And password <> "Password") Then
                Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Account.mdb")
                Dim queryRead As String = "select * from Utenti where username = @Username"

                Using cmdRead = New OleDbCommand(queryRead, conn)
                    cmdRead.Parameters.Add("Username", OleDbType.VarChar).Value = username
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    Dim reader As OleDbDataReader = cmdRead.ExecuteReader
                    cmdRead.Dispose()

                    If reader.Read = False Then
                        If password = passwordConfirm Then
                            Dim queryRegister As String = "INSERT INTO Utenti ([Username], [Password]) VALUES (@Username, @Password)"
                            Using cmdRegister = New OleDbCommand(queryRegister, conn)

                                cmdRegister.Parameters.Add("Username", OleDbType.VarChar).Value = username
                                cmdRegister.Parameters.Add("Password", OleDbType.VarChar).Value = password

                                If conn.State = ConnectionState.Closed Then conn.Open()
                                cmdRegister.ExecuteNonQuery()
                                reader.Close()
                                cmdRegister.Dispose()

                                lblMsgLogin.Text = "Registrato correttamente"
                                lblMsgLogin.ForeColor = Color.FromArgb(110, 218, 161)
                                lblMsgLogin.Visible = True

                                TextBox1.Select()
                                txtUsername.Text = "Username"
                                txtUsername.ForeColor = Color.FromArgb(207, 207, 207)
                                txtPassword.Text = "Password"
                                txtPassword.UseSystemPasswordChar = False
                                txtPassword.ForeColor = Color.FromArgb(207, 207, 207)
                                txtPasswordConfirm.Text = "Conferma Password"
                                txtPasswordConfirm.UseSystemPasswordChar = False
                                txtPasswordConfirm.ForeColor = Color.FromArgb(207, 207, 207)

                                If My.Settings.arrayUtenti Is Nothing Then
                                    My.Settings.arrayUtenti = New System.Collections.Specialized.StringCollection
                                End If
                                My.Settings.arrayUtenti.Add(username)
                                My.Settings.Save()


                            End Using
                        Else
                            lblPMsgPasswordConfirm.Visible = True
                        End If
                    Else
                        lblMsgLogin.Text = "Il nome scelto è già esistente"
                        lblMsgLogin.ForeColor = Color.FromArgb(192, 85, 85)
                        lblMsgLogin.Visible = True
                        reader.Close()
                        cmdRead.Dispose()
                    End If
                End Using
            Else
                lblMsgPassword.Visible = True
            End If
        Else
            lblMsgUsername.Visible = True
        End If
    End Sub
#End Region

#Region "Login button"
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Login.Show()
        Me.Close()
    End Sub
#End Region

#Region "Mostra/Nascondi Dati"
    Private Sub eyePassword_Click(sender As Object, e As EventArgs) Handles eyePassword.Click
        If pwdShow = False Then
            eyePassword.Image = My.Resources.ResourceManager.GetObject("closed_eye")
            txtPassword.UseSystemPasswordChar = False
            pwdShow = True
        Else
            eyePassword.Image = My.Resources.ResourceManager.GetObject("eye")
            txtPassword.UseSystemPasswordChar = True
            pwdShow = False
        End If
    End Sub

    Private Sub eyeConfirmPassword_Click(sender As Object, e As EventArgs) Handles eyeConfirmPassword.Click
        If pwdConfShow = False Then
            eyeConfirmPassword.Image = My.Resources.ResourceManager.GetObject("closed_eye")
            txtPasswordConfirm.UseSystemPasswordChar = False
            pwdConfShow = True
        Else
            eyeConfirmPassword.Image = My.Resources.ResourceManager.GetObject("eye")
            txtPasswordConfirm.UseSystemPasswordChar = True
            pwdConfShow = False
        End If
    End Sub

#End Region
End Class