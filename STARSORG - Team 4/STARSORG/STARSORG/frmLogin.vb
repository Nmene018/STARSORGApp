Imports System.Data.SqlClient
Public Class frmLogin
    Public objSecurities As CSecurities
    Private blnClearing As Boolean
    Private blnReloading As Boolean = False
    Private changePass As frmChangePass
    Private login As frmLogin


#Region "textboxes"
    Private Sub txtboxes_gotfocus(sender As Object, e As EventArgs) Handles txtUserID.GotFocus, txtPassword.GotFocus
        Dim txtbox As TextBox
        txtbox = DirectCast(sender, TextBox)
        txtbox.SelectAll()
    End Sub
    Private Sub txtboxes_lostfocus(sender As Object, e As EventArgs) Handles txtUserID.LostFocus, txtPassword.LostFocus
        Dim txtbox As TextBox
        txtbox = DirectCast(sender, TextBox)
        txtbox.DeselectAll()
    End Sub
#End Region
    Private Sub EndProgram()

        Dim f As Form
        Me.Cursor = Cursors.WaitCursor
        If Not objSQLConn Is Nothing Then
            objSQLConn.Close()
            objSQLConn.Dispose()
        End If
        Me.Cursor = Cursors.Default
        Application.Exit()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        tslStatus.Text = ""
        objSecurities.CurrentObject.isNewSecurity = False
        errP.Clear()
        EndProgram()
        lstSecPriv.SelectedIndex = 0
    End Sub

    Private Sub LoadSecurities()
        Dim objDR As SqlDataReader
        Try
            objDR = objSecurities.GetAllSecurities

            objDR.Close()
        Catch ex As Exception
            MessageBox.Show("Failed to Load Security Information: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If objSecurities.CurrentObject.UserID <> "" Then
            txtUserID.Text = objSecurities.CurrentObject.UserID
        End If
    End Sub
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objSecurities = New CSecurities
        objSecurities.CurrentObject.isNewSecurity = False
    End Sub
    Private Sub frmLogin_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ClearScreenControls(Me)
        LoadSecurities()
        changePass = New frmChangePass
        login = New frmLogin
        txtUserID.Focus()
        lstSecPriv.Items.Add("ADMIN")
        lstSecPriv.Items.Add("OFFICER")
        lstSecPriv.Items.Add("MEMBER")
        lstSecPriv.Items.Add("GUEST")
    End Sub
    Private Sub LoadSelectedRecord()
        Try
            With objSecurities.CurrentObject
                txtUserID.Text = .UserID
                txtPassword.Text = .Password
                txtPID.Text = .PID
                .SecRole = lstSecPriv.SelectedItem.ToString()
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading Security Values: " & ex.ToString, "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        objSecurities.CurrentObject.isNewSecurity = False
    End Sub



    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim intResultPID As Double
        Dim blnErrors As Boolean

        tslStatus.Text = ""
        If Not ValidateTextBoxLength(txtUserID, errP) Then
            errP.SetError(txtUserID, "Please enter a valid Panther ID.")
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtPassword, errP) Then
            errP.SetError(txtPassword, "Please enter a valid Password.")
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtPID, errP) Then
            errP.SetError(txtPID, "Please enter a valid Panther ID.")
            blnErrors = True
        End If
        If lstSecPriv.SelectedIndex = -1 Then
            errP.SetError(lstSecPriv, "Please enter a Security Role.")
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        With objSecurities.CurrentObject
            .UserID = txtUserID.Text
            .Password = txtPassword.Text
            .PID = txtPID.Text
            .SecRole = lstSecPriv.SelectedItem.ToString
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResultPID = objSecurities.CheckUserIDExists
            If intResultPID = 1 Then
                tslStatus.Text = "Invalid Username or Password"
                blnReloading = True
            Else
                tslStatus.Text = "Login Successful"
                blnReloading = False
                blnFirstTime = False
                strPID = CStr(objSecurities.CurrentObject.PID)
                strUserID = CStr(objSecurities.CurrentObject.UserID)
                strSecRole = CStr(objSecurities.CurrentObject.SecRole)
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to save account security record: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Error"
            grpLogin.Enabled = True
        End Try
        Me.Cursor = Cursors.Default

        LoadSecurities()
        If blnReloading Then
            Me.Show()
        End If
        If Not blnReloading Then
            Me.Hide()
        End If

    End Sub

    Private Sub btnGuest_Click(sender As Object, e As EventArgs) Handles btnGuest.Click
        Dim intResultPID As Double
        Try
            Me.Cursor = Cursors.WaitCursor
            intResultPID = objSecurities.CreateGuestUser
            If intResultPID Then
                tslStatus.Text = "Login Successful"
                blnReloading = False
                blnFirstTime = False
                strPID = "0000001"
                strUserID = "GUEST"
                strSecRole = "GUEST"
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to save account security record: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Error"
            grpLogin.Enabled = True
        End Try
        Me.Cursor = Cursors.Default
        If blnReloading Then
            Me.Show()
        End If
        If Not blnReloading Then
            Me.Hide()
        End If
    End Sub

    Private Sub btnChangePass_Click(sender As Object, e As EventArgs) Handles btnChangePass.Click
        changePass.ShowDialog()
    End Sub


End Class