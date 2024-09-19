using RealEstateApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.SupportingClasses
{
    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public Countries Country { get; set; } = Countries.Sweden;

        public Address(string street, string zipcode, string city, Countries country)
        {
            Street = street;
            ZipCode = zipcode;
            City = city;
            Country = country;
        }

        public Address()
        {
        }

        public override string? ToString()
        {
            return $"{Street}, {ZipCode} {City}, {Country}";
        }
    }
}
