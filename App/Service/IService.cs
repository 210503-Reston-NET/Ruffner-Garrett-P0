using System.Collections.Generic;
using StoreModels;
namespace Service
{
    public interface IService
    {
         public void AddCustomer(string name);
         public List<Customer> GetAllCustomers();
         public void SearchCustomers(string name);
         public void viewOrders(Customer customer);
         public void viewOrders(Location location);
         public void viewOrder(Order order);
         public void placeOrder(Location location, Customer customer, Order order);
         public void viewInventory(Location location);

         public void updateInventory(Location location, Item item);
    }
}