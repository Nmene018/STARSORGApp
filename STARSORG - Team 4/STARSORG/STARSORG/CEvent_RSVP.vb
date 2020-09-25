Imports System.Data.SqlClient
Public Class CEvent_RSVP
    Private _mstrEventID As String
    Private _mstrFName As String
    Private _mstrLName As String
    Private _mstrEmail As String
    Private _isNewEvent_RSVP As Boolean
    Public Sub New()
        _mstrEventID = ""
        _mstrFName = ""
        _mstrLName = ""
        _mstrEmail = ""
    End Sub
#Region "Exposed Properties"
    Public Property EventID As String
        Get
            Return _mstrEventID
        End Get
        Set(strVal As String)
            _mstrEventID = strVal
        End Set
    End Property
    Public Property FName As String
        Get
            Return _mstrFName
        End Get
        Set(strVal As String)
            _mstrFName = strVal
        End Set
    End Property
    Public Property LName As String
        Get
            Return _mstrLName
        End Get
        Set(strVal As String)
            _mstrLName = strVal
        End Set
    End Property
    Public Property Email As String
        Get
            Return _mstrEmail
        End Get
        Set(strVal As String)
            _mstrEmail = strVal
        End Set
    End Property
    Public Property IsNewEvent_RSVP As Boolean
        Get
            Return _isNewEvent_RSVP
        End Get
        Set(blnVal As Boolean)
            _isNewEvent_RSVP = blnVal
        End Set
    End Property
    Public ReadOnly Property GetRSVPParameters() As ArrayList
        'this properties code will create the parameters for the stored procedures to save a record
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("eventID", _mstrEventID))
            params.Add(New SqlParameter("fName", _mstrFName))
            params.Add(New SqlParameter("lName", _mstrLName))
            params.Add(New SqlParameter("email", _mstrEmail))
            Return params
        End Get
    End Property
#End Region
    Public Function Save() As Integer
        'if not a new event, or it is a new and has a unique id, then do save (update or insert)
        Return myDB.ExecSp("sp_saveEvent_RSVP", GetRSVPParameters())
    End Function
    Public Function GetReportData() As SqlDataAdapter
        Return myDB.GetDataAdapterBySP("dbo.sp_getAllEventRSVPs", Nothing)
    End Function
End Class
