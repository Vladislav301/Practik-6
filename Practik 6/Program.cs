using System;
using System.Globalization;

public class DateTimeParsingExample
{
    public static void Main(string[] args)
    {
        string[] dateStrings = { "2024-03-15", "15.03.2024", "April 15, 2024", "invalid date", "2024-03-15 14:30:00" };
        string[] formats = { "yyyy-MM-dd", "dd.MM.yyyy", "MMMM dd, yyyy", "yyyy-MM-dd HH:mm:ss" };
        foreach (string dateString in dateStrings)
        {
            DateTime date;
            if (DateTime.TryParse(dateString, out date))
            {
                Console.WriteLine($"TryParse(\"{dateString}\"): {date}");
            }
            else
            {
                Console.WriteLine($"TryParse(\"{dateString}\"): Не удалось распознать дату.");

                for (int i = 0; i < formats.Length; i++)
                {
                    if (DateTime.TryParseExact(dateString, formats[i], CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        Console.WriteLine($"TryParseExact(\"{dateString}\", \"{formats[i]}\"): {date}");
                        break;
                    }
                    if (i == formats.Length - 1 && dateString != "invalid date")
                        Console.WriteLine($"TryParseExact(\"{dateString}\"): Не удалось разобрать дату (точный парсер).");
                }
            }
        }
    }
}