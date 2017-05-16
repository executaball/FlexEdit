Public Class MainForm
    Public thisone As Integer = 12
    Public i As Integer = 0
    Public mySplashScreen = DirectCast(My.Application.SplashScreen, Splash)

    'increment splash screen progress bar function
    Public Sub ConsolSplashIncrement()
        mySplashScreen.Invoke(New MethodInvoker(AddressOf mySplashScreen.IncrementProgress))
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim mySplashScreen = DirectCast(My.Application.SplashScreen, Form2)
        'My.Application.mySplashScreen.Invoke(New MethodInvoker(AddressOf My.Application.mySplashScreen.IncrementProgress))


        'Bugfix 1 for metrotab
        Dim speed As Integer = MetroTabControl1.Speed : MetroTabControl1.Speed = 20
        For i As Integer = 0 To MetroTabControl1.TabPages.Count
            MetroTabControl1.SelectedIndex = i
        Next
        MetroTabControl1.SelectedIndex = 0 : MetroTabControl1.Speed = speed

        ConsolSplashIncrement()

        'Moves sidepanel to correct position (because moved out of way for development)
        Sidepanel.Width = 367

        ConsolSplashIncrement()

        'SHOW PRE-RELEASE WARNING
        Panel_PreReleaseWarning.Visible = True

        ConsolSplashIncrement()
        'Highlight first option
        buttontab_1.selected = True

        ConsolSplashIncrement()

        For x As Integer = 1 To 5
            ConsolSplashIncrement()
            funcdelay100()
        Next


    End Sub

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

        MetroTabControl1.SelectedTab = TabPage1

    End Sub
    'Tab2
    Private Sub buttontab_2_Click(sender As Object, e As EventArgs) Handles buttontab_2.Click

        MetroTabControl1.SelectedTab = TabPage2

    End Sub
    'Tab3
    Private Sub buttontab_3_Click(sender As Object, e As EventArgs) Handles buttontab_3.Click

        MetroTabControl1.SelectedTab = TabPage3

    End Sub
    'Tab4
    Private Sub buttontab_4_Click(sender As Object, e As EventArgs) Handles buttontab_4.Click

        MetroTabControl1.SelectedTab = TabPage4

    End Sub
    'Tab5
    Private Sub buttontab_5_Click(sender As Object, e As EventArgs) Handles buttontab_5.Click

        MetroTabControl1.SelectedTab = TabPage5

    End Sub



    'FUNCTIONS to DISPLAY status of saveword

    Public Sub Status1toLOADED()

        label_status1.Text = "Loaded"

        picbox_status1.Image = My.Resources.Resources.full_success

    End Sub

    Public Sub Status1toUNLOAD()

        label_status1.Text = "Not loaded"

        picbox_status1.Image = My.Resources.Resources.redfull_error

    End Sub

    Public Sub Status2toLOADED()

        label_status2.Text = "Loaded"

        picbox_status2.Image = My.Resources.Resources.full_success

    End Sub

    Public Sub Status2toUNLOAD()

        label_status2.Text = "Not loaded"

        picbox_status2.Image = My.Resources.Resources.redfull_error

    End Sub

    Public Sub Status3toLOADED()

        label_status3.Text = "Loaded"

        picbox_status3.Image = My.Resources.Resources.full_success

    End Sub

    Public Sub Status3toUNLOAD()

        label_status3.Text = "Not loaded"

        picbox_status3.Image = My.Resources.Resources.redfull_error

    End Sub

    Public Sub Status4toLOADED()

        label_status4.Text = "Loaded"

        picbox_status4.Image = My.Resources.Resources.full_success

    End Sub

    Public Sub Status4toUNLOAD()

        label_status4.Text = "Not loaded"

        picbox_status4.Image = My.Resources.Resources.redfull_error

    End Sub

    Public Sub Status5toLOADED()

        label_status5.Text = "Loaded"

        picbox_status5.Image = My.Resources.Resources.full_success

    End Sub

    Public Sub Status5toUNLOAD()

        label_status5.Text = "Not loaded"

        picbox_status5.Image = My.Resources.Resources.redfull_error

    End Sub

    'FUNCTIONS over

    'Load saveword button
    Private Sub BunifuTileButton3_Click(sender As Object, e As EventArgs) Handles BunifuTileButton3.Click

        Dim message, title, defaultValue As String
        Dim myValue As Object
        ' Set prompt.
        message = "Enter a value between 1 and 3"
        ' Set title.
        title = "InputBox Demo"
        defaultValue = "1"   ' Set default value.

        ' Display message, title, and default value.
        myValue = InputBox(message, title, defaultValue)
        ' If user has clicked Cancel, set myValue to defaultValue 
        If myValue Is "" Then myValue = defaultValue

        ' Display dialog box at position 100, 100.
        myValue = InputBox(message, title, defaultValue, 100, 100)
        ' If user has clicked Cancel, set myValue to defaultValue 
        If myValue Is "" Then myValue = defaultValue

    End Sub


End Class

