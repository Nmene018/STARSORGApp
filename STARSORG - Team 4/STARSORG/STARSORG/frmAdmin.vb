Imports System.Data.SqlClient
Public Class frmAdmin
    Private objSecurities As CSecurities
    Private blnClearing As Boolean
    Private Admin As frmAdmin
#Region "toolbar stuff"
#Region "textboxes"
    Private Sub txtboxes_gotfocus(sender As Object, e As EventArgs) Handles txtAdminPID.GotFocus, txtAdminPID.GotFocus
        Dim txtbox As TextBox
        txtbox = DirectCast(sender, TextBox)
        txtbox.SelectAll()
    End Sub
    Private Sub txtboxes_lostfocus(sender As Object, e As EventArgs) Handles txtAdminPID.LostFocus, txtAdminPID.LostFocus
        Dim txtbox As TextBox
        txtbox = DirectCast(sender, TextBox)
        txtbox.DeselectAll()
    End Sub
#End Region
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

    Private Sub tsbproxy_mouseenter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter, tsbAdmin.MouseEnter, tsbEvent.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogOut.MouseEnter, tsbMember.MouseEnter, tsbRole.MouseEnter, tsbRSVP.MouseEnter, tsbSemester.MouseEnter
        'we need to do this only because we are not putting our images in the image property of the toolbar buttons
        Dim tsbproxy As ToolStripButton
        tsbproxy = DirectCast(sender, ToolStripButton)
        tsbproxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbproxy_mouseleave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave, tsbAdmin.MouseLeave, tsbEvent.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogOut.MouseLeave, tsbMember.MouseLeave, tsbRole.MouseLeave, tsbRSVP.MouseLeave, tsbSemester.MouseLeave
        'we need to do this only because we are not putting our images in the image property of the toolbar buttons
        Dim tsbproxy As ToolStripButton
        tsbproxy = DirectCast(sender, ToolStripButton)
        tsbproxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub

    Private Sub tsbcourse_click(sender As Object, e As EventArgs) Handles tsbCourse.Click
        intNextAction = ACTION_COURSE
        Me.Hide()
    End Sub

    Private Sub tsbevent_click(sender As Object, e As EventArgs) Handles tsbEvent.Click
        intNextAction = ACTION_EVENT
        Me.Hide()
    End Sub

    Private Sub tsbhelp_click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        intNextAction = ACTION_HELP
        Me.Hide()
    End Sub

    Private Sub tsbhome_click(sender As Object, e As EventArgs) Handles tsbHome.Click
        intNextAction = ACTION_HOME
        Me.Hide()
    End Sub

    Private Sub tsblogout_click(sender As Object, e As EventArgs) Handles tsbLogOut.Click
        intNextAction = ACTION_LOGOUT
        Me.Hide()
    End Sub

    Private Sub tsbmember_click(sender As Object, e As EventArgs) Handles tsbMember.Click
        intNextAction = ACTION_MEMBER
        Me.Hide()
    End Sub

    Private Sub tsbrole_click(sender As Object, e As EventArgs) Handles tsbRole.Click
        intNextAction = ACTION_ROLE
        Me.Hide()
    End Sub

    Private Sub tsbrsvp_click(sender As Object, e As EventArgs) Handles tsbRSVP.Click
        intNextAction = ACTION_RSVP
        Me.Hide()
    End Sub
    Private Sub tsbsemester_click(sender As Object, e As EventArgs) Handles tsbSemester.Click
        intNextAction = ACTION_SEMESTER
        Me.Hide()
    End Sub
    Private Sub tsbadmin_click(sender As Object, e As EventArgs) Handles tsbAdmin.Click

    End Sub
#End Region
    Private Sub LoadSecurities()
        Dim objDR As SqlDataReader
        Try
            objDR = objSecurities.GetAllSecurities
            objDR.Close()
        Catch ex As Exception
            MessageBox.Show("Failed to Load Security Information: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objSecurities = New CSecurities
        objSecurities.CurrentObject.isNewSecurity = False
    End Sub
    Private Sub LoadSelectedRecord()
        Try
            With objSecurities.CurrentObject
                .PID = txtAdminPID.Text
                .UserID = txtUserID.Text
                .SecRole = lstSecPriv.SelectedItem.ToString()
                .Password = txtAdminPassword.Text
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading Security Values: " & ex.ToString, "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmAdmin_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ClearScreenControls(Me)
        LoadSecurities()
        lstSecPriv.Items.Add("ADMIN")
        lstSecPriv.Items.Add("OFFICER")
        lstSecPriv.Items.Add("MEMBER")
        lstSecPriv.Items.Add("GUEST")
        grpMemSec.Enabled = False
        Admin = New frmAdmin
        secprivaccess()
        txtAdminOrgPass.Focus()
        lblMemInfo.Text = ("Panther ID: " & strPID & vbCrLf & "User ID: " & strUserID & vbCrLf & "Security Role: " & strSecRole)
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        errP.Clear()
        Dim intResult As Integer
        Dim blnErrors As Boolean
        tslStatus.Text = ""
#Region "Validation"
        If Not ValidateTextBoxLength(txtAdminPID, errP) Then
            errP.SetError(txtAdminPID, "Please enter a valid Panther ID.")
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtAdminPassword, errP) Then
            errP.SetError(txtAdminPassword, "Please enter a valid Password.")
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtUserID, errP) Then
            errP.SetError(txtUserID, "Please enter a valid User ID.")
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtAdminConfirmMember, errP) Then
            errP.SetError(txtAdminConfirmMember, "Please enter a valid Password.")
            blnErrors = True
        End If
        If lstSecPriv.SelectedIndex = -1 Then
            errP.SetError(lstSecPriv, "Please enter a Security Role.")
            blnErrors = True
        End If
        If Not txtAdminConfirmMember.Text = txtAdminPassword.Text Then
            errP.SetError(txtAdminConfirmMember, "Must match previous entry.")
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
#End Region

        With objSecurities.CurrentObject
            .PID = txtAdminPID.Text
            .UserID = txtUserID.Text
            .SecRole = lstSecPriv.SelectedItem.ToString()
            .Password = txtAdminPassword.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objSecurities.CreateUser
            If intResult = 1 Then
                grpMemSec.Enabled = True
                lstNewMemInfo.Items.Add("Panther ID: " & objSecurities.CurrentObject.PID)
                lstNewMemInfo.Items.Add("User ID: " & objSecurities.CurrentObject.UserID)
                lstNewMemInfo.Items.Add("Password: " & objSecurities.CurrentObject.Password)
                lstNewMemInfo.Items.Add("Security Privilege: " & objSecurities.CurrentObject.SecRole)
                tslStatus.Text = "Account Security record saved"
            End If
            If intResult = -1 Then
                MessageBox.Show("Panther ID must be unique. Unable to save Security record", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Error"
                grpAdmin.Enabled = True
                grpMemSec.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to save account security record: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Error"
            grpAdmin.Enabled = True
            grpMemSec.Enabled = False
        End Try
        Me.Cursor = Cursors.Default
        'LoadSecurities() 'reload
        grpAdmin.Enabled = True
    End Sub
    Private Sub btnAdminSave_Click(sender As Object, e As EventArgs) Handles btnAdminSave.Click
        errP.Clear()
        Dim blnErrors As Boolean
        If Not ValidateTextBoxLength(txtAdminOrgPass, errP) Then
            errP.SetError(txtAdminOrgPass, "Please enter a valid Original Password.")
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtAdminConfirmPass, errP) Then
            errP.SetError(txtAdminConfirmPass, "Please enter a valid Password.")
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtAdminNewPass, errP) Then
            errP.SetError(txtAdminNewPass, "Please enter a valid Password.")
            blnErrors = True
        End If
        If Not txtAdminConfirmPass.Text = txtAdminNewPass.Text Then
            errP.SetError(txtAdminConfirmPass, "Must match previous entry.")
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        Dim intChangePass As Integer
        With objSecurities.CurrentObject
            .UserID = txtAdminOrgPass.Text
            .Password = txtAdminConfirmPass.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intChangePass = objSecurities.ChangePassword
            If intChangePass = 1 Then
                tslStatus.Text = "Password Changed"
            End If
            If intChangePass = -1 Then
                tslStatus.Text = "Old Password does not exist under a record"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to save account security record: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Error"
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnChgPassCancel_Click(sender As Object, e As EventArgs) Handles btnChgPassCancel.Click
        blnClearing = True
        tslStatus.Text = ""
        errP.Clear()
        txtAdminOrgPass.Clear()
        txtAdminNewPass.Clear()
        txtAdminConfirmPass.Clear()
        If lstNewMemInfo.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'reload what was selected in case user had messed up the form
        Else
            grpMemSec.Enabled = False
        End If
        objSecurities.CurrentObject.isNewSecurity = False
        grpAdmin.Enabled = True
    End Sub

    Private Sub btnCrtCancel_Click(sender As Object, e As EventArgs) Handles btnCrtCancel.Click
        blnClearing = True
        tslStatus.Text = ""
        errP.Clear()
        txtAdminPID.Clear()
        txtUserID.Clear()
        txtAdminPassword.Clear()
        txtAdminConfirmMember.Clear()
        lstNewMemInfo.Items.Clear()
        grpMemSec.Enabled = False
        objSecurities.CurrentObject.isNewSecurity = False
        grpAdmin.Enabled = True
    End Sub

End Class