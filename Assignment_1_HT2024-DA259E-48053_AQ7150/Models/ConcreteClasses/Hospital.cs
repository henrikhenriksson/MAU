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
        public bool PerformsResearch { get; set; }
        public Hospital(int id,
                        Address address,
                        string institutionType,
                        string numberOfDepartments,
                        int maxCapacity,
                        bool hasEmergencyWard,
                        bool performsResearch) : base(id, address, institutionType, numberOfDepartments, maxCapacity)
        {
            HasEmergencyWard = hasEmergencyWard;
            PerformsResearch = performsResearch;
        }




        public override string GetInfo()
        {
            return $"Hospital Info:\n" +
                   $"ID: {ID}\n" +
                   $"Address: {Address}\n" +
                   $"Institution type: {InstitutionType}\n" +
                   $"Departments: {NumberOfDepartments}\n" +
                   $"Capacity: {MaxCapacity}\n" +
                   $"Has Emergency Ward: {HasEmergencyWard}\n" +
                   $"Research Facilities: {PerformsResearch}";
        }
    }
}
