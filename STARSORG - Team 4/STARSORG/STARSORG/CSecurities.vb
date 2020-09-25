Imports System.Data.SqlClient
Public Class CSecurities
    Private _Security As CSecurity
    Public Sub New()
        _Security = New CSecurity
    End Sub

    Public ReadOnly Property CurrentObject() As CSecurity
        Get
            Return _Security
        End Get
    End Property
    Public Sub Clear()
        _Security = New CSecurity
    End Sub
    Public Sub CreateNewSecurity()
        Clear()
        _Security.isNewSecurity = True
    End Sub
    Public Function CheckUserIDExists() As Integer
        Return _Security.CheckUserIDExists()
    End Function
    Public Function GetAllSecurities() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllSecurities", Nothing)
        Return objDR
    End Function
    Public Function GetSecurityByPID(strPID As String) As CSecurity
        Dim params As New ArrayList
        ' Dim objDR As SqlDataReader
        params.Add(New SqlParameter("PID", strPID))
        FillObject(myDB.GetDataReaderBySP("sp_getSecurityByPID", params))
        Return _Security
    End Function
    Public Function CreateUser() As Integer
        Return _Security.CreateUser
    End Function
    Public Function CreateGuestUser() As Integer
        Return _Security.CreateGuestUser
    End Function
    Public Function ChangePassword() As Integer
        Return _Security.ChangePassword()
    End Function
    Private Function FillObject(objDR As SqlDataReader) As CSecurity
        If objDR.Read Then
            With _Security
                .PID = objDR.Item("PID")
                .UserID = objDR.Item("UserID")
                .Password = objDR.Item("Password")
                .SecRole = objDR.Item("SecRole")
            End With
        Else
            'no record
        End If
        objDR.Close()
        Return _Security
    End Function

End Class
