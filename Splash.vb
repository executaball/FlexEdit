Public NotInheritable Class Splash


    'Public Delegate Sub SetProgressBarDelegate(ByVal max As Integer)
    'Public Delegate Sub UpdateProgressBarDelegate(ByVal value As Integer)

    'Public Sub BarLong(ByVal MemCount As Integer)
    'If Me.InvokeRequired Then
    'Me.Invoke(New SetProgressBarDelegate(AddressOf BarLong), MemCount)
    ''Else
    'Me.MetroProgressbar1.Maximum = MemCount
    'Me.BunifuProgressBar1.MaximumValue = MemCount

    'End If
    'End Sub

    'Public Sub ShowBar(ByVal SoFar As Integer)
    'If Me.InvokeRequired Then
    'Me.Invoke(New UpdateProgressBarDelegate(AddressOf ShowBar), SoFar)
    ''Else
    'Me.MetroProgressbar1.Value = SoFar
    'Me.BunifuProgressBar1.Value = SoFar
    'End If
    'End Sub


    'Public Sub IncrementProgress()
    'Me.ProgressBar1.PerformStep()
    'End Sub




    Private Sub SplashScreen1_Load(ByVal sender As Object,
                                       ByVal e As System.EventArgs) Handles Me.Load
        'Me.ProgressBar1.Step = 1
        Me.CenterToScreen()
        VersionL.Text = System.String.Format(VersionL.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)


        ProgressBar1.MarqueeAnimationSpeed = 40
        ProgressBar1.Style = ProgressBarStyle.Marquee

    End Sub

    'Public Sub IncrementProgress()
    'If Me.ProgressBar1.Value < Me.ProgressBar1.Maximum Then Me.ProgressBar1.Value = Me.ProgressBar1.Value + 10

    'If Me.BunifuProgressBar1.Value < Me.BunifuProgressBar1.MaximumValue Then Me.BunifuProgressBar1.Value = Me.BunifuProgressBar1.Value + 10

    'If Me.MetroProgressbar1.Value < Me.MetroProgressbar1.Maximum Then Me.MetroProgressbar1.Value = Me.MetroProgressbar1.Value + 10


    'End Sub




End Class