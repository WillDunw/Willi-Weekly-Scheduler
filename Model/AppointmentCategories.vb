Imports System.Data.SQLite

Public Class AppointmentCategories
    Public Sub New()

    End Sub

    Public Sub AddCategory(title As String, categoryType As AppointmentCategory.CategoryType)
        Dim cmd = Database.Connection.CreateCommand()

        Try
            cmd.CommandText = "INSERT INTO categories (Title, CategoryTypeID) VALUES (@Title, @Type);"
            cmd.Parameters.Add(New SQLiteParameter("@Title", title))
            cmd.Parameters.Add(New SQLiteParameter("@Type", CInt(categoryType)))
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New SQLiteException(ex.Message)

        Finally
            cmd.Dispose()
        End Try
    End Sub

    Public Sub DeleteCategory(catID As Integer)
        Dim cmd = Database.Connection.CreateCommand()

        Try
            cmd.CommandText = "DELETE FROM categories WHERE Id = @catID;"
            cmd.Parameters.Add(New SQLiteParameter("@catID", catID))
            If cmd.ExecuteNonQuery() = 0 Then
                Throw New SQLiteException("No record found with ID: " + catID.ToString())
            End If
        Catch ex As Exception
            Throw New SQLiteException(ex.Message)
        Finally
            cmd.Dispose()
        End Try
    End Sub

    Public Sub UpdateCategory(catID As Integer, newTitle As String, newCategoryType As AppointmentCategory.CategoryType)
        Dim cmd = Database.Connection.CreateCommand()

        Try
            cmd.CommandText = "UPDATE categories SET Title = @newTitle, CategoryTypeID = @newCategory WHERE Id = @catID;"
            cmd.Parameters.Add(New SQLiteParameter("@newTitle", newTitle))
            cmd.Parameters.Add(New SQLiteParameter("@newCategory", CInt(newCategoryType)))
            cmd.Parameters.Add(New SQLiteParameter("@catID", catID))
            If cmd.ExecuteNonQuery() = 0 Then
                Throw New SQLiteException("No record found with ID: " + catID.ToString())
            End If
        Catch ex As Exception
            Throw New SQLiteException(ex.Message)
        Finally
            cmd.Dispose()
        End Try
    End Sub

    Public Function List() As List(Of AppointmentCategory)
        Dim idColumn = 0, titleColumn = 1, typeIDColumn = 2
        Dim cats = New List(Of AppointmentCategory)

        Dim reader As SQLiteDataReader
        Dim cmd = Database.Connection.CreateCommand()

        cmd.CommandText = "SELECT Id, Title, CategoryTypeID FROM categories ORDER BY Id ASC;"

        reader = cmd.ExecuteReader()

        Try
            If reader.HasRows Then
                While reader.Read()
                    Dim id = reader.GetInt32(idColumn)
                    Dim title = reader.GetString(titleColumn)
                    Dim catType = CType(reader.GetInt32(typeIDColumn), AppointmentCategory.CategoryType)

                    cats.Add(New AppointmentCategory(id, title, catType))
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

        Return cats
    End Function

    Public Function GetSingleCategory(id As Integer)
        Dim cmd = Database.Connection.CreateCommand()
        Dim reader As SQLiteDataReader

        Dim idColumn = 0, titleColumn = 1, typeIDColumn = 2
        Dim category As AppointmentCategory

        cmd.CommandText = "SELECT Id, Title, CategoryTypeID FROM categories WHERE Id = @Id;"
        cmd.Parameters.Add(New SQLiteParameter("@Id", id))
        reader = cmd.ExecuteReader()

        If reader.Read() Then
            category = New AppointmentCategory(reader.GetInt32(idColumn), reader.GetString(titleColumn), CType(reader.GetInt32(typeIDColumn), AppointmentCategory.CategoryType))
        Else
            Throw New Exception($"Category with Id {id} does not exist.")
        End If

        reader.Close()

        Return category
    End Function
End Class
