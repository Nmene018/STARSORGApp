Imports System.Data.SqlClient
Public Class frmEvent
    Private objEvents As CEvents
    Private blnClearing As Boolean
    Private blnReloading As Boolean
#Region "Toolbar stuff"
#Region "Security Privileges"
    Public Sub secPrivAccess()
        If strSecRole = "GUEST" Then
            tsbHome.Enabled = True
            tsbRole.Enabled = False
            tsbMember.Enabled = False
            tsbEvent.Enabled = False
            tsbRSVP.Enabled = True
            tsbCourse.Enabled = False
            tsbSemester.Enabled = False
            tsbAdmin.Enabled = False
            tsbHelp.Enabled = True
            tsbLogOut.Enabled = True
        End If
        If strSecRole = "MEMBER" Then
            tsbHome.Enabled = True
            tsbMember.Enabled = False
            tsbRole.Enabled = False
            tsbEvent.Enabled = False
            tsbRSVP.Enabled = True
            tsbCourse.Enabled = False
            tsbSemester.Enabled = False
            tsbAdmin.Enabled = False
            tsbHelp.Enabled = True
            tsbLogOut.Enabled = True
        End If
        If strSecRole = "OFFICER" Then
            tsbHome.Enabled = True
            tsbMember.Enabled = True
            tsbMember.Enabled = True
            tsbEvent.Enabled = True
            tsbRSVP.Enabled = True
            tsbCourse.Enabled = True
            tsbSemester.Enabled = True
            tsbAdmin.Enabled = False
            tsbHelp.Enabled = True
            tsbLogOut.Enabled = True
        End If
        If strSecRole = "ADMIN" Then
            tsbHome.Enabled = True
            tsbMember.Enabled = True
            tsbMember.Enabled = True
            tsbEvent.Enabled = True
            tsbRSVP.Enabled = True
            tsbCourse.Enabled = True
            tsbSemester.Enabled = True
            tsbAdmin.Enabled = True
            tsbHelp.Enabled = True
            tsbLogOut.Enabled = True
        End If
    End Sub
#End Region
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbAdmin.MouseEnter, tsbSemester.MouseEnter, tsbRSVP.MouseEnter, tsbMember.MouseEnter, tsbMember.MouseEnter, tsbLogOut.MouseEnter, tsbHome.MouseEnter, tsbHelp.MouseEnter, tsbEvent.MouseEnter, tsbCourse.MouseEnter
        'we need to do this only because we are not puttng out images in the image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbAdmin.MouseLeave, tsbSemester.MouseLeave, tsbRSVP.MouseLeave, tsbMember.MouseLeave, tsbMember.MouseLeave, tsbLogOut.MouseLeave, tsbHome.MouseLeave, tsbHelp.MouseLeave, tsbEvent.MouseLeave, tsbCourse.MouseLeave
        'we need to do this only because we are not puttng out images in the image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub

    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) Handles tsbCourse.Click
        intNextAction = ACTION_COURSE
        Me.Hide()
    End Sub

    Private Sub tsbEvent_Click(sender As Object, e As EventArgs) Handles tsbEvent.Click
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        intNextAction = ACTION_HELP
        Me.Hide()
    End Sub

    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click
        intNextAction = ACTION_HOME
        Me.Hide()
    End Sub

    Private Sub tsbLogOut_Click(sender As Object, e As EventArgs) Handles tsbLogOut.Click
        intNextAction = ACTION_LOGOUT
        Me.Hide()
    End Sub

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        intNextAction = ACTION_MEMBER
        Me.Hide()
    End Sub

    Private Sub tsbRole_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        intNextAction = ACTION_ROLE
        Me.Hide()
    End Sub

    Private Sub tsbRSVP_Click(sender As Object, e As EventArgs) Handles tsbRSVP.Click
        intNextAction = ACTION_RSVP
        Me.Hide()
    End Sub

    Private Sub tsbSemester_Click(sender As Object, e As EventArgs) Handles tsbSemester.Click
        intNextAction = ACTION_SEMESTER
        Me.Hide()
    End Sub

#End Region
#Region "Text boxes"
    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtDesc.GotFocus, txtEventID.GotFocus, txtLocation.GotFocus, txtSemesterID.GotFocus, txtTypeID.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub
    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtEventID.LostFocus, txtDesc.LostFocus, txtLocation.LostFocus, txtSemesterID.LostFocus, txtTypeID.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub
#End Region
    Private Sub LoadEvents()
        Dim objDR As SqlDataReader
        lstEvents.Items.Clear()
        Try
            objDR = objEvents.GetAllEvents()
            Do While objDR.Read
                lstEvents.Items.Add(objDR.Item("EventID"))
            Loop
            objDR.Close()
        Catch ex As Exception
            'could have CDB throw the error and trap it here
        End Try
        If objEvents.CurrentObject.EventID <> "" Then
            lstEvents.SelectedIndex = lstEvents.FindStringExact(objEvents.CurrentObject.EventID)
        End If
        blnReloading = False
    End Sub
    Private Sub frmEvent_Load(sender As Object, e As EventArgs) Handles Me.Load
        objEvents = New CEvents
    End Sub
    Private Sub frmEvent_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        LoadEvents()
        grpEdit.Enabled = False
        lblMemInfo.Text = ("Panther ID: " & strPID & vbCrLf & "User ID: " & strUserID & vbCrLf & "Security Role: " & strSecRole)
    End Sub
    Private Sub lstEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEvents.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If blnReloading Then
            tslStatus.Text = ""
            Exit Sub
        End If
        If lstEvents.SelectedIndex = -1 Then
            Exit Sub
        End If
        chkNew.Checked = False
        LoadSelectedRecord()
        grpEdit.Enabled = True
    End Sub
    Private Sub LoadSelectedRecord()
        Try
            objEvents.GetEventByEventID(lstEvents.SelectedItem.ToString)
            With objEvents.CurrentObject
                txtEventID.Text = .EventID
                txtDesc.Text = .EventDescription
                txtTypeID.Text = .EventTypeID
                txtSemesterID.Text = .SemesterID
                dtpStartDate.Value = .StartDate
                dtpEndDate.Value = .EndDate
                txtLocation.Text = .Location

            End With
        Catch ex As Exception
            MessageBox.Show("Error loading Event values: " & ex.ToString, "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub chkNew_CheckedChanged(sender As Object, e As EventArgs) Handles chkNew.CheckedChanged
        If blnClearing Then
            Exit Sub
        End If
        If chkNew.Checked Then
            tslStatus.Text = ""
            txtEventID.Clear()
            txtDesc.Clear()
            txtLocation.Clear()
            txtSemesterID.Clear()
            txtTypeID.Clear()
            dtpStartDate.Value = DateTime.Now
            dtpEndDate.Value = DateTime.Now
            lstEvents.SelectedIndex = -1
            grpEvents.Enabled = False
            grpEdit.Enabled = True
            txtEventID.Focus()
            objEvents.CreateNewEvent()
        Else
            grpEvents.Enabled = True
            grpEdit.Enabled = False
            objEvents.CurrentObject.isNewEvent = False
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        tslStatus.Text = ""
        '----add your validation code here----
        If Not ValidateTextBoxLength(txtEventID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtDesc, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtTypeID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtSemesterID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtLocation, errP) Then
            blnErrors = True
        End If
        If dtpEndDate.Value < dtpStartDate.Value Then
            blnErrors = True
            errP.SetIconAlignment(dtpEndDate, ErrorIconAlignment.MiddleLeft)
            errP.SetError(dtpEndDate, "Please check End Date again.")
        End If
        If blnErrors Then
            Exit Sub
        End If
        With objEvents.CurrentObject
            .EventID = txtEventID.Text
            .EventDescription = txtDesc.Text
            .EventTypeID = txtTypeID.Text
            .SemesterID = txtSemesterID.Text
            .StartDate = dtpStartDate.Value
            .EndDate = dtpEndDate.Value
            .Location = txtLocation.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objEvents.Save
            If intResult = 1 Then
                tslStatus.Text = "Event record saved"
            End If
            If intResult = -1 Then ' eventID was not unique when adding new record
                MessageBox.Show("EventID must be unique. Unable to save Event record.", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Error"
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to save Event record." & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Error"
        End Try
        Me.Cursor = Cursors.Default
        blnReloading = True
        LoadEvents() 'reload so that a new saved record will appear in the list
        chkNew.Checked = False
        grpEvents.Enabled = True ' in case it was disabled for a new record
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        tslStatus.Text = ""
        chkNew.Checked = False
        errP.Clear()
        If lstEvents.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'reload what was selected in case user had messed up the form
        Else
            grpEdit.Enabled = False

        End If
        blnClearing = False
        objEvents.CurrentObject.isNewEvent = False
        grpEvents.Enabled = True
        dtpStartDate.Value = DateTime.Now
        dtpEndDate.Value = DateTime.Now
    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim EventReport As New frmEventReport
        If lstEvents.Items.Count = 0 Then
            MessageBox.Show("There are no records to print")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        EventReport.Display()
        Me.Cursor = Cursors.Default
    End Sub
End Class