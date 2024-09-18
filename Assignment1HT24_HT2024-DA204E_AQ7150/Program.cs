using Assignment1HT24_HT2024_DA204E_AQ7150.Classes;

// Written by: Henrik Henriksson (AQ7150)


namespace MyApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            SetupConsoleWindow();

            ShowPetClass();

            AwaitUserInput();

            ShowTicketSellerClass();

            AwaitUserInput();

            ShowAlbumClass();

            AwaitUserInput();

            ShowBookClass();

            AwaitUserInput();

        }

        private static void ShowBookClass()
        {
            Console.Title = " My Book Discount";

            Console.WriteLine("Starting the Book Class Showcase");

            Book book = new();

            book.Start();

        }

        private static void ShowAlbumClass()
        {

            Console.Title = " My Favorite Album ";

            Console.WriteLine("Starting the album program");

            Album album = new();

            album.Start();

        }

        private static void ShowTicketSellerClass()
        {
            Console.Title = "TicketSeller";

            TicketSeller ticketSeller = new();

            ticketSeller.Start();

        }

        private static void AwaitUserInput()
        {
            Console.WriteLine("\nPress enter to start the next part!\n");
            Console.ReadLine();

        }

        private static void ShowPetClass()
        {
            Console.Title = " My Favorite Pet ";

            Pet pet = new();

            pet.Start();
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