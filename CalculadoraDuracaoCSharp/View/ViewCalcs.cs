using System;
using CalculadoraDuracaoCSharp.Controller;

namespace CalculadoraDuracaoCSharp.View
{
    public class ViewCalcs
    {
        public static void Menu()
        {
            Console.WriteLine("+=====================================+");
            Console.WriteLine("+         DURATION CALCULATOR  v1.3.0 +");
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

            Console.WriteLine($"\nThe sum of the durations is: {FormatDuration(ControllerCalcs.Sum(startTime, endTime))}");

            NewCalc();
        }

        public static void Subtract()
        {
            Console.Clear();

            Console.Write("Insert an initial duration (hh:mm:ss): ");
            TryParseFlexible(Console.ReadLine() ?? "00:00:00", out TimeSpan startTime);

            Console.Write("Insert a final duration (hh:mm:ss): ");
            TryParseFlexible(Console.ReadLine() ?? "00:00:00", out TimeSpan endTime);

            Console.WriteLine($"\nThe subtraction of the durations is: {FormatDuration(ControllerCalcs.Subtract(startTime, endTime))}");

            NewCalc();
        }

        public static void NewCalc()
        {
            Console.Write("\nDo you want to perform another calculation? (y/n): ");
            string response = (Console.ReadLine() ?? "n").ToLower(); // Guarantee the input is lowercase to avoid case sensitivity issues

            // Same thing as in Program.cs
            while (response != "y" && response != "n")
            {
                Console.Clear();

                Console.Write("Invalid option!");

                System.Threading.Thread.Sleep(2000);
                Console.Clear();

                Console.Write("\nDo you want to perform another calculation? (y/n): ");
                response = (Console.ReadLine() ?? "n").ToLower();
            }

            if (response == "y")
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
            else if (response == "n")
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

        // Uses and shows the received values as they are (e.g., 25:00:00 will be 25 hours, not 1 day and 1 hour)
        // The "int" makes sure only the integer part of the values are used (e.g., 25.5:00:00 == 25:00:00)
        private static string FormatDuration(TimeSpan ts) => $"{(int)ts.TotalHours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}";

        // Attempts to parse a string into a TimeSpan, supporting "HHH:mm:ss" and "hh:mm:ss" formats.
        private static bool TryParseFlexible(string s, out TimeSpan result)
        {
            result = default;

            try
            {
                // Split the values using the ":". Transform them in double. Then each single value will be an array
                // double.Parse converts to double, removing the difference between single digits and digits with starting zero
                    // e.g., 6:30:00 == 06:30:00
                    // The calc will be made in the same way because of the arrays. And then FormatDuration will change the format to 06:30:00 when printing
                var p = s.Split(':').Select(double.Parse).ToArray();
            
                // Makes a different operation depending on how much "values" user enters
                // e.g., 12:30:00 == 12:30:30 | 30:30 == 00:30:30 | 30 == 00:30:30
                result = p.Length switch
                {
                    3 => TimeSpan.FromHours(p[0]) + TimeSpan.FromMinutes(p[1]) + TimeSpan.FromSeconds(p[2]),
                    2 => TimeSpan.FromMinutes(p[0]) + TimeSpan.FromSeconds(p[1]),
                    1 => TimeSpan.FromSeconds(p[0]),
                    _ => throw new Exception()
                };

                return true;
            } catch { return false; }
        }
    }
}