using RealEstateApp.Models.Interfaces;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    public class Shop : Commercial
    {
        public string TypeOfShop { get; set; }


        public Shop(int id, Address address, double areal, int numberOfFloors, bool isIndustrial, string typeOfShop) : base(id, address, areal, numberOfFloors, isIndustrial)
        {
            this.TypeOfShop = typeOfShop;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Shop Info:" +
                $"\nID: {ID}" +
                $"\nAddress: {Address}" +
                $"\nAreal: {Areal}" +
                $"\nProperties:" +
                $"\nFloors: {NumberOfFloors}" +
                $"\n Industrial: {IsIndustrial}" +
                $"\n TypeofShop: {TypeOfShop}");

        }
    }
}
