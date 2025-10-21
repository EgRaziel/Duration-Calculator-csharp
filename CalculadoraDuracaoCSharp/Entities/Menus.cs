using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraDuracaoCSharp
{
    public class Menus
    {
        public static void Menu()
        {
            // Calculates the necessary padding for centering the title.
            string bars = new string('=', 37);
            string title = "DURATION CALCULATOR";
            string version = "1.1.0";
            int width = bars.Length;
            int titleWidth = title.Length + 2 + ("v" + version).Length; // include version label and spacing when centering
            int spaces = (width - titleWidth) / 2;

            // print top border of the header
            System.Threading.Thread.Sleep(400);
            System.Console.WriteLine(bars);

            // print centered title using calculated padding
            System.Threading.Thread.Sleep(400);
            Console.WriteLine(new string(' ', spaces) + title + "  " + "v" + version); // print centered title with version

            // print bottom border of the header
            System.Threading.Thread.Sleep(400);
            System.Console.WriteLine(bars);

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
            TimeSpan StartTime = ParseFlexible(Console.ReadLine());

            Console.Write("Insert a final duration (hh:mm:ss): ");
            TimeSpan EndTime = ParseFlexible(Console.ReadLine());

            Calcs calc = new Calcs(StartTime, EndTime);
            calc.Sum();

            Console.WriteLine($"\nThe sum of the durations is: {FormatDuration(calc.Duration)}");

            NewCalc();
        }

        public static void Subtract()
        {
            Console.Clear();

            Console.Write("Insert an initial duration (hh:mm:ss): ");
            TimeSpan StartTime = ParseFlexible(Console.ReadLine());

            Console.Write("Insert a final duration (hh:mm:ss): ");
            TimeSpan EndTime = ParseFlexible(Console.ReadLine());

            Calcs calc = new Calcs(StartTime, EndTime);
            calc.Subtract();

            Console.WriteLine($"\nThe subtraction of the durations is: {FormatDuration(calc.Duration)}");

            NewCalc();
        }

        public static void NewCalc()
        {
            Console.Write("\nDo you want to perform another calculation? (y/n): ");
            char response = char.Parse(Console.ReadLine().ToLower());

            // Same thing as in Program.cs
            while (response != 'y' && response != 'n')
            {
                Console.Clear();

                Console.Write("Invalid option!");

                System.Threading.Thread.Sleep(2000);
                Console.Clear();

                Console.Write("\nDo you want to perform another calculation? (y/n): ");
                response = char.Parse(Console.ReadLine().ToLower()); // Guarantee the input is lowercase to avoid case sensitivity issues
            }

            if (response == 'y')
            {
                Console.Clear();
                
                Console.Write("Do you want to add or subtract? (1 - Add / 2 - Subtract): ");
                int option = int.Parse(Console.ReadLine());

                // Same thing as above
                while (option != 1 && option != 2)
                {
                    Console.Clear();

                    Console.WriteLine("Invalid option!");
                    System.Threading.Thread.Sleep(2000);

                    Console.Clear();
                    Console.Write("Do you want to add or subtract? (1 - Add / 2 - Subtract): ");
                    option = int.Parse(Console.ReadLine());
                }

                if (option == 1)
                {
                    Sum();
                }
                else if (option == 2)
                {
                    Subtract();
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

        // Minimal helper: try built-in parser first, then accept HHH:mm:ss by manual parsing.
        private static TimeSpan ParseFlexible(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new FormatException("Empty time input.");

            if (TimeSpan.TryParse(input.Trim(), out TimeSpan ts)) return ts; // accept normal formats

            var parts = input.Trim().Split(':');
            if (parts.Length == 3 &&
                long.TryParse(parts[0], out long hours) &&
                int.TryParse(parts[1], out int minutes) &&
                int.TryParse(parts[2], out int seconds) &&
                minutes >= 0 && minutes < 60 &&
                seconds >= 0 && seconds < 60)
            {
                return TimeSpan.FromHours(hours) + TimeSpan.FromMinutes(minutes) + TimeSpan.FromSeconds(seconds);
            }

            throw new FormatException("Invalid time format. Use HHH:mm:ss or hh:mm:ss.");
        }
    }
}