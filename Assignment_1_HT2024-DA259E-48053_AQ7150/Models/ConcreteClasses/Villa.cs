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
        public Villa(int id, Address address, int numberOfRooms, double areal, bool hasGarden, bool hasGarage) : base(id, address, numberOfRooms, areal, hasGarden, hasGarage)
        {
        }

        public override void GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
