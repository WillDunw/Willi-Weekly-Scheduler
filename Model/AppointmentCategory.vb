Public Class AppointmentCategory
    Private _CategoryID As Integer
    Private _Title As String
    Private _CategoryType As CategoryType

    Public Enum CategoryType
        FreeTime = 1
        Sleep = 2
        Rest = 3
        Chores = 4
        School = 5
        Work = 6
        Friends = 7
    End Enum

    Public Sub New(categoryID As Integer, title As String, categoryType As CategoryType)
        _CategoryID = categoryID
        _Title = title
        _CategoryType = categoryType
    End Sub

    Public ReadOnly Property CategoryID() As Integer
        Get
            Return _CategoryID
        End Get
    End Property

    Public ReadOnly Property Title() As String
        Get
            Return _Title
        End Get
    End Property

    Public ReadOnly Property Type() As CategoryType
        Get
            Return _CategoryType
        End Get
    End Property
End Class
