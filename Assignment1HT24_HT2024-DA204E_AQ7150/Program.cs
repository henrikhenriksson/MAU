using Assignment1HT24_HT2024_DA204E_AQ7150.Classes;
using System;

namespace MyApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            SetupConsoleWindow();

            Console.Title = " My Favorite Pet ";

            Pet pet = new();

            pet.Start();


            Console.WriteLine("Press enter to start the next part!");
            Console.ReadLine();


        }

        private static void SetupConsoleWindow()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "My Console Classes";
        }

    }

   

}