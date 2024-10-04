// Written by: Henrik Henriksson (AQ7150)


using System.Numerics;

namespace ConsoleAppAss2.Classes.Assignment2D
{
    internal class SchedulerApp
    {
        private readonly List<int> WeeksInYear = new();

        public SchedulerApp()
        {

            // fill the list with 52 indexes
            for (int week = 1; week <= 52; week++)
            {
                WeeksInYear.Add(week);

            }
        }

        private List<int> GetShiftWeeks(int startWeek, int interval)
        {
            List<int> shiftWeeks = new List<int>();

            for (int week = startWeek; week <= WeeksInYear.Count; week += interval)
            {
                shiftWeeks.Add(week);
            }

            return shiftWeeks;
        }

        // Entry point
        public void Run()
        {
            Console.Title = "Scheduler";

            while (true)
            {
                PresentMenuOptions();
                int selection = Utility.GetIntInput("Select an option: ", 0, 2);

                if (selection == 0)
                {
                    Console.WriteLine("Exiting program");
                    break;
                }




                switch (selection)
                {
                    case 1:
                        var (weekendStartWeek, weekendInterval) = ConfigParameters("Weekend", 2, 2); // set defaults and shiftType
                        DisplaySchedule("Weekend", weekendStartWeek, weekendInterval);
                        break;

                    case 2:
                        var (nightStartWeek, nightInterval) = ConfigParameters("Night", 1, 4);
                        DisplaySchedule("Night", nightStartWeek, nightInterval);
                        break;

                    default:
                        Console.WriteLine("Invalid Selection!");
                        break;
                }


            }

        }
        // Tuples is an awesome concept!
        private (int startWeek, int interval) ConfigParameters(string shiftType, int defaultStartweek, int defaultInterval)
        {

            Console.WriteLine($"\nConfig {shiftType} parameters");

            int startWeek= GetInputInt($"Enter a Start week for {shiftType} Schedule.", defaultStartweek, 1,52);
            int interval = GetInputInt($"Enter an interval for {shiftType} Schedule.", defaultInterval, 1, 52);

            return (startWeek, interval);
        }




        private void PresentMenuOptions()
        {
            Console.WriteLine("+++++ The Scheduler! +++++");
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Your Work Schedule");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("\nMenu Options: ");
            Console.WriteLine("1. Config and Show a list of the weekends to work");
            Console.WriteLine("2. Config and Show a list of the nights to work");
            Console.WriteLine("0. Exit the program");

        }



        private void DisplaySchedule(string shiftType, int startWeek, int interval)
        {
            // select corresponding List based on user selection
            List<int> scheduledWeeksToDisplay = GetShiftWeeks(startWeek, interval);

            Console.WriteLine($"\n+++++ {shiftType} Weeks +++++");

            foreach (var week in scheduledWeeksToDisplay)
            {
                Console.WriteLine($"{week}");
            }

            Console.WriteLine();
        }

        // Custom implementation of helper function as to accept whitespace for defaults
        private static int GetInputInt(string message, int defaultValue, int min, int max)
        {
            int inputValue = -1;
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine($"{message} (Press Enter for Default: {defaultValue})");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return defaultValue;
                }

                if (int.TryParse(input, out inputValue)
                    && inputValue >= min
                    && inputValue <= max)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter a valid integer between {min} and {max} or press Enter default.");
                }
            }

            return inputValue;
        }
    }
}
