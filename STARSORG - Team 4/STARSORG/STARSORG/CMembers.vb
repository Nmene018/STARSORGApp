Imports System.Data.SqlClient
Public Class CMembers
    'Represents the MEMBER table and its associated business rules
    Private _Member As CMember
    Private _Members As List(Of CMember)
    Public Sub New()
        'instantiate the CMember object
        _Member = New CMember
    End Sub

    Public ReadOnly Property CurrentObject() As CMember
        Get
            Return _Member
        End Get
    End Property

    Public ReadOnly Property AllObjects() As List(Of CMember)
        Get
            Return _Members
        End Get
    End Property

    Public Sub Clear()
        _Member = New CMember
    End Sub
    Public Sub CreateNewMember()
        'call this when clearing the edit portion of the screen to add a new member
        Clear()
        _Member.IsNewMember = True
    End Sub
    Public Function Save() As Integer
        Return _Member.Save()
    End Function

    Public Function GetAllMembers() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllMembers", Nothing)

        Return objDR
    End Function
    Public Function GetMemberByPID(strID As String) As CMember
        Dim params As New ArrayList
        'Dim objDR As SqlDataReader
        params.Add(New SqlParameter("PID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getMemberByPID", params))

        Return _Member
    End Function

    Public Function GetMemberByLName(strLName As String) As SqlDataReader
        Dim objDR As SqlDataReader
        Dim params As New ArrayList
        params.Add(New SqlParameter("LName", strLName))
        objDR = myDB.GetDataReaderBySP("sp_getMemberByLName", params)

        Return objDR
    End Function

    Private Function FillObject(objDR As SqlDataReader) As CMember
        If objDR.Read Then
            With _Member
                .PID = objDR.Item("PID")
                .FName = objDR.Item("FName")
                .LName = objDR.Item("LName")
                .MI = objDR.Item("MI")
                .Email = objDR.Item("Email")
                .Phone = objDR.Item("Phone")
                .PhotoPath = objDR.Item("PhotoPath")
            End With
        Else 'no record was returned
            objDR.Close()
            'nothing to do here
        End If

        objDR.Close()
        Return _Member
    End Function

End Class
