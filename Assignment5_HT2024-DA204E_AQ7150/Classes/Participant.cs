﻿// written by Henrik Henriksson(AQ7150)


using EventOrganizerApp.Classes;

namespace Assignment4_HT2024_DA204E_AQ7150.Classes
{
    public class Participant
    {
        private string _firstName;
        private string _lastName;
        private Address _address;

        public Participant(string firstName, string lastName, Address address)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
           

        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name cannot be empty");
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot be empty");
                }
            }
        }

        public Address _Address
        {
            get { return _address; }
            set
            {
                if (value != null)
                {
                    _address = value;
                }
            }
        }

        public string GetFullName() { return $"{_lastName.ToUpper()}, {_firstName}"; }

    }
}
