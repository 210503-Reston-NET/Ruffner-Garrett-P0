using System.Collections.Generic;
using StoreModels;

namespace Data
{
    public class RepoDB : IRepository
    {
        public void AddCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void AddLocation(Location location)
        {
            throw new System.NotImplementedException();
        }

        public void AddProduct(Product product)
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

        public List<Product> GetAllProducts()
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

        public void UpdateLocation(Location location)
        {
            throw new System.NotImplementedException();
        }
    }
}