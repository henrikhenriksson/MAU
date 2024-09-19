using RealEstateApp.Models.AbstractClasses;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    public class Apartment : Residential
    {
        public Apartment(int id,
                         Address address,
                         int floorNumber,
                         int numberOfRooms,
                         double areal,
                         bool hasGarden,
                         bool hasGarage,
                         bool hasBalcony) : base(id, address, numberOfRooms, areal, hasGarden, hasGarage)
        {
            FloorNumber = floorNumber;
            HasBalcony = hasBalcony;
        }

        public int FloorNumber { get; set; }

        public bool HasBalcony { get; set; }



        public override void GetInfo()
        {
            Console.WriteLine($"Apartment Info:" +
                $"\nID: {ID}" +
                $"\nAddress: {Address}" +
                $"\nRooms: {NumberOfRooms}" +
                $"\nArea: {Areal}" +
                $"\nFloor Number: {FloorNumber}" +
                $"\nProperties: " +
                $"\nGarden : {HasGarden}" +
                $"\nGarage: {HasGarage}" +
                $"\nBalcony: {HasBalcony}"
                );

        }
    }
}
