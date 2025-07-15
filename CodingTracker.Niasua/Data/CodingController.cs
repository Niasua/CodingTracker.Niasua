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

    public static void InsertSession(CodingSession session)
    {
        session.CalculateDuration();

        using var connection = new SqliteConnection(AppConfig.GetConnectionString());

        var insertQuery = @"INSERT INTO coding_sessions (StartTime, EndTime, DurationHours)
                            VALUES (@StartTime, @EndTime, @DurationHours);";

        connection.Execute(insertQuery, session);
    }

    public static List<CodingSession> GetAllSessions()
    {
        using var connection = new SqliteConnection(AppConfig.GetConnectionString());

        var query = "SELECT * FROM coding_sessions";

        var sessions = connection.Query<CodingSession>(query).ToList();

        return sessions;
    }

    public static void DeleteSession(CodingSession session)
    {
        using var connection = new SqliteConnection(AppConfig.GetConnectionString());

        var deleteQuery = @"DELETE FROM coding_sessions
                            WHERE Id = @Id;";

        connection.Execute(deleteQuery, session);
    }

    public static CodingSession GetSessionById(int id)
    {
        using var connection = new SqliteConnection(AppConfig.GetConnectionString());

        var query = @"SELECT * FROM coding_sessions
                      WHERE Id = @Id;";

        var session = connection.QuerySingleOrDefault<CodingSession>(query, new {Id = id});

        return session;
    }
}
