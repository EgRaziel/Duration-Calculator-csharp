using System;
using CalculadoraDuracaoCSharp.Controller;

namespace CalculadoraDuracaoCSharp
{
    public class ViewCalcs
    {
        public static void Menu()
        {
            Console.WriteLine("+=====================================+");
            Console.WriteLine("+         DURATION CALCULATOR  v1.2.0 +");
            Console.WriteLine("+=====================================+");

            System.Threading.Thread.Sleep(400);
            Console.WriteLine("\n1. Sum Duration");

            System.Threading.Thread.Sleep(400);
            Console.WriteLine("2. Subtract Duration");

            System.Threading.Thread.Sleep(400);
            Console.WriteLine("0. Exit");

            System.Threading.Thread.Sleep(400);
            Console.Write("\nChoose an option: ");
        }

        public static void Sum()
        {
            Console.Clear();

            Console.Write("Insert an initial duration (hh:mm:ss): ");
            TryParseFlexible(Console.ReadLine() ?? "00:00:00", out TimeSpan startTime);

            Console.Write("Insert a final duration (hh:mm:ss): ");
            TryParseFlexible(Console.ReadLine() ?? "00:00:00", out TimeSpan endTime);

            ControllerCalcs.Sum(startTime, endTime, out TimeSpan duration);

            Console.WriteLine($"\nThe sum of the durations is: {FormatDuration(duration)}");

            NewCalc();
        }

        public static void Subtract()
        {
            Console.Clear();

            Console.Write("Insert an initial duration (hh:mm:ss): ");
            TryParseFlexible(Console.ReadLine() ?? "00:00:00", out TimeSpan StartTime);

            Console.Write("Insert a final duration (hh:mm:ss): ");
            TryParseFlexible(Console.ReadLine() ?? "00:00:00", out TimeSpan EndTime);

            ControllerCalcs.Subtract(StartTime, EndTime, out TimeSpan duration);

            Console.WriteLine($"\nThe subtraction of the durations is: {FormatDuration(duration)}");

            NewCalc();
        }

        public static void NewCalc()
        {
            Console.Write("\nDo you want to perform another calculation? (y/n): ");
            char response = char.Parse(Console.ReadLine() ?? "n");
            response = char.ToLower(response); // Guarantee the input is lowercase to avoid case sensitivity issues

            // Same thing as in Program.cs
            while (response != 'y' && response != 'n')
            {
                Console.Clear();

                Console.Write("Invalid option!");

                System.Threading.Thread.Sleep(2000);
                Console.Clear();

                Console.Write("\nDo you want to perform another calculation? (y/n): ");
                response = char.Parse(Console.ReadLine() ?? "n");
                response = char.ToLower(response);
            }

            if (response == 'y')
            {
                Console.Clear();
                
                Console.Write("Do you want to add or subtract? (1 - Sum / 2 - Subtract): ");
                int option = int.Parse(Console.ReadLine() ?? "1");

                // Same thing as above
                while (option != 1 && option != 2)
                {
                    Console.Clear();

                    Console.WriteLine("Invalid option!");
                    System.Threading.Thread.Sleep(2000);

                    Console.Clear();
                    Console.Write("Do you want to add or subtract? (1 - Sum / 2 - Subtract): ");
                    option = int.Parse(Console.ReadLine() ?? "1");
                }

                switch (option)
                {
                    case 1:
                        Sum();
                        break;
                    case 2:
                        Subtract();
                        break;
                }
                
            }
            else if (response == 'n')
            {
                Exit();
            }
        }

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using the Calculator!");

            // Prints a little exit animation, with dots appearing one by one.
            System.Threading.Thread.Sleep(1000);
            Console.Write("Exiting");

            System.Threading.Thread.Sleep(750);
            Console.Write(".");

            System.Threading.Thread.Sleep(750);
            Console.Write(".");

            System.Threading.Thread.Sleep(750);
            Console.Write(".");

            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0); // force termination of the application
        }

        // Format TimeSpan as HHH:mm:ss using total hours to avoid "d.hh:mm:ss" output when days are present.
        private static string FormatDuration(TimeSpan ts)
        {
            long totalHours = (long)ts.TotalHours; // total whole hours (may be > 24)
            return $"{totalHours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}";
        }

        // Attempts to parse a string into a TimeSpan, supporting "HHH:mm:ss" and "hh:mm:ss" formats.
        private static bool TryParseFlexible(string s, out TimeSpan result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(s)) return false; // Fail on empty/null input.

            var parts = s.Trim().Split(':'); // Split into hours, minutes, and seconds.

            // Try parsing 3-part format (hours, minutes, seconds).
            if (parts.Length == 3
                && long.TryParse(parts[0], out long hours)
                && int.TryParse(parts[1], out int minutes)
                && int.TryParse(parts[2], out int seconds)
                && minutes >= 0 && minutes < 60
                && seconds >= 0 && seconds < 60)
            {
                result = TimeSpan.FromHours(hours) + TimeSpan.FromMinutes(minutes) + TimeSpan.FromSeconds(seconds);
                return true;
            }

            // Try parsing 2-part format (minutes, seconds).
            if (parts.Length == 2
                && int.TryParse(parts[0], out int mm)
                && int.TryParse(parts[1], out int ss)
                && mm >= 0 && ss >= 0 && ss < 60)
            {
                result = TimeSpan.FromMinutes(mm) + TimeSpan.FromSeconds(ss);
                return true;
            }

            return TimeSpan.TryParse(s, out result); // Fallback to standard TimeSpan parsing.
        }
    }
}