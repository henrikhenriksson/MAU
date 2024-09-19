// Ignore Spelling: App

using RealEstateApp.Models.AbstractClasses;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.Interfaces
{
    public abstract class Commercial : Estate
    {
        public double Areal { get; set; }
        public int NumberOfFloors { get; set; }
        public bool IsIndustrial { get; set; }

        public Commercial(int id, Address address, double areal, int numberOfFloors, bool isIndustrial) : base(id, address) 
        {
            Areal = areal;
            NumberOfFloors = numberOfFloors;
            this.IsIndustrial = isIndustrial;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Area: {Areal}, Floors: {NumberOfFloors}, Industrial: {IsIndustrial}";
        }


    }
}
