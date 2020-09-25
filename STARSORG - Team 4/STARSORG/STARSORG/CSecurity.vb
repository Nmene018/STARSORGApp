Imports System.Data.SqlClient
Public Class CSecurity
    Private _mstrPID As String
    Private _mstrUserID As String
    Private _mstrPassword As String
    Private _mstrSecRole As String
    Private _isNewSecurity As Boolean
    Private _mstrNewPass As String
    Public Sub New()
        _mstrPID = ""
        _mstrUserID = ""
        _mstrPassword = ""
        _mstrSecRole = ""
        _mstrNewPass = ""

    End Sub
#Region "Exposed Properties"
    Public Property PID As String
        Get
            Return _mstrPID
        End Get
        Set(strVal As String)
            _mstrPID = strVal
        End Set
    End Property
    Public Property UserID As String
        Get
            Return _mstrUserID
        End Get
        Set(strVal As String)
            _mstrUserID = strVal
        End Set
    End Property
    Public Property Password As String
        Get
            Return _mstrPassword
        End Get
        Set(strVal As String)
            _mstrPassword = strVal
        End Set
    End Property
    Public Property NewPass As String
        Get
            Return _mstrNewPass
        End Get
        Set(strVal As String)
            _mstrNewPass = strVal
        End Set
    End Property
    Public Property SecRole As String
        Get
            Return _mstrSecRole
        End Get
        Set(strVal As String)
            _mstrSecRole = strVal
        End Set
    End Property
    Public Property isNewSecurity As Boolean
        Get
            Return _isNewSecurity
        End Get
        Set(blnVal As Boolean)
            _isNewSecurity = blnVal
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("PID", _mstrPID))
            params.Add(New SqlParameter("UserID", _mstrUserID))
            params.Add(New SqlParameter("Password", _mstrPassword))
            params.Add(New SqlParameter("SecRole", _mstrSecRole))
            Return params
        End Get
    End Property

    Public ReadOnly Property GetLoginParameters() As ArrayList
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("UserID", _mstrUserID))
            params.Add(New SqlParameter("Password", _mstrPassword))
            Return params
        End Get
    End Property
#End Region
    Public Function CheckUserIDExists() As Integer
        Dim params As New ArrayList
        params.Add(New SqlParameter("PID", _mstrPID))
        params.Add(New SqlParameter("UserID", _mstrUserID))
        params.Add(New SqlParameter("Password", _mstrPassword))
        params.Add(New SqlParameter("SecRole", _mstrSecRole))
        Dim strResult As Integer = myDB.GetSingleValueFromSP("sp_CheckUserIDExists", params)
        If strResult = 0 Then
            Return 1
        End If
        If Not strResult = 0 Then
            Return -1
        End If
        Return myDB.ExecSp("sp_saveCheckPassword", GetSaveParameters)
    End Function
    Public Function CreateUser() As Integer
        If isNewSecurity Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("PID", _mstrPID))
            params.Add(New SqlParameter("Password", _mstrPassword))
            params.Add(New SqlParameter("UserID", _mstrUserID))
            params.Add(New SqlParameter("SecRole", _mstrSecRole))

            Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckUserIDExists", params)
            If strResult = 0 Then
                Return 1
            End If
            If Not strResult = 0 Then
                Return -1
            End If
        End If
        Return myDB.ExecSp("sp_saveCheck", GetSaveParameters())
    End Function
    Public Function CreateGuestUser() As Integer
        If isNewSecurity Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("PID", _mstrPID))
        End If
        Return myDB.ExecSp("sp_saveGuestID", Nothing)
    End Function

    Public Function ChangePassword() As Integer
        Return myDB.ExecSp("sp_ChgPassword", GetLoginParameters())
    End Function

    Public Function GetSecRole() As SqlDataAdapter
        Return myDB.GetDataAdapterBySP("dbo.sp_getAllSecurities", Nothing)
    End Function
End Class
