using Dapper;
using Microsoft.Data.Sqlite;
using CodingTracker.Niasua.Models;
using CodingTracker.Niasua.Configuration;


namespace CodingTracker.Niasua.Data;

internal static class CodingController
{
    public static void InitializeDatabase()
    {
        using var connection = new SqliteConnection(AppConfig.GetConnectionString());

        var tableQuery = @"CREATE TABLE IF NOT EXISTS coding_sessions (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            StartTime TEXT NOT NULL,
                            EndTime TEXT NOT NULL,
                            DurationHours REAL NOT NULL
                        );";

        connection.Execute(tableQuery);
    }
}
