using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


                if (string.IsNullOrWhiteSpace(_description))
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


        public Task(string description, DateTime dueDate, PriorityLevel priority)
        {
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }

        private string GetFormattedPriorityLevelString()
        {
            return Priority.ToString().Replace("_", " ");
        }

        public override string ToString()
        {

            //return $"Task: {Description}, Due: {DueDate:g}. Priority: {Priority}";

            return $"{DueDate.ToLongDateString(),-20} {GetTimeString(),10} {GetFormattedPriorityLevelString(),-16} {Description,-20}";

        }
        private string GetTimeString()
        {
            return $"{DueDate.Hour:D2}:{DueDate.Minute:D2}";
        }

    }
}
