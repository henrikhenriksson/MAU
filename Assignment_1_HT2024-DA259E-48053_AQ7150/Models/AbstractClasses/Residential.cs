using RealEstateApp.Models.SupportingClasses;

namespace RealEstateApp.Models.AbstractClasses
{
    public abstract class Residential : Estate
    {
        public int NumberOfRooms { get; set; }
        public bool HasGarden { get; set; }
        public bool HasGarage {  get; set; }

        protected Residential(int id, Address address, int numberOfRooms, bool hasGarden, bool hasGarage)
        : base(id, address) 
        {
            NumberOfRooms = numberOfRooms;
            HasGarden = hasGarden;
            HasGarage = hasGarage;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Rooms: {NumberOfRooms}, Garden: {HasGarden}, Garage: {HasGarage}";
        }
    }
}
