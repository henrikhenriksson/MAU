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


        public double LotSize { get; set; }
        public int ConstructionYear { get; set; }
        public bool HasBasement { get; set; }

        public Villa(int id, Address address, int numberOfRooms, double areal, bool hasGarden, bool hasGarage, int lotSize, int constructionYear, bool hasBasement) : base(id, address, numberOfRooms, areal, hasGarden, hasGarage)
        {
            LotSize = LotSize;
            ConstructionYear = constructionYear;
            HasBasement = hasBasement;
        }

        public override void GetInfo()
        {
            Console.Write(
                $"Villa Info:" +
                $"\nID: {ID}" +
                $"\nAddress: {Address}" +
                $"\nRooms: {NumberOfRooms}" +
                $"\nGarage: {HasGarage}" +
                $"\nGarden: {HasGarage}" +


                $"\nConstructionYear: {ConstructionYear}" +


                $"\nID: {ID}"





                );
        }
    }
}
