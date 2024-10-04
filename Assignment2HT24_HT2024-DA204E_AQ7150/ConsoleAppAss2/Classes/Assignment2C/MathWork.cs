// Written by: Henrik Henriksson(AQ7150)

namespace ConsoleAppAss2.Classes.Assignment2C
{
    internal class MathWork
    {
        public void Start()
        {

            Console.Title = "Math Works!";
            Calculate();
        }

        private void Calculate()
        {
            bool continueRunning = true;

            if (continueRunning)
            {
                do
                {
                    int firstEntry = Utility.GetIntInput("Enter a starting Integer: ");
                    int secondEntry = Utility.GetIntInput("Enter an Ending Integer:");

                    int start;
                    int end;

                    if (firstEntry < secondEntry)
                    {
                        start = firstEntry;
                        end = secondEntry;
                    }
                    else
                    {
                        start = secondEntry;
                        end = firstEntry;
                    }



                    Console.WriteLine("\n+++++ Summation of  your numbers +++++");
                    Console.WriteLine($"\nThe sum of numbers from {start} to {end} is: {SumNumbers(start, end)}");

                    PrintEvenNumbers(start, end);
                    PrintOddNumbers(start, end);

                    CalculateSquareRoots(start, end);

                    continueRunning = ExitCalculation();
                }
                while (continueRunning);
            }
        }
        private void CalculateSquareRoots(int num1, int num2)
        {

            Console.WriteLine("+++++ Square Roots +++++");


            // outer loop prints a row
            for (int i = num1; i <= num2; i++)
            {
                string resultRow = string.Empty; // this string will hold the accumulated sqrts

                for (int j = i; j <= num2; j++)
                {
                    double sqrt = Math.Sqrt(j);

                    resultRow += $"{sqrt:F2}\t";
                }
                Console.WriteLine($"Sqrt({i} to {num2,-3})\t{resultRow.Trim()}");
            }



        }

        private bool ExitCalculation()
        {
            string userInput = Utility.ReadInput("\nPress 'x' to exit or any letter key to continue");
            return !userInput.Equals("x", StringComparison.CurrentCultureIgnoreCase); // return false
        }

        private void PrintEvenNumbers(int num1, int num2)
        {

            List<int> evenNumbers = new List<int>(); // List for dynamic size

            for (int i = 0; i <= num2; i++)
            {
                if (i % 2 == 0) // check if even
                {
                    evenNumbers.Add(i);
                }
            }

            if (evenNumbers.Count < 1)
            {
                Console.WriteLine($"No even numbers found in the range: {num1} to {num2}");
                return;
            }
            PrintNumbersInRows(evenNumbers, 12, $"Even numbers in the range {num1} to {num2}");

        }

        private void printMultiplicationTable()
        {
            // I'm leaving this method out as it seems to have been omitted from the instructions.
            throw new NotImplementedException();

        }

        private void PrintOddNumbers(int num1, int num2)
        {

            List<int> oddNumbers = new List<int>();

            for (int i = num1; i <= num2; i++)
            {
                if (i % 2 != 0) // add if there is a remainder
                {
                    oddNumbers.Add(i);
                }
            }

            if (oddNumbers.Count < 1)
            {
                Console.WriteLine($"No odd numbers found in the range: {num1} to {num2}");
                return;

            }

            PrintNumbersInRows(oddNumbers, 12, $"Odd numbers in the range {num1} to {num2}");


        }

        // this method is extracted to perform printing for the two number printing methods.
        private void PrintNumbersInRows(List<int> numbers, int entriesPerRow, string message)
        {

            int currentEntry = 0;

            Console.WriteLine($"\n+++++ {message} +++++");

            foreach (var number in numbers)
            {
                Console.Write($"{number,-10}");

                currentEntry++;

                if (currentEntry >= entriesPerRow)
                {
                    Console.WriteLine();
                    currentEntry = 0;
                }

            }
            Console.WriteLine();

        }


        private int SumNumbers(int start, int end)
        {

            int sum = 0;

            for (int i = start; i <= end; i++)
            {
                sum += i;
            }
            return sum;

        }

    }
}
