using System.Collections.Generic;
using StoreModels;
namespace Data
{
    public interface IRepository
    {
        public void AddCustomer(Customer customer);
        public Customer SearchCustomer(string name);

        public List<Order> GetOrders(Customer customer);

        public List<Order> GetOrders(Location location);

        public Order ViewOrder();

        public void PlaceOrder(Order order);

        public List<Item> GetInventory(Location location);
        
         
    }
}