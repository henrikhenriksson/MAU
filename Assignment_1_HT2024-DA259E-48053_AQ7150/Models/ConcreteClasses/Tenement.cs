using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    internal class Tenement : Apartment
    {
        public int MonthlyFee { get; set; }
        public string HousingCooperative {  get; set; }

      

        public Tenement(int id, Address address, int floorNumber, int numberOfRooms, double areal, bool hasGarden, bool hasGarage, bool hasBalcony, int monthlyFee, string housingCooperative) : base(id, address, floorNumber, numberOfRooms, areal, hasGarden, hasGarage, hasBalcony)
        {
            MonthlyFee = monthlyFee;
            HousingCooperative = housingCooperative;

        }
    }
}
