using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace Speed_typing_test
{
    internal class Program
    {
        static void Main()
        {
            ConsoleKeyInfo key;
            string name;
            Console.Write("Введите своё имя: ");
            name = Console.ReadLine();
            Console.Clear();
            
            do
            {
                STTest.Text();
                Console.WriteLine("\n\nНажмите Enter для начала");
                STTest.Record();
                Thread time = new Thread(new ThreadStart(STTest.Timer));
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    time.Start();
                    STTest.Test(name, time); 
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            } while (true);


        }
    }
}