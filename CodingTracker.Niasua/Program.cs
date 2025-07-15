using CodingTracker.Niasua.Data;
using CodingTracker.Niasua.Models;
using CodingTracker.Niasua.UI;
using CodingTracker.Niasua.UserInput;
using Spectre.Console;
using SQLitePCL;

Batteries.Init();

CodingController.InitializeDatabase();

bool exit = false;

while (!exit)
{
    Console.Clear();
    AnsiConsole.MarkupLine("[bold blue]Coding Tracker[/]");
    AnsiConsole.MarkupLine("\nSelect an option:\n");

    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Choose an [green]action[/].")
        .AddChoices(new[]
        {
            "View all sessions",
            "Add new session",
            "Delete session",
            "Exit"
        }));

    switch (choice)
    {
        case "View all sessions":

            var sessions = CodingController.GetAllSessions();
            ViewAllSessions(sessions);

            break;

        case "Add new session":

            var session = UserInputHandler.GetCodingSessionFromUser();
            AddSession(session);

            break;

        case "Delete session":

            sessions = CodingController.GetAllSessions();
            DeleteSession(sessions);

            break;

        case "Exit":

            exit = true;

            break;
    }
}

static void ViewAllSessions(List<CodingSession> sessions)
{
    TableDisplay.ShowSessions(sessions);

    Pause();
}

static void AddSession(CodingSession session)
{
    CodingController.InsertSession(session);

    AnsiConsole.MarkupLine("\n[green]Session successfully added.[/]\n");
    Pause();
}

static void DeleteSession(List<CodingSession> sessions)
{
    TableDisplay.ShowSessions(sessions);

    
    var id = UserInputHandler.GetSessionId();
    var sessionToDelete = CodingController.GetSessionById(id);

    if (sessionToDelete is null)
    {
        AnsiConsole.MarkupLine("[red]That session doesn't exist.[/]");
        Pause();
        return;
    }

    CodingController.DeleteSession(sessionToDelete);

    AnsiConsole.MarkupLine("\n[green]Session successfully deleted.[/]\n");
    Pause();
}

static void Pause()
{
    AnsiConsole.MarkupLine("\n[grey]Press any key to continue...[/]");
    Console.ReadKey();
}