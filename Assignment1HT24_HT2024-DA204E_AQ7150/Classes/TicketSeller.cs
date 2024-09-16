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

           
            name = Utility.ReadInput("Your name please?");
            numberOfAdults = Utility.GetIntInput("Number of adults?");
            numberOfChildren = Utility.GetIntInput("Number of children: ");
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