Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class Home
    Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\AppDB.mdb")

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

        'Imposta tutti i label dei dati non visibili
        Dim lblList = {"lblMsgEta", "lblMsgAltezza", "lblMsgPeso", "lblMsgSesso", "lblMsgPetto", "lblMsgTricipite", "lblMsgTorace", "lblMsgAddome", "lblMsgVita", "lblMsgFianchi", "lblMsgCoscia"}
        For Each lbl In lblList
            With tabControl.TabPages(1).Controls(lbl)
                .Visible = False
            End With
        Next
        lblBMI.Text = ""

        'Se l'arrayUtenti non esiste lo crea
        If My.Settings.arrayUtenti Is Nothing Then
            My.Settings.arrayUtenti = New System.Collections.Specialized.StringCollection
        End If
        'Se l'array contiene l'utente loggato nell'app seleziona la scheda dei dati come principale
        If My.Settings.arrayUtenti.Contains(My.Settings.currentUser) Then
            tabControl.SelectedTab = tabPrimoInserimento
            openTab(sender, "Dati")
        Else
            loadBMI()
            loadFM()
            openTab(sender, "Calcoli")
        End If

        'Abbassa il bottone per salvare i dati
        lblSave.Location = New Point(lblSave.Location.X, lblSave.Location.Y + 20)

        Dim selectSex As String = "SELECT Sesso FROM Utenti WHERE Username = @Username"

        Using sexCmd = New OleDbCommand(selectSex, conn)
            sexCmd.Parameters.Add("Username", OleDbType.VarChar).Value = My.Settings.currentUser
            If conn.State = ConnectionState.Closed Then conn.Open()

            If Not IsDBNull(sexCmd.ExecuteScalar) Then
                txtSesso.Text = sexCmd.ExecuteScalar
                txtSesso.ReadOnly = True
                sexCmd.Dispose()
            End If
        End Using

        TextBox1.Select()

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
    Private Sub panelLogout_Click(sender As Object, e As EventArgs) Handles panelLogout.Click, lblLogout.Click, imgLogout.Click
        My.Settings.savedUsername = ""
        My.Settings.savedPassword = ""
        My.Settings.Save()
        My.Settings.checkRicordamiSett = False

        Login.Show()
        Me.Close()
    End Sub
#End Region

#Region "Bottoni menu"
    Private Sub Calcoli_Click(sender As Object, e As EventArgs) Handles panelCalcoli.Click, lblCalcoli.Click, imgCalcoli.Click, panelDati.Click, lblDati.Click, imgDati.Click
        openTab(sender, "")
    End Sub
    Sub openTab(sender, home)
        Dim obj As Object = CType(sender, Object)
        If obj.Name = "lblCalcoli" Or obj.Name = "imgCalcoli" Or obj.Name = "panelCalcoli" Or home = "Calcoli" Then
            tabControl.SelectedTab = tabCalcoli
            imgCalcoli.Image = My.Resources.ResourceManager.GetObject("calcolatore_clicked")
            imgDati.Image = My.Resources.ResourceManager.GetObject("dati")
            lblCalcoli.ForeColor = Color.FromArgb(140, 180, 230)
            lblDati.ForeColor = Color.White

            TextBox1.Select()
            loadBMI()
            loadFM()

        ElseIf obj.Name = "lblDati" Or obj.Name = "imgDati" Or obj.Name = "panelDati" Or home = "Dati" Then
            tabControl.SelectedTab = tabPrimoInserimento
            imgDati.Image = My.Resources.ResourceManager.GetObject("dati_clicked")
            imgCalcoli.Image = My.Resources.ResourceManager.GetObject("calcolatore")
            lblDati.ForeColor = Color.FromArgb(140, 180, 230)
            lblCalcoli.ForeColor = Color.White

            TextBox1.Select()
        End If
    End Sub
#End Region

#Region "Load dati"
    Sub loadBMI()

        Dim peso As Double
        Dim altezza As Integer

        Using getData = New OleDbCommand("SELECT TOP 1 Peso, Altezza FROM Informazioni WHERE ID_User = @ID_User ORDER BY id DESC", conn)
            getData.Parameters.Add("ID_User", OleDbType.VarChar).Value = My.Settings.currentUserID
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim reader As OleDbDataReader = getData.ExecuteReader

            If reader.HasRows Then
                While reader.Read
                    peso = reader.GetString(0)
                    altezza = reader.GetString(1)
                End While
            End If
            reader.Close()
        End Using


        'Calcolo BMI
        Dim bmi As Double = (peso / Math.Pow((altezza / 100), 2))

        'Se il BMI è "NaN" richiede l'inserimento di dati
        'altrimenti inserisce il valore del BMI nella textbox
        If bmi.ToString.Equals("NaN") Then
            txtBMI.Text = "Inserisci dei dati"
        Else
            txtBMI.Text = bmi.ToString("0.0")
            lblBMI.Visible = True
        End If

        'Assegna un valore al lblBMI in base al valore di esso
        If bmi < 18.5 Then
            lblBMI.Text = "Sottopeso"
            lblBMI.ForeColor = Color.FromArgb(3, 177, 252)
        ElseIf bmi >= 18.5 And bmi <= 24.9 Then
            lblBMI.Text = "Normopeso"
            lblBMI.ForeColor = Color.FromArgb(3, 252, 111)
        ElseIf bmi >= 25 And bmi <= 29.9 Then
            lblBMI.Text = "Sovrappeso"
            lblBMI.ForeColor = Color.FromArgb(252, 252, 3)
        ElseIf bmi >= 30 And bmi <= 34.9 Then
            lblBMI.Text = "Obeso"
            lblBMI.ForeColor = Color.FromArgb(252, 169, 3)
        ElseIf bmi >= 35 Then
            lblBMI.Text = "Obeso estremo"
            lblBMI.ForeColor = Color.FromArgb(252, 3, 36)
        End If
    End Sub

    Sub loadFM()
        Dim sesso As String = ""

        Using getData = New OleDbCommand("SELECT Sesso FROM Utenti WHERE Username = @Username", conn)
            getData.Parameters.Add("Username", OleDbType.VarChar).Value = My.Settings.currentUser
            If conn.State = ConnectionState.Closed Then conn.Open()

            If Not IsDBNull(getData.ExecuteScalar) Then
                sesso = getData.ExecuteScalar
            Else
                txtFM.Text = "Inserisci dei dati"
            End If

            getData.Dispose()
        End Using

        If sesso = "Maschio" Then

            Dim eta As Integer
            Dim addome As Double
            Dim petto As Double
            Dim coscia As Double

            Using getData = New OleDbCommand("SELECT TOP 1 Età, Addome, Petto, Coscia FROM Informazioni WHERE ID_User = @ID_User ORDER BY id DESC", conn)
                getData.Parameters.Add("ID_User", OleDbType.VarChar).Value = My.Settings.currentUserID
                If conn.State = ConnectionState.Closed Then conn.Open()

                Dim reader As OleDbDataReader = getData.ExecuteReader

                If reader.HasRows Then
                    While reader.Read
                        eta = reader.GetString(0)
                        addome = reader.GetString(1)
                        petto = reader.GetString(2)
                        coscia = reader.GetString(3)
                    End While
                End If
                reader.Close()
            End Using

            Dim sPliche As Double = (addome + petto + coscia)
            Dim densCorp As Double = 1.10938 - (0.0008267 * sPliche) + (0.0000016 * Math.Pow(sPliche, 2)) - (0.0002574 * eta)
            Dim fm As Double = (495 / densCorp) - 450

            txtFM.Text = fm.ToString("0.00") & "%"

        ElseIf sesso = "Femmina" Then

            Dim eta As Integer
            Dim fianchi As Double
            Dim tricipite As Double
            Dim coscia As Double

            Using getData = New OleDbCommand("SELECT TOP 1 Età, Fianchi, Tricipite, Coscia FROM Informazioni WHERE ID_User = @ID_User ORDER BY id DESC", conn)
                getData.Parameters.Add("ID_User", OleDbType.VarChar).Value = My.Settings.currentUserID
                If conn.State = ConnectionState.Closed Then conn.Open()

                Dim reader As OleDbDataReader = getData.ExecuteReader

                If reader.HasRows Then
                    While reader.Read
                        eta = reader.GetString(0)
                        fianchi = reader.GetString(1)
                        tricipite = reader.GetString(2)
                        coscia = reader.GetString(3)
                    End While
                End If
                reader.Close()
            End Using

            Dim sPliche As Double = fianchi + tricipite + coscia
            Dim densCorp As Double = 1.0902369 - (0.0009379 * sPliche) + (0.0000026 * Math.Pow(sPliche, 2)) - (0.00000979 * eta)
            Dim fm As Double = (495 / densCorp) - 450

            txtFM.Text = fm.ToString("0.00") & "%"
        End If
    End Sub
#End Region

#Region "Text Check"

    'Tutti punti e virgole tranne:
    'Età, Altezza, Sesso

    Private Sub limitToNumbers_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEta.KeyPress, txtAltezza.KeyPress, txtPeso.KeyPress, txtPetto.KeyPress,
            txtTricipite.KeyPress, txtTorace.KeyPress, txtAddome.KeyPress, txtVita.KeyPress, txtFianchi.KeyPress, txtCoscia.KeyPress

        Dim obj As Object = CType(sender, Object)

        If obj.name <> "txtEta" And obj.name <> "txtAltezza" And obj.name <> "txtSesso" Then
            If Not (Char.IsNumber(e.KeyChar) OrElse e.KeyChar = "," OrElse e.KeyChar = "." OrElse Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Else
            If Not (Char.IsNumber(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub labelCheck_Enter(sender As Object, e As EventArgs) Handles txtEta.Enter, txtAltezza.Enter, txtPeso.Enter, txtSesso.Enter, txtPetto.Enter,
            txtTricipite.Enter, txtTorace.Enter, txtAddome.Enter, txtVita.Enter, txtFianchi.Enter, txtCoscia.Enter

        Dim tb As TextBox = DirectCast(sender, TextBox)
        Dim lbl As String = tb.Name.Replace("txt", "lblMsg")

        With tabControl.TabPages(1).Controls(lbl)
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
        For Each lbl As Label In tabControl.TabPages(1).Controls.OfType(Of Label)()
            If lbl.Name.StartsWith("lblMsg") Then
                If lbl.Visible = True Then
                    lbl.Visible = False
                End If
            End If
        Next

        Dim emptyTextboxList As New ArrayList
        Dim values As New ArrayList
        'Cerca tutte le textbox nel form
        For Each tb As TextBox In tabControl.TabPages(1).Controls.OfType(Of TextBox)()
            'Controlla che abbiano un dato al loro interno
            If tb.TextLength = 0 Then
                'Non hanno un dato e vengono aggiunge all'array per mostrare "Inserisci un dato"
                emptyTextboxList.Add(tb.Name.Trim.Replace("txt", "lblmsg"))
            Else
                'Hanno un dato
                'Controlla se il nome è "txtSesso"

                If tb.Name = "txtSesso" Then
                    If Integer.TryParse(tb.Text, vbNull) Then
                        With tabControl.TabPages(1).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                            .Text = "Dato non valido"
                            .Visible = True
                        End With
                    Else
                        'Controlla che il sesso sia "m" o "maschio"
                        If tb.Text.ToLower = "m" Or tb.Text.ToLower = "maschio" Then
                            values.Add("Maschio")
                            'Controlla che il sesso sia "f" o "femmina
                        ElseIf tb.Text.ToLower = "f" Or tb.Text.ToLower = "femmina" Then
                            values.Add("Femmina")
                        Else
                            With tabControl.TabPages(1).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
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
                            With tabControl.TabPages(1).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                                .Text = "Età non valida"
                                .Visible = True
                            End With
                        End If
                    Else
                        With tabControl.TabPages(1).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                            .Text = "Età non valida"
                            .Visible = True
                        End With
                    End If
                ElseIf tb.Name = "txtPeso" Then
                    If Double.TryParse(tb.Text, vbNull) Then
                        values.Add(tb.Text.Replace(".", ","))
                    End If
                    'Se il nome non è ne "txtSesso" ne "txtEta"
                Else
                    'Controlla che il valore sia un numero
                    If Double.TryParse(tb.Text, vbNull) Then
                        values.Add(tb.Text.Replace(".", ","))
                    Else
                        With tabControl.TabPages(1).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
                            .Text = "Dato non valido"
                            .Visible = True
                        End With
                    End If
                End If

            End If
        Next

        'Rende visibili i label delle textbox vuote con testo "Inserisci un dato"
        For Each emptyTextbox In emptyTextboxList
            With tabControl.TabPages(1).Controls(emptyTextbox)
                .Text = "Inserisi un dato"
                .Visible = True
            End With
        Next

        'Se tutti i dati sono stati inseriti li inserisce nel database
        If values.Count = 11 Then
            Dim msg As DialogResult = MessageBox.Show("Sei sicuro?", "Salva dati", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If msg = DialogResult.Yes Then
                Dim idSearch As String = "SELECT ID FROM Utenti WHERE Username = @Username"
                Dim idFound As String

                Using cmdRead = New OleDbCommand(idSearch, conn)
                    cmdRead.Parameters.Add("Username", OleDbType.VarChar).Value = My.Settings.currentUser
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    idFound = cmdRead.ExecuteScalar()

                    cmdRead.Dispose()
                End Using

                Dim queryDati As String = "INSERT INTO Informazioni (ID_User, [Coscia], [Fianchi], [Vita], [Addome], [Torace], [Tricipite], [Petto], [Peso], [Altezza], [Età]) VALUES (@ID_User, @Coscia, @Fianchi, @Vita, @Addome, @Torace, @Tricipite, @Petto, @Peso, @Altezza, @Età)"
                Using cmdAdd = New OleDbCommand(queryDati, conn)
                    cmdAdd.Parameters.Add("ID_User", OleDbType.VarChar).Value = idFound
                    cmdAdd.Parameters.Add("Coscia", OleDbType.VarChar).Value = values(0)
                    cmdAdd.Parameters.Add("Fianchi", OleDbType.VarChar).Value = values(1)
                    cmdAdd.Parameters.Add("Vita", OleDbType.VarChar).Value = values(2)
                    cmdAdd.Parameters.Add("Addome", OleDbType.VarChar).Value = values(3)
                    cmdAdd.Parameters.Add("Torace", OleDbType.VarChar).Value = values(4)
                    cmdAdd.Parameters.Add("Tricipite", OleDbType.VarChar).Value = values(5)
                    cmdAdd.Parameters.Add("Petto", OleDbType.VarChar).Value = values(6)
                    cmdAdd.Parameters.Add("Peso", OleDbType.VarChar).Value = values(8)
                    cmdAdd.Parameters.Add("Altezza", OleDbType.VarChar).Value = values(9)
                    cmdAdd.Parameters.Add("Età", OleDbType.VarChar).Value = values(10)


                    If conn.State = ConnectionState.Closed Then conn.Open()
                    cmdAdd.ExecuteNonQuery()
                    cmdAdd.Dispose()
                End Using

                'Controlla se l'utente ha già inserito i dati dopo essersi registrato
                If My.Settings.arrayUtenti.Contains(My.Settings.currentUser) Then
                    'Se non ha ancora inserito dei dati aggiorna il sesso per poi rimuoverlo
                    'dalla lista di utenti che devono ancora inserire dei dati
                    Dim querySesso As String = "UPDATE Utenti SET Sesso=@Sesso WHERE Username=@Username"
                    Using cmdSesso = New OleDbCommand(querySesso, conn)
                        cmdSesso.Parameters.Add("Sesso", OleDbType.VarChar).Value = values(7)
                        cmdSesso.Parameters.Add("Username", OleDbType.VarChar).Value = My.Settings.currentUser

                        If conn.State = ConnectionState.Closed Then conn.Open()
                        cmdSesso.ExecuteNonQuery()
                        cmdSesso.Dispose()
                    End Using

                    My.Settings.arrayUtenti.Remove(My.Settings.currentUser)
                    My.Settings.Save()
                End If

                'Cerca tutte le textbox nel form dove il nome non è "txtSesso" e rimuove il testo inserito
                For Each txtBox As TextBox In tabControl.TabPages(1).Controls.OfType(Of TextBox)()
                    If txtBox.Name <> "txtSesso" Then
                        With tabControl.TabPages(1).Controls(txtBox.Name)
                            .Text = ""
                        End With
                    End If
                Next

                If txtSesso.Text.ToLower = "m" Or txtSesso.Text.ToLower = "maschio" Then
                    txtSesso.Text = "Maschio"
                    txtSesso.ReadOnly = True
                ElseIf txtSesso.Text.ToLower = "f" Or txtSesso.Text.ToLower = "femmina" Then
                    txtSesso.Text = "Femmina"
                    txtSesso.ReadOnly = True
                End If

                MessageBox.Show("Dati salvati!", "Salvataggio dati", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Inserisci tutti i dati!", "Salvataggio dati", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

#Region "ToolTip"
    Private Sub lblFM_MouseHover(sender As Object, e As EventArgs) Handles lblFM.MouseHover
        tooltipFM.SetToolTip(lblFM, "Percentuale massa grassa")
    End Sub
#End Region
End Class