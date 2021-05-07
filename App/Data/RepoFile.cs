using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Collections.Generic;
using StoreModels;
namespace Data
{
    public class RepoFile : IRepository
    {
        private const string filePath = "Data/Data.json";
        private string jsonString;

        public void AddCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public List<Item> GetInventory(Location location)
        {
            throw new System.NotImplementedException();
        }

        public List<Item> GetItem(){
            return JsonSerializer.Deserialize<List<Item>>(jsonString);
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