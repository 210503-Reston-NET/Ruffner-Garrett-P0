using System.Collections.Generic;
using StoreModels;

namespace Data
{
    public class DataRepo : IRepository
    {
        public void AddCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void AddLocation(Location location)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new System.NotImplementedException();
        }

        public List<Location> GetAllLocations()
        {
            throw new System.NotImplementedException();
        }

        public List<Item> GetInventory(Location location)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetOrders(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetOrders(Location location)
        {
            throw new System.NotImplementedException();
        }

        public void PlaceOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Customer SearchCustomer(string name)
        {
            throw new System.NotImplementedException();
        }

        public Order ViewOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}