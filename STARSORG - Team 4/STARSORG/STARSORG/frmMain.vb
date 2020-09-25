Public Class frmMain
    Private MainInfo As frmMain
    Private RoleInfo As frmRole
    Private LoginInfo As frmLogin
    Private EventInfo As frmEvent
    Private RSVPInfo As frmEvent_RSVP
    Private CourseInfo As frmCourse
    Private Help As frmHelp
    Private AdminInfo As frmAdmin
    Private Member As frmMembers
    Private SemesterInfo As frmSemester

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
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter, tsbAdmin.MouseEnter, tsbEvent.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogOut.MouseEnter, tsbMember.MouseEnter, tsbRole.MouseEnter, tsbRSVP.MouseEnter, tsbSemester.MouseEnter
        'we need to do this only because we are not putting our images in the image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave, tsbAdmin.MouseLeave, tsbEvent.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogOut.MouseLeave, tsbMember.MouseLeave, tsbRole.MouseLeave, tsbRSVP.MouseLeave, tsbSemester.MouseLeave
        'we need to do this only because we are not putting our images in the image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub
#End Region
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        RoleInfo = New frmRole
        MainInfo = New frmMain
        LoginInfo = New frmLogin
        EventInfo = New frmEvent
        CourseInfo = New frmCourse
        Help = New frmHelp
        AdminInfo = New frmAdmin
        RSVPInfo = New frmEvent_RSVP
        SemesterInfo = New frmSemester
        Member = New frmMembers
        Try
            myDB.OpenDB()
        Catch ex As Exception
            MessageBox.Show("Unable to open database. Connection String = " & gstrConn, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EndProgram()
        End Try
    End Sub
    Private Sub EndProgram()
        'Close each form except main
        Dim f As Form
        Me.Cursor = Cursors.WaitCursor
        For Each f In Application.OpenForms
            If f.Name <> Me.Name Then
                If Not f Is Nothing Then
                    f.Close()
                End If
            End If
        Next
        'close database connection
        If Not objSQLConn Is Nothing Then
            objSQLConn.Close()
            objSQLConn.Dispose()
        End If
        Me.Cursor = Cursors.Default
        Application.Exit()
    End Sub
#Region "ToolBar Click Event"
    Private Sub tsbRole_Click(sender As Object, e As EventArgs) Handles tsbRole.Click
        Me.Hide()
        RoleInfo.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbEvent_Click(sender As Object, e As EventArgs) Handles tsbEvent.Click
        Me.Hide()
        EventInfo.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub
    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) Handles tsbCourse.Click
        Me.Hide()
        CourseInfo.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub
    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click
        Me.Show()
    End Sub
    Private Sub tsbRSVP_Click(sender As Object, e As EventArgs) Handles tsbRSVP.Click
        Me.Hide()
        RSVPInfo.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub
    Private Sub tsbSemester_Click(sender As Object, e As EventArgs) Handles tsbSemester.Click
        Me.Hide()
        SemesterInfo.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub
    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        Me.Hide()
        Help.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub
    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        Me.Hide()
        Member.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub
    Private Sub tsbAdmin_Click(sender As Object, e As EventArgs) Handles tsbAdmin.Click
        Me.Hide()
        AdminInfo.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub
#End Region
    Private Sub PerformNextAction()
        'get the next action on the child form, and then simiulate the click of that button here
        Select Case intNextAction
            Case ACTION_COURSE
                tsbCourse.PerformClick()
            Case ACTION_EVENT
                tsbEvent.PerformClick()
            Case ACTION_HELP
                tsbHelp.PerformClick()
            Case ACTION_HOME
                tsbHome.PerformClick()
            Case ACTION_LOGOUT
                tsbLogOut.PerformClick()
                EndProgram()
            Case ACTION_MEMBER
                tsbMember.PerformClick()
            Case ACTION_NONE
                'nothing to do here
            Case ACTION_ROLE
                tsbRole.PerformClick()
            Case ACTION_RSVP
                tsbRSVP.PerformClick()
            Case ACTION_ADMIN
                tsbAdmin.PerformClick()
            Case ACTION_SEMESTER
                tsbSemester.PerformClick()
            Case Else
                MessageBox.Show("Unexpected Case Value in frmMain:PerformNextAction", "Perform error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    Private Sub tsbLogOut_Click(sender As Object, e As EventArgs) Handles tsbLogOut.Click
        EndProgram()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If blnFirstTime Then
            Me.Hide()
            frmLogin.ShowDialog()

        End If
        If Not blnFirstTime Then
            Me.Show()
            secPrivAccess()
        End If
        lblMemInfo.Text = ("Panther ID: " & strPID & vbCrLf & "User ID: " & strUserID & vbCrLf & "Security Role: " & strSecRole)
    End Sub



End Class
