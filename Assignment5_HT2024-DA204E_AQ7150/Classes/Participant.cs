using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerApp.Classes
{
    internal class Participant
    {
        // Fields
        private string firstName;
        private string lastName;
        private Address address;

        // Constructor
        public Participant(string firstName, string lastName, Address address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
        }

        // Properties
        public string FirstName
        {
            get { return firstName; }
            set { if (!string.IsNullOrEmpty(value)) firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { if (!string.IsNullOrEmpty(value)) lastName = value; }
        }

        public Address Address
        {
            get { return address; }
            set { if (value != null) address = value; }
        }

        // Method to return formatted participant information
        public override string ToString()
        {
            return $"{lastName.ToUpper()}, {firstName} - Address: {address}";
        }
    }
}
