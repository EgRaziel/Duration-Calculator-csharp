using CalculadoraDuracaoCSharp;

namespace CalculadoraDuracaoCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menus.Menu();

            int option = int.Parse(Console.ReadLine());

            // Validate the option: keep prompting while the option is not 0, 1 or 2.
            while (option != 0 && option != 1 && option != 2)
            {
                Console.Clear();

                Console.WriteLine("Invalid option!");
                System.Threading.Thread.Sleep(2000);

                Console.Clear();
                Menus.Menu();
                option = int.Parse(Console.ReadLine());
            }

            if (option == 1)
            {
                Menus.Sum();
            }
            else if (option == 2)
            {
                Menus.Subtract();
            }
            else if (option == 0)
            {
                Menus.Exit();
            }
        }
    }
}