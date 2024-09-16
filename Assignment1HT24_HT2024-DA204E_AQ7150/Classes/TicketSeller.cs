namespace Assignment1HT24_HT2024_DA204E_AQ7150.Classes
{
    internal class TicketSeller
    {
        private double amountToPay;
        private string name;
        private int numberOfAdults;
        private int numberOfChildren;
        private double price = 100.0;

        public TicketSeller()
        {
            amountToPay = -1;
            name = string.Empty;
            numberOfAdults = -1;
            numberOfChildren = -1;
        }

        private void CalculateAmountToPay()
        {
            double childPrice = price * 0.25;
            Console.WriteLine(childPrice.ToString());

            amountToPay = (numberOfAdults * price) + (numberOfChildren * childPrice);
        }

        private void ReadInput()
        {
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Your name please?");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("The name cannot be empty or just whitespace. Please enter a valid name.");
                }
            }
            try
            {
                numberOfAdults = GetNumberInput("Number of adults?");
                numberOfChildren = GetNumberInput("Number of children: ");
            }
            catch (Exception e)
            {
                Console.WriteLine($"A user input generated error has occurred: {e.Message}");
            }
        }

        private int GetNumberInput(string message)
        {
            int parsedNumber = -1;
            bool isValidInt = false;
            string input = string.Empty;

            while (parsedNumber < 0)
            {
                Console.WriteLine(message);
                input = Console.ReadLine();

                isValidInt = int.TryParse(input, out parsedNumber);

                if (isValidInt && parsedNumber >= 0)
                {
                    // Valid input
                    return parsedNumber;
                }
                else if (!isValidInt)
                {
                    Console.WriteLine($"Your input {input} is not a valid number."
                        + $"\n Please enter your pet as a number");
                }
                else
                {
                    Console.WriteLine("Age cannot be negative. Please enter a valid age");
                }
            }
            return parsedNumber;
        }

        private void ShowResults()
        {
            Console.WriteLine($"+++ Your receipt +++" +
                $"\n+++ Amount to pay: {amountToPay:F2} SEK" +
                $"\n+++ Price per Ticket: {price:F2} +++" +
                $"\n\nThank you {name} and please come back!");
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the KID'S FAIR!\n" +
                "Children always get a 75 % discount!");

            ReadInput();
            CalculateAmountToPay();
            ShowResults();
        }
    }
}