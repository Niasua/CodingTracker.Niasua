using Spectre.Console;
using CodingTracker.Niasua.Models;

namespace CodingTracker.Niasua.UI
{
    internal static class TableDisplay
    {
        internal static void ShowSessions(List<CodingSession> sessions)
        {
            var table = new Table();
            table.Border(TableBorder.Rounded);
            table.AddColumn("[yellow]ID[/]");
            table.AddColumn("[cyan]Start Time[/]");
            table.AddColumn("[cyan]End Time[/]");
            table.AddColumn("[green]Duration (hrs)[/]");

            foreach (var session in sessions)
            {
                table.AddRow(
                    session.Id.ToString(),
                    session.StartTime.ToString("dd-mm-yyyy HH:mm"),
                    session.EndTime.ToString("dd-mm-yyyy HH:mm"),
                    session.DurationHours.ToString("0.##")
                    );
            }

            AnsiConsole.Write(table);
        }
    }
}
