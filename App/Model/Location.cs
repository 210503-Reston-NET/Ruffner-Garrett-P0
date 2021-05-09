using System;
using System.Globalization;
using System.Collections.Generic;
namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        public Location(string locationName, string address)
        {
            this.Address = address;
            this.LocationName = locationName;
            Inventory  = new List<Item>();
        }
        public override string ToString()
        {
            return String.Format("Name: {0} Address: {1}",this.LocationName,this.Address);
        }
        public string Address { get; set; }
        public string LocationName { get; set; }

        public List<Item> Inventory { get; set; }
    }
}