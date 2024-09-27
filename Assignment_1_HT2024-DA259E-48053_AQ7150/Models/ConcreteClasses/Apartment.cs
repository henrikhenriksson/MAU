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

        public int FloorNumber { get; set; }
        public bool HasBalcony { get; set; }
        
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

       



        public override string GetInfo()
        {
            return $"Apartment Info:\n" +
               $"ID: {ID}\n" +
               $"Address: {Address}\n" +
               $"Rooms: {NumberOfRooms}\n" +
               $"Area: {Areal} sqm\n" +
               $"Floor Number: {FloorNumber}\n" +
               $"Has Garden: {HasGarden}\n" +
               $"Has Garage: {HasGarage}\n" +
               $"Has Balcony: {HasBalcony}";

        }
    }
}
