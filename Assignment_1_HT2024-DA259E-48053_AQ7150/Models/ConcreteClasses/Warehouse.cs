using RealEstateApp.Models.Interfaces;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    internal class Warehouse : Commercial
    {

        public double StorageCapacity { get; set; }
        public int LoadingDocks { get; set; }
        public bool HasFreezers { get; set; }


        public Warehouse(int id, Address address, double areal, int numberOfFloors, bool isIndustrial, double storageCapacity, int loadingDocks, bool hasFreezers) : base(id, address, areal, numberOfFloors, isIndustrial)
        {
            StorageCapacity = storageCapacity;
            LoadingDocks = loadingDocks;
            HasFreezers = hasFreezers;

        }

        public override void GetInfo()
        {
            Console.Write($"Warehouse Info:" +
                $"\nID: {ID}" +
                $"\nAddress: {Address}" +
                $"\nAreal: {Areal}" +
                $"\nProperties:" +
                $"\nFloors: {NumberOfFloors}" +
                $"\n Industrial: {IsIndustrial}" +
                 $"\n StorageCapacity: {StorageCapacity}" +
                  $"\n Loading Docks: {LoadingDocks}" +
                   $"\n Cold Facilities: {HasFreezers}"
                );
        }
    }
}
