using RealEstateApp.Models.AbstractClasses;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    public class University : Institutional
    {
        public int UniversityPrograms { get; set; }
        public bool PerformsResearch { get; set; }

        public University(int id,
                          Address address,
                          string institutionType,
                          string numberOfDepartments,
                          int maxCapacity,
                          int universityPrograms,
                          bool performsResearch) : base(id, address, institutionType = "University", numberOfDepartments, maxCapacity)
        {
            UniversityPrograms = universityPrograms;
            PerformsResearch = performsResearch;


        }

        public override void GetInfo()
        {
            Console.WriteLine($"University Info:" +
                $"\nID: {ID}" +
                $"\nAddress: {Address}" +
                $"\nInstitution type: {InstitutionType}" +
                $"\nDegree Programs: {UniversityPrograms}" +
                $"\nResearch Facilities: {PerformsResearch}" +
                $"Departments: {NumberOfDepartments}" +
                $"Capacity: {MaxCapacity}");
        }
    }
}
