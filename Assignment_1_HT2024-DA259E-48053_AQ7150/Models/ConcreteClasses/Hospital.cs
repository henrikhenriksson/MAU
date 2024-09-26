using RealEstateApp.Models.AbstractClasses;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    internal class Hospital : Institutional
    {

        public bool HasEmergencyWard { get; set; }
        public int PerformsResearch { get; set; }
        public Hospital(int id, Address address, string institutionType, string numberOfDepartments, int maxCapacity, bool hasEmergencyWard, int performsResearch) : base(id, address, institutionType, numberOfDepartments, maxCapacity)
        {
            HasEmergencyWard = hasEmergencyWard;
            PerformsResearch = performsResearch;
        }




        public override void GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
