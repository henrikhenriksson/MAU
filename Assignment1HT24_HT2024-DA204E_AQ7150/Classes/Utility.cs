namespace Assignment1HT24_HT2024_DA204E_AQ7150.Classes
{
    public static class Utility
    {


        public static int GetIntInput(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            int inputValue = -1;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write($"{message} : ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out inputValue) && inputValue >= min && inputValue <= max)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter a valid integer between {min} and {max}.");
                }
            }

            return inputValue;
        }

        public static double GetDoubleInput(string message, double min = double.MinValue, double max = double.MaxValue)
        {
            double inputValue = -1;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write($"{message} : ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out inputValue) && inputValue >= 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter a valid decimal number between {min} and {max}.");
                }
            }

            return inputValue;
        }
        public static string ReadInput(string message)
        {
            string userInput = string.Empty;

            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.Write($"{message} : ");
                userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Input cannot be empty or just whitespace. Please enter a valid name.");
                }
            }

            return userInput;
        }

    }
}
