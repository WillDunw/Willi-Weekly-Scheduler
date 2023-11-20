Imports System.Data.SQLite
Imports System.IO
Public Class Database
    Private Shared _sqlite_conn As SQLiteConnection
    Private Shared _databaseFilePath As String = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Scheduler\schedule.db"

    Public Shared ReadOnly Property Connection() As SQLiteConnection
        Get
            Return _sqlite_conn
        End Get
    End Property

    'Hate this method but due to the order of operations cant really change unless I'm missing something
    Public Shared Sub LoadDatabase()
        If My.Computer.FileSystem.FileExists(_databaseFilePath) Then
            _sqlite_conn = New SQLiteConnection($"Data Source={_databaseFilePath};Foreign Keys=1")
            _sqlite_conn.Open()
        Else
            Directory.CreateDirectory(Path.GetDirectoryName(_databaseFilePath))
            File.Create(_databaseFilePath).Close()
            _sqlite_conn = New SQLiteConnection($"Data Source={_databaseFilePath};Foreign Keys=1")
            _sqlite_conn.Open()
            InitializeDB()
        End If
    End Sub

    Private Shared Sub CloseDatabaseAndReleaseFile()
        If IsNothing(_sqlite_conn) Then
            _sqlite_conn.Close()

            GC.Collect()
            GC.WaitForPendingFinalizers()
        End If
    End Sub

    Private Shared Sub InitializeDB()
        Dim cmd = _sqlite_conn.CreateCommand()

        cmd.CommandText = "DROP TABLE IF EXISTS appointments"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "DROP TABLE IF EXISTS categories"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "DROP TABLE IF EXISTS categoryTypes"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "CREATE TABLE appointments(Id INTEGER PRIMARY KEY, Subject VARCHAR(100), StartTime INTEGER, EndTime INTEGER, CategoryID INTEGER)"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "CREATE TABLE categories(Id INTEGER PRIMARY KEY, Title VARCHAR(30), CategoryTypeID INTEGER)"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "CREATE TABLE categoryTypes(Id INTEGER PRIMARY KEY, Description VARCHAR(30))"
        cmd.ExecuteNonQuery()

        cmd.Dispose()
    End Sub
End Class
