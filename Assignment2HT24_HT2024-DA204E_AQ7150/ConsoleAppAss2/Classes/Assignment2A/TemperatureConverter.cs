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
            const int fahrenHeitMax = 212;
            const int interval = 10; 

            // formula: C = 5/9 *(F - 32)
            Console.WriteLine("\nFahrenHeit to Celsius conversion table:");

            for (int fahrenheit = 0; fahrenheit < fahrenHeitMax; fahrenheit += interval)
            {
                double celsius = Math.Round((5.0 / 9.0) * (fahrenheit - 32), 2);
                Console.WriteLine($"{fahrenheit} F = {celsius}C");
            }

        }



        private void ConvertCelsiusToFahrenheit()
        {
            const int celsiusMax = 100;
            const int interval = 5;
            Console.WriteLine("\nCelsius to Fahrenheit conversion table:");

            for (int celsius = 0; celsius < celsiusMax; celsius+=interval)
            {
                double fahrenheit = Math.Round((9.0 / 5.0) * celsius + 32);
                Console.WriteLine($"{celsius} C = {fahrenheit} F");
            }


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
