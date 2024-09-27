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

        public override string GetInfo()
        {
            return $"Warehouse Info:\n" +
                   $"ID: {ID}\n" +
                   $"Address: {Address}\n" +
                   $"Area: {Areal} sqm\n" +
                   $"Properties:\n" +
                   $"Floors: {NumberOfFloors}\n" +
                   $"Industrial: {IsIndustrial}\n" +
                   $"Storage Capacity: {StorageCapacity} cubic meters\n" +
                   $"Loading Docks: {LoadingDocks}\n" +
                   $"Cold Facilities (Freezers): {HasFreezers}";
        }
    }
}
