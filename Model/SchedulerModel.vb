Imports System.Data.SQLite

Public Class SchedulerModel
    Private _appointments As Appointments
    Private _categories As AppointmentCategories

    Public Sub New()
        Database.LoadDatabase()

        _appointments = New Appointments()
        _categories = New AppointmentCategories()

        InitializeCategoryTypes()
    End Sub

    Public ReadOnly Property Appointments() As Appointments
        Get
            Return _appointments
        End Get
    End Property

    Public ReadOnly Property Categories() As AppointmentCategories
        Get
            Return _categories
        End Get
    End Property

    Private Sub InitializeCategoryTypes()
        Try

            Dim cmd = Database.Connection.CreateCommand()

            cmd.CommandText = "SELECT * FROM categoryTypes;"
            Dim reader = cmd.ExecuteReader()
            'Only runs if the table is empty - aka has not been initialized
            If Not reader.Read() Then

                reader.Close()

                cmd.CommandText = "DELETE FROM categoryTypes"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "INSERT INTO categoryTypes (Id, Description)  VALUES (1, 'FreeTime')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "INSERT INTO categoryTypes (Id, Description)  VALUES (2, 'Sleep')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "INSERT INTO categoryTypes (Id, Description)  VALUES (3, 'Rest')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "INSERT INTO categoryTypes (Id, Description)  VALUES (4, 'Chores')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "INSERT INTO categoryTypes (Id, Description)  VALUES (5, 'School')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "INSERT INTO categoryTypes (Id, Description)  VALUES (6, 'Work')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "INSERT INTO categoryTypes (Id, Description)  VALUES (7, 'Friends')"
                cmd.ExecuteNonQuery()

            End If
        Catch ex As Exception
            Throw New SQLiteException(ex.Message)
        End Try
    End Sub


End Class
