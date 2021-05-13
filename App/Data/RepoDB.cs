using System.Collections.Generic;
using System.Linq;
using StoreModels;
using Entity = Data.Entities;
namespace Data
{
    public class RepoDB : IRepository
    {
        private Entity.p0Context _context;
        public RepoDB(Entity.p0Context context)
        {
            _context = context;
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(
                new Entity.Customer
                {
                    Name = customer.Name
                }
            );
            _context.SaveChanges();
        }

        public void AddLocation(Location location)
        {
            _context.Locations.Add(
                new Entity.Location
                {
                   LocationName = location.LocationName,
                   Address = location.Address,
                }
            );
           _context.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                customer => new Customer(customer.Name)
            ).ToList();
        }

        public List<Location> GetAllLocations()
        {
            return _context.Locations.Select(
                location => new Location(location.LocationName, location.Address)
            ).ToList();
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