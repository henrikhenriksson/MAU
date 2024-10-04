// Written by: Henrik Henriksson(AQ7150)


namespace ConsoleAppAss2.Classes.Assignment2B
{
    internal class StringFunctions
    {

        public void Start()
        {

            bool continueRunning = true;

            do
            {
                Console.Title = "String Functions (Assignment 2B)";
                Console.WriteLine("++++++++++++ String Functions ++++++++++++");

                Console.WriteLine("\n++++++++++++ String Length ++++++++++++");
                string messagePrompt = "Write a text with any number of characters and press Enter.\nAlternatively, you can copy and paste a text into this window";
                string inputMessage = Utility.ReadInput(messagePrompt).Trim(); // Trim any whitespace chars that might be copied.
                Console.WriteLine($"\n{StringLength(inputMessage)}");
                messagePrompt = ""; // reset to prevent undesired behaviour

                Console.WriteLine("\n++++++++++++ The Fortune Teller ++++++++++++");
                messagePrompt = "\nLet me predict your day!\nSelect a day between 1 and 7";
                int selection = Utility.GetIntInput(messagePrompt, 1, 7);

                Console.WriteLine(PredictMyDay(selection));

                continueRunning = RunAgain();
            }
            while (continueRunning);
        }

        private bool RunAgain()
        {
            while (true)
            { // run forever until a valid input is read

                string input = Utility.ReadInput("\n\nWould you like to continue running this program?");
                if (input.ToLower() == "y")
                {
                    return true;
                }
                else if (input.ToLower() == "n")
                { return false; }
                else
                {
                    Console.WriteLine("Invalid input, enter 'y/Y' for yes, or 'n/N' for no");
                }
            }


        }



        // this method returns a string with the input message in upper case and the number of chars in the string.
        private string StringLength(string inputMessage)
        {
            return $"{inputMessage.ToUpper()} Number of Chars: {inputMessage.Length}";
        }

        private string PredictMyDay(int selection)
        {

            switch (selection)
            {
                case 1:
                    return "Keep calm on Mondays! You can fall apart!";
                case 2:
                    return "Tuesdays and Wednesdays break your heart!";
                case 3:
                    return "Tuesdays and Wednesdays break your heart!";
                case 4:
                    return "Thursday is your lucky day, don't wait for Friday!";
                case 5:
                    return "Friday, you are in love!";
                case 6:
                    return "Saturday, do nothing and do plenty of it!";
                case 7:
                    return "And Sunday always comes too soon!";
                default:
                    return "No day? A good day but it doesn't exist!";
            }
        }

    }
}
