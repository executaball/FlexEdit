Public Class Output_Saveword_Form

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub Output_Saveword_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()

        textbox_saveword1.Text = MainForm.EXPORTSavewordText1
        textbox_saveword2.Text = MainForm.EXPORTSavewordText2
        textbox_saveword3.Text = MainForm.EXPORTSavewordText3

    End Sub

    'Handling clipboard copies

    Private Sub metrobutton_copy1_Click(sender As Object, e As EventArgs) Handles metrobutton_copy1.Click

        Try
            Dim strSaveword1 As String = textbox_saveword1.Text
            My.Computer.Clipboard.SetText(strSaveword1)

            If strSaveword1 = My.Computer.Clipboard.GetText() Then

                metrobutton_copy1.Text = "COPIED"
                Timer1.Start()

            Else

                MsgBox("Copying to clipboard failed on selfcheck routine but did not trigger exception. This is not supposed to happen. You might have software interfering with clipboard access.")

            End If


        Catch z As Exception
            MsgBox("Error when copying to clipboard. Details: " & z.Message, vbCritical, "Critical Error")

        End Try



    End Sub

    Private Sub metrobutton_copy2_Click(sender As Object, e As EventArgs) Handles metrobutton_copy2.Click

        Try
            Dim strSaveword2 As String = textbox_saveword2.Text
            My.Computer.Clipboard.SetText(strSaveword2)

            If strSaveword2 = My.Computer.Clipboard.GetText() Then

                metrobutton_copy2.Text = "COPIED"
                Timer2.Start()


            Else

                MsgBox("Copying to clipboard failed on selfcheck routine but did not trigger exception. This is not supposed to happen. You might have software interfering with clipboard access.")

            End If


        Catch z As Exception
            MsgBox("Error when copying to clipboard. Details: " & z.Message, vbCritical, "Critical Error")

        End Try



    End Sub

    Private Sub metrobutton_copy3_Click(sender As Object, e As EventArgs) Handles metrobutton_copy3.Click

        Try
            Dim strSaveword3 As String = textbox_saveword3.Text
            My.Computer.Clipboard.SetText(strSaveword3)

            If strSaveword3 = My.Computer.Clipboard.GetText() Then

                metrobutton_copy3.Text = "COPIED"
                Timer3.Start()

            Else

                MsgBox("Copying to clipboard failed on selfcheck routine but did not trigger exception. This is not supposed to happen. You might have software interfering with clipboard access.", vbCritical, "Critical Error")

            End If


        Catch z As Exception
            MsgBox("Error when copying to clipboard. Details: " & z.Message, vbCritical, "Critical Error")

        End Try



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        metrobutton_copy1.Text = "Copy"
        Timer1.Stop()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        metrobutton_copy2.Text = "Copy"
        Timer2.Stop()

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        metrobutton_copy3.Text = "Copy"
        Timer3.Stop()

    End Sub

    Private Sub metrobutton_exit_Click(sender As Object, e As EventArgs) Handles metrobutton_exit.Click

        textbox_saveword1.Text = ""
        textbox_saveword2.Text = ""
        textbox_saveword3.Text = ""

        Me.Close()

    End Sub
End Class