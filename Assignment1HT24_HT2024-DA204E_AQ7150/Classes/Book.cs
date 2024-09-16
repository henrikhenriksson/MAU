namespace Assignment1HT24_HT2024_DA204E_AQ7150.Classes
{
    internal class Book
    {
        private string title;
        private string author;
        private double price;
        private int yearPublished;


        public Book()
        {
            title = string.Empty;
            author = string.Empty;
            price = -1;
            yearPublished = -1;

        }


        public void Start()
        {

            ReadBookInformation();
            CalculateDiscount();
            DisplayBookInformation();

        }

        private void DisplayBookInformation()
        {
            Console.WriteLine(
                $"\n+++ Book Information +++" +
                $"\n+++ Book Title: {title} +++" +
                $"\n+++ Author: {author} +++" +
                $"\n+++ Original Price: {price} +++" +
                $"\n+++ Book Age (Published {yearPublished}): {CalculateAge()} year(s) +++" +
                $"\n+++ yearly discount based on age: {getDiscountRate(CalculateAge())*100:F1} % +++" +
                $"\n+++ Discounted price: {CalculateDiscount():F2} +++"


                );
        }

        private int CalculateAge()
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - yearPublished;
        }

        private double CalculateDiscount()
        {
            int age = CalculateAge();

            // We have a dynamic price reduction based on the age of the book according to the following table
            double discountRate = getDiscountRate(age);



            // 50 % is the maximum discount
            double totalDiscount = Math.Min(age * discountRate, 0.50);

            return Math.Round(price * (1 - totalDiscount), 2);

        }

        private double getDiscountRate(int age)
        {
            switch (age)
            {
                case <= 10:
                    return 0.005;
                case <= 20:
                    return 0.010;
                default:
                    return 0.025;
            }

        }

        private void ReadBookInformation()
        {
            title = Utility.ReadInput("What is the title of the book?");
            author = Utility.ReadInput($"Who authored {title}?");
            price = Utility.GetDoubleInput("What was the price of the book when new?", 0, 10000000); // We assume no book is worth more than 10 million
            yearPublished = Utility.GetIntInput("What year was the book published?", -3000, DateTime.Now.Year); // We assume no books are older than 5000 years.
        }



    }
}
