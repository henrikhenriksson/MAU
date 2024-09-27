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

        public override string GetInfo()
        {
            return $"University Info:\n" +
                   $"ID: {ID}\n" +
                   $"Address: {Address}\n" +
                   $"Institution type: {InstitutionType}\n" +
                   $"Degree Programs: {UniversityPrograms}\n" +
                   $"Research Facilities: {PerformsResearch}\n" +
                   $"Departments: {NumberOfDepartments}\n" +
                   $"Capacity: {MaxCapacity}";
        }
    }
}
