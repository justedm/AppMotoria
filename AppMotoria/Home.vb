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

        If My.Settings.arrayUtenti Is Nothing Then
            My.Settings.arrayUtenti = New System.Collections.Specialized.StringCollection
        End If

        If My.Settings.arrayUtenti.Contains(My.Settings.currentUser) Then
            tabControl.SelectedTab = tabPrimoInserimento
        End If

        lblMsgEta.Visible = False
        lblMsgAltezza.Visible = False
        lblMsgPeso.Visible = False
        lblMsgSesso.Visible = False
        lblMsgPetto.Visible = False
        lblMsgTricipite.Visible = False
        lblMsgTorace.Visible = False
        lblMsgAddome.Visible = False
        lblMsgVita.Visible = False
        lblMsgFianchi.Visible = False
        lblMsgCoscia.Visible = False

        TextBox1.Select()

        lblSave.Location = New Point(lblSave.Location.X, lblSave.Location.Y + 20)
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

#Region "Text Check"

    Private Sub limitToNumbers_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEta.KeyPress, txtAltezza.KeyPress, txtPetto.KeyPress,
            txtTricipite.KeyPress, txtTorace.KeyPress, txtAddome.KeyPress, txtVita.KeyPress, txtFianchi.KeyPress, txtCoscia.KeyPress

        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeso.KeyPress

        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub


    Private Sub labelCheck_Enter(sender As Object, e As EventArgs) Handles txtEta.Enter, txtAltezza.Enter, txtPeso.Enter, txtSesso.Enter, txtPetto.Enter,
            txtTricipite.Enter, txtTorace.Enter, txtAddome.Enter, txtVita.Enter, txtFianchi.Enter, txtCoscia.Enter

        Dim tb As TextBox = DirectCast(sender, TextBox)
        Dim lbl As String = tb.Name.Replace("txt", "lblMsg")

        With tabControl.TabPages(2).Controls(lbl)
            If .Visible = True Then
                .Visible = False
            End If
        End With
    End Sub
    Private Sub checkSessoAndEta_Leave(sender As Object, e As EventArgs) Handles txtEta.Leave, txtSesso.Leave

        Dim tb As TextBox = DirectCast(sender, TextBox)

        If tb.Name = "txtEta" Then
            If Integer.TryParse(txtEta.Text, vbNull) Then
                Dim eta As Integer = txtEta.Text

                If eta <= 0 Or eta >= 99 Then
                    txtEta.Clear()
                    lblMsgEta.Text = "Età non valida"
                    lblMsgEta.Visible = True
                End If

            ElseIf txtEta.Text = "" Then
            Else
                txtEta.Clear()
                lblMsgEta.Text = "Dato non valido"
                lblMsgEta.Visible = True
            End If
        ElseIf tb.Name = "txtSesso" Then
            If Integer.TryParse(txtSesso.Text, vbNull) Then
                txtSesso.Clear()
                lblMsgSesso.Text = "Dato non valido"
                lblMsgSesso.Visible = True
            ElseIf txtSesso.Text = "" Then
                '
            Else
                If txtSesso.Text.ToLower = "m" Or txtSesso.Text.ToLower = "maschio" Then
                    '
                ElseIf txtSesso.Text.ToLower = "f" Or txtSesso.Text.ToLower = "femmina" Then
                    '
                Else
                    txtSesso.Clear()
                    lblMsgSesso.Visible = True
                End If
            End If
        End If

    End Sub

#End Region

#Region "Save button"
    Private Sub lblSave_Click(sender As Object, e As EventArgs) Handles lblSave.Click

        'Cerca ogni label nel form con il nome che inizia con "lblMsg"
        'Imposta la visibilità in false
        For Each lbl As Label In tabControl.TabPages(2).Controls.OfType(Of Label)()
            If lbl.Name.StartsWith("lblMsg") Then
                If lbl.Visible = True Then
                    lbl.Visible = False
                End If
            End If
        Next

        'Cerca tutte le textbox nel form
        Dim emptyTextboxList As New ArrayList
        Dim values As New ArrayList
        'Cerca tutte le textbox nel form
        For Each tb As TextBox In tabControl.TabPages(2).Controls.OfType(Of TextBox)()
            'Controlla che abbiano un dato al loro interno
            If tb.TextLength = 0 Then
                'Non hanno un dato e vengono aggiunge all'array per mostrare "Inserisci un dato"
                emptyTextboxList.Add(tb.Name.Trim.Replace("txt", "lblmsg"))
            Else
                'Hanno un dato
                'Controlla se il nome è "txtSesso"
                If tb.Name = "txtSesso" Then
                    If Integer.TryParse(tb.Text, vbNull) Then
                        With tabControl.TabPages(2).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                            .Text = "Dato non valido"
                            .Visible = True
                        End With
                    Else
                        'Controlla che il sesso sia "m" o "maschio"
                        If tb.Text.ToLower = "m" Or tb.Text.ToLower = "maschio" Then
                            values.Add("maschio")
                            'Controlla che il sesso sia "f" o "femmina
                        ElseIf tb.Text.ToLower = "f" Or tb.Text.ToLower = "femmina" Then
                            values.Add("femmina")
                        Else
                            With tabControl.TabPages(2).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                                .Text = "Dato non valido"
                                .Visible = True
                            End With
                        End If
                    End If
                    'Controlla se il nome è "txtEta"
                ElseIf tb.Name = "txtEta" Then
                    'Controlla che il valore sia un numero
                    If Integer.TryParse(tb.Text, vbNull) Then
                        'Controlla che l'eta inserita sia >= 1 o <= 99
                        If tb.Text >= 1 And tb.Text <= 99 Then
                            values.Add(tb.Text)
                        Else
                            With tabControl.TabPages(2).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                                .Text = "Età non valida"
                                .Visible = True
                            End With
                        End If
                    Else
                        With tabControl.TabPages(2).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                            .Text = "Età non valida"
                            .Visible = True
                        End With
                    End If
                ElseIf tb.Name = "txtPeso" Then
                    If Double.TryParse(tb.Text, vbNull) Then
                        values.Add(tb.Text)
                    End If
                    'Se il nome non è ne "txtSesso" ne "txtEta"
                Else
                    'Controlla che il valore sia un numero
                    If Integer.TryParse(tb.Text, vbNull) Then
                        values.Add(tb.Text)
                    Else
                        With tabControl.TabPages(2).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                            .Text = "Dato non valido"
                            .Visible = True
                        End With
                    End If
                End If

            End If
        Next

        'Rende visibili i label delle textbox vuote con testo "Inserisci un dato"
        For Each emptyTextbox In emptyTextboxList
            With tabControl.TabPages(2).Controls(emptyTextbox)
                .Text = "Inserisi un dato"
                .Visible = True
            End With
        Next

        If values.Count = 11 Then
            MsgBox("OK")
        Else
            MsgBox("Inserisci tutti i dati")
        End If


        '[1] - Coscia
        '[2] - Fianchi
        '[3] - Vita
        '[4] - Addome
        '[5] - Torace
        '[6] - Tricipite
        '[7] - Petto
        '[8] - Sesso
        '[9] - Peso
        '[10] - Altezza
        '[11] - Età






    End Sub
#End Region
End Class