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

        Dim lblList = {"lblMsgEta", "lblMsgAltezza", "lblMsgPeso", "lblMsgSesso", "lblMsgPetto", "lblMsgTricipite", "lblMsgTorace", "lblMsgAddome", "lblMsgVita", "lblMsgFianchi", "lblMsgCoscia"}

        For Each lbl In lblList
            With tabControl.TabPages(1).Controls(lbl)
                .Visible = False
            End With
        Next
        lblBMI.Visible = False

        If My.Settings.arrayUtenti Is Nothing Then
            My.Settings.arrayUtenti = New System.Collections.Specialized.StringCollection
        End If

        If My.Settings.arrayUtenti.Contains(My.Settings.currentUser) Then
            tabControl.SelectedTab = tabPrimoInserimento
        Else
            loadBMI()
        End If

        lblSave.Location = New Point(lblSave.Location.X, lblSave.Location.Y + 20)

        Dim sexQuery As String = "SELECT * FROM Utenti WHERE Username = @Username AND Sesso IS NOT NULL"

        Using cmdRead = New OleDbCommand(sexQuery, conn)
            cmdRead.Parameters.Add("Username", OleDbType.VarChar).Value = My.Settings.currentUser
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim reader As OleDbDataReader = cmdRead.ExecuteReader
            cmdRead.Dispose()

            If reader.Read = True Then
                Dim selectSex As String = "select Sesso FROM Utenti WHERE Username = @Username"

                Using sexCmd = New OleDbCommand(selectSex, conn)
                    sexCmd.Parameters.Add("Username", OleDbType.VarChar).Value = My.Settings.currentUser

                    txtSesso.Text = sexCmd.ExecuteScalar
                    txtSesso.ReadOnly = True

                End Using

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
        My.Settings.currentUser = ""
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

            TextBox1.Select()
            loadBMI()

        ElseIf obj.Name = "lblDati" Or obj.Name = "imgDati" Or obj.Name = "panelDati" Then
            tabControl.SelectedTab = tabPrimoInserimento
            imgDati.Image = My.Resources.ResourceManager.GetObject("dati_clicked")
            imgCalcoli.Image = My.Resources.ResourceManager.GetObject("calcolatore")
            lblDati.ForeColor = Color.FromArgb(140, 180, 230)
            lblCalcoli.ForeColor = Color.White

            TextBox1.Select()
        End If
    End Sub

    Sub loadBMI()
        'Carica i dati
        Dim cmdSearchID As String = "SELECT ID FROM Utenti WHERE Username = @Username"
        Dim idFound As String

        Using cmdRead = New OleDbCommand(cmdSearchID, conn)
            cmdRead.Parameters.Add("Username", OleDbType.VarChar).Value = My.Settings.currentUser
            If conn.State = ConnectionState.Closed Then conn.Open()

            idFound = cmdRead.ExecuteScalar()

            cmdRead.Dispose()
        End Using

        Dim cmdPeso As String = "SELECT TOP 1 Peso FROM Informazioni WHERE ID_User = @ID_User ORDER BY id DESC"
        Dim cmdAltezza As String = "SELECT TOP 1 Altezza FROM Informazioni WHERE ID_User = @ID_User ORDER BY id DESC"
        Dim peso As Double
        Dim altezza As Integer

        'Prende Peso
        Using getData = New OleDbCommand(cmdPeso, conn)
            getData.Parameters.Add("ID_User", OleDbType.VarChar).Value = idFound

            peso = getData.ExecuteScalar
        End Using
        'Prende altezza
        Using getData = New OleDbCommand(cmdAltezza, conn)
            getData.Parameters.Add("ID_User", OleDbType.VarChar).Value = idFound

            altezza = getData.ExecuteScalar
        End Using

        Dim bmi As Double = (peso / Math.Pow((altezza / 100), 2))

        If bmi.ToString.Equals("NaN") Then
            txtBMI.Text = "Inserisci dei dati"
        Else
            txtBMI.Text = bmi.ToString("0.0")
            lblBMI.Visible = True
        End If



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
#End Region

#Region "Text Check"

    Private Sub limitToNumbers_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEta.KeyPress, txtAltezza.KeyPress, txtPetto.KeyPress,
            txtTricipite.KeyPress, txtTorace.KeyPress, txtAddome.KeyPress, txtVita.KeyPress, txtFianchi.KeyPress, txtCoscia.KeyPress

        If Not (Char.IsNumber(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeso.KeyPress

        If Not (Char.IsNumber(e.KeyChar) OrElse e.KeyChar = "," OrElse e.KeyChar = "." OrElse Char.IsControl(e.KeyChar)) Then
            e.Handled = True
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
                        With tabControl.TabPages(2).Controls(tb.Name.Trim.Replace("txt", "lblMsg"))
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
                    If Integer.TryParse(tb.Text, vbNull) Then
                        values.Add(tb.Text)
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

                Dim txtBoxList As New ArrayList
                For Each txtBox As TextBox In tabControl.TabPages(1).Controls.OfType(Of TextBox)()
                    txtBoxList.Add(txtBox.Name.Trim)
                Next

                For Each txtBox In txtBoxList
                    If txtBox <> "txtSesso" Then
                        With tabControl.TabPages(1).Controls(txtBox)
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
End Class