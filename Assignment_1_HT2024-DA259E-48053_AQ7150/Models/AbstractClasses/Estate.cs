using RealEstateApp.Models.Interfaces;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.AbstractClasses
{
    public abstract class Estate : IEstate
    {
        public int ID { get; set; }
        public Address Address { get; set; }


        protected Estate(int id, Address address)
        {
            ID = id;
            Address = address;
        }

        public abstract void GetInfo();

    }
}
