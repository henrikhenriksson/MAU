// Written by: Henrik Henriksson(AQ7150)

using static Assignment6_HT2024_DA204E_AQ7150.Enums.Enums;

namespace Assignment6_HT2024_DA204E_AQ7150.Classes
{
    public class Task
    {

        private string _description;
        private DateTime _dueDate;
        private PriorityLevel _priority;
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("An empty Descrition is not very useful.\n Please enter some description");
                }

                _description = value;
            }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {

                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Due date cannot be in the past.");


                }
                _dueDate = value;
            }
        }

        public PriorityLevel Priority { get { return _priority; } set { _priority = value; } }

        // we use only parameterized constructor for this class as all the fields should be considered required
        public Task(string description, DateTime dueDate, PriorityLevel priority)
        {
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }

        // enums are formatted with _, E.G: Very_Important
        private string GetFormattedPriorityLevelString()
        {
            return Priority.ToString().Replace("_", " ");
        }

        // Override
        //  converts task field values with formatting to make prettier printout.
        public override string ToString()
        {
            return $"{DueDate.ToShortDateString(),-15} {GetTimeString(),-10} {GetFormattedPriorityLevelString(),-30} {Description.PadLeft(35)}";
        }
        // prettier format of timestring
        private string GetTimeString()
        {
            return $"{DueDate.Hour:D2}:{DueDate.Minute:D2}";
        }

    }
}
