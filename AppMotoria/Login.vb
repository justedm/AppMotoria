Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class Login
    'Boolean for eyeSetting
    Dim pwdShow = False

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

#Region "Form load"
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()
        eyeSetting.Visible = False
        lblMsgUsername.Visible = False
        lblMsgPassword.Visible = False
        lblMsgLogin.Visible = False

        If My.Settings.checkRicordamiSett = True Then
            If My.Settings.savedUsername <> "" And My.Settings.savedPassword <> "" Then
                Home.Show()
                Me.Close()
            End If
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

#Region "Inserimento dati"
    Private Sub usrBox_Click(sender As Object, e As EventArgs) Handles usrBox.Click
        txtUsername.Select()
    End Sub

    Private Sub pwdBox_Click(sender As Object, e As EventArgs) Handles pwdBox.Click
        txtPassword.Select()
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
            eyeSetting.Visible = True
        End If
        lblMsgPassword.Visible = False
    End Sub
    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        If txtPassword.Text = "" Then
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.FromArgb(207, 207, 207)
            txtPassword.UseSystemPasswordChar = False
            eyeSetting.Visible = False
        End If
    End Sub
#End Region

#Region "Login button"
    Private Sub lblLogin_Click(sender As Object, e As EventArgs) Handles lblLogin.Click
        Dim username = txtUsername.Text.Trim
        Dim password = txtPassword.Text.Trim


        If (username <> "" And username <> "Username") Then
            If (password <> "" And password <> "Password") Then
                Dim val As Integer
                Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DBApp.mdb")
                Dim query As String = "select count(*) from Utenti Where StrComp([Username], @Username, 0) = 0 AND StrComp([Password], @Password, 0) = 0"

                Using cmd = New OleDbCommand(query, conn)
                    cmd.Parameters.Add("@Username", OleDbType.VarChar).Value = username
                    cmd.Parameters.Add("@Password", OleDbType.VarChar).Value = password

                    If conn.State = ConnectionState.Closed Then conn.Open()

                    val = cmd.ExecuteScalar
                    cmd.Dispose()

                    If val <> 0 Then

                        My.Settings.currentUser = username
                        My.Settings.Save()

                        Using cmdRead = New OleDbCommand("SELECT ID FROM Utenti WHERE Username = @Username", conn)
                            cmdRead.Parameters.Add("Username", OleDbType.VarChar).Value = My.Settings.currentUser
                            If conn.State = ConnectionState.Closed Then conn.Open()

                            My.Settings.currentUserID = cmdRead.ExecuteScalar()

                            cmdRead.Dispose()
                        End Using

                        If checkRicordami.Checked = True Then
                            My.Settings.savedUsername = txtUsername.Text
                            My.Settings.savedPassword = txtPassword.Text
                            My.Settings.checkRicordamiSett = True
                            My.Settings.Save()
                        End If

                        Home.Show()
                        Me.Close()
                    Else
                        lblMsgLogin.Visible = True
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

#Region "Register button"
    Private Sub lblRegister_Click(sender As Object, e As EventArgs) Handles lblRegister.Click
        Register.Show()
        Me.Close()
    End Sub
#End Region

#Region "Mostra/Nascondi Dati"
    Private Sub eyeSetting_Click(sender As Object, e As EventArgs) Handles eyeSetting.Click
        If pwdShow = False Then
            eyeSetting.Image = My.Resources.ResourceManager.GetObject("closed_eye")
            txtPassword.UseSystemPasswordChar = False
            pwdShow = True
        Else
            eyeSetting.Image = My.Resources.ResourceManager.GetObject("eye")
            txtPassword.UseSystemPasswordChar = True
            pwdShow = False
        End If
    End Sub
#End Region

End Class
