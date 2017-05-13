Imports System.Data.DataTable

Public Class FlexEdit

    Dim table As New DataTable("Table")
    Dim savewords As Integer = 1





    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initial setup - fills the tables with names (will clear later)
        table.Columns.Add("Id", Type.GetType("System.Int32"))
        table.Columns.Add("Value", Type.GetType("System.String"))
        table.Columns.Add("Name", Type.GetType("System.String"))

        'assinging the datagridview to use 'table' as data source
        DataGridViewVars.DataSource = table

        textbox_value_editor.DataBindings.Add("Text", table, "Value")

        'disabling tabs and buttons INITIALIZATION process

        Dim tabPg As TabPage

        For Each tabPg In TabControl1.TabPages
            If Not tabPg.Text = "Saveword" Then
                tabPg.Enabled = False
            End If
        Next

    End Sub


    Private Sub button_loadsvwd_Click(sender As Object, e As EventArgs) Handles button_loadsvwd.Click

        'First enable and unlock tabs to do work

        Dim tabPg As TabPage

        For Each tabPg In TabControl1.TabPages
            tabPg.Enabled = True
        Next

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
            Dim rinput As String = boxSaveword1.Text
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

            For Each tabPg In TabControl1.TabPages
                If Not tabPg.Text = "Saveword" Then
                    tabPg.Enabled = False
                End If
            Next

            Return

        End Try

        'ONLY RUNS FOR SAVEWORD 2
        If savewords = 2 Or savewords = 3 Then

            Try
                Dim rinput As String = boxSaveword2.Text
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

                For Each tabPg In TabControl1.TabPages
                    If Not tabPg.Text = "Saveword" Then
                        tabPg.Enabled = False
                    End If
                Next
                Return 'ends sub here
            End Try

        End If

        'Saveword 3 Specific

        If savewords = 3 Then

            Try
                Dim rinput As String = boxSaveword3.Text
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

                For Each tabPg In TabControl1.TabPages
                    If Not tabPg.Text = "Saveword" Then
                        tabPg.Enabled = False
                    End If
                Next
                Return 'ends sub here

            End Try

        End If

        'ENDING SAVEWORD 3

        'determine finishing tasks whether saveword loaded or not
        If SaveLoadCompleted1 = True Then

            MsgBox("Saveword Part 1 import complete!", vbInformation, "Import success")
            LabelSaveStatus.Text = "Saveword Loaded"
            LabelSaveStatus.ForeColor = Color.Olive

            RunAnnotateVars()


        End If

        'tasks for saveword 2

        If SaveLoadCompleted2 = True AndAlso savewords > 1 Then

            MsgBox("Saveword Part 2 import complete!", vbInformation, "Import success")
            LabelSaveStatus.Text = "Saveword1,2 Loaded"
            LabelSaveStatus.ForeColor = Color.Olive

            RunAnnotateVars2()

        End If

        'tasks for saveword 3

        If SaveLoadCompleted3 = True AndAlso savewords = 3 Then

            MsgBox("Saveword Part 3 import complete!", vbInformation, "Import success")
            LabelSaveStatus.Text = "Saveword1,2,3 Loaded"
            LabelSaveStatus.ForeColor = Color.Olive

            RunAnnotateVars3()

        ElseIf SaveLoadCompleted3 = False And savewords = 3 Then

            MsgBox("Saveword 3 has not been loaded. Savewords 1 and 2 are loaded normally. You can use the program as is or try loading saveword 3 again.", vbExclamation, "Caution")

        End If

    End Sub

    Private Sub checkboxsave2_Click(sender As Object, e As EventArgs) Handles checkboxsave2.Click

        If checkboxsave2.Checked = False Then

            boxSaveword2.Enabled = True
            If boxSaveword3.Enabled = False Then
                savewords = 2
            End If

        ElseIf checkboxsave2.Checked = True Then

            boxSaveword2.Enabled = False
            boxSaveword3.Enabled = False
            checkboxsave3.Checked = True
            savewords = 1

        End If

    End Sub

    Private Sub checkboxsave3_Click(sender As Object, e As EventArgs) Handles checkboxsave3.Click

        If boxSaveword2.Enabled = True Then

            If checkboxsave3.Checked = False Then

                boxSaveword3.Enabled = True
                savewords = 3

            ElseIf checkboxsave3.Checked = True Then

                boxSaveword3.Enabled = False
                savewords = 2

            End If

        ElseIf boxSaveword2.Enabled = False Then


            If boxSaveword3.Enabled = True Then

                checkboxsave3.Checked = True
                boxSaveword3.Enabled = False
                MsgBox("Sorry, you cannot enable saveword part 3 without enabling part 2.")
                savewords = 2

            ElseIf boxSaveword3.Enabled = False Then

                MsgBox("Sorry, you cannot enable saveword part 3 without enabling part 2.")
                checkboxsave3.Checked = True
                savewords = 2

            End If


        End If

    End Sub

    Private Sub button_makesvwd_Click(sender As Object, e As EventArgs) Handles button_makesvwd.Click

        'Terminate if detected database is empty (2.0 safeguard) (improved from v1.0.6)

        If LabelSaveStatus.Text = "Saveword not loaded" Or LabelSaveStatus.Text = "Saveword Exported" Then

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
            boxSaveword1.Text = ""
            boxSaveword1.ReadOnly = True

            'saveword 2 specific tasks
            If savewords > 1 Then
                boxSaveword2.Text = ""
                boxSaveword2.ReadOnly = True
            End If

            'saveword 3 specific tasks
            If savewords = 3 Then
                boxSaveword3.Text = ""
                boxSaveword3.ReadOnly = True
            End If

            LabelSaveStatus.Text = "Saveword not loaded"
            LabelSaveStatus.ForeColor = Color.Black

            'disabling tabs and buttons

            Dim tabPg As TabPage

            For Each tabPg In TabControl1.TabPages
                If Not tabPg.Text = "Saveword" Then
                    tabPg.Enabled = False
                End If
            Next

            'buttons now

            button_loadsvwd.Enabled = False
            button_makesvwd.Enabled = False

            checkboxsave2.Enabled = False
            checkboxsave3.Enabled = False



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

                        boxSaveword1.Text = boxSaveword1.Text + sval & "}"

                    ElseIf ngxcounter = 60 Then
                        boxSaveword1.Text = boxSaveword1.Text + sval

                    ElseIf ngxcounter > 60 Then
                        MsgBox("FATAL ERROR: Counter overflow occured when processing saveword 1, program terminating to avoid further issues.", vbCritical, "FATAL ERROR")
                        End

                    End If


                Loop

            Catch z As Exception

                MsgBox("Error recreating saveword 1. Exception details: " & z.Message, vbCritical, "Critical Error")

            End Try

            'Only runs when loading 2 or 3 savewords. Exports saveword 2
            If savewords > 1 Then

                boxSaveword2.Text = "chantpartA}" 'first time, out of the loop

                Try

                    Do Until ngxcounter2 = 162 'final value is 161 on table, but because counting from 0, add one

                        Dim row As DataRow = table.Select("Id = " & ngxcounter2).FirstOrDefault()
                        If Not row Is Nothing Then
                            sval2 = row.Item("Value")
                        End If

                        Inc(ngxcounter2)


                        If ngxcounter2 < 162 Then

                            boxSaveword2.Text = boxSaveword2.Text + sval2 & "}"

                        ElseIf ngxcounter2 = 162 Then
                            boxSaveword2.Text = boxSaveword2.Text + sval2

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
            If savewords = 3 Then

                boxSaveword3.Text = "chantpartB}" 'first time, out of the loop

                Try

                    Do Until ngxcounter3 = 225 'final value is 161 on table, but because counting from 0, add one

                        Dim row As DataRow = table.Select("Id = " & ngxcounter3).FirstOrDefault()
                        If Not row Is Nothing Then
                            sval3 = row.Item("Value")
                        End If

                        Inc(ngxcounter3)


                        If ngxcounter3 < 225 Then

                            boxSaveword3.Text = boxSaveword3.Text + sval3 & "}"

                        ElseIf ngxcounter3 = 225 Then
                            boxSaveword3.Text = boxSaveword3.Text + sval3

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

            LabelSaveStatus.Text = "Saveword Exported"
            LabelSaveStatus.ForeColor = Color.Blue

            MsgBox("Saveword successfully exported.", vbInformation, "Export success")



            'Finally, enable clear button

            button_unlockclear.Visible = True
            button_unlockclear.Enabled = True

            'Enabling copy buttons

            but_copy_1.Visible = True
            but_copy_1.Enabled = True
            but_copy_2.Visible = True
            but_copy_2.Enabled = True
            but_copy_3.Visible = True
            but_copy_3.Enabled = True


        End If



    End Sub

    Private Sub button_unlockclear_Click(sender As Object, e As EventArgs) Handles button_unlockclear.Click


        Select Case MsgBox("Unlocking buttons and clearing memory. Are you sure?", vbOKCancel + vbQuestion, "Clearing Memory")
            Case MsgBoxResult.Ok


                'do some cleanup, then set failsafe conditions
                boxSaveword1.Text = ""
                boxSaveword1.ReadOnly = False

                boxSaveword2.Text = ""
                boxSaveword2.ReadOnly = False
                boxSaveword2.Enabled = False
                checkboxsave2.Checked = True

                boxSaveword3.Text = ""
                boxSaveword3.ReadOnly = False
                boxSaveword3.Enabled = False
                checkboxsave3.Checked = True

                LabelSaveStatus.Text = "Saveword not loaded"
                LabelSaveStatus.ForeColor = Color.Black


                'buttons now

                button_loadsvwd.Enabled = True
                button_makesvwd.Enabled = True

                checkboxsave2.Enabled = True
                checkboxsave3.Enabled = True

                'disabling copy buttons

                but_copy_1.Visible = False
                but_copy_1.Enabled = False
                but_copy_2.Visible = False
                but_copy_2.Enabled = False
                but_copy_3.Visible = False
                but_copy_3.Enabled = False

                'self destruct sequence x(

                button_unlockclear.Enabled = False
                button_unlockclear.Visible = False

            Case MsgBoxResult.Cancel


        End Select



    End Sub

    'Handling clipboard copies

    Private Sub but_copy_1_Click(sender As Object, e As EventArgs) Handles but_copy_1.Click

        Try
            Dim strSaveword1 As String = boxSaveword1.Text
            My.Computer.Clipboard.SetText(strSaveword1)

            If strSaveword1 = My.Computer.Clipboard.GetText() Then

                MsgBox("Copied to clipboard", vbInformation, "Copy success")

            Else

                MsgBox("Copying to clipboard failed on selfcheck routine but did not trigger exception. This is not supposed to happen. You might have software interfering with clipboard access.")

            End If


        Catch z As Exception
            MsgBox("Error when copying to clipboard. Details: " & z.Message, vbCritical, "Critical Error")

        End Try



    End Sub

    Private Sub but_copy_2_Click(sender As Object, e As EventArgs) Handles but_copy_2.Click

        Try
            Dim strSaveword2 As String = boxSaveword2.Text
            My.Computer.Clipboard.SetText(strSaveword2)

            If strSaveword2 = My.Computer.Clipboard.GetText() Then

                MsgBox("Copied to clipboard", vbInformation, "Copy success")

            Else

                MsgBox("Copying to clipboard failed on selfcheck routine but did not trigger exception. This is not supposed to happen. You might have software interfering with clipboard access.")

            End If


        Catch z As Exception
            MsgBox("Error when copying to clipboard. Details: " & z.Message, vbCritical, "Critical Error")

        End Try



    End Sub

    Private Sub but_copy_3_Click(sender As Object, e As EventArgs) Handles but_copy_3.Click

        Try
            Dim strSaveword3 As String = boxSaveword3.Text
            My.Computer.Clipboard.SetText(strSaveword3)

            If strSaveword3 = My.Computer.Clipboard.GetText() Then

                MsgBox("Copied to clipboard", vbInformation, "Copy success")

            Else

                MsgBox("Copying to clipboard failed on selfcheck routine but did not trigger exception. This is not supposed to happen. You might have software interfering with clipboard access.", vbCritical, "Critical Error")

            End If


        Catch z As Exception
            MsgBox("Error when copying to clipboard. Details: " & z.Message, vbCritical, "Critical Error")

        End Try



    End Sub





    Private Sub button_update_Click(sender As Object, e As EventArgs) Handles button_update.Click
        RunUpdateTextBoxPriority()
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
                    'DataGridViewVars.RowsDefaultCellStyle.SelectionBackColor = Color.DimGray
                    irowindex = DataGridViewVars.SelectedCells.Item(0).Value
                    'MessageBox.Show(irowindex)
                    Exit For
                End If
            End If
        Next

    End Sub

    Function Inc(ByRef i As Integer)
        i = i + 1
    End Function

    Function RunUpdateTextBoxPriority()


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

    End Function

    Function RunAnnotateVars()

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

    End Function

    Function RunAnnotateVars2()

        Dim index As Integer = 59 '59 -> 60 - 1 because of 0 start

        DataGridViewVars.Rows(index).Cells(2).Value = "ChantB starts here, not done yet."
        Inc(index)



    End Function

    Function RunAnnotateVars3()

    End Function

End Class
