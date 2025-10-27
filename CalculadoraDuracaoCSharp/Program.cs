using CalculadoraDuracaoCSharp;
using CalculadoraDuracaoCSharp.View;

namespace CalculadoraDuracaoCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewCalcs.Menu();

            int option;

            // Validate the option: keep prompting while the option is not 0, 1 or 2.
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.Clear();

                Console.WriteLine("Invalid option!");
                System.Threading.Thread.Sleep(2000);

                Console.Clear();
                ViewCalcs.Menu();
            }

            switch (option)
            {
                case 1:
                    ViewCalcs.Sum();
                    break;
                case 2:
                    ViewCalcs.Subtract();
                    break;
                case 0:
                    ViewCalcs.Exit();
                    break;
            }
        }
    }
}