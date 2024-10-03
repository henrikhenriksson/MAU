using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAss2.Classes.Assignment2C
{
    internal class MathWork
    {
        public void Start() { }

        private void Calculate()
        {
            bool continueRunning = true;

            if (continueRunning)
            {
                do
                {
                    int start = Utility.GetIntInput("Enter a starting Integer (or 'x' to Exit");
                    int end = Utility.GetIntInput("Enter an Ending Integer (or 'x' to exit)", start); // the end should not be bigger than the start



                    Console.WriteLine("+++++ Summation of  your numbers +++++");
                    Console.WriteLine($"The sum of numbers from {start} to {end} is: {SumNumbers(start, end)}");



                    continueRunning = ExitCalculation();
                }
                while (continueRunning);
            }
        }
        private void CalculateSquareRoots(int num1, int num2) { }

        private bool ExitCalculation()
        {
            string userInput = Utility.ReadInput("Press 'x' to exit or any key to continue");
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


            Console.WriteLine($"++++++ Even numbers in the range {num1} to {num2}+++++");

            const int entriesPerRow = 12;
            int currentEntry = 0;


            // print each even number in the list
            foreach (int evenNumber in evenNumbers)
            {

                Console.Write($"{evenNumber,-5} ");

                currentEntry++;

                // print new line and reset counter
                if(currentEntry >= entriesPerRow)
                {
                    Console.WriteLine();
                    currentEntry = 0;
                }

            }


        }

        private void printMultiplicationTable() { }

        private void PrintOddNumbers(int num1, int num2) { }

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
