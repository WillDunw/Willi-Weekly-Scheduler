Imports System.Data.SQLite
Imports System.Diagnostics.Eventing

Public Class Appointments

    Public Sub New()

    End Sub

    Public Sub AddAppointment(subject As String, startTime As DateTime, endTime As DateTime, categoryID As Integer)
        Dim cmd = Database.Connection.CreateCommand()

        Try
            If endTime.CompareTo(startTime) < 0 Then
                Throw New ArgumentException("Start time cannot be after end time.")
            End If
            Dim existingAppt = ListAllWithTime(startTime, endTime)

            If existingAppt.Count <> 0 Then
                Throw New SQLiteException("Cannot insert appointment since one is already scheduled.")
            End If

            cmd.CommandText = "INSERT INTO appointments (Subject, StartTime, EndTime, CategoryID) VALUES (@Subject, @StartTime, @EndTime, @CategoryID);"
            cmd.Parameters.Add(New SQLiteParameter("@Subject", subject))
            cmd.Parameters.Add(New SQLiteParameter("@StartTime", startTime.ToBinary()))
            cmd.Parameters.Add(New SQLiteParameter("@EndTime", endTime.ToBinary()))
            cmd.Parameters.Add(New SQLiteParameter("@CategoryID", categoryID))
            cmd.ExecuteNonQuery()
        Catch ex As SQLiteException
            Throw New SQLiteException(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Dispose()
        End Try
    End Sub

    Public Sub Delete(id As Integer)
        Dim cmd = Database.Connection.CreateCommand()

        Try
            cmd.CommandText = "DELETE FROM appointments WHERE Id = @Id;"
            cmd.Parameters.Add(New SQLiteParameter("@Id", id))
            cmd.ExecuteNonQuery()
        Catch ex As SQLiteException
            Throw New SQLiteException(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Dispose()
        End Try
    End Sub

    Public Sub Update(id As Integer, newSubject As String, newStartTime As DateTime, newEndTime As DateTime, newCatId As Integer)
        Dim cmd = Database.Connection.CreateCommand()

        Try
            cmd.CommandText = "UPDATE appointments SET Subject = @newSubject, StartTime = @newStartTime, EndTime = @newEndTime, CategoryID = @newCatID WHERE Id = @Id;"
            cmd.Parameters.Add(New SQLiteParameter("@newSubject", newSubject))
            cmd.Parameters.Add(New SQLiteParameter("@newStartTime", newStartTime.ToBinary()))
            cmd.Parameters.Add(New SQLiteParameter("@newEndTime", newEndTime.ToBinary()))
            cmd.Parameters.Add(New SQLiteParameter("@newCatID", newCatId))
            cmd.Parameters.Add(New SQLiteParameter("@Id", id))

            If cmd.ExecuteNonQuery() = 0 Then
                Throw New Exception("No record found with ID: " + id)
            End If
        Catch ex As SQLiteException
            Throw New SQLiteException(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Dispose()
        End Try
    End Sub

    Public Function FindOneAppointment(id As Integer) As Appointment
        Dim cmd = Database.Connection.CreateCommand()

        Dim idColumn = 0, subjectColumn = 1, startTimeColumn = 2, endTimeColumn = 3, categoryIDColumn = 4
        Dim appointment As Appointment

        cmd.CommandText = "SELECT Id, Subject, StartTime, EndTime, CategoryID FROM appointments WHERE Id = @id;"
        cmd.Parameters.Add(New SQLiteParameter("@id", id))

        Dim reader = cmd.ExecuteReader()

        Try
            If reader.Read() Then
                Dim id2 = reader.GetInt32(idColumn)
                Dim subject = reader.GetString(subjectColumn)
                Dim startTime = DateTime.FromBinary(reader.GetInt64(startTimeColumn))
                Dim endTime = DateTime.FromBinary(reader.GetInt64(endTimeColumn))
                Dim categoryID = reader.GetInt32(categoryIDColumn)

                appointment = New Appointment(id2, subject, startTime, endTime, categoryID)
            Else
                Throw New SQLiteException($"Appointment with id: {id} could not be found.")
            End If
        Catch ex As SQLiteException
            Throw New SQLiteException(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return appointment
    End Function

    Public Function ListAll() As List(Of Appointment)
        Dim cmd = Database.Connection.CreateCommand()
        Dim idColumn = 0, subjectColumn = 1, startTimeColumn = 2, endTimeColumn = 3, categoryIDColumn = 4
        Dim appointments = New List(Of Appointment)

        cmd.CommandText = "SELECT Id, Subject, StartTime, EndTime, CategoryID FROM appointments ORDER BY Id ASC;"

        Dim reader = cmd.ExecuteReader()
        Try
            If reader.HasRows Then
                While reader.Read()
                    Dim id = reader.GetInt32(idColumn)
                    Dim subject = reader.GetString(subjectColumn)
                    Dim startTime = DateTime.FromBinary(reader.GetInt64(startTimeColumn))
                    Dim endTime = DateTime.FromBinary(reader.GetInt64(endTimeColumn))
                    Dim categoryID = reader.GetInt32(categoryIDColumn)

                    appointments.Add(New Appointment(id, subject, startTime, endTime, categoryID))
                End While
            End If
        Catch ex As SQLiteException
            Throw New SQLiteException(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            reader.Close()
            cmd.Dispose()
        End Try

        Return appointments
    End Function

    Public Function ListAllWithTime(startTime As DateTime, endTime As DateTime) As List(Of Appointment)
        Dim cmd = Database.Connection.CreateCommand()
        Dim idColumn = 0, subjectColumn = 1, startTimeColumn = 2, endTimeColumn = 3, categoryIDColumn = 4
        Dim appointments = New List(Of Appointment)

        cmd.CommandText = "SELECT Id, Subject, StartTime, EndTime, CategoryID FROM appointments WHERE StartTime >= @startTime AND StartTime <= @endTime OR EndTime <= @endTime AND EndTime > @startTime ORDER BY Id ASC;"
        cmd.Parameters.Add(New SQLiteParameter("@startTime", startTime.ToBinary()))
        cmd.Parameters.Add(New SQLiteParameter("@endTime", endTime.ToBinary()))

        Dim reader = cmd.ExecuteReader()

        Try
            If reader.HasRows Then
                While reader.Read()
                    Dim id = reader.GetInt32(idColumn)
                    Dim subject = reader.GetString(subjectColumn)
                    Dim startTimeAppointment = DateTime.FromBinary(reader.GetInt64(startTimeColumn))
                    Dim endTimeAppointment = DateTime.FromBinary(reader.GetInt64(endTimeColumn))
                    Dim categoryID = reader.GetInt32(categoryIDColumn)

                    appointments.Add(New Appointment(id, subject, startTimeAppointment, endTimeAppointment, categoryID))
                End While
            End If
        Catch ex As SQLiteException
            Throw New SQLiteException(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            reader.Close()
            cmd.Dispose()
        End Try

        Return appointments
    End Function

    Public Sub ClearAppointmentsInTimeFrame(startTime As DateTime, endTime As DateTime)
        Try
            For Each appointment In ListAllWithTime(startTime, endTime)
                Delete(appointment.AppointmentID)
            Next
        Catch ex As SQLiteException
            Throw New SQLiteException(ex.Message)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
