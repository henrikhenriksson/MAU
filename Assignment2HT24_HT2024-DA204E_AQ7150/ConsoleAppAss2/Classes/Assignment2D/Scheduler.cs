// Written by: Henrik Henriksson (AQ7150)


using System.Numerics;

namespace ConsoleAppAss2.Classes.Assignment2D
{
    internal class Scheduler
    {
        private readonly List<int> WeeksInYear = new();

        public Scheduler()
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


            bool continueRunning = true;


            do
            {
                PresentMenuOptions();
                int selection = Utility.GetIntInput("Select an option: ", 0, 2);

                if (selection == 0)
                {
                    Console.WriteLine("Exiting program");
                    continueRunning = false;
                    break;
                }

                int weekendStartWeek = 2;
                int weekendInterval = 2;

                int nightStartWeek = 2;
                int nightInterval = 4;



                switch (selection)
                {
                    case 1:

                        DisplaySchedule("Weekend", weekendStartWeek, weekendInterval);
                        break;

                    case 2:
                        DisplaySchedule("Night", nightStartWeek, nightInterval);
                        break;

                    default:
                        Console.WriteLine("Invalid Selection!");
                        break;
                }


            }
            while (continueRunning);

        }
        // Tuples is an awesome concept!
        private (int startWeek, int interval) ConfigParameters(string shiftType, int defaultStartweek, int defaultInterval)
        {

            Console.WriteLine($"\nConfig {shiftType} parameters");

            Console.Write($"Enter a start week for {shiftType} shifts, default is: {defaultStartweek}");
            string startWeekInput = Console.ReadLine();

            int startWeek = string.IsNullOrWhiteSpace(startWeekInput) ? defaultStartweek : int.Parse(startWeekInput);

            Console.Write($"Enter an interval for {shiftType} shifts, default is: {defaultInterval}");

            string intervalInput = Console.ReadLine();
            int interval = string.IsNullOrWhiteSpace(intervalInput) ? defaultInterval : int.Parse(intervalInput);   

            return (startWeek, interval);


        }

        private void PresentMenuOptions()
        {
            Console.Title = "Scheduler";
            Console.WriteLine("+++++ The Scheduler! +++++");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Your Work Schedule", -20);
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("\nMenu Options: ");
            Console.WriteLine("1. Config and Show a list of the weekends to work");
            Console.WriteLine("2. Config and Show a list of the nights to work");
        }



        private void DisplaySchedule(string shiftType, int startWeek, int interval)
        {
            // select corresponding List based on user selection
            List<int> scheduledWeeksToDislplay = GetShiftWeeks(startWeek, interval);

            Console.WriteLine($"\n+++++ {shiftType} Weeks +++++");

            foreach (var week in scheduledWeeksToDislplay)
            {
                Console.WriteLine($"{week}");
            }

            Console.WriteLine();
        }



    }
}
