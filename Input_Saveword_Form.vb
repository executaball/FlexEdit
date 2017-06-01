Public Class Input_Saveword_Form

    Private Sub checkbox_saveword2_Click(sender As Object, e As EventArgs) Handles checkbox_saveword2.Click

        If checkbox_saveword2.Checked = True Then

            textbox_saveword2.Enabled = True
            MainForm.saveword2enabled = True

        ElseIf checkbox_saveword2.Checked = False Then

            textbox_saveword2.Enabled = False
            textbox_saveword3.Enabled = False
            checkbox_saveword3.Checked = False

            MainForm.saveword2enabled = False
            MainForm.saveword3enabled = False

        End If

    End Sub

    Private Sub checkbox_saveword3_Click(sender As Object, e As EventArgs) Handles checkbox_saveword3.Click

        If textbox_saveword2.Enabled = True Then

            If checkbox_saveword3.Checked = True Then

                textbox_saveword3.Enabled = True
                MainForm.saveword3enabled = True

            ElseIf checkbox_saveword3.Checked = False Then

                textbox_saveword3.Enabled = False
                MainForm.saveword3enabled = False

            End If

        ElseIf textbox_saveword2.Enabled = False Then

            checkbox_saveword3.Checked = False
            textbox_saveword3.Enabled = False
            MsgBox("Sorry, you cannot enable saveword part 3 without enabling part 2.")

            MainForm.saveword3enabled = False

        End If


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()

        textbox_saveword1.Text = "Saveword Part 1"
        textbox_saveword1.ForeColor = Color.DarkGray

        textbox_saveword2.Text = "Saveword Part 2"
        textbox_saveword2.ForeColor = Color.DarkGray

        textbox_saveword3.Text = "Saveword Part 3"
        textbox_saveword3.ForeColor = Color.DarkGray

    End Sub

    Private Sub textbox_saveword1_Click(sender As Object, e As EventArgs) Handles textbox_saveword1.Click
        textbox_saveword1.Text = ""
        textbox_saveword1.ForeColor = Color.Black
    End Sub

    Private Sub textbox_saveword2_Click(sender As Object, e As EventArgs) Handles textbox_saveword2.Click
        textbox_saveword2.Text = ""
        textbox_saveword2.ForeColor = Color.Black
    End Sub

    Private Sub textbox_saveword3_Click(sender As Object, e As EventArgs) Handles textbox_saveword3.Click
        textbox_saveword3.Text = ""
        textbox_saveword3.ForeColor = Color.Black
    End Sub

    Private Sub metrobutton_load_Click(sender As Object, e As EventArgs) Handles metrobutton_load.Click
        MainForm.SavewordText1 = textbox_saveword1.Text
        MainForm.SavewordText2 = textbox_saveword2.Text
        MainForm.SavewordText3 = textbox_saveword3.Text

        MainForm.RunLoadSaveword()

        Me.Close()
    End Sub

    Private Sub metrobutton_cancel_Click(sender As Object, e As EventArgs) Handles metrobutton_cancel.Click
        Me.Close()
    End Sub


End Class