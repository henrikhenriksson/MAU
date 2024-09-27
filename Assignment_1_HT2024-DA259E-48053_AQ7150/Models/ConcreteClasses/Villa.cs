using RealEstateApp.Models.AbstractClasses;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    internal class Villa : Residential
    {
        public int ConstructionYear { get; set; }

        public Villa(
            int id,
            Address address,
            int numberOfRooms,
            double areal,
            bool hasGarden,
            bool hasGarage,
            int constructionYear) : base(id, address, numberOfRooms, areal, hasGarden, hasGarage)
        {
            ConstructionYear = constructionYear;
        }

        public override string GetInfo()
        {
            return $"Villa Info:\n" +
                   $"ID: {ID}\n" +
                   $"Address: {Address}\n" +
                   $"Rooms: {NumberOfRooms}\n" +
                   $"Has Garage: {HasGarage}\n" +
                   $"Has Garden: {HasGarden}\n" +
                   $"Construction Year: {ConstructionYear}";
        }
    }
}
