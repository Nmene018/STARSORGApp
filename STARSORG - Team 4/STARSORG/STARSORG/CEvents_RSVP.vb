Imports System.Data.SqlClient
Public Class CEvents_RSVP
    Private _Event_RSVP As CEvent_RSVP
    Public Sub New()
        'instantiate the CEVENT object
        _Event_RSVP = New CEvent_RSVP
    End Sub
    Public ReadOnly Property CurrentObject() As CEvent_RSVP
        Get
            Return _Event_RSVP
        End Get
    End Property
    Public Sub Clear()
        _Event_RSVP = New CEvent_RSVP
    End Sub
    Public Sub CreateNewEvent_RSVP()
        'call this when clearing the edit portion of the screen to add a new event rsvp
        Clear()
        _Event_RSVP.IsNewEvent_RSVP = True
    End Sub
    Public Function Save() As Integer
        Return _Event_RSVP.Save()
    End Function
    Public Function GetAllEvents() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllEvents", Nothing)
        Return objDR
    End Function
    Public Function GetEventByEventID(strID As String) As CEvent_RSVP
        Dim params As New ArrayList
        'Dim objDR As SqlDataReader
        params.Add(New SqlParameter("eventID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getEventByEventID", params))
        Return _Event_RSVP
    End Function
    Private Function FillObject(objDR As SqlDataReader) As CEvent_RSVP
        If objDR.Read Then
            With _Event_RSVP
                .EventID = objDR.Item("EventID")
                .FName = objDR.Item("FName")
                .LName = objDR.Item("LName")
                .Email = objDR.Item("Email")
            End With
        Else 'no record was returned
            'nothing to do here
        End If
        objDR.Close()
        Return _Event_RSVP
    End Function
End Class
