using CodingTracker.Niasua.Data;
using CodingTracker.Niasua.Models;
using CodingTracker.Niasua.UI;
using Spectre.Console;
using SQLitePCL;

Batteries.Init();

CodingController.InitializeDatabase();

bool exit = false;

while (!exit)
{
    Console.Clear();
    AnsiConsole.MarkupLine("[bold blue]Coding Tracker[/]");
    AnsiConsole.MarkupLine("Select an option:\n");

    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Choose an [green]action[/].")
        .AddChoices(new[]
        {
            "View all sessions",
            "Add new session",
            "Exit"
        }));

    switch (choice)
    {
        case "View all sessions":
            var sessions = CodingController.GetAllSessions();
            TableDisplay.ShowSessions(sessions);
            break;
        case "Add new session":
            break;
        case "Exit":
            exit = true;
            break;
    }
}