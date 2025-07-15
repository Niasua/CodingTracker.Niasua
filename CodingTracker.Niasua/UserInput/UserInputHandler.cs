using System;
using CodingTracker.Niasua.Models;

namespace CodingTracker.Niasua.UserInput;

internal static class UserInputHandler
{
    private const string DateTimeFormat = "dd-MM-yyyy HH:mm";

    public static CodingSession GetCodingSessionFromUser()
    {
        Console.WriteLine($"Please enter the start date and time ({DateTimeFormat}):");
        DateTime startTime = ReadValidDateTime();

        Console.WriteLine($"Please enter the end date and time ({DateTimeFormat}):");
        DateTime endTime = ReadValidDateTime();

        while (endTime <= startTime)
        {
            Console.WriteLine("End time must be AFTER start time. Please enter a valid end date and time:");
            endTime = ReadValidDateTime();
        }

        return new CodingSession
        {
            StartTime = startTime,
            EndTime = endTime
        };
    }

    private static DateTime ReadValidDateTime()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if(DateTime.TryParseExact(input, DateTimeFormat, null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate;
            }
            else
            {
                Console.WriteLine($"Invalid date/time format. Please use the format: {DateTimeFormat}");
            }
        }
    }
}
