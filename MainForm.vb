Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.DataTable

Public Class MainForm
    'Vars
    Public i As Integer = 0
    Public mySplashScreen = DirectCast(My.Application.SplashScreen, Splash)

    'States that will be controlled by checkboxes
    Public saveword2enabled As Boolean = False
    Public saveword3enabled As Boolean = False

    'Checks whether user has accepted the agreement for raw edits (prompt)
    Dim AcceptedRawTerms As Boolean = False

    'Load saveword form vars
    Public SavewordText1 As String
    Public SavewordText2 As String
    Public SavewordText3 As String

    'Save saveword TO (Export Form)

    Public EXPORTSavewordText1 As String
    Public EXPORTSavewordText2 As String
    Public EXPORTSavewordText3 As String

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

    'Datatable
    'Dim data As New DataSet1
    Dim table As New DataTable("Table")



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim mySplashScreen = DirectCast(My.Application.SplashScreen, Form2)
        'My.Application.mySplashScreen.Invoke(New MethodInvoker(AddressOf My.Application.mySplashScreen.IncrementProgress))


        'Bugfix 1 for metrotab
        Dim speed As Integer = MetroTabControl1.Speed : MetroTabControl1.Speed = 20
        For i As Integer = 0 To MetroTabControl1.TabPages.Count
            MetroTabControl1.SelectedIndex = i
        Next
        MetroTabControl1.SelectedIndex = 0 : MetroTabControl1.Speed = speed
        'Bugfix over

        'SHOW PRE-RELEASE WARNING
        Panel_PreReleaseWarning.Visible = True

        'Highlight first option
        buttontab_1.selected = True

        'Do datatable tasks
        Load_DoDatabaseTasks()

        'Do DPI scaling
        Load_DoScaling()
        'Center main form to screen
        Me.CenterToScreen()

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

        If Status1 = False Then
            MsgBox("Please load a saveword first", vbInformation, "FlexEdit")
            'Highlight first option
            buttontab_1.selected = True
            Return
        End If

        If AcceptedRawTerms = False Then


            Select Case MsgBox("Raw edits is a developer feature only and should not be used without knowledge of the game code. Editing values in these variables can easily break whole quest chains irreversibily for your current play-through. Not even FS writers can fix a broken saveword. You will have to start a new game if that happens. IF YOU DECIDE TO USE THIS, PLEASE BACKUP YOUR SAVES.", MsgBoxStyle.YesNo + vbExclamation, "Are you sure")
                Case MsgBoxResult.Yes
                    AcceptedRawTerms = True
                    RunUpdateTextBoxPriority()
                    MetroTabControl1.SelectedTab = Tab7Raw
            ' Do something if yes
                Case MsgBoxResult.No
                    'do nothing if user does not accept
            End Select

        ElseIf AcceptedRawTerms = True Then
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

            MsgBox("Saveword Part 1 has not been loaded. Savewords Part 2 and Part 3 will not be attempted.", vbExclamation, "Caution")


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
                        table.Rows.Add(count + 59, yValues(count))
                    End If

                Next 'ends sub here


                SaveLoadCompleted2 = True


                'error handling
            Catch z As Exception
                MsgBox("Error parsing Saveword Part 2. Perhaps you have entered it incorrectly? Exception details: " & z.Message, vbCritical, "Critical Error")

                SaveLoadCompleted2 = False

                MsgBox("Saveword Part 2 has not been loaded. Saveword Part 3 will not be attempted.", vbExclamation, "Caution")

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
                        table.Rows.Add(count + 161, zValues(count))
                    End If

                Next


                SaveLoadCompleted3 = True


                'error handling
            Catch z As Exception

                MsgBox("Error parsing Saveword Part 3. Perhaps you have entered it incorrectly? Exception details: " & z.Message, vbCritical, "Critical Error")

                SaveLoadCompleted3 = False

                MsgBox("Saveword Part 3 has not been loaded.")

                'disabling tabs and buttons

                Return 'ends sub here

            End Try

        End If

        'ENDING SAVEWORD 3

        'determine finishing tasks whether saveword loaded or not
        If SaveLoadCompleted1 = True Then

            MsgBox("Saveword Part 1 import complete!", vbInformation, "Import success")
            Status1 = True

            'RunAnnotateVars()
            NGXAnnote()


        End If

        'tasks for saveword 2

        If SaveLoadCompleted2 = True AndAlso saveword2enabled = True Then

            MsgBox("Saveword Part 2 import complete!", vbInformation, "Import success")
            Status2 = True

            'RunAnnotateVars2()
            NGXAnnote2()

        End If

        'tasks for saveword 3

        If SaveLoadCompleted3 = True AndAlso saveword3enabled = True Then

            MsgBox("Saveword Part 3 import complete!", vbInformation, "Import success")
            Status3 = True

            'RunAnnotateVars3()

        ElseIf SaveLoadCompleted3 = False And saveword3enabled = True Then

            MsgBox("Saveword 3 has not been loaded. Savewords 1 and 2 are loaded normally. You can use the program as is or try loading saveword 3 again.", vbExclamation, "Caution")

        End If

        If SaveLoadCompleted1 = True Or SaveLoadCompleted2 = True Or SaveLoadCompleted3 = True Then

            resizeDataTable()

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



    Private Sub NGXAnnote()

        Dim rawAnnotation As String
        'rawAnnotation = My.Settings.Annotation1
        'rawAnnotation = "Strength,Dexerity,Stamina,Charisma,Perception,Intelligent,Level,HP,Humanity,Score,hp of doctor matt,Body infection,Head infection,Skin infection,Tail infection,Genital Infection,SatisfiedTanuki,hospquest,Cocks (Number of cocks),Breasts (Number of breast),Cunts (Number of cunts),Breast Size,Cock Length,Cock Width (Also affects cum and ball size),Cunt Length,Cunt Width,Equipped Weapon,franksex,frankmalesex,Snow special (annote),REMOVED (value always 0),Coleen special (annote),coleentalk,coleenfound,coleencollared,coleenalpha,coleenslut,coleenspray,hp of doctor mouse,coonstatus,featunlock,butterflymagic? wth is this,catnum,mateable,gryphoncomforted,shiftable,medeaget,mtp,hyg,nes,mtrp,boristalk,borisquest,progress of alex,angiehappy,angietalk,deerconsent,hp  of Susan,mattcollection"
        'above is backup from v2.0.14
        rawAnnotation = "Strength,Dexerity,Stamina,Charisma,Perception,Intelligent,Level,HP,Humanity,Score,hp of doctor matt,Body infection,Head infection,Skin infection,Tail infection,Genital Infection,SatisfiedTanuki,Hospquest,Cocks (Number of cocks),Breasts (Number of breast),Cunts (Number of cunts),Breast Size,Cock Length,Cock Width,Cunt Length,Cunt Width,Equipped Weapon,Frank M/F,Frank M/M,Hyper Squirrel Resolved,REMOVED (value always 0),Coleen Location,Coleen Talk,Coleen Found,Coleen Collared,Coleen Alpha,Coleen Slut,Coleen Spray,HP of Dr Mouse,Candy(coonstatus),featunlock,Butterfly,Catnum,Mateable,gryphoncomforted,shiftable,Medea,MTP,HYG,NES,MTRP,Boristalk,Borisquest,progress of alex,Angiehappy,Angietalk,deerconsent,HP of Susan,mattcollection"
        Dim fAnnote() As String = rawAnnotation.Split(",")
        For count = 0 To fAnnote.Length - 1
            DataGridViewVars.Rows(count).Cells(2).Value = fAnnote(count)
        Next

    End Sub

    Private Sub NGXAnnote2()

        Dim rawAnnotation As String
        rawAnnotation = "Not Finished"

        Dim fAnnote() As String = rawAnnotation.Split(",")
        For count = 0 To fAnnote.Length - 1
            DataGridViewVars.Rows(count + 59).Cells(2).Value = fAnnote(count)
        Next

    End Sub



    'Annotation Functions
    Private Sub RunAnnotateVars()

        Dim index As Integer = 0



        DataGridViewVars.Rows(index).Cells(2).Value = "Strength"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Dexerity"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Stamina"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Charisma"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Perception"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Intelligence"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Level"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "HP"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Humanity"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Score"
        Inc(index)

        'doctor

        DataGridViewVars.Rows(index).Cells(2).Value = "hp of doctor matt"
        Inc(index)

        'filling infection tab

        DataGridViewVars.Rows(index).Cells(2).Value = "Body infection"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Head infection"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Skin infection"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Tail infection"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Genital infection"
        Inc(index)

        'filling ok, variable go

        DataGridViewVars.Rows(index).Cells(2).Value = "SatisfiedTanuki"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "hospquest"
        Inc(index)


        'body go

        DataGridViewVars.Rows(index).Cells(2).Value = "Cocks (Number of cocks)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Breasts (Number of breasts)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Cunts (Number of cunts)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Breast Size"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Cock Length"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Cock Width (Also affects cum and ball size)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Cunt Length"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Cunt Width"
        Inc(index)

        'variables go
        DataGridViewVars.Rows(index).Cells(2).Value = "Equipped Weapon"
        Inc(index)

        'weapon would be index 27
        'more

        DataGridViewVars.Rows(index).Cells(2).Value = "franksex"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "frankmalesex"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Snow special (annotation)"
        Inc(index) 'hyper squirrel girl thing, will annotate later
        DataGridViewVars.Rows(index).Cells(2).Value = "REMOVED (value always 0)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Coleen special (annotation)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleentalk"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleenfound"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleencollared"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleenalpha"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleenslut"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleenspray"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "hp of doctor mouse"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coonstatus"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "featunlock"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Butterflymagic? Wth is this?"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "catnum"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "mateable"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "gryphoncomforted"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "shiftable"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "medeaget"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "mtp"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "hyg"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "nes"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "mtrp"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "boristalk"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "borisquest"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "progress of alex"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "angiehappy"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "angietalk"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "deerconsent"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "hp of Susan"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "mattcollection"

    End Sub

    Private Sub RunAnnotateVars2()

        Dim index As Integer = 59 '59 -> 60 - 1 because of 0 start

        DataGridViewVars.Rows(index).Cells(2).Value = "ChantB starts here, not done yet."
        Inc(index)



    End Sub

    Private Sub RunAnnotateVars3()
        'empty
    End Sub

    Private Sub BunifuTileButton4_Click(sender As Object, e As EventArgs) Handles TileLoadToCode.Click

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
            Dim ngxcounter2 As Integer = 60 'literally first term, starting with 1 

            Dim sval3 As String = "You should not be seeing this, something has gone horribly wrong. Error Code (3)"
            Dim ngxcounter3 As Integer = 162

            'do some cleanup, then set failsafe conditions
            EXPORTSavewordText1 = ""
            EXPORTSavewordText2 = ""
            EXPORTSavewordText3 = ""


            'before real processing, assimilate textfields to database (IMPORTANT)



            'Start real processing


            Try

                Do Until ngxcounter = 60

                    Dim row As DataRow = table.Select("Id = " & ngxcounter).FirstOrDefault()
                    If Not row Is Nothing Then
                        sval = row.Item("Value")
                    End If

                    Inc(ngxcounter)

                    If ngxcounter < 60 Then

                        EXPORTSavewordText1 = EXPORTSavewordText1 + sval & "}"

                    ElseIf ngxcounter = 60 Then
                        EXPORTSavewordText1 = EXPORTSavewordText1 + sval

                    ElseIf ngxcounter > 60 Then
                        MsgBox("FATAL ERROR: Counter overflow occured when processing saveword 1, program terminating to avoid further issues.", vbCritical, "FATAL ERROR")
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

                    Do Until ngxcounter2 = 162 'final value is 161 on table, but because counting from 0, add one

                        Dim row As DataRow = table.Select("Id = " & ngxcounter2).FirstOrDefault()
                        If Not row Is Nothing Then
                            sval2 = row.Item("Value")
                        End If

                        Inc(ngxcounter2)


                        If ngxcounter2 < 162 Then

                            EXPORTSavewordText2 = EXPORTSavewordText2 + sval2 & "}"

                        ElseIf ngxcounter2 = 162 Then
                            EXPORTSavewordText2 = EXPORTSavewordText2 + sval2

                        ElseIf ngxcounter2 > 162 Then
                            MsgBox("FATAL ERROR: Counter overflow occured when processing saveword 2, program terminating to avoid further issues.", vbCritical, "FATAL ERROR")
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

                    Do Until ngxcounter3 = 225 'final value is 161 on table, but because counting from 0, add one

                        Dim row As DataRow = table.Select("Id = " & ngxcounter3).FirstOrDefault()
                        If Not row Is Nothing Then
                            sval3 = row.Item("Value")
                        End If

                        Inc(ngxcounter3)


                        If ngxcounter3 < 225 Then

                            EXPORTSavewordText3 = EXPORTSavewordText3 + sval3 & "}"

                        ElseIf ngxcounter3 = 225 Then
                            EXPORTSavewordText3 = EXPORTSavewordText3 + sval3

                        ElseIf ngxcounter3 > 225 Then
                            MsgBox("FATAL ERROR: Counter overflow occured when processing saveword 3, program terminating to avoid further issues.", vbCritical, "FATAL ERROR")
                            End

                        End If


                    Loop

                Catch z As Exception

                    MsgBox("Error recreating saveword 3. Exception details: " & z.Message, vbCritical, "Critical Error")

                End Try

            End If

            'Export ok

            MsgBox("Saveword successfully exported.", vbInformation, "Export success")

            SavewordExportOK = True


        End If



    End Sub

    'Info button
    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Info.ShowDialog()
    End Sub

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
    Private Sub BunifuTileButton1_Click(sender As Object, e As EventArgs) Handles TileLoadFromFile.Click
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

    'Glk data writers

    'Glk success

    Private WriteOK As Int32 = 0

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

    'Function needed in glkdata reader sub (incremental)
    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function

    Private Sub BunifuTileButton2_Click(sender As Object, e As EventArgs) Handles TileSaveToFile.Click
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

                                My.Settings.FlexUserDirectory = ""
                                'saving
                                My.Settings.Save()

                            End If

                        End If
                End Select

            End If

        End If

    End Sub

    Private Sub Tab3Body_Click(sender As Object, e As EventArgs) Handles Tab3Body.Click

    End Sub
End Class

