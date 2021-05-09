using System.Collections.Generic;
using StoreModels;
namespace Data
{
    public interface IRepository
    {
        /// <summary>
        /// Provide data read/write services to the BL
        /// TODO:
        /// Store and Retrieve Customers
        ///     Throw exeption when customer already exists
        /// Add new Customer
        /// Search for customer
        /// Create Orders
        /// </summary>
        public void AddCustomer(Customer customer);

        public List<Customer> GetAllCustomers();
        public Customer SearchCustomer(string name);

        public List<Order> GetOrders(Customer customer);

        public List<Order> GetOrders(Location location);

        public Order ViewOrder();

        public void PlaceOrder(Order order);

        public List<Item> GetInventory(Location location);
        
         
    }
}