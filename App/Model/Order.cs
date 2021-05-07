using System;
using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        public Order(Customer customer, Location location, double total, List<Item> items)
        {
            this.Customer = customer;
            this.Location = location;
            this.Total = total;
            this.Items = items;
        }

        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public double Total { get; set; }
        public List<Item> Items { get; set; }
    }
}