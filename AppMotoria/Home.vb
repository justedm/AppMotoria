Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class Home

#Region "Movimento form"
    Public Const WM_NCLBUTTONDOWN As Integer = 161
    Public Const HT_CAPTION As Integer = 2

    <DllImport("User32")> Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer

    End Function

    <DllImport("User32")> Private Shared Function ReleaseCapture() As Boolean

    End Function

    Private Sub topBar_MouseDown(sender As Object, e As MouseEventArgs) Handles topBar.MouseDown
        If (e.Button = MouseButtons.Left) Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
#End Region

#Region "Caricamento form"
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabControl.ItemSize = New Size(0, 1)
        tabControl.SizeMode = TabSizeMode.Fixed
        tabControl.SendToBack()
    End Sub
#End Region

#Region "Pulsante chiusura"
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

#Region "Bottone logout"
    Private Sub panelLogout_Click(sender As Object, e As EventArgs) Handles panelLogout.Click
        logoutFunction()
    End Sub

    Private Sub lblLogout_Click(sender As Object, e As EventArgs) Handles lblLogout.Click
        logoutFunction()
    End Sub

    Private Sub imgLogout_Click(sender As Object, e As EventArgs) Handles imgLogout.Click
        logoutFunction()
    End Sub
    Sub logoutFunction()
        My.Settings.savedUsername = ""
        My.Settings.savedPassword = ""
        My.Settings.checkRicordamiSett = False
        My.Settings.Save()
        Login.Show()
        Me.Close()
    End Sub
#End Region

#Region "Bottoni menu"
    Private Sub panelCalcoli_Click(sender As Object, e As EventArgs) Handles panelCalcoli.Click
        openTab(sender)
        'tabControl.SelectedTab = tabDati
        'lblCalcoli.ForeColor = Color.FromArgb(140, 180, 230)
        'lblDati.ForeColor = Color.White
    End Sub

    Private Sub panelDati_Click(sender As Object, e As EventArgs) Handles panelDati.Click
        openTab(sender)
        'tabControl.SelectedTab = tabCalcoli
        'lblDati.ForeColor = Color.FromArgb(140, 180, 230)
        'lblCalcoli.ForeColor = Color.White
    End Sub

    Private Sub lblCalcoli_Click(sender As Object, e As EventArgs) Handles lblCalcoli.Click
        openTab(sender)
    End Sub

    Private Sub lblDati_Click(sender As Object, e As EventArgs) Handles lblDati.Click
        openTab(sender)
    End Sub

    Private Sub imgCalcoli_Click(sender As Object, e As EventArgs) Handles imgCalcoli.Click
        openTab(sender)
    End Sub

    Private Sub imgDati_Click(sender As Object, e As EventArgs) Handles imgDati.Click
        openTab(sender)
    End Sub

    Sub openTab(sender)
        Dim obj As Object = CType(sender, Object)
        If obj.Name = "lblCalcoli" Or obj.Name = "imgCalcoli" Or obj.Name = "panelCalcoli" Then
            tabControl.SelectedTab = tabCalcoli
            imgCalcoli.Image = My.Resources.ResourceManager.GetObject("calcolatore_clicked")
            imgDati.Image = My.Resources.ResourceManager.GetObject("dati")
            lblCalcoli.ForeColor = Color.FromArgb(140, 180, 230)
            lblDati.ForeColor = Color.White
        ElseIf obj.Name = "lblDati" Or obj.Name = "imgDati" Or obj.Name = "panelDati" Then
            tabControl.SelectedTab = tabDati
            imgDati.Image = My.Resources.ResourceManager.GetObject("dati_clicked")
            imgCalcoli.Image = My.Resources.ResourceManager.GetObject("calcolatore")
            lblDati.ForeColor = Color.FromArgb(140, 180, 230)
            lblCalcoli.ForeColor = Color.White
        End If
    End Sub
#End Region

End Class