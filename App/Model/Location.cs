using System.Collections.Generic;
namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        public Location(string address, string locationName)
        {
            this.Address = address;
            this.LocationName = locationName;

        }

        public string Address { get; set; }
        public string LocationName { get; set; }

        public List<Item> Inventory { get; set; }
    }
}