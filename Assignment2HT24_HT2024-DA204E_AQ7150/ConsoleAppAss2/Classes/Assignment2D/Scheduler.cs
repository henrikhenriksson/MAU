// Written by: Henrik Henriksson (AQ7150)


namespace ConsoleAppAss2.Classes.Assignment2D
{
    internal class Scheduler
    {
        private const int WeeksInYear = 52;
        private List<int> WeekendShiftWeeks = new List<int>();
        private List<int> NightShiftWeeks = new List<int>();


        // Entry point
        public void Run()
        {
            GenerateShiftWeekends();
            GenerateShiftNights();

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

                switch (selection)
                {
                    case 1:
                        displaySchedule("Weekend");
                        break;

                    case 2:
                        displaySchedule("Night");
                        break;

                    default:
                        Console.WriteLine("Invalid Selection!")
                        break;
                }


            }
            while (continueRunning);

        }



        private void PresentMenuOptions()
        {
            Console.Title = "Scheduler";
            Console.WriteLine("+++++ The Scheduler! +++++");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Your Work Schedule", -20);
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("\nMenu Options: ");
            Console.WriteLine("1. Show a list of the weekends to work");
            Console.WriteLine("2. Show a list of the nights to work");
        }

        private void GenerateShiftNights()
        {
            // Night shifts increment of 4 starting first week
            for (int week = 1; week <= WeeksInYear; week += 4)
            {
                NightShiftWeeks.Add(week);
            }

        }

        private void GenerateShiftWeekends()
        {

            // Weekendshifts based on an increment of 2 for every other weekend
            for (int week = 2; week <= WeeksInYear; week += 2)
            {
                WeekendShiftWeeks.Add(week);
            }
        }

        private void displaySchedule(string shiftType)
        {
            // select corresponding List based on user selection
            List<int> scheduledWeeksToDislplay = shiftType == "WeekendSched" ? WeekendShiftWeeks : NightShiftWeeks;



        }



    }
}
