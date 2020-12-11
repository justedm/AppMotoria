Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class Login

    Dim pwdShow = False

    'Movimento Form
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
    'Fine Movimento Form

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()
        eyeSetting.Visible = False

        If My.Settings.checkRicordamiSett = True Then
            If My.Settings.savedUsername <> "" And My.Settings.savedPassword <> "" Then
                Home.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        End
    End Sub

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
    End Sub

    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        If txtPassword.Text = "Password" Then
            txtPassword.ForeColor = Color.FromArgb(224, 224, 224)
            txtPassword.Clear()
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text <> "" Then
            eyeSetting.Visible = True
        End If
    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        btnClose.Image = My.Resources.ResourceManager.GetObject("close_red")
    End Sub
    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.Image = My.Resources.ResourceManager.GetObject("close")
    End Sub

    Private Sub lblLogin_Click(sender As Object, e As EventArgs) Handles lblLogin.Click
        If (txtUsername.Text <> "" And txtPassword.Text <> "") Then
            If (txtUsername.Text <> "Username") Then
                If (txtPassword.Text <> "Password") Then
                    Dim val As Integer

                    Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Account.mdb;Persist Security Info=True")
                    Using cmd = New OleDbCommand("select count(*) from Utenti where Username = @Username and Password = @Password;", conn)
                        cmd.Parameters.Add("@Username", OleDbType.VarChar).Value = txtUsername.Text.Trim
                        cmd.Parameters.Add("@Password", OleDbType.VarChar).Value = txtPassword.Text.Trim
                        If conn.State = ConnectionState.Closed Then conn.Open()
                        val = cmd.ExecuteScalar
                        cmd.Dispose()
                        If val = 1 Then

                            If checkRicordami.Checked = True Then
                                My.Settings.savedUsername = txtUsername.Text
                                My.Settings.savedPassword = txtPassword.Text
                                My.Settings.checkRicordamiSett = True
                                My.Settings.Save()
                            End If
                            Home.Show()
                            Me.Close()
                        Else
                            MsgBox("Credenziali errate")
                        End If
                    End Using
                Else
                    MsgBox("Inserisci la password")
                End If
            Else
                MsgBox("Inserisci un nome utente")
            End If
        Else
            MsgBox("Inserisci i dati utente!")
        End If
    End Sub

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

    Private Sub lblRegister_Click(sender As Object, e As EventArgs) Handles lblRegister.Click
        Register.Show()
        Me.Close()
    End Sub

End Class
