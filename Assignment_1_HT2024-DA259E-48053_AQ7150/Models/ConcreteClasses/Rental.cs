using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    public class Rental : Apartment
    {
        public double Rent { get; set; }
        public string LeasePeriod { get; set; }


        public Rental(int id,
                      Address address,
                      int floorNumber,
                      int numberOfRooms,
                      double areal,
                      bool hasGarden,
                      bool hasGarage,
                      bool hasBalcony,
                      double rent,
                      string leasePeriod) : base(id, address, numberOfRooms, areal, hasGarden, hasGarage, hasBalcony)
        {
            Rent = rent;
            LeasePeriod = leasePeriod;
        }

        public override string GetInfo()
        {
            // Call base class GetInfo to get common Apartment info
            string baseInfo = base.GetInfo();

            // Append Rental-specific information
            return baseInfo +
                   $"\nMonthly Rent: {Rent:C}" +
                   $"\nLease Period: {LeasePeriod}";
        }

    }
}
