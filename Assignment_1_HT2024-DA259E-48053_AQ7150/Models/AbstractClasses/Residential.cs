using RealEstateApp.Models.SupportingClasses;

namespace RealEstateApp.Models.AbstractClasses
{
    public abstract class Residential : Estate
    {
        protected Residential(int id, Address address, int numberOfRooms, double areal, bool hasGarden, bool hasGarage) 
            : base(id, address)
        {
            NumberOfRooms = numberOfRooms;
            Areal = areal;
            HasGarden = hasGarden;
            HasGarage = hasGarage;

        }

        public int NumberOfRooms { get; set; }

        public double Areal { get; set; }
        public bool HasGarden { get; set; }
        public bool HasGarage { get; set; }






    }
}
