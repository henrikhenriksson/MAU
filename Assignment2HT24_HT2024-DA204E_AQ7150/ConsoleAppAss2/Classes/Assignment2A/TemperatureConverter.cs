// Written by: Henrik Henriksson (AQ7150)  


using System.Numerics;

namespace ConsoleAppAss2.Classes.Assignment2A
{
    internal class TemperatureConverter
    {

        // Entrance point
        public void Start()
        {

            int choice;
            do
            {
                PresentMainMenu();

                choice = getUserInput();


                switch (choice)
                {

                    case 1:

                        ConvertFahrenheitToCelsius();
                        break;

                    case 2:
                        ConvertCelsiusToFahrenheit();
                        break;
                    case 3:
                        Console.WriteLine("Exiting Program");
                        break;
                    default:
                        Console.WriteLine("Invalid Selection, please choose 1,2 or 0 to quit");
                        break;
                }
                if (choice != 0)
                {
                    Console.WriteLine("Press Enter to return to menu");
                    Console.ReadLine();
                }

            }
            while (choice != 0);




        }

        private void ConvertFahrenheitToCelsius()
        {
            // formula: C = 5/9 *(F - 32)


        }



        private void ConvertCelsiusToFahrenheit()
        {
            // formula: F = 9/5 * C + 32

        }

        private int getUserInput()
        {

            int choice = -1;

            while (!int.TryParse(Console.ReadLine(), out choice)
                || choice < 0
                || choice > 2)
            {

                Console.WriteLine("Invalid Selection, please choose 1,2 or 0 to quit");

            }

            return choice;


        }

        private void PresentMainMenu()
        {

            // fix form/size of console
            Console.Clear();
            Console.WriteLine("Temperature Converter");
            Console.WriteLine("1. Convert Fahrenheit to Celsius");
            Console.WriteLine("2. Convert Celsius to Fahrenheit");
            Console.WriteLine("0. Exit");
            Console.Write("Chose an option: ");


        }

    }



}
