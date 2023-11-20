''' <summary>
''' This class is actually a stripped-down version of the actual Appointment class, which was generated using the 
''' Linq-to-SQL Designer (essentially a Linq ORM to the Appointments table in the db)
''' </summary>
''' <remarks>Obviously, you should use your own appointment object/classes, and change the code-behind in MonthView.xaml.vb to
''' support a List(Of T) where T is whatever the System.Type is for your appointment class.
''' </remarks>
''' <author>Kirk Davis, February 2009 (in like, 4 hours, and it shows!)</author>
Public Class Appointment
    Private _AppointmentID As Integer
    Private _Subject As String
    Private _StartTime As DateTime
    Private _EndTime As DateTime
    Private _CategoryID As Integer

    Public Sub New(appointmentID As Integer, subject As String, startTime As DateTime, endTime As DateTime, categoryID As Integer)
        _AppointmentID = appointmentID
        _Subject = subject
        _StartTime = startTime
        _EndTime = endTime
        _CategoryID = categoryID
    End Sub

    Public ReadOnly Property AppointmentID() As Integer
        Get
            Return _AppointmentID
        End Get
    End Property

    Public ReadOnly Property Subject() As String
        Get
            Return Me._Subject
        End Get
    End Property

    Public ReadOnly Property StartTime() As System.Nullable(Of Date)
        Get
            Return Me._StartTime
        End Get
    End Property

    Public ReadOnly Property EndTime() As System.Nullable(Of Date)
        Get
            Return Me._EndTime
        End Get
    End Property

    Public ReadOnly Property CategoryID() As Integer
        Get
            Return Me._CategoryID
        End Get
    End Property

End Class