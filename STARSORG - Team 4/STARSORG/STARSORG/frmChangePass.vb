Imports System.Data.SqlClient
Public Class frmChangePass
    Private objSecurities As CSecurities
    Private blnClearing As Boolean
    Private changePass As frmChangePass
    Private login As frmLogin

#Region "Textboxes"
    Private Sub txtboxes_GotFocus(sender As Object, e As EventArgs) Handles txtUserID.GotFocus, txtNewPass.GotFocus, txtConfirmPass.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub
    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtUserID.LostFocus, txtNewPass.LostFocus, txtConfirmPass.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
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
    Private Sub frmChangePass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objSecurities = New CSecurities
        objSecurities.CurrentObject.isNewSecurity = False
    End Sub
    Private Sub frmChangePass_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ClearScreenControls(Me)
        LoadSecurities()
        changePass = New frmChangePass
        login = New frmLogin
        txtUserID.Focus()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        errP.Clear()
        Dim blnErrors As Boolean
        If Not ValidateTextBoxLength(txtUserID, errP) Then
            errP.SetError(txtUserID, "Please enter a valid Original Password.")
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtConfirmPass, errP) Then
            errP.SetError(txtConfirmPass, "Please enter a valid Password.")
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtNewPass, errP) Then
            errP.SetError(txtNewPass, "Please enter a valid Password.")
            blnErrors = True
        End If

        If Not txtConfirmPass.Text = txtNewPass.Text Then
            errP.SetError(txtConfirmPass, "Must match previous entry.")
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        Dim intChangePass As Integer
        With objSecurities.CurrentObject
            .UserID = txtUserID.Text
            .Password = txtConfirmPass.Text
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        objSecurities.CurrentObject.isNewSecurity = False
    End Sub

End Class