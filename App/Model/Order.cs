using System;
namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        public Order(Customer customer, Location location, double total, Tuple<Item, int> items)
        {
            Customer = customer;
            Location = location;
            Total = total;
            Items = items;
        }

        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public double Total { get; set; }
        public Tuple<Item, int> Items { get; set; }
    }
}