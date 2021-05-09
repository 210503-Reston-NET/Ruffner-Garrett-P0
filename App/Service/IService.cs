using System.Collections.Generic;
using StoreModels;
namespace Service
{
    public interface IService
    {
        public void AddCustomer(string name);
        public List<Customer> GetAllCustomers();
        public List<Location> GetAllLocations();
        public List<Product> GetAllProducts();
        public void AddProduct(string productName, double productPrice);
        public void AddLocation(string name, string address);
        public Customer SearchCustomers(string name);
        public List<Order> viewOrders(Customer customer);
        public List<Order> viewOrders(Location location);
        public void placeOrder(Location location, Customer customer, Order order);
        public void viewInventory(Location location);
        public void updateInventory(Location location, Item item);
    }
}