using System.Collections.Generic;
using StoreModels;
namespace Data
{
    public interface IRepository
    {
        /// <summary>
        /// Provide data read/write services to the BL
        /// </summary>
        public void AddCustomer(Customer customer);
        public List<Customer> GetAllCustomers();
        public List<Location> GetAllLocations();
        public List<Order> GetOrders(Customer customer, bool price, bool asc);
        public List<Order> GetOrders(Location location, bool price, bool asc);
        public void AddLocation(Location location);
        public void PlaceOrder(Order order);
        public void AddProduct(Product product);
        public List<Product> GetAllProducts();
        void UpdateInventoryItem(Location location, Item item);
        public void AddProductToInventory(Location location, Item item);
        public void StartTransaction();
        public void EndTransaction(bool success);
    }
}