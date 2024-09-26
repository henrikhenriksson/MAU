using RealEstateApp.Models.AbstractClasses;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    public class School : Institutional
    {
        public string EducationalStage;

        public School(int id,
                      Address address,
                      string institutionType,
                      string numberOfDepartments,
                      int maxCapacity, string educationalStage) : base(id, address, institutionType = "School", numberOfDepartments, maxCapacity)
        {
            EducationalStage = educationalStage;
        }

        public override void GetInfo()
        {

            Console.WriteLine($"School Info:" +
                $"\nID: {ID}" +
                $"\nAddress: {Address}" +
                $"\nInstitution type: {InstitutionType}" +
                $"\nEducational Stage: {EducationalStage}" +
                $"Departments: {NumberOfDepartments}" +
                $"Capacity: {MaxCapacity}");

        }
    }
}
