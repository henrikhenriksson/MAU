using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    internal class Rowhouse : Villa
    {
        

        public bool HasSharedGarage { get; set; } // Rowhouses typically have shared walls with neighbors

        public Rowhouse(int id,
                        Address address,
                        int numberOfRooms,
                        double areal,
                        bool hasGarden,
                        bool hasGarage,
                        bool hasSharedGarage,
                        int constructionYear) : base(id, address, numberOfRooms, areal, hasGarden, hasGarage, constructionYear)
        {
            HasSharedGarage = hasSharedGarage;
        }

        public override string GetInfo()
        {
            return base.GetInfo() +
                   $"\nHas Shared Walls: {HasSharedGarage}";
        }
    }

}
