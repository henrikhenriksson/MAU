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
        public Hospital(int id, Address address, string institutionType, string numberOfDepartments, int maxCapacity) : base(id, address, institutionType, numberOfDepartments, maxCapacity)
        {
        }

        public override void GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
