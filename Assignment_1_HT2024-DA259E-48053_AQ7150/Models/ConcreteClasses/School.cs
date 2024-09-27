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

        public override string GetInfo()
        {

            return $"School Info:\n" +
                 $"ID: {ID}\n" +
                 $"Address: {Address}\n" +
                 $"Institution type: {InstitutionType}\n" +
                 $"Educational Stage: {EducationalStage}\n" +
                 $"Departments: {NumberOfDepartments}\n" +
                 $"Capacity: {MaxCapacity}";

        }
    }
}
