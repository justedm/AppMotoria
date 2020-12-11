Imports System.Runtime.InteropServices
Imports System.Data.OleDb
Public Class Register

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

#Region "Button Close"
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
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()
        eyePassword.Visible = False
        eyeConfirmPassword.Visible = False
    End Sub

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
            eyePassword.Visible = True
        End If
    End Sub

    Private Sub txtPasswordConfirm_Enter(sender As Object, e As EventArgs) Handles txtPasswordConfirm.Enter
        If txtPasswordConfirm.Text = "Conferma Password" Then
            txtPasswordConfirm.ForeColor = Color.FromArgb(224, 224, 224)
            txtPasswordConfirm.Clear()
            txtPasswordConfirm.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub txtPasswordConfirm_TextChanged(sender As Object, e As EventArgs) Handles txtPasswordConfirm.TextChanged
        If txtPasswordConfirm.Text <> "" Then
            eyeConfirmPassword.Visible = True
        End If
    End Sub

    Private Sub lblRegister_Click(sender As Object, e As EventArgs) Handles lblRegister.Click
        If (txtUsername.Text <> "" And txtPassword.Text <> "" And txtPasswordConfirm.Text <> "") Then
            If (txtUsername.Text <> "Username" And txtPassword.Text <> "Password" And txtPasswordConfirm.Text <> "Conferma Password") Then
                If (txtPassword.Text = txtPasswordConfirm.Text) Then
                    Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Account.mdb;Persist Security Info=True")

                    Using cmdRead = New OleDbCommand("select * from Utenti where username = @Username", conn)
                        cmdRead.Parameters.Add("Username", OleDbType.VarChar).Value = txtUsername.Text.Trim
                        If conn.State = ConnectionState.Closed Then conn.Open()
                        Dim reader As OleDbDataReader = cmdRead.ExecuteReader

                        If reader.Read = False Then
                            If txtPassword.Text = txtPasswordConfirm.Text Then
                                Using cmdRegister = New OleDbCommand("INSERT INTO Utenti ([Username], [Password]) VALUES (@Username, @Password)", conn)

                                    cmdRegister.Parameters.Add("Username", OleDbType.VarChar).Value = txtUsername.Text
                                    cmdRegister.Parameters.Add("Password", OleDbType.VarChar).Value = txtPassword.Text

                                    If conn.State = ConnectionState.Closed Then conn.Open()
                                    reader.Close()
                                    cmdRegister.ExecuteNonQuery()
                                    MsgBox("Registrato Correttamente")
                                End Using
                            Else
                                MsgBox("Le password inserite non sono uguali")
                            End If
                        Else
                            MsgBox("Il nome scelto è già esistente")
                        End If
                    End Using
                Else
                    MsgBox("Le password non coincidono")
                End If
            Else
                MsgBox("Inserisci i dati richiesti (Default)")
            End If
        Else
            MsgBox("Inserisci tutti i dati richiesti")
        End If
    End Sub

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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Login.Show()
        Me.Close()
    End Sub

#End Region
End Class