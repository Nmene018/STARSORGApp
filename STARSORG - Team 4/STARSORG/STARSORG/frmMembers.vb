Imports System.IO
Imports System.Data.SqlClient
Public Class frmMembers
    Private objMembers As CMembers
    Private blnClearing As Boolean
    Private blnReloading As Boolean

#Region "ToolBar Stuff"
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
#Region "ToolBar Display"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter, tsbEvent.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogOut.MouseEnter, tsbMember.MouseEnter, tsbRole.MouseEnter, tsbRSVP.MouseEnter, tsbSemester.MouseEnter
        'we need to do this only because we are not putting our images in the image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave, tsbEvent.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogOut.MouseLeave, tsbMember.MouseLeave, tsbRole.MouseLeave, tsbRSVP.MouseLeave, tsbSemester.MouseLeave
        'we need to do this only because we are not putting our images in the image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub
#End Region
#Region "ToolBar Click Event"
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

    End Sub

    Private Sub tsbRole_Click(sender As Object, e As EventArgs) Handles tsbRole.Click
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
    Private Sub tsbAdmin_Click(sender As Object, e As EventArgs)
        intNextAction = ACTION_ADMIN
        Me.Hide()
    End Sub

    Private Sub frmEvent_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        lblMemInfo.Text = ("Panther ID: " & strPID & vbCrLf & "User ID: " & strUserID & vbCrLf & "Security Role: " & strSecRole)
    End Sub
#End Region
#End Region
#Region "Textboxes"
    Private Sub txtDesctiption_GotFocus(sender As Object, e As EventArgs) Handles txtPID.GotFocus, txtFirstName.GotFocus, txtLastName.GotFocus, txtMiddleInitial.GotFocus, txtPhone.GotFocus, txtEmail.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub
    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtPID.LostFocus, txtFirstName.LostFocus, txtLastName.LostFocus, txtMiddleInitial.LostFocus, txtPhone.LostFocus, txtEmail.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub
#End Region

    Private Sub LoadMembers()
        Dim objDR As SqlDataReader
        lstMembers.Items.Clear()
        Try
            objDR = objMembers.GetAllMembers()
            Do While objDR.Read
                lstMembers.Items.Add(objDR.Item("PID"))
                'MessageBox.Show("Current Item Being Read: " & objDR.Item("LName"), "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Loop
            objDR.Close()
        Catch ex As Exception
            objDR.Close()
            'could have CDB throw the error and trip it here
        End Try
        If objMembers.CurrentObject.PID <> "" Then
            lstMembers.SelectedIndex = lstMembers.FindStringExact(objMembers.CurrentObject.PID)
        End If
        blnReloading = False
    End Sub

    Private Sub frmRole_Load(sender As Object, e As EventArgs) Handles Me.Load
        objMembers = New CMembers
    End Sub

    Private Sub frmRole_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        LoadMembers()
        ' == Disable edit controls ==
        txtPhotoPath.Enabled = False
        txtPID.Enabled = False
        txtFirstName.Enabled = False
        txtLastName.Enabled = False
        txtMiddleInitial.Enabled = False
        txtPhone.Enabled = False
        txtEmail.Enabled = False
        picMember.ImageLocation = "..\..\Resources\member.png"
        'grpEdit.Enabled = False
    End Sub

    Private Sub lstMembers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMembers.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If blnReloading Then
            tslStatus.Text = ""
            Exit Sub
        End If
        If lstMembers.SelectedIndex = -1 Then
            Exit Sub
        End If
        chkNew.Checked = False
        LoadSelectedRecord()

        picMember.ImageLocation = txtPhotoPath.Text

        ' == Disable edit controls ==
        txtPhotoPath.Enabled = True
        txtPID.Enabled = False
        txtFirstName.Enabled = True
        txtLastName.Enabled = True
        txtMiddleInitial.Enabled = True
        txtPhone.Enabled = True
        txtEmail.Enabled = True
    End Sub
    Private Sub LoadSelectedRecord()
        Try
            objMembers.GetMemberByPID(lstMembers.SelectedItem.ToString)
            With objMembers.CurrentObject
                txtPID.Text = .PID
                txtFirstName.Text = .FName
                txtLastName.Text = .LName
                txtMiddleInitial.Text = .MI
                txtEmail.Text = .Email
                txtPhone.Text = .Phone
                txtPhotoPath.Text = .PhotoPath
            End With
        Catch ex As Exception
            MessageBox.Show("Error Loading Role values: " & ex.ToString, "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        chkNew.Checked = False
        objMembers.CurrentObject.IsNewMember = False

    End Sub

    Private Sub chkNew_CheckedChanged(sender As Object, e As EventArgs) Handles chkNew.CheckedChanged
        If blnClearing Then
            Exit Sub
        End If
        If chkNew.Checked Then
            tslStatus.Text = ""

            ' == Clear inputs ==
            txtPID.Clear()
            txtFirstName.Clear()
            txtLastName.Clear()
            txtMiddleInitial.Clear()
            txtEmail.Clear()
            txtPhone.Clear()
            txtPhotoPath.Clear()

            txtPID.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtMiddleInitial.Text = ""
            txtEmail.Text = ""
            txtPhone.Text = ""
            txtPhotoPath.Text = ""
            picMember.ImageLocation = "..\..\Resources\member.png"

            'end inputs

            lstMembers.SelectedIndex = -1
            ' == Disable Controles ==
            lstMembers.Enabled = False

            txtPhotoPath.Enabled = True
            txtPID.Enabled = True
            txtFirstName.Enabled = True
            txtLastName.Enabled = True
            txtMiddleInitial.Enabled = True
            txtPhone.Enabled = True
            txtEmail.Enabled = True
            'grpRoles.Enabled = False
            'grpEdit.Enabled = True
            'end controls

            'Focus on PID
            txtPID.Focus()

            objMembers.CreateNewMember()
        Else
            ' == Disable Controles ==
            lstMembers.Enabled = True

            txtPhotoPath.Enabled = False
            txtPID.Enabled = False
            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            txtMiddleInitial.Enabled = False
            txtPhone.Enabled = False
            txtEmail.Enabled = False
            'grpRoles.Enabled = False
            'grpEdit.Enabled = True
            'end controls

            objMembers.CurrentObject.IsNewMember = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim intResult As Integer
        Dim blnErrors As Boolean
        tslStatus.Text = ""
        '-------- add your validation code here ----------
        If Not ValidateTextBoxLength(txtPID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtFirstName, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtLastName, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtMiddleInitial, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtEmail, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtPhone, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtPhotoPath, errP) Then
            blnErrors = True
        End If


        If blnErrors Then
            Exit Sub
        End If
        With objMembers.CurrentObject
            .PID = txtPID.Text
            .FName = txtFirstName.Text
            .LName = txtLastName.Text
            .MI = txtMiddleInitial.Text
            .Email = txtEmail.Text
            .Phone = txtPhone.Text
            .PhotoPath = txtPhotoPath.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objMembers.Save
            If intResult = 1 Then
                tslStatus.Text = "objMember record saved"
            End If
            If intResult = -1 Then 'Member ID was not unique when adding a new record
                MessageBox.Show("PID must be unique. Unable to save Member record", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Error"
            End If
            If intResult = -2 Then 'Member Role does not exist
                MessageBox.Show("No 'member' role exists\n Please create one", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Error"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to save Member record " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Error"
        End Try

        Me.Cursor = Cursors.Default
        blnReloading = True
        LoadMembers() 'reload so that a newly saved record will apepar in the list
        chkNew.Checked = False
        objMembers.CurrentObject.IsNewMember = False
        'grpRoles.Enabled = True 'in case it was disabled for a new record
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'Clear Inputs
        'txtPID.Clear()
        'txtFirstName.Clear()
        'txtLastName.Clear()
        'txtMiddleInitial.Clear()
        'txtEmail.Clear()
        'txtPhone.Clear()
        'txtPhotoPath.Clear()

        txtPID.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtMiddleInitial.Text = ""
        txtEmail.Text = ""
        txtPhone.Text = ""
        txtPhotoPath.Text = ""

        picMember.ImageLocation = "..\..\Resources\member.png"

        lstMembers.SelectedIndex = -1
        txtPID.Focus()

        objMembers.CreateNewMember()

        blnClearing = True
        tslStatus.Text = ""
        chkNew.Checked = False
        errP.Clear()
        If lstMembers.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'reload what was sdelected in case user had messed up the form
        Else
            txtPhotoPath.Enabled = True
            txtPID.Enabled = True
            txtFirstName.Enabled = True
            txtLastName.Enabled = True
            txtMiddleInitial.Enabled = True
            txtPhone.Enabled = True
            txtEmail.Enabled = True

            chkNew.Checked = True
            'grpEdit.Enabled = False
            Exit Sub
        End If
        blnClearing = False
        objMembers.CurrentObject.IsNewMember = False
        lstMembers.Enabled = True
        'grpRoles.Enabled = True
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'show the open file dialog, then get the results from that dialog
        ofdOpen.ShowDialog()
        txtPhotoPath.Text = ofdOpen.FileName
        picMember.ImageLocation = txtPhotoPath.Text
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim objDR As SqlDataReader
        Try
            objDR = objMembers.GetMemberByLName(txtSearch.Text)
            lstMembers.Items.Clear()
            Do While objDR.Read
                lstMembers.Items.Add(objDR.Item("PID"))
            Loop
            objDR.Close()
        Catch ex As Exception
            objDR.Close()
            'could have CDB throw the error and trip it here
        End Try
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim MemberReport As New frmMemberReport
        If lstMembers.Items.Count = 0 Then
            MessageBox.Show("THere are no records to print")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        MemberReport.Display()
        Me.Cursor = Cursors.Default
    End Sub
End Class