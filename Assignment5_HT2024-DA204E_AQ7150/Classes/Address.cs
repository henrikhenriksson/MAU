using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerApp.Classes
{
    internal class Address
    {
        private string _street;
        private string _city;
        private string _postalCode;
        private Countries _country;

        public string Street
        {
            get { return _street; }
            set
            {
                if (Validate(value))
                {
                    _street = value;
                }
                else
                {
                    throw new ArgumentException("Street cannot be empty");
                }
            }
        }

        public string City
        {
            get { return _city; }
            set
            {

                if (Validate(value))
                {
                    _city = value;
                }
                else
                {
                    throw new ArgumentException("City cannot be empty");
                }
            }
        }
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {

                if (ValidatePostalCode(value))
                {

                    _postalCode = value;
                }
                else
                {
                    throw new ArgumentException("Postal Code is 5 digits");
                }

            }
        }

        public Countries Country
        {
            get { return _country; }
            set
            {
                _country = value;
            }
        }
        // copy constructor to avoid unintended behaviour.
        public Address(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            _street = address._street;
            _city = address._city;
            _postalCode = address._postalCode;
            _country = address._country;
        }

        public Address(string street, string city, string postalCode, Countries country)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
        private bool Validate(string text)
        {
            return !string.IsNullOrEmpty(text);
        }

        private bool ValidatePostalCode(string postalCodeToValidate)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(postalCodeToValidate, "^\\d{3}\\s?\\d{2}$");
        }
        public override string ToString()
        {
            return $"{_street}, {_city}, {_postalCode}, {_country}";
        }
    }
}
