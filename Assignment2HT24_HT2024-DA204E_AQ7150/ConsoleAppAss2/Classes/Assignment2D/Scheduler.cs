using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAss2.Classes.Assignment2D
{
    internal class Scheduler
    {
        private const int weeksInYear = 52;
        private List<int> WeeksWithWeekendShifts = new List<int>();
        private List<int> WeeksWithNightShifts = new List<int>();


        // Entry point
        public void Run()
        {
            GenerateShiftWeekends();
            GenerateShiftNights();


        }

        private void GenerateShiftNights()
        {
            // Night shifts increment of 4 starting first week
            for (int week = 1; week <= weeksInYear; week+=4)
            {
                WeeksWithNightShifts.Add(week);
            }

        }

        private void GenerateShiftWeekends()
        {

            // Weekendshifts based on an increment of 2 for every other weekend
            for (int week = 2; week <= weeksInYear; week += 2)
            {
                WeeksWithWeekendShifts.Add(week);
            }
        }

        private void displaySchedule(string shiftType)
        {

        }
    }
}
