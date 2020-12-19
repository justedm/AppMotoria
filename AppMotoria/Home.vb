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
    Private Sub txtEta_Enter(sender As Object, e As EventArgs) Handles txtEta.Enter
        If lblMsgEta.Visible = True Then lblMsgEta.Visible = False
    End Sub
    Private Sub txtEta_Leave(sender As Object, e As EventArgs) Handles txtEta.Leave
        If Integer.TryParse(txtEta.Text, vbNull) Then
            Dim eta As Integer = txtEta.Text

            If eta < 0 Or eta > 99 Then
                txtEta.Clear()
                lblMsgEta.Text = "Età inserita non valida"
                lblMsgEta.Visible = True
            End If

        ElseIf txtEta.Text = "" Then
        Else
            txtEta.Clear()
            lblMsgEta.Text = "Dato non valido"
            lblMsgEta.Visible = True
        End If
    End Sub

    Private Sub txtAltezza_Enter(sender As Object, e As EventArgs) Handles txtAltezza.Enter
        If lblMsgAltezza.Visible = True Then lblMsgAltezza.Visible = False
    End Sub
    Private Sub txtAltezza_Leave(sender As Object, e As EventArgs) Handles txtAltezza.Leave
        If Integer.TryParse(txtAltezza.Text, vbNull) Then
            '
        ElseIf txtAltezza.Text = "" Then
            '
        Else
            txtAltezza.Clear()
            lblMsgAltezza.Visible = True
        End If
    End Sub

    Private Sub txtPeso_Enter(sender As Object, e As EventArgs) Handles txtPeso.Enter
        If lblMsgPeso.Visible = True Then lblMsgPeso.Visible = False
    End Sub
    Private Sub txtPeso_Leave(sender As Object, e As EventArgs) Handles txtPeso.Leave
        If Integer.TryParse(txtPeso.Text, vbNull) Then
            '
        ElseIf txtPeso.Text = "" Then
            '
        Else
            txtPeso.Clear()
            lblMsgPeso.Visible = True
        End If
    End Sub

    Private Sub txtSesso_Enter(sender As Object, e As EventArgs) Handles txtSesso.Enter
        If lblMsgSesso.Visible = True Then lblMsgSesso.Visible = False
    End Sub
    Private Sub txtSesso_Leave(sender As Object, e As EventArgs) Handles txtSesso.Leave
        If Integer.TryParse(txtSesso.Text, vbNull) Then
            txtSesso.Clear()
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
    End Sub

    Private Sub txtPetto_Enter(sender As Object, e As EventArgs) Handles txtPetto.Enter
        If lblMsgPetto.Visible = True Then lblMsgPetto.Visible = False
    End Sub
    Private Sub txtPetto_Leave(sender As Object, e As EventArgs) Handles txtPetto.Leave
        If Integer.TryParse(txtPetto.Text, vbNull) Then
            '
        ElseIf txtPetto.Text = "" Then
            '
        Else
            txtPetto.Clear()
            lblMsgPetto.Visible = True
        End If
    End Sub

    Private Sub txtTricipite_Enter(sender As Object, e As EventArgs) Handles txtTricipite.Enter
        If lblMsgTricipite.Visible = True Then lblMsgTricipite.Visible = False
    End Sub
    Private Sub txtTricipite_Leave(sender As Object, e As EventArgs) Handles txtTricipite.Leave
        If Integer.TryParse(txtTricipite.Text, vbNull) Then
            '
        ElseIf txtTricipite.Text = "" Then
            '
        Else
            txtTricipite.Clear()
            lblMsgTricipite.Visible = True
        End If
    End Sub

    Private Sub txtTorace_Enter(sender As Object, e As EventArgs) Handles txtTorace.Enter
        If lblMsgTorace.Visible = True Then lblMsgTorace.Visible = False
    End Sub
    Private Sub txtTorace_Leave(sender As Object, e As EventArgs) Handles txtTorace.Leave
        If Integer.TryParse(txtTorace.Text, vbNull) Then
            '
        ElseIf txtTorace.Text = "" Then
            '
        Else
            txtTorace.Clear()
            lblMsgTorace.Visible = True
        End If
    End Sub

    Private Sub txtAddome_Enter(sender As Object, e As EventArgs) Handles txtAddome.Enter
        If lblMsgAddome.Visible = True Then lblMsgAddome.Visible = False
    End Sub
    Private Sub txtAddome_Leave(sender As Object, e As EventArgs) Handles txtAddome.Leave
        If Integer.TryParse(txtAddome.Text, vbNull) Then
            '
        ElseIf txtAddome.Text = "" Then
            '
        Else
            txtAddome.Clear()
            lblMsgAddome.Visible = True
        End If
    End Sub

    Private Sub txtVita_Enter(sender As Object, e As EventArgs) Handles txtVita.Enter
        If lblMsgVita.Visible = True Then lblMsgVita.Visible = False
    End Sub
    Private Sub txtVita_Leave(sender As Object, e As EventArgs) Handles txtVita.Leave
        If Integer.TryParse(txtVita.Text, vbNull) Then
            '
        ElseIf txtVita.Text = "" Then
            '
        Else
            txtVita.Clear()
            lblMsgVita.Visible = True
        End If
    End Sub

    Private Sub txtFianchi_Enter(sender As Object, e As EventArgs) Handles txtFianchi.Enter
        If lblMsgFianchi.Visible = True Then lblMsgFianchi.Visible = False
    End Sub
    Private Sub txtFianchi_Leave(sender As Object, e As EventArgs) Handles txtFianchi.Leave
        If Integer.TryParse(txtFianchi.Text, vbNull) Then
            '
        ElseIf txtFianchi.Text = "" Then
            '
        Else
            txtFianchi.Clear()
            lblMsgFianchi.Visible = True
        End If
    End Sub

    Private Sub txtCoscia_Enter(sender As Object, e As EventArgs) Handles txtCoscia.Enter
        If lblMsgCoscia.Visible = True Then lblMsgCoscia.Visible = False
    End Sub
    Private Sub txtCoscia_Leave(sender As Object, e As EventArgs) Handles txtCoscia.Leave
        If Integer.TryParse(txtCoscia.Text, vbNull) Then
            '
        ElseIf txtCoscia.Text = "" Then
            '
        Else
            txtCoscia.Clear()
            lblMsgCoscia.Visible = True
        End If
    End Sub
#End Region

#Region "Save button"

    'Controllare che tutte le textbox abbiano un valore --OK
    '-> Se la textbox è vuota: Modifica label con "Inserire un dato" --OK
    '		-> Se non è vuota controlla che il valore sia un integer (tranne per sesso) --OK
    '		-> Se il valore non è un integer: Modifica label con "Dato non corretto" --OK
    '			-> Se è integer assegna i valori a variabili --OK

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

        Dim check As Integer = 0
        'Cerca tutte le textbox vuote nel form
        'Inserisce i nomi dei label delle textbox vuote in un array
        Dim emptyTextboxList As New ArrayList
        For Each tb As TextBox In tabControl.TabPages(2).Controls.OfType(Of TextBox)()
            If tb.Text.Length = 0 Then
                emptyTextboxList.Add(tb.Name.Trim.Replace("txt", "lblMsg"))
            Else

                If Integer.TryParse(tb.Text, vbNull) Then
                    'Inserisce i valori corretti nelle variabili apposite
                    'Esegue la query di access per inserire i dati nel database

                    If tb.Name = "txtEta" Then
                        Dim varEta As Integer = tb.Text
                    ElseIf tb.Name = "txtAltezza" Then
                        Dim varAltezza As Integer = tb.Text
                    ElseIf tb.Name = "txtPeso" Then
                        Dim varPeso As Integer = tb.Text
                    ElseIf tb.Name = "txtPetto" Then
                        Dim varPetto As Integer = tb.Text
                    ElseIf tb.Name = "txtTricipite" Then
                        Dim varTricipite As Integer = tb.Text
                    ElseIf tb.Name = "txtTorace" Then
                        Dim varTorace As Integer = tb.Text
                    ElseIf tb.Name = "txtAddome" Then
                        Dim varAddome As Integer = tb.Text
                    ElseIf tb.Name = "txtVita" Then
                        Dim varVita As Integer = tb.Text
                    ElseIf tb.Name = "txtFianchi" Then
                        Dim varFianchi As Integer = tb.Text
                    ElseIf tb.Name = "txtCoscia" Then
                        Dim varCoscia As Integer = tb.Text
                    End If

                    check = check + 1


                    'INSERT INTO Informazioni (Età, Altezza, Peso, Sesso, Petto, Tricipite, Torace, Addome, Vita, Fianchi, Coscia) VALUES (varEta, varAltezza, varPeso, varSesso, varPetto, varTricipite, varTorace, varAddome, varVita, varFianchi, varCoscia)


                Else

                    If tb.Name <> "txtSesso" Then
                        With tabControl.TabPages(2).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                            .Text = "Dato non valido"
                            .Visible = True
                        End With
                    Else
                        'Convalida il valore del sesso e lo inserisce nella variabile
                        Dim varSesso As String
                        If tb.Text.ToLower = "maschio" Or tb.Text.ToLower = "m" Then
                            varSesso = "maschio"
                            check = check + 1
                        ElseIf tb.Text.ToLower = "femmina" Or tb.Text.ToLower = "f" Then
                            varSesso = "femmina"
                            check = check + 1
                        Else
                            With tabControl.TabPages(2).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                                .Text = "Dato non valido"
                                .Visible = True
                            End With
                        End If
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

        If check = 11 Then
            MsgBox("Ok")
        Else
            MsgBox("errore nella compilazione")
        End If

    End Sub
#End Region
End Class