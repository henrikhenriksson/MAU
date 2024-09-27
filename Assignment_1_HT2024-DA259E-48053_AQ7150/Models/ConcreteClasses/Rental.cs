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
                      string leasePeriod) : base(id, address, floorNumber, numberOfRooms, areal, hasGarden, hasGarage, hasBalcony)
        {
            Rent = rent;
            LeasePeriod = leasePeriod;
        }

        public override void GetInfo()
        {
            base.GetInfo(); // Call base class GetInfo to print common Apartment info
            Console.Write($"Monthly Rent: {Rent:C}" +
                $" Lease Period: {LeasePeriod}"
                );
        }

    }
}
