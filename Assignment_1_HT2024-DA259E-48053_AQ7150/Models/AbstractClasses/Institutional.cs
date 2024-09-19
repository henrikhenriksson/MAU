using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.AbstractClasses
{
    public abstract class Institutional : Estate
    {

        public string InstitutionType {  get; protected set; }
        public string NumberOfDepartments { get; set; }

        public int MaxCapacity { get; set; }

        public Institutional(int id, Address address, string institutionType, string numberOfDepartments, int maxCapacity) : base(id,address)
        {
            InstitutionType = institutionType;
            NumberOfDepartments = numberOfDepartments;
            MaxCapacity = maxCapacity;
        }
    }
}
