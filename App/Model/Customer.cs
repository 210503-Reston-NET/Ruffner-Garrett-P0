using System.Collections.Generic;
namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        public Customer(string name, List<Order> orders)
        {
            this.Name = name;
            this.Orders = orders;
        }

        public string Name { get; set; }
        //TODO: add more properties to identify the customer
        public List<Order> Orders { get; set; }
    }
}