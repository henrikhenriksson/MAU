﻿using RealEstateApp.Models.Interfaces;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.ConcreteClasses
{
    internal class Warehouse : Commercial
    {
        public Warehouse(int id, Address address, double areal, int numberOfFloors, bool isIndustrial) : base(id, address, areal, numberOfFloors, isIndustrial)
        {
        }

        public override void GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
