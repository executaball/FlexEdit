Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.DataTable
'Updater (Major Update 1)
Imports System.Threading
Imports System.Diagnostics
'Connectivity
Imports System.Text
Imports System.Net

Public Class MainForm
    'Vars
    Public i As Integer = 0
    Public mySplashScreen = DirectCast(My.Application.SplashScreen, Splash)

    'Version of FS this was built for
    Public fsversion As String = "September 2017"

    'Var checked in sub threads for app emergency abort
    Public FlexAbort As Boolean = False

    'Connectivity
    Public GrabAddress As String = "http://goo.gl/8d2xXV"
    Public AllRefDownload As String = ""

    'States that will be controlled by checkboxes
    Public saveword2enabled As Boolean = False
    Public saveword3enabled As Boolean = False

    'Load saveword form vars
    Public SavewordText1 As String
    Public SavewordText2 As String
    Public SavewordText3 As String

    'Save saveword TO (Export Form)

    Public EXPORTSavewordText1 As String
    Public EXPORTSavewordText2 As String
    Public EXPORTSavewordText3 As String

    'Saveword Export Backup

    Public EXPORT_BACKUP_1 As String
    Public EXPORT_BACKUP_2 As String
    Public EXPORT_BACKUP_3 As String
    Public EXPORT_BACKUP_INV As String
    Public EXPORT_BACKUP_STR As String


    'Status to be used with update function for main page
    Public Status1 As Boolean = False
    Public Status2 As Boolean = False
    Public Status3 As Boolean = False
    Public Status4 As Boolean = False
    Public Status5 As Boolean = False

    'Temp datapath variable (UNUSED)
    'Private _datapath As String = "storage.xml"

    'Check file exist, number of files that don't exist
    Public CheckFileExistErrorCounter As Int32 = 0
    Public FileOK As Boolean = True

    'Updater
    Private updaterModulePath As String

    'Saveword EVO helper (IMPORTANT) (Used in counters for processing all saveword exports/imports)
    Private saveword1stringlimit As Integer = 0
    Private saveword2stringlimit As Integer = 59
    Private saveword3stringlimit As Integer = 161
    Private saveword3endlimit As Integer = 226 'original 224, add 2 for compatibility with Sept 2017, equal 227

    'Explanation: string limits are the position at which they will start counting, basically saveword2stringlimit is when saveword 1 ends in the table. etc. saveword3endlimit is where saveword 3 ends. If FS adds any more, this number will inc up.


    'Datatable
    'Dim data As New DataSet1
    Dim table As New DataTable("Table")



    Private Sub form1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dim mysplashscreen = directcast(my.application.splashscreen, form2)
        'my.application.mysplashscreen.invoke(new methodinvoker(addressof my.application.mysplashscreen.incrementprogress))


        'bugfix 1 for metrotab
        Dim speed As Integer = MetroTabControl1.Speed : MetroTabControl1.Speed = 20
        For i As Integer = 0 To MetroTabControl1.TabPages.Count
            MetroTabControl1.SelectedIndex = i
        Next
        MetroTabControl1.SelectedIndex = 0 : MetroTabControl1.Speed = speed
        'bugfix over

        'show pre-release warning
        Panel_PreReleaseWarning.Visible = True
        '(Out of beta!)

        'highlight first option
        buttontab_1.selected = True

        'do datatable tasks
        Load_DoDatabaseTasks()

        'do dpi scaling
        Load_DoScaling()

        'compute the updater.exe path relative to the application main module path
        updaterModulePath = Path.Combine(Application.StartupPath, "wyupdate.exe")

        'TESTONLY
        My.Settings.FlexBoot = 0
        My.Settings.AutoupdatePref = True

        'Autoupdater consent
        If My.Settings.FlexBoot = 0 Then
            Select Case MsgBox("FlexEdit uses an Autoupdater that periodically accesses its Github page to check for new application updates. It will only ever notify you, never install anything on its own. Do you consent to this? This can later be disabled/enabled in settings", MsgBoxStyle.YesNo, "Use autoupdater?")
                Case MsgBoxResult.Yes
                    'Do nothing, carry on
                Case MsgBoxResult.No
                    My.Settings.AutoupdatePref = False
                    My.Settings.Save()
            End Select
        End If

        'Check if updater exists first, before actually attempting update.
        If System.IO.File.Exists(updaterModulePath) Then
            'Do nothing, the file exists
        Else
            'the file doesn't exist
            My.Settings.AutoupdatePref = False
            My.Settings.Save()
            MsgBox("Error checking for updates. Please make sure 'wyUpdate.exe' is in the same directory as FlexEdit. Autoupdates have now been disabled. You can re-enable in settings. ", vbExclamation, "Updater error")
        End If

        If My.Settings.AutoupdatePref = True Then
            'run updater tasks
            Dim thread As Thread = New Thread(New ThreadStart(AddressOf StartSilent))
            thread.Start()
        End If

        'center main form to screen
        Me.CenterToScreen()

        'welcome message
        If My.Settings.FlexBoot = 0 Then
            MsgBox("Welcome to FlexEdit. You can send bug reports / suggestions via the survey (click the info button). Or just poke @executaball on the Flexible Survival official Discord!", vbInformation, "Welcome to FlexEdit")
            MsgBox("Disclaimer: FlexEdit may from time to time check an online text file in the FlexEdit Github. This may cause pop-ups from your Firewall. Please click 'allow' if any such windows show up. FlexEdit does not upload any user information nor download any files. It *literally* just reads a text file to ensure compatibility with future savewords.", vbExclamation, "Notice")
        End If

        'Updates versioning bar in relation to web update
        Load_UpdateComptBar()



        'increment flex boot counter
        My.Settings.FlexBoot += 1
        My.Settings.Save()
    End Sub

    'Updater Silent operations
    Public Sub StartSilent()
        Thread.Sleep(10000)
        Try
            Dim proc As Process = Process.Start(updaterModulePath, "/quickcheck")
            proc.Close()
        Catch z As Exception
            MsgBox("Error checking for updates. Please make sure 'wyUpdate.exe' is in the same directory as FlexEdit. " & z.Message, vbCritical, "Error")
        End Try
    End Sub


    'This handler should be associated with a menu item that launches the updater in check now mode (usually from  Help submenu)
    Public Sub CheckForUpdates() '(sender As System.Object, e As System.EventArgs) 'Handles CheckForUpdatesMenuItem.Click
        Try
            Dim proc As Process = Process.Start(updaterModulePath)
            proc.Close()
        Catch z As Exception
            MsgBox("Error launching updater. Please check if 'wyUpdate.exe' is in the same directory as FlexEdit. " & z.Message, vbCritical, "Error")
        End Try
    End Sub

    Public Sub Load_UpdateComptBar() 'updates the bottom bar
        'Connectivity Update
        Dim client As WebClient = New WebClient()
        WebBrowser1.Visible = False
        WebBrowser1.Navigate(New Uri(GrabAddress))
        WebBrowser1.Visible = False
        Try
            Dim reader As StreamReader = New StreamReader(client.OpenRead(GrabAddress))
            'AllRefDownload = reader.ReadToEnd
            Dim allLines As List(Of String) = New List(Of String)
            Do While Not reader.EndOfStream
                allLines.Add(reader.ReadLine())
            Loop
            reader.Close()
            Dim EndVar As String = ReadLine(2, allLines)


            MsgBox(EndVar)

            'SavewordText1 = EndVar
        Catch z As Exception
            MsgBox("Error updating the FlexEdit saveword resolution database. Error: " & z.Message, vbCritical, "Error")
        End Try
        'MsgBox(AllRefDownload)

        My.Settings.AllRefLatest = AllRefDownload
        My.Settings.Save()

        'Dim reader As New System.IO.StreamReader(PersistentUserDirectory + "\txsave.glkdata")
        'Dim allLines As List(Of String) = New List(Of String)
        'Do While Not reader.EndOfStream
        '    allLines.Add(reader.ReadLine())
        'Loop
        'reader.Close()
        'Dim EndVar As String = ReadLine(2, allLines)


        ''MsgBox(EndVar)

        'SavewordText1 = EndVar



    End Sub

    'Does scaling of UI elements (critical) (called by Form1_Load)
    Private Sub Load_DoScaling()

        'Moves sidepanel to correct position (because moved out of way for development)

        Sidepanel.Width = 0.26 * Me.Width

        Dim ButtonWidth As Integer

        ButtonWidth = Sidepanel.Width

        buttontab_1.Width = ButtonWidth
        buttontab_2.Width = ButtonWidth
        buttontab_3.Width = ButtonWidth
        buttontab_4.Width = ButtonWidth
        buttontab_5.Width = ButtonWidth
        buttontab_6.Width = ButtonWidth
        buttontab_7.Width = ButtonWidth


        'MetroTabControl1.Width = 0.75 * Me.Width + 125
        'Panel1.Width = 0.75 * Me.Width + 113
        '160686
        'Dim SideBarVar As Integer = 184860 / Me.Width
        Dim SideBarVar As Integer = 130
        Panel1.Width = Me.Width - ButtonWidth + SideBarVar

        'MsgBox("Panel width")
        'MsgBox(Panel1.Width)

        'MsgBox("Side width")
        'MsgBox(Sidepanel.Width)

        '(Debug msgbox for scaling work)


        'WORK SCALING BUTTONS
        Dim TotalWidth As Int32 = Panel2.Width
        Dim ButtonSize As Int32 = TotalWidth * 0.2

        'BunifuTileButton1.Size = ButtonSize, ButtonSize

        MetroTabControl1.Margin = New Padding(0)
        Panel1.Margin = New Padding(0)

    End Sub

    'Does database related tasks (called by Form1_Load)
    Private Sub Load_DoDatabaseTasks()

        'Initial setup - fills the tables with names (will clear later)
        table.Columns.Add("Id", Type.GetType("System.Int32"))
        table.Columns.Add("Value", Type.GetType("System.String"))
        table.Columns.Add("Name", Type.GetType("System.String"))

        'assinging the datagridview to use 'table' as data source
        DataGridViewVars.DataSource = table

        'calling function to resize, will use function in all edits
        resizeDataTable()
        Me.DataGridViewVars.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        DataGridViewVars.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 102, 204)

        textbox_value_editor.DataBindings.Add("Text", table, "Value")

    End Sub

    'Table resize function (can be called in all edits)
    Private Sub resizeDataTable()

        DataGridViewVars.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        'DataGridViewVars.AutoSizeColumnsMode =
        'DataGridViewAutoSizeColumnsMode.AllCells

        With DataGridViewVars
            '.Columns(0).Width = 100
            '.Columns(1).Width = 200
            .Columns(2).Width = .Width - .Columns(0).Width - .Columns(1).Width
        End With

    End Sub

    'Simple delay function
    Private Sub funcdelay100()
        Threading.Thread.Sleep(100)
    End Sub

    'top right exit button
    Private Sub topbarbutton_exit_Click(sender As Object, e As EventArgs) Handles topbarbutton_exit.Click
        FlexAbort = True
        Application.Exit()
    End Sub

    'top right minimize button
    Private Sub topbarbutton_min_Click(sender As Object, e As EventArgs) Handles topbarbutton_min.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'TAB BUTTONS

    'Tab1
    Private Sub buttontab_1_Click(sender As Object, e As EventArgs) Handles buttontab_1.Click

        MetroTabControl1.SelectedTab = Tab1Save

    End Sub
    'Tab2
    Private Sub buttontab_2_Click(sender As Object, e As EventArgs) Handles buttontab_2.Click
        If Status1 = False Then
            MsgBox("Please load a saveword first", vbInformation, "FlexEdit")
            'Highlight first option
            buttontab_1.selected = True
            Return
        End If

        MetroTabControl1.SelectedTab = Tab2Gen

    End Sub
    'Tab3
    Private Sub buttontab_3_Click(sender As Object, e As EventArgs) Handles buttontab_3.Click
        If Status1 = False Then
            MsgBox("Please load a saveword first", vbInformation, "FlexEdit")
            'Highlight first option
            buttontab_1.selected = True
            Return
        End If

        MetroTabControl1.SelectedTab = Tab3Body

    End Sub
    'Tab4
    Private Sub buttontab_4_Click(sender As Object, e As EventArgs) Handles buttontab_4.Click
        If Status1 = False Then
            MsgBox("Please load a saveword first", vbInformation, "FlexEdit")
            'Highlight first option
            buttontab_1.selected = True
            Return
        End If

        MetroTabControl1.SelectedTab = Tab4Infect

    End Sub
    'Tab5 (Not enabled yet)
    Private Sub buttontab_5_Click(sender As Object, e As EventArgs) Handles buttontab_5.Click

        'MetroTabControl1.SelectedTab = Tab5Inv
        MsgBox("Sorry, inventory edits aren't supported yet in this version of FlexEdit.", vbInformation, "FlexEdit")

    End Sub
    'Tab6 (Not enabled yet)
    Private Sub buttontab_6_Click(sender As Object, e As EventArgs) Handles buttontab_6.Click

        'MetroTabControl1.SelectedTab = Tab6Store
        MsgBox("Sorry, storage edits aren't supported yet in this version of FlexEdit.", vbInformation, "FlexEdit")

    End Sub
    'Tab7 (special logic for showing notice prompt)
    Private Sub buttontab_7_Click(sender As Object, e As EventArgs) Handles buttontab_7.Click
        'End sub if no saveword loaded, this results in no execution of the accepted terms logic
        If Status1 = False Then
            MsgBox("Please load a saveword first", vbInformation, "FlexEdit")
            'Highlight first option
            buttontab_1.selected = True
            Return
        End If

        If My.Settings.RawEditsEnable = False Then

            MsgBox("Careful! Incorrectly modifying FS saveword variables can easily break quest chains. I recommend you read up the Github code on what you are editing and know full well what you are doing.  (This warning can be disabled in the settings menu)", vbExclamation, "Warning")
            RunUpdateTextBoxPriority()
            MetroTabControl1.SelectedTab = Tab7Raw

        ElseIf My.Settings.RawEditsEnable = True Then
            RunUpdateTextBoxPriority()
            MetroTabControl1.SelectedTab = Tab7Raw

        End If

    End Sub



    'FUNCTIONS to DISPLAY status of saveword

    Public Sub Status1toLOADED()

        label_status1.Text = "Loaded"

        picbox_status1.Image = My.Resources.Resources.Checkmark

    End Sub

    Public Sub Status1toUNLOAD()

        label_status1.Text = "Not loaded"

        picbox_status1.Image = My.Resources.Resources.Red_Cross

    End Sub

    Public Sub Status2toLOADED()

        label_status2.Text = "Loaded"

        picbox_status2.Image = My.Resources.Resources.Checkmark

    End Sub

    Public Sub Status2toUNLOAD()

        label_status2.Text = "Not loaded"

        picbox_status2.Image = My.Resources.Resources.Red_Cross

    End Sub

    Public Sub Status3toLOADED()

        label_status3.Text = "Loaded"

        picbox_status3.Image = My.Resources.Resources.Checkmark

    End Sub

    Public Sub Status3toUNLOAD()

        label_status3.Text = "Not loaded"

        picbox_status3.Image = My.Resources.Resources.Red_Cross

    End Sub

    Public Sub Status4toLOADED()

        label_status4.Text = "Loaded"

        picbox_status4.Image = My.Resources.Resources.Checkmark

    End Sub

    Public Sub Status4toUNLOAD()

        'label_status4.Text = "Not loaded"

        'picbox_status4.Image = My.Resources.Resources.redfull_error

        '!! TEMP DISABLED

    End Sub

    Public Sub Status5toLOADED()

        label_status5.Text = "Loaded"

        picbox_status5.Image = My.Resources.Resources.Checkmark

    End Sub

    Public Sub Status5toUNLOAD()

        'label_status5.Text = "Not loaded"

        'picbox_status5.Image = My.Resources.Resources.redfull_error

        '!! TEMP DISABLED

    End Sub

    'Function to set all to unload
    Public Sub StatusCLEAR()

        Status1toUNLOAD()
        Status2toUNLOAD()
        Status3toUNLOAD()
        Status4toUNLOAD()
        Status5toUNLOAD()

    End Sub

    'Function - Checks all vars and updates the labels accordingly
    Public Sub StatusUPDATE()

        If Status1 = True Then
            Status1toLOADED()
        Else
            Status1toUNLOAD()
        End If

        If Status2 = True Then
            Status2toLOADED()
        Else
            Status2toUNLOAD()
        End If

        If Status3 = True Then
            Status3toLOADED()
        Else
            Status3toUNLOAD()
        End If

        If Status4 = True Then
            Status4toLOADED()
        Else
            Status4toUNLOAD()
        End If

        If Status5 = True Then
            Status5toLOADED()
        Else
            Status5toUNLOAD()
        End If

    End Sub

    'FUNCTIONS over

    'Load saveword button

    'Opens input window and waits for function call
    Private Sub TileLoadFromCode_Click(sender As Object, e As EventArgs) Handles TileLoadFromCode.Click

        Input_Saveword_Form.ShowDialog()

    End Sub

    'Load saveword control sub
    Public Sub RunLoadSaveword()

        'funcdelay100()


        'before doing anything, we assume user is doing this second time.
        'perform cleanup for datatable here
        'Care errors, added error handling as of rev 3
        Try
            table.Clear()
        Catch f As DataException
            ' Process exception below
            MsgBox("Exception of type {0} occurred.",
           f.GetType().ToString())
        End Try



        'after cleanup, repopulate

        '   currently relying on windows logic handling, might add safeguard later

        'ready for normal tasks now


        Dim SaveLoadCompleted1 As Boolean = False
        Dim SaveLoadCompleted2 As Boolean = False
        Dim SaveLoadCompleted3 As Boolean = False

        Try
            Dim rinput As String = SavewordText1
            Dim xValues() As String = rinput.Split("}")
            For count = 0 To xValues.Length - 1
                table.Rows.Add(count + 1, xValues(count))
            Next
            Dim intStr As Integer = xValues(0)
            Dim intDex As Integer = xValues(1)
            Dim intSta As Integer = xValues(2)
            Dim intCha As Integer = xValues(3)
            Dim intPer As Integer = xValues(4)
            Dim intInt As Integer = xValues(5)
            Dim intLvl As Integer = xValues(6)
            Dim intHP As Integer = xValues(7)
            Dim intHum As Integer = xValues(8)
            Dim intScr As Integer = xValues(9)
            'Dim inthpmatt As Integer = xValues(10) 'D
            Dim strBody As String = xValues(11)
            Dim strHead As String = xValues(12)
            Dim strSkin As String = xValues(13)
            Dim strTail As String = xValues(14)
            Dim strGeni As String = xValues(15)
            'vars
            '(not needed) Dim intTanuki As Integer = xValues(16)
            '(not needed) Dim intHosQue As Integer = xValues(17)
            'body
            Dim intbodymod_cocks As Integer = xValues(18)
            Dim intbodymod_breasts As Integer = xValues(19)
            Dim intbodymod_cunts As Integer = xValues(20)
            Dim intbodymod_breast_size As Integer = xValues(21)
            Dim intbodymod_cock_length As Integer = xValues(22)
            Dim intbodymod_cock_width As Integer = xValues(23)
            Dim intbodymod_cunt_length As Integer = xValues(24)
            Dim intbodymod_cunt_width As Integer = xValues(25)
            'wep
            Dim strEqpWeapon As String = xValues(26)
            'vars down below
            '(not needed) Dim intbodymod_cunt_length As Integer = xValues(27)
            '(TEMPLATE) Dim intbodymod_cunt_length As Integer = xValues(28)



            'all vars are filled

            'filling textboxes next for body tab

            nudStr.Text = intStr
            nudDex.Text = intDex
            nudSta.Text = intSta
            nudCha.Text = intCha
            nudPer.Text = intPer
            nudInt.Text = intInt
            nudLvl.Text = intLvl
            nudHP.Text = intHP
            nudHum.Text = intHum
            nudScr.Text = intScr

            'filling infection tab

            comboBODY.Text = strBody
            comboHEAD.Text = strHead
            comboSKIN.Text = strSkin
            comboTAIL.Text = strTail
            comboGENI.Text = strGeni



            'filling ok, variable go

            'body go
            nud_body_cocks.Text = intbodymod_cocks
            nud_body_breasts.Text = intbodymod_breasts
            nud_body_cunts.Text = intbodymod_cunts
            nud_body_breast_size.Text = intbodymod_breast_size
            nud_body_cock_length.Text = intbodymod_cock_length
            nud_body_cock_width.Text = intbodymod_cock_width
            nud_body_cunt_length.Text = intbodymod_cunt_length
            nud_body_cunt_width.Text = intbodymod_cunt_width

            SaveLoadCompleted1 = True


            'error handling
        Catch z As Exception
            MsgBox("Error parsing Saveword Part 1. Perhaps you have entered it incorrectly? Exception details: " & z.Message, vbCritical, "Critical Error")

            SaveLoadCompleted2 = False

            MsgBox("Saveword Part 1 has failed to load. Savewords Part 2 and Part 3 will not be attempted.", vbExclamation, "Caution")


            'disabling tabs and buttons


            Return

        End Try

        'ONLY RUNS FOR SAVEWORD 2
        If saveword2enabled = True Then

            Try
                Dim rinput As String = SavewordText2
                Dim yValues() As String = rinput.Split("}")
                For count = 0 To yValues.Length - 1
                    If count > 0 Then
                        table.Rows.Add(count + saveword2stringlimit, yValues(count)) 'saveword2stringlimit is a fixed var, currently 59, might change in future
                    End If

                Next 'ends sub here


                SaveLoadCompleted2 = True


                'error handling
            Catch z As Exception
                MsgBox("Error parsing Saveword Part 2. Perhaps you have entered it incorrectly? Exception details: " & z.Message, vbCritical, "Critical Error")

                SaveLoadCompleted2 = False

                MsgBox("Saveword Part 2 has failed to load. Saveword Part 3 will not be attempted.", vbExclamation, "Caution")

                'disabling tabs and buttons

                Return 'ends sub here
            End Try

        End If

        'Saveword 3 Specific

        If saveword3enabled = True Then

            Try
                Dim rinput As String = SavewordText3
                Dim zValues() As String = rinput.Split("}")
                For count = 0 To zValues.Length - 1
                    If count > 0 Then
                        table.Rows.Add(count + saveword3stringlimit, zValues(count)) 'saveword3stringlimit is a fixed var, currently 161, might change in future
                    End If

                Next


                SaveLoadCompleted3 = True


                'error handling
            Catch z As Exception

                MsgBox("Error parsing Saveword Part 3. Perhaps you have entered it incorrectly? Exception details: " & z.Message, vbCritical, "Critical Error")

                SaveLoadCompleted3 = False

                MsgBox("Saveword Part 3 has failed to load.")

                'disabling tabs and buttons

                Return 'ends sub here

            End Try

        End If

        'ENDING SAVEWORD 3

        'determine finishing tasks whether saveword loaded or not
        If SaveLoadCompleted1 = True Then

            Status1 = True

            NGXAnnote()


        End If

        'tasks for saveword 2

        If SaveLoadCompleted2 = True AndAlso saveword2enabled = True Then

            Status2 = True

            NGXAnnote2()

        End If

        'tasks for saveword 3

        If SaveLoadCompleted3 = True AndAlso saveword3enabled = True Then

            Status3 = True

            NGXAnnote3()

        ElseIf SaveLoadCompleted3 = False And saveword3enabled = True Then

            MsgBox("Saveword 3 has not been loaded. Savewords 1 and 2 are loaded normally. You can use the program as is or try loading the savewords again.", vbExclamation, "Caution")

        End If

        If SaveLoadCompleted1 = True Or SaveLoadCompleted2 = True Or SaveLoadCompleted3 = True Then

            resizeDataTable()

        End If

        If Status3 = True Then
            MsgBox("All Saveword parts import complete!", vbInformation, "Import success")
        ElseIf Status2 = True And saveword3enabled = False Then
            MsgBox("Savewords Part 1 and 2 has been imported!", vbInformation, "Import success")
        ElseIf Status1 = True And saveword3enabled = False Then
            MsgBox("Savewords Part 1 has been imported!", vbInformation, "Import success")
        End If

        '(IMPORTANT!!) Updates the labels
        StatusUPDATE()



    End Sub

    'Simple Increment Function
    Private Sub Inc(ByRef i As Integer)
        Try
            i += 1
        Catch z As Exception
            MsgBox("FATAL ERROR Has occured when using the increment function. This should 100% should never ever have happened. Exception details: " & z.Message, vbCritical, "FATAL ERROR")
        End Try
    End Sub

    'Runs update to put textboxes into database (Trigger by button or by export routine)
    Private Sub RunUpdateTextBoxPriority()


        DataGridViewVars.Rows(0).Cells(1).Value = nudStr.Text
        DataGridViewVars.Rows(1).Cells(1).Value = nudDex.Text
        DataGridViewVars.Rows(2).Cells(1).Value = nudSta.Text
        DataGridViewVars.Rows(3).Cells(1).Value = nudCha.Text
        DataGridViewVars.Rows(4).Cells(1).Value = nudPer.Text
        DataGridViewVars.Rows(5).Cells(1).Value = nudInt.Text
        DataGridViewVars.Rows(6).Cells(1).Value = nudLvl.Text
        DataGridViewVars.Rows(7).Cells(1).Value = nudHP.Text
        DataGridViewVars.Rows(8).Cells(1).Value = nudHum.Text
        DataGridViewVars.Rows(9).Cells(1).Value = nudScr.Text

        'filling infection tab

        'Skipped 10 because hp matt not needed

        DataGridViewVars.Rows(11).Cells(1).Value = comboBODY.Text
        DataGridViewVars.Rows(12).Cells(1).Value = comboHEAD.Text
        DataGridViewVars.Rows(13).Cells(1).Value = comboSKIN.Text
        DataGridViewVars.Rows(14).Cells(1).Value = comboTAIL.Text
        DataGridViewVars.Rows(15).Cells(1).Value = comboGENI.Text



        'filling ok, variable go

        'body go

        'Skipped 16,17 because vars (table handling)
        DataGridViewVars.Rows(18).Cells(1).Value = nud_body_cocks.Text
        DataGridViewVars.Rows(19).Cells(1).Value = nud_body_breasts.Text
        DataGridViewVars.Rows(20).Cells(1).Value = nud_body_cunts.Text
        DataGridViewVars.Rows(21).Cells(1).Value = nud_body_breast_size.Text
        DataGridViewVars.Rows(22).Cells(1).Value = nud_body_cock_length.Text
        DataGridViewVars.Rows(23).Cells(1).Value = nud_body_cock_width.Text
        DataGridViewVars.Rows(24).Cells(1).Value = nud_body_cunt_length.Text
        DataGridViewVars.Rows(25).Cells(1).Value = nud_body_cunt_width.Text

    End Sub

    'New Annotation functions

    Private Sub NGXAnnote()

        Dim rawAnnotation As String
        'rawAnnotation = My.Settings.Annotation1
        'rawAnnotation = "Strength,Dexerity,Stamina,Charisma,Perception,Intelligent,Level,HP,Humanity,Score,hp of doctor matt,Body infection,Head infection,Skin infection,Tail infection,Genital Infection,SatisfiedTanuki,hospquest,Cocks (Number of cocks),Breasts (Number of breast),Cunts (Number of cunts),Breast Size,Cock Length,Cock Width (Also affects cum and ball size),Cunt Length,Cunt Width,Equipped Weapon,franksex,frankmalesex,Snow special (annote),REMOVED (value always 0),Coleen special (annote),coleentalk,coleenfound,coleencollared,coleenalpha,coleenslut,coleenspray,hp of doctor mouse,coonstatus,featunlock,butterflymagic? wth is this,catnum,mateable,gryphoncomforted,shiftable,medeaget,mtp,hyg,nes,mtrp,boristalk,borisquest,progress of alex,angiehappy,angietalk,deerconsent,hp  of Susan,mattcollection"
        'above is backup from v2.0.14
        'rawAnnotation = "Strength,Dexerity,Stamina,Charisma,Perception,Intelligent,Level,HP,Humanity,Score,hp of doctor matt,Body infection,Head infection,Skin infection,Tail infection,Genital Infection,SatisfiedTanuki,Hospquest,Cocks (Number of cocks),Breasts (Number of breast),Cunts (Number of cunts),Breast Size,Cock Length,Cock Width,Cunt Length,Cunt Width,Equipped Weapon,Frank M/F,Frank M/M,Hyper Squirrel Resolved,REMOVED (value always 0),Coleen Location,Coleen Talk,Coleen Found,Coleen Collared,Coleen Alpha,Coleen Slut,Coleen Spray,HP of Dr Mouse,Candy(coonstatus),featunlock,Butterfly,Catnum,Mateable,gryphoncomforted,shiftable,Medea,MTP,HYG,NES,MTRP,Boristalk,Borisquest,progress of alex,Angiehappy,Angietalk,deerconsent,HP of Susan,mattcollection"
        rawAnnotation = "[strength of player]}[dexterity of player]}[stamina of player]}[charisma of player]}[perception of player]}[intelligence of player]}[level of player]}[maxhp of player]}[humanity of player]}[score - 50]}[hp of doctor matt]}[bodyname of player]}[facename of player]}[skinname of player]}[tailname of player]}[cockname of player]}[SatisfiedTanuki]}[hospquest]}[cocks of player]}[breasts of player]}[cunts of player]}[breast size of player]}[cock length of player]}[cock width of player]}[cunt length of player]}[cunt width of player]}[weapon object of player]}[franksex]}[frankmalesex]}[if Hyper Squirrel Girl is resolved]1[else]0[end if]}0}[location of coleen]}[coleentalk]}[coleenfound]}[coleencollared]}[coleenalpha]}[coleenslut]}[coleenspray]}[hp of doctor mouse]}[coonstatus]}[featunlock]}[butterflymagic]}[catnum]}[mateable]}[gryphoncomforted]}[shiftable]}[medeaget]}[mtp]}[hyg]}[NESProgress]}[mtrp]}[boristalk]}[borisquest]}[progress of alex]}[angiehappy]}[angietalk]}[deerconsent]}[hp of Susan]}[mattcollection]"

        Dim fAnnote() As String = rawAnnotation.Split("}")
        For count = 0 To fAnnote.Length - 1
            DataGridViewVars.Rows(count).Cells(2).Value = fAnnote(count)
        Next

    End Sub

    Private Sub NGXAnnote2()

        Dim rawAnnotation As String
        'rawAnnotation = "Orthas HP,Stables Fancy Quest,Sven HP,Sven Lust,Sarah Slut,Sarah Talk,Sarah Pups,Null (Does nothing),Brunc w/ Alex,Treasure Found,Treasure Hunt (tmapfound),Sandra HP,Frank Libido,Fang HP,Fang Libido,Philip (pigfed),Philip (pigfucked),Pet Cute Crab Resolved,Pet Exotic Bird Resolved,Pet Felinoid Companion Resolved,Pet bee girl Resolved,Pet house cat Resolved,Pet little fox Resolved,Pet skunk kit Resolved,Pet helper dog Resolved,Pet Rachel Mouse Resolved,Elijah HP,Elijah Interactions (npcEint),Latex Husky Mode,Parasitic Larva,Leonard HP,Solstice HP,Ronda the Slut Rat,Athanasia HP,Skunkbeast Lord Status,Kitsune (ktp),Release Number,Kara (Tattohunter),Kara (tatsave),Kara (piercesave),Diego (diegochanged),Eric HP,Christy HP,Christy Dragontype,Christy dragonessfuck,Doctor Medea HP,Doctor Moffatt HP,Lucy HP,David Thirst,David Lust,David HP,Adam HP,Alexandra HP,Larissa HP,Sam HP,Wereraptor curse status,Wereraptor cure nermine,Doctor Utah HP,Mike HP,Xerxes HP,Helen HP,Helen Libido,Rex HP,Karen HP,Francois HP,Fancois Libido,Alexandra Level,Thomas HP,Thomas Libido,Thomas Lust,ThomasQuestVar,Rubber Tigress HP,Septus HP,Xerxes Lust,Helen Lust,Tristian HP,Icarus HP,Joanna HP,Joanna Lust,Angie Aroused,DBCaptureQuestVar (Demon Brute),DemonBruteStatus (Gender),Lilith HP,LilithKidCounter,Felix HP,Felix Libido,Sonya VikingRelationship,Sonya VikingKidCounter,MovingOrwell,Jimmy HP,David libido,Amy HP,Amy Libido,SquadEncounters,Corbin Thirst,Corbin HP,CorbinKidCounter,Anthony HP,Duke HP,Duke Thirst,Zigor HP,Amy Thirst"
        rawAnnotation = "[hp of Orthas]}[fancyquest]}[hp of sven]}[lust of sven]}[sarahslut]}[sarahtalk]}[sarahpups]}0}[alexbrunch]}[treasurefound]}[tmapfound]}[hp of Sandra]}[libido of Frank]}[hp of Fang]}[libido of Fang]}[pigfed]}[pigfucked]}[if cute crab is tamed]1[else]0[end if]}[if exotic bird is tamed]1[else]0[end if]}[if Felinoid companion is tamed]1[else]0[end if]}[hp of bee girl]}[if house cat is tamed]1[else]0[end if]}[if little fox is tamed]1[else]0[end if]}[if skunk kit is tamed]1[else]0[end if]}[if helper dog is tamed]1[else]0[end if]}[mousecurse]}[hp of Elijah]}[npcEint]}[if latexhuskymode is true]1[else]0[end if]}[if insectlarva is true]1[else]0[end if]}[hp of Leonard]}[hp of Solstice]}[hp of Ronda]}[hp of Athanasia]}[skunkbeaststatus]}[ktp]}[release number]}[tattoohunter]}[tatsave]}[piercesave]}[diegochanged]}[hp of Eric]}[hp of Christy]}[dragontype]}[dragonessfuck]}[hp of Doctor Medea]}[hp of Doctor Moffatt]}[hp of Lucy]}[thirst of david]}[lust of david]}[hp of david]}[hp of Adam]}[hp of Alexandra]}[hp of Larissa]}[hp of Sam]}[wrcursestatus]}[wrcurseNermine]}[hp of Doctor Utah]}[hp of Mike]}[hp of Xerxes]}[hp of Helen]}[libido of Helen]}[hp of Rex]}[hp of Karen]}[hp of François]}[libido of François]}[level of Alexandra]}[hp of Thomas]}[libido of Thomas]}[lust of Thomas]}[ThomasQuestVar]}[hp of rubber tigress]}[hp of Septus]}[lust of Xerxes]}[lust of Helen]}[hp of tristian]}[hp of Icarus]}[hp of Joanna]}[lust of Joanna]}[angiearoused]}[DBCaptureQuestVar]}[DemonBruteStatus]}[hp of Lilith]}[LilithKidCounter]}[hp of Felix]}[Libido of Felix]}[VikingRelationship]}[VikingKidCounter]}[MovingOrwell]}[hp of Jimmy]}[libido of David]}[hp of Amy]}[libido of Amy]}[SquadEncounters]}[thirst of Corbin]}[hp of Corbin]}[CorbinKidCounter]}[hp of Anthony]}[hp of Duke]}[thirst of Duke]}[hp of Zigor]}[thirst of Amy]"

        Dim fAnnote() As String = rawAnnotation.Split("}")
        For count = 0 To fAnnote.Length - 1
            DataGridViewVars.Rows(count + saveword2stringlimit).Cells(2).Value = fAnnote(count) 'stringlimit 59
        Next

    End Sub

    Private Sub NGXAnnote3()

        Dim rawAnnotation As String
        'rawAnnotation = "Nadia HP,NadiaFertilityCounter,NadiaChickCounter,Nadia (npcNadiaint),Amy Level,Amy XP,Amy Dexterity,SvenAmySex,BrutusAmySex,Zephias Lust,Ares HP,Hayato HP,Tehuantl HP,Carl HP,Carl Level,Kristen HP,Kristen Libido,Brooke HP,Bubble HP,Newt HP,Null (Does nothing),Piginitiation,Gillian HP,Stella HP,Null (Does nothing),OrcSlaverStatus,CellDoorStatus,Onyx XP,Val HP,Val Thirst,ValPregCounter,ValPregnancy,SlaveRaidEncounters,Chris HP,Vanessa HP,Vanessa XP,Meredith HP,Meredith level,Gwen HP,Rane HP,Elijah Thirst,SpidertaurRelationship,CatgirlFucked,FionaFangStatus,FionaCarlStatus,Gabriel HP,Erica HP,Erica Thirst,Police Station Population,Police Station infpop,Null (Does nothing),Null (Does nothing),Hadiya Hp,Gobby HP,Sidney HP,Sidney level,Sidney XP,Micaela HP,Micaela Level,Micaela XP,Macadamia HP,Yolanda HP,SarahCured"
        rawAnnotation = "[hp of Nadia]}[NadiaFertilityCounter]}[NadiaChickCounter]}[npcNadiaint]}[level of Amy]}[Xp of Amy]}[Dexterity of Amy]}[SvenAmySex]}[BrutusAmySex]}[lust of Zephias]}[hp of Ares]}[if hp of hayato is 30]20[else][hp of Hayato][end if]}[hp of Tehuantl]}[hp of Carl]}[level of Carl]}[hp of Kristen]}[libido of Kristen]}[hp of Brooke]}[hp of Bubble]}[hp of Newt]}0}[piginitiation]}[hp of Gillian]}[hp of Stella]}[StellaNPCInt]}[OrcSlaverStatus]}[CellDoorStatus]}[xp of Onyx]}[hp of Val]}[thirst of Val]}[ValPregCounter]}[ValPregnancy]}[SlaveRaidEncounters]}[hp of Chris]}[hp of Vanessa]}[xp of Vanessa]}[hp of Meredith]}[level of Meredith]}[hp of Gwen]}[hp of Rane]}[thirst of Elijah]}[SpidertaurRelationship]}[CatgirlFucked]}[FionaFangStatus]}[FionaCarlStatus]}[hp of Gabriel]}[hp of Erica]}[Thirst of Erica]}[population of Police Station]}[infpop of Police Station]}0}0}[hp of Hadiya]}[hp of Gobby]}[hp of Sidney]}[level of Sidney]}[xp of Sidney]}[hp of Micaela]}[level of Micaela]}[xp of Micaela]}[hp of Macadamia]}[hp of Yolanda]}[SarahCured]}[libido of chris]}[dexterity of chris]"

        Dim fAnnote() As String = rawAnnotation.Split("}")
        For count = 0 To fAnnote.Length - 1
            DataGridViewVars.Rows(count + saveword3stringlimit).Cells(2).Value = fAnnote(count) 'String limit 161
        Next

    End Sub


    Private Sub ButtonLoadToCode_Click(sender As Object, e As EventArgs) Handles TileLoadToCode.Click

        RunExportSaveword()


        If SavewordExportOK = True Then
            Output_Saveword_Form.ShowDialog()
        End If

    End Sub

    Private SavewordExportOK As Boolean

    Private Sub RunExportSaveword()

        SavewordExportOK = False

        'Terminate if detected database is empty (2.0 safeguard) (improved from v1.0.6)

        If Status1 = False Then

            MsgBox("No saveword detected in memory. Please load a saveword first.", vbExclamation, "Error")

            Return

        Else


            'Firstly join textboxes into database

            RunUpdateTextBoxPriority() 'call function to do so

            'variables
            Dim sval As String = "You should not be seeing this, something has gone horribly wrong. Error Code (1)"
            Dim ngxcounter As Integer = 1

            Dim sval2 As String = "You should not be seeing this, something has gone horribly wrong. Error Code (2)"
            Dim ngxcounter2 As Integer = saveword2stringlimit + 1 'literally first term, starting with 1 

            Dim sval3 As String = "You should not be seeing this, something has gone horribly wrong. Error Code (3)"
            Dim ngxcounter3 As Integer = saveword3stringlimit + 1

            Dim ngxcounter_end_3 As Integer = saveword3endlimit + 1

            'do some cleanup, then set failsafe conditions
            EXPORTSavewordText1 = ""
            EXPORTSavewordText2 = ""
            EXPORTSavewordText3 = ""


            'before real processing, assimilate textfields to database (IMPORTANT)



            'Start real processing


            Try

                Do Until ngxcounter = ngxcounter2 'ngxcounter 2 should be 60

                    Dim row As DataRow = table.Select("Id = " & ngxcounter).FirstOrDefault()
                    If Not row Is Nothing Then
                        sval = row.Item("Value")
                    End If

                    Inc(ngxcounter)

                    If ngxcounter < ngxcounter2 Then

                        EXPORTSavewordText1 = EXPORTSavewordText1 + sval & "}"

                    ElseIf ngxcounter = ngxcounter2 Then
                        EXPORTSavewordText1 = EXPORTSavewordText1 + sval

                    ElseIf ngxcounter > ngxcounter2 Then
                        MsgBox("FATAL ERROR: Counter overflow occured when processing saveword 2, program terminating to avoid further issues. This should never happen, please copy the following numbers and submit a bug report- c1:" & ngxcounter & " c2:" & ngxcounter2, vbCritical, "FATAL ERROR")
                        End

                    End If


                Loop

            Catch z As Exception

                MsgBox("Error recreating saveword 1. Exception details: " & z.Message, vbCritical, "Critical Error")

            End Try

            'Only runs when loading 2 or 3 savewords. Exports saveword 2
            If saveword2enabled = True Then

                EXPORTSavewordText2 = "chantpartA}" 'first time, out of the loop

                Try

                    Do Until ngxcounter2 = ngxcounter3 'final value is 161 on table, but because counting from 0, add one

                        Dim row As DataRow = table.Select("Id = " & ngxcounter2).FirstOrDefault()
                        If Not row Is Nothing Then
                            sval2 = row.Item("Value")
                        End If

                        Inc(ngxcounter2)


                        If ngxcounter2 < ngxcounter3 Then

                            EXPORTSavewordText2 = EXPORTSavewordText2 + sval2 & "}"

                        ElseIf ngxcounter2 = ngxcounter3 Then
                            EXPORTSavewordText2 = EXPORTSavewordText2 + sval2

                        ElseIf ngxcounter2 > ngxcounter3 Then
                            MsgBox("FATAL ERROR: Counter overflow occured when processing saveword 2, program terminating to avoid further issues. This should never happen, please copy the following numbers and submit a bug report- c2:" & ngxcounter2 & " c3:" & ngxcounter3, vbCritical, "FATAL ERROR")
                            End

                        End If


                    Loop

                Catch z As Exception

                    MsgBox("Error recreating saveword 2. Exception details: " & z.Message, vbCritical, "Critical Error")

                End Try

            End If

            'Only runs when loading 2 or 3 savewords. Exports saveword 3
            If saveword3enabled = True Then

                EXPORTSavewordText3 = "chantpartB}" 'first time, out of the loop

                Try

                    Do Until ngxcounter3 = ngxcounter_end_3 'final value is 161 on table, but because counting from 0, add one

                        Dim row As DataRow = table.Select("Id = " & ngxcounter3).FirstOrDefault()
                        If Not row Is Nothing Then
                            sval3 = row.Item("Value")
                        End If

                        Inc(ngxcounter3)


                        If ngxcounter3 < ngxcounter_end_3 Then

                            EXPORTSavewordText3 = EXPORTSavewordText3 + sval3 & "}"

                        ElseIf ngxcounter3 = ngxcounter_end_3 Then
                            EXPORTSavewordText3 = EXPORTSavewordText3 + sval3

                        ElseIf ngxcounter3 > ngxcounter_end_3 Then
                            MsgBox("FATAL ERROR: Counter overflow occured when processing saveword 2, program terminating to avoid further issues. This should never happen, please copy the following numbers and submit a bug report- c3:" & ngxcounter3 & " ce3:" & ngxcounter_end_3, vbCritical, "FATAL ERROR")
                            End

                        End If


                    Loop

                Catch z As Exception

                    MsgBox("Error recreating saveword 3. Exception details: " & z.Message, vbCritical, "Critical Error")

                End Try

            End If

            'Export ok

            SavewordExportOK = True


        End If



    End Sub

    'TOP BAR BUTTONS

    'Info button
    Private Sub BarImageButton_Info_Click(sender As Object, e As EventArgs) Handles BarImageButton_Info.Click
        Info.ShowDialog()
    End Sub
    'Update button
    Private Sub BarImageButton_Update_Click(sender As Object, e As EventArgs) Handles BarImageButton_Update.Click
        CheckForUpdates()
    End Sub
    'Settings button
    Private Sub BarImageButton_Cog_Click(sender As Object, e As EventArgs) Handles BarImageButton_Cog.Click
        SettingsForm.ShowDialog()
    End Sub


    'Search Function
    Private Sub textbox_search_TextChanged(sender As Object, e As EventArgs) Handles textbox_search.TextChanged

        Dim srch As String
        Dim irowindex As Integer
        srch = textbox_search.Text

        DataGridViewVars.ClearSelection()
        For i As Integer = 0 To DataGridViewVars.Rows.Count - 1
            If DataGridViewVars.Rows(i).Cells(0).Value IsNot Nothing Then
                If DataGridViewVars.Rows(i).Cells(2).Value.ToString.ToUpper.StartsWith(srch.ToUpper) Then
                    DataGridViewVars.Rows(i).Selected = True
                    irowindex = DataGridViewVars.SelectedCells.Item(0).Value
                    'MessageBox.Show(irowindex)
                    Exit For
                End If
            End If
        Next

    End Sub

    'Folder load
    Private Sub ButtonLoadFromFile_Click(sender As Object, e As EventArgs) Handles TileLoadFromFile.Click
        'UNS FolderBrowserDialog1.ShowDialog()
        'UNS End Sub

        'UNS Private Sub FolderBrowserDialog1_Disposed(sender As Object, e As EventArgs) Handles BunifuTileButton1.Click

        'Dim folderDlg As New FolderBrowserDialog

        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        If PersistentUserDirectory = "" Then

            MsgBox("Please choose the folder where the ""Flexible Survival.gblorb"" is in. This path will be remembered next time you load by file.", vbInformation, "FlexEdit")
            TriggerLoadDialog()

        Else

            Select Case MsgBox("Do you wish to continue using the stored directory? " & PersistentUserDirectory, MsgBoxStyle.YesNo + vbInformation, "FlexEdit")
                Case MsgBoxResult.Yes

                    CheckExist()

                    If FileOK = True Then

                        FileOK = False

                        GlkdataREADER()
                        GlkdataREADER2()
                        GlkdataREADER3()
                        RunLoadSaveword()

                    Else

                        My.Settings.FlexUserDirectory = ""
                        'saving
                        My.Settings.Save()

                    End If

                Case MsgBoxResult.No

                    My.Settings.FlexUserDirectory = ""
                    'saving
                    My.Settings.Save()

                    MsgBox("Please choose the folder where the ""Flexible Survival.gblorb"" is in. This path will be remembered next time you load by file.", vbInformation, "FlexEdit")
                    TriggerLoadDialog()

            End Select

        End If
    End Sub

    Private Sub TriggerLoadDialog()

        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then

            'MsgBox(FolderBrowserDialog1.SelectedPath.ToString)
            'Setting persistent user setting to path AND using it as normal variable
            My.Settings.FlexUserDirectory = FolderBrowserDialog1.SelectedPath.ToString
            'saving
            My.Settings.Save()

            CheckExist()

            If FileOK = True Then

                FileOK = False

                GlkdataREADER()
                GlkdataREADER2()
                GlkdataREADER3()
                RunLoadSaveword()

            Else

                My.Settings.FlexUserDirectory = ""
                'saving
                My.Settings.Save()

            End If

        End If

    End Sub

    Private ExportDialogOK As Boolean = False
    Private Sub TriggerEXPORTDialog()

        ExportDialogOK = False

        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then

            'MsgBox(FolderBrowserDialog1.SelectedPath.ToString)
            'Setting persistent user setting to path AND using it as normal variable
            My.Settings.FlexUserDirectory = FolderBrowserDialog1.SelectedPath.ToString
            'saving
            My.Settings.Save()

            ExportDialogOK = True

        End If

    End Sub

    'Check if file exists
    Private Sub CheckExist()

        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        Dim SavePath1 As String = PersistentUserDirectory + "\txsave.glkdata"
        Dim SavePath2 As String = PersistentUserDirectory + "\txsave2.glkdata"
        Dim SavePath3 As String = PersistentUserDirectory + "\txsave3.glkdata"
        Dim SavePathINV As String = PersistentUserDirectory + "\invsave.glkdata"
        Dim SavePathSTR As String = PersistentUserDirectory + "\storsave.glkdata"

        'Dim saveword1_exists As Boolean = False
        'Dim saveword2_exists As Boolean = False
        'Dim saveword3_exists As Boolean = False
        'Dim savewordINV_exists As Boolean = False
        'Dim savewordSTR_exists As Boolean = False

        'Dim CheckFileExistErrorCounter As Int32 = 0
        '(Transferred to global)

        If System.IO.File.Exists(SavePath1) Then
            'The file exists
        Else
            CheckFileExistErrorCounter += 1
        End If

        If System.IO.File.Exists(SavePath2) Then
            'The file exists
        Else
            CheckFileExistErrorCounter += 1
        End If

        If System.IO.File.Exists(SavePath3) Then
            'The file exists
        Else
            CheckFileExistErrorCounter += 1
        End If

        If System.IO.File.Exists(SavePathINV) Then
            'The file exists
        Else
            CheckFileExistErrorCounter += 1
        End If

        If System.IO.File.Exists(SavePathSTR) Then
            'The file exists
        Else
            CheckFileExistErrorCounter += 1
        End If

        If CheckFileExistErrorCounter = 0 Then

            FileOK = True

        ElseIf CheckFileExistErrorCounter > 1 Then

            FileOK = False
            MsgBox("One or more saveword files could not be found in the directory, please make sure all 5 '.glkdata' files are present in the chosen folder.", vbExclamation, "Error")

        End If

        'Clears counter for next use
        CheckFileExistErrorCounter = 0

    End Sub


    'Glk data readers
    Private Sub GlkdataREADER()

        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        Dim reader As New System.IO.StreamReader(PersistentUserDirectory + "\txsave.glkdata")
        Dim allLines As List(Of String) = New List(Of String)
        Do While Not reader.EndOfStream
            allLines.Add(reader.ReadLine())
        Loop
        reader.Close()
        Dim EndVar As String = ReadLine(2, allLines)


        'MsgBox(EndVar)

        SavewordText1 = EndVar

    End Sub

    Private Sub GlkdataREADER2()

        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        Dim reader As New System.IO.StreamReader(PersistentUserDirectory + "\txsave2.glkdata")
        Dim allLines As List(Of String) = New List(Of String)
        Do While Not reader.EndOfStream
            allLines.Add(reader.ReadLine())
        Loop
        reader.Close()
        Dim EndVar As String = ReadLine(2, allLines)


        'MsgBox(EndVar)

        SavewordText2 = EndVar
        saveword2enabled = True

    End Sub

    Private Sub GlkdataREADER3()

        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        Dim reader As New System.IO.StreamReader(PersistentUserDirectory + "\txsave3.glkdata")
        Dim allLines As List(Of String) = New List(Of String)
        Do While Not reader.EndOfStream
            allLines.Add(reader.ReadLine())
        Loop
        reader.Close()
        Dim EndVar As String = ReadLine(2, allLines)


        'MsgBox(EndVar)

        SavewordText3 = EndVar
        saveword3enabled = True

    End Sub

    'Glk Backup Readers
    Private Sub BACKUP_READER()

        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        Dim reader As New System.IO.StreamReader(PersistentUserDirectory + "\txsave.glkdata")
        Dim allLines As List(Of String) = New List(Of String)
        Do While Not reader.EndOfStream
            allLines.Add(reader.ReadLine())
        Loop
        reader.Close()
        Dim EndVar As String = ReadLine(2, allLines)


        'MsgBox(EndVar)

        EXPORT_BACKUP_1 = EndVar

    End Sub

    Private Sub BACKUP_READER2()

        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        Dim reader As New System.IO.StreamReader(PersistentUserDirectory + "\txsave2.glkdata")
        Dim allLines As List(Of String) = New List(Of String)
        Do While Not reader.EndOfStream
            allLines.Add(reader.ReadLine())
        Loop
        reader.Close()
        Dim EndVar As String = ReadLine(2, allLines)


        'MsgBox(EndVar)

        EXPORT_BACKUP_2 = EndVar

    End Sub

    Private Sub BACKUP_READER3()

        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        Dim reader As New System.IO.StreamReader(PersistentUserDirectory + "\txsave3.glkdata")
        Dim allLines As List(Of String) = New List(Of String)
        Do While Not reader.EndOfStream
            allLines.Add(reader.ReadLine())
        Loop
        reader.Close()
        Dim EndVar As String = ReadLine(2, allLines)


        'MsgBox(EndVar)

        EXPORT_BACKUP_3 = EndVar

    End Sub
    'Glk success
    Private WriteOK As Int32 = 0

    'Glk data writers
    Private Sub GlkdataWRITER()
        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        Dim filePath As String = PersistentUserDirectory + "\txsave.glkdata"
        Dim lines() As String = System.IO.File.ReadAllLines(filePath)
        If lines.Length > 1 Then
            lines(1) = EXPORTSavewordText1
            System.IO.File.WriteAllLines(filePath, lines)

        Else

            'throw error, wrong file type?

        End If

        WriteOK += 1

    End Sub

    Private Sub GlkdataWRITER2()
        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        Dim filePath As String = PersistentUserDirectory + "\txsave2.glkdata"
        Dim lines() As String = System.IO.File.ReadAllLines(filePath)
        If lines.Length > 1 Then
            lines(1) = EXPORTSavewordText2
            System.IO.File.WriteAllLines(filePath, lines)

        Else

            'throw error, wrong file type?

        End If

        WriteOK += 1

    End Sub

    Private Sub GlkdataWRITER3()
        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        Dim filePath As String = PersistentUserDirectory + "\txsave3.glkdata"
        Dim lines() As String = System.IO.File.ReadAllLines(filePath)
        If lines.Length > 1 Then
            lines(1) = EXPORTSavewordText3
            System.IO.File.WriteAllLines(filePath, lines)

        Else

            'throw error, wrong file type?

        End If

        WriteOK += 1

    End Sub

    'Glk backup success indicator
    Private BackupOK As Boolean = False
    'Glk backup
    Private Sub BackupWRITER()

        'DECLARING PERSISTENT settings
        Dim PersistentUserDirectory As String = My.Settings.FlexUserDirectory 'direct var of directory (load)

        'Time code
        Dim MyFileName As String
        MyFileName = System.DateTime.Now.ToString
        For i = 1 To Len(MyFileName)
            If Mid$(MyFileName$, i, 1) = " " Then Mid$(MyFileName$, i, 1) = "_"
            If Mid$(MyFileName$, i, 1) = "/" Or Mid$(MyFileName$, i, 1) = ":" Then _
    Mid$(MyFileName$, i, 1) = "-"
        Next i
        'Time code finish

        'Changes lines if null / empty
        If String.IsNullOrEmpty(EXPORT_BACKUP_INV) Then
            EXPORT_BACKUP_INV = "Not accessed"
        End If
        If String.IsNullOrEmpty(EXPORT_BACKUP_STR) Then
            EXPORT_BACKUP_STR = "Not accessed"
        End If

        Dim filePath As String = PersistentUserDirectory + "\" & "FlexEditBackup_" & MyFileName & ".txt"

        Try
            'Make file
            If Not System.IO.File.Exists(filePath) Then
                System.IO.File.Create(filePath).Dispose()
            End If
            'End make
        Catch z As Exception
            MsgBox("Error creating backup file. Exception details: " & z.Message, vbCritical, "Critical Error")
            BackupOK = False
        End Try

        'Dim lines() As String = System.IO.File.ReadAllLines(filePath)


        'lines(0) = "FlexEdit Backup File - " & System.DateTime.Now.ToString
        'lines(1) = "This is the contents of all 6 .glkdata files before FlexEdit performed overwrite"

        'lines(3) = "Saveword Part 1"
        'lines(4) = EXPORT_BACKUP_1

        'lines(6) = "Saveword Part 2"
        'lines(7) = EXPORT_BACKUP_2

        'lines(9) = "Saveword Part 3"
        'lines(10) = EXPORT_BACKUP_3

        ''lines(12) = "Inventory"
        ''lines(13) = EXPORT_BACKUP_INV

        ''lines(15) = "Storage"
        ''lines(16) = EXPORT_BACKUP_STR

        ''System.IO.File.WriteAllLines(filePath, lines)
        Try
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(filePath, True)
            file.WriteLine("FlexEdit Backup File - " & System.DateTime.Now.ToString)
            file.WriteLine("This is the contents of all 6 .glkdata files before FlexEdit performed overwrite")
            file.WriteLine("")
            file.WriteLine("Saveword Part 1")
            file.WriteLine(EXPORT_BACKUP_1)
            file.WriteLine("")
            file.WriteLine("Saveword Part 2")
            file.WriteLine(EXPORT_BACKUP_2)
            file.WriteLine("")
            file.WriteLine("Saveword Part 3")
            file.WriteLine(EXPORT_BACKUP_3)
            file.WriteLine("")
            file.WriteLine("Inventory")
            file.WriteLine(EXPORT_BACKUP_INV)
            file.WriteLine("")
            file.WriteLine("Storage")
            file.WriteLine(EXPORT_BACKUP_STR)
            file.Close()

            BackupOK = True

        Catch z As Exception
            MsgBox("Error writing to backup file. Exception details: " & z.Message, vbCritical, "Critical Error")
            BackupOK = False
        End Try

    End Sub

    Function BACKUPNullCheck()

        If String.IsNullOrEmpty(EXPORT_BACKUP_1) Then
            Return 1
        End If
        If String.IsNullOrEmpty(EXPORT_BACKUP_2) Then
            Return 1
        End If
        If String.IsNullOrEmpty(EXPORT_BACKUP_3) Then
            Return 1
        End If

        Return 0
    End Function

    'Glk backup CONSOLIDATION
    Private Sub BACKUP_Consolidation()
        If My.Settings.MakeBackupsOnSave = False Then
            Return
        End If
        BACKUP_READER()
        BACKUP_READER2()
        BACKUP_READER3()

        'Stops if strings empty (safeguard)
        If BACKUPNullCheck() = 1 Then
            MsgBox("Backup failed. Save will now be attempted.", vbCritical, "Backup error")
            Return
        End If

        BackupWRITER()
        If BackupOK = True Then
            MsgBox("A backup file has been made in the game directory. This behaviour can be changed in settings.", vbInformation, "FlexEdit")
        Else
            MsgBox("Backup failed. Save will now be attempted.", vbCritical, "Backup error")
        End If
    End Sub
    'Function needed in glkdata reader sub (incremental)
    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function

    Private Sub ButtonSaveToFile_Click(sender As Object, e As EventArgs) Handles TileSaveToFile.Click
        If Status1 = False Or Status2 = False Or Status3 = False Then

            MsgBox("All 3 saveword parts must be loaded. Please load them first.", vbExclamation, "Error")

            Return

        Else

            If My.Settings.FlexUserDirectory = "" Then

                MsgBox("Please choose the folder where the ""Flexible Survival.gblorb"" is in. This path will be remembered next time you load by file.", vbInformation, "FlexEdit")
                TriggerEXPORTDialog()

                If ExportDialogOK = True Then

                    CheckExist()

                    If FileOK = True Then

                        FileOK = False

                        RunExportSaveword()

                        If SavewordExportOK = True Then

                            BACKUP_Consolidation()
                            GlkdataWRITER()
                            GlkdataWRITER2()
                            GlkdataWRITER3()

                            If WriteOK = 3 Then
                                MsgBox("Saveword successfully saved to file.", vbInformation, "Save to File success")

                            Else

                                MsgBox("Saveword did not successfully save to file", vbCritical, "Save to File error")

                            End If

                            WriteOK = 0
                        Else

                            My.Settings.FlexUserDirectory = ""
                            'saving
                            My.Settings.Save()

                        End If
                    Else
                        MsgBox("Error, FlexEdit did not find existing '.glkdata' files. FlexEdit cannot create files as each file is specific to the game. Save to file has failed.", vbCritical, "Save error")

                        My.Settings.FlexUserDirectory = ""
                        'saving
                        My.Settings.Save()

                    End If

                End If

            Else

                Select Case MsgBox("Do you wish to continue using the stored directory? " & My.Settings.FlexUserDirectory, MsgBoxStyle.YesNo + vbInformation, "FlexEdit")
                    Case MsgBoxResult.Yes

                        CheckExist()

                        If FileOK = True Then

                            FileOK = False

                            RunExportSaveword()

                            If SavewordExportOK = True Then

                                BACKUP_Consolidation()
                                GlkdataWRITER()
                                GlkdataWRITER2()
                                GlkdataWRITER3()

                                If WriteOK = 3 Then
                                    MsgBox("Saveword successfully saved to file.", vbInformation, "Save to File success")

                                Else

                                    MsgBox("Saveword did not successfully save to file", vbCritical, "Save to File error")

                                End If

                                WriteOK = 0
                            Else

                                My.Settings.FlexUserDirectory = ""
                                'saving
                                My.Settings.Save()

                            End If

                        Else

                            MsgBox("Error, FlexEdit did not find existing '.glkdata' files. FlexEdit cannot create files as each file is specific to the game. Save to file has failed.", vbCritical, "Save error")

                            My.Settings.FlexUserDirectory = ""
                            'saving
                            My.Settings.Save()

                        End If

                    Case MsgBoxResult.No

                        My.Settings.FlexUserDirectory = ""
                        'saving
                        My.Settings.Save()

                        MsgBox("Please choose the folder where the ""Flexible Survival.gblorb"" is in. This path will be remembered next time you load by file.", vbInformation, "FlexEdit")
                        TriggerEXPORTDialog()

                        If ExportDialogOK = True Then

                            CheckExist()

                            If FileOK = True Then

                                FileOK = False

                                RunExportSaveword()

                                If SavewordExportOK = True Then

                                    BACKUP_Consolidation()
                                    GlkdataWRITER()
                                    GlkdataWRITER2()
                                    GlkdataWRITER3()

                                    If WriteOK = 3 Then
                                        MsgBox("Saveword successfully saved to file.", vbInformation, "Save to File success")

                                    Else

                                        MsgBox("Saveword did not successfully save to file", vbCritical, "Save to File error")

                                    End If

                                    WriteOK = 0
                                Else

                                    My.Settings.FlexUserDirectory = ""
                                    'saving
                                    My.Settings.Save()

                                End If

                            Else
                                MsgBox("Error, FlexEdit did not find existing '.glkdata' files. FlexEdit cannot create files as each file is specific to the game. Save to file has failed.", vbCritical, "Save error")

                                My.Settings.FlexUserDirectory = ""
                                'saving
                                My.Settings.Save()

                            End If

                        End If
                End Select

            End If

        End If

    End Sub
End Class

