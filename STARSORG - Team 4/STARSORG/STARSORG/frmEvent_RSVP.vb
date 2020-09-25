Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class frmEvent_RSVP
    Private objRSVP As CEvents_RSVP
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

    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbSemester.MouseEnter, tsbRSVP.MouseEnter, tsbMember.MouseEnter, tsbMember.MouseEnter, tsbLogOut.MouseEnter, tsbHome.MouseEnter, tsbHelp.MouseEnter, tsbEvent.MouseEnter, tsbCourse.MouseEnter
        'we need to do this only because we are not puttng out images in the image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbSemester.MouseLeave, tsbRSVP.MouseLeave, tsbMember.MouseLeave, tsbMember.MouseLeave, tsbLogOut.MouseLeave, tsbHome.MouseLeave, tsbHelp.MouseLeave, tsbEvent.MouseLeave, tsbCourse.MouseLeave
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
        intNextAction = ACTION_EVENT
        Me.Hide()


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
        'no action needed - we are already on the ROLE form

    End Sub

    Private Sub tsbSemester_Click(sender As Object, e As EventArgs) Handles tsbSemester.Click
        intNextAction = ACTION_SEMESTER
        Me.Hide()
    End Sub

#End Region
#Region "Text boxes"
    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtLName.GotFocus, txtFName.GotFocus, txtDesc.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub
    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtLName.LostFocus, txtFName.LostFocus, txtDesc.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub
#End Region
    Private Sub LoadEvents()
        Dim objDR As SqlDataReader
        cboEventID.Items.Clear()
        Try
            objDR = objEvents.GetAllEvents()
            Do While objDR.Read
                cboEventID.Items.Add(objDR.Item("EventID"))
            Loop
            objDR.Close()
        Catch ex As Exception
            'could have CDB throw the error and trap it here
        End Try
        If objEvents.CurrentObject.EventID <> "" Then
            cboEventID.SelectedIndex = cboEventID.FindStringExact(objEvents.CurrentObject.EventID)
        End If
        blnReloading = False
    End Sub
    Private Sub frmEvent_RSVP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objRSVP = New CEvents_RSVP
        objEvents = New CEvents
    End Sub
    Private Sub frmEvent_RSVP_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ClearScreenControls(Me)
        LoadEvents()
        grpEdit.Enabled = False
        lblMemInfo.Text = ("Panther ID: " & strPID & vbCrLf & "User ID: " & strUserID & vbCrLf & "Security Role: " & strSecRole)
    End Sub
    Private Sub cboEventID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEventID.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If blnReloading Then
            tslStatus.Text = ""
            Exit Sub
        End If
        If cboEventID.SelectedIndex = -1 Then
            Exit Sub
        End If
        LoadSelectedRecord()
        grpEdit.Enabled = True
        ClearRSVP()
    End Sub
    Private Sub LoadSelectedRecord()
        Try
            objEvents.GetEventByEventID(cboEventID.SelectedItem.ToString)
            With objEvents.CurrentObject
                cboEventID.Text = .EventID
                txtDesc.Text = .EventDescription

            End With
        Catch ex As Exception
            MessageBox.Show("Error loading Event values: " & ex.ToString, "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnRSVP_Click(sender As Object, e As EventArgs) Handles btnRSVP.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        Dim pattern = "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
        tslStatus.Text = ""
        '----add your validation code here----
        If Not ValidateTextBoxLength(txtFName, errP) Then
            blnErrors = True
        End If
        If Not Regex.Match(txtFName.Text, "^[a-z]*$", RegexOptions.IgnoreCase).Success Then
            blnErrors = True
            errP.SetIconAlignment(txtFName, ErrorIconAlignment.MiddleLeft)
            errP.SetError(txtFName, "Alphabetical letters only.")
            txtFName.Focus()
        End If
        If Not ValidateTextBoxLength(txtLName, errP) Then
            blnErrors = True
        End If
        If Not Regex.Match(txtLName.Text, "^[a-z]*$", RegexOptions.IgnoreCase).Success Then
            blnErrors = True
            errP.SetIconAlignment(txtLName, ErrorIconAlignment.MiddleLeft)
            errP.SetError(txtLName, "Alphabetical letters only.")
            txtLName.Focus()
        End If
        If Not ValidateTextBoxLength(txtEmail, errP) Then
            blnErrors = True
        End If
        If Not Regex.Match(txtEmail.Text, pattern).Success Then
            blnErrors = True
            errP.SetIconAlignment(txtEmail, ErrorIconAlignment.MiddleLeft)
            errP.SetError(txtEmail, "Please input valid email address.")
            txtEmail.Focus()
        End If
        If blnErrors Then
            Exit Sub
        End If
        With objRSVP.CurrentObject
            .EventID = cboEventID.Text
            .FName = txtFName.Text
            .LName = txtLName.Text
            .Email = txtEmail.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objRSVP.Save
            If intResult = 1 Then
                tslStatus.Text = "RSVP saved"
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
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        ClearRSVP()
        errP.Clear()
        If cboEventID.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'reload what was selected in case user had messed up the form
        Else
            grpEdit.Enabled = False

        End If
        blnClearing = False
        objRSVP.CurrentObject.IsNewEvent_RSVP = False
    End Sub
    Public Sub ClearRSVP()
        tslStatus.Text = ""
        txtFName.Clear()
        txtLName.Clear()
        txtEmail.Clear()
        grpEdit.Enabled = True
    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim RSVPReport As New frmRSVPReport
        If cboEventID.Items.Count = 0 Then
            MessageBox.Show("There are no records to print")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        RSVPReport.Display()
        Me.Cursor = Cursors.Default
    End Sub
End Class