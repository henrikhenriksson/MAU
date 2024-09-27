using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models.Interfaces
{
    public interface IEstate
    {
        int ID { get; set; }
        Address Address { get; }
        string GetInfo();

    }
}
