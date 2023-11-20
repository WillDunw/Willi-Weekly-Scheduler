Public Class Presenter
    Dim model As SchedulerModel
    Dim view As IWindow
    Public Sub New(view As IWindow)
        Me.view = view
        model = New SchedulerModel()
    End Sub

    Public Function SwitchView(view As IWindow)
        Me.view = view
    End Function

    Public Function GetCategories() As List(Of AppointmentCategory)
        Return model.Categories.List()
    End Function

    Public Function GetAppointmentsWithTime(startTime As DateTime, endTime As DateTime) As List(Of Appointment)
        Dim test = model.Appointments.ListAll()
        Return model.Appointments.ListAllWithTime(startTime, endTime)
    End Function

    Public Function MustAddCategories() As Boolean
        Return model.Categories.List().Count = 0
    End Function

    Public Sub AddAppointment(subject As String, startTime As String, endTime As String, categoryID As Integer)
        If String.IsNullOrEmpty(subject) Then
            view.DisplayError("Subject cannot be empty.")
        ElseIf String.IsNullOrEmpty(startTime) Then
            view.DisplayError("Start time cannot be empty.")
        ElseIf String.IsNullOrEmpty(endTime) Then
            view.DisplayError("End time cannot be empty.")
        ElseIf DateTime.Parse(endTime).CompareTo(DateTime.Parse(startTime)) < 0 Then
            view.DisplayError("End time cannot be before start time.")
        ElseIf categoryID = -1 Then
            view.DisplayError("Category cannot be empty.")
        Else
            '+1 because the ids in the database start at 1
            model.Appointments.AddAppointment(subject, DateTime.Parse(startTime), DateTime.Parse(endTime), categoryID)
            view.ResetValues()
        End If
    End Sub

    'No need to validate category type since it is set by default.
    Public Sub AddCategory(title As String, categoryType As AppointmentCategory.CategoryType)
        If String.IsNullOrEmpty(title) Then
            view.DisplayError("Category title cannot be empty.")
        Else
            model.Categories.AddCategory(title, categoryType)
        End If
    End Sub
End Class
