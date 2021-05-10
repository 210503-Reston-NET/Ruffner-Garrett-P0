using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Collections.Generic;
using StoreModels;
using System.IO;
using System;
using Serilog;
namespace Data
{
    public class RepoFile : IRepository
    {
        private const string _customerFilePath = "App/FileStorage/Customers.json";
        private const string _orderFilePath = "App/FileStorage/Orders.json";

        private const string _locationFilePath = "App/FileStorage/Locations.json";

        private const string _productFilePath = "App/FileStorage/Products.json";
        private string _jsonString;

        public void AddCustomer(Customer customer)
        {
            List<Customer> customers = GetAllCustomers();
            customers.Add(customer);
            _jsonString = JsonSerializer.Serialize(customers);
            File.WriteAllText(_customerFilePath, _jsonString);
            return;
        }

        public void AddLocation(Location location)
        {
            List<Location> locations = GetAllLocations();
            locations.Add(location);
            _jsonString = JsonSerializer.Serialize(locations);
            File.WriteAllText(_locationFilePath, _jsonString);
            return;
        }
        public void AddProduct(Product product)
        {
            List<Product> products = GetAllProducts();
            products.Add(product);
            _jsonString = JsonSerializer.Serialize(products);
            File.WriteAllText(_productFilePath, _jsonString);
            return;
        }

        public List<Customer> GetAllCustomers()
        {
            Log.Verbose("Retrieving all customers from File");
            List<Customer> retVal;
            try
            {
                _jsonString = File.ReadAllText(_customerFilePath);
                retVal = JsonSerializer.Deserialize<List<Customer>>(_jsonString);
            }
            catch(JsonException){
                Log.Error("Could not Deserialize json");
                throw new Exception("Could not read json");
            }
            catch (Exception ex)
            {
                //logging to the console
                Log.Error(ex.Message);
                retVal = new List<Customer>();
            }
            

            return retVal;
        }

        public List<Order> GetOrders(Customer customer)
        {
            Log.Verbose("Searching for order by customer");
            List<Order> orders;
            try
            {
                _jsonString = File.ReadAllText(_orderFilePath);
                orders = JsonSerializer.Deserialize<List<Order>>(_jsonString);
                List<Order> selectedOrders = new List<Order>();
                foreach (Order order in orders)
                {
                    if(order.Customer ==customer){
                        selectedOrders.Add(order);
                    }
                }
                return selectedOrders;
            }
            catch(JsonException){
                Log.Error("Could not Deserialize json");
                throw new Exception("Could not read json");
            }
            catch (Exception ex)
            {
                //logging to the console
                Log.Error(ex.Message);
                orders = new List<Order>();
                return orders;
            } 
        }
        public List<Order> GetOrders(Location location)
        {
           Log.Verbose("Searching for order by locaiton");
            List<Order> orders;
            try
            {
                _jsonString = File.ReadAllText(_orderFilePath);
                orders = JsonSerializer.Deserialize<List<Order>>(_jsonString);
                List<Order> selectedOrders = new List<Order>();
                foreach (Order order in orders)
                {
                    if(order.Location ==location){
                        selectedOrders.Add(order);
                    }
                }
                return selectedOrders;
            }
            catch(JsonException){
                Log.Error("Could not Deserialize json");
                throw new Exception("Could not read json");
            }
            catch (Exception ex)
            {
                //logging to the console
                Log.Error(ex.Message);
                orders = new List<Order>();
                return orders;
            }
        }

   

        public List<Item> GetItem(){
            return JsonSerializer.Deserialize<List<Item>>(_jsonString);
        }

        public List<Location> GetAllLocations()
        {
            Log.Verbose("Retrieving all Locations from File");
            List<Location> retVal;
            try
            {
                _jsonString = File.ReadAllText(_locationFilePath);
                retVal = JsonSerializer.Deserialize<List<Location>>(_jsonString);
            }
            catch(JsonException){
                Log.Error("Could not Deserialize json");
                throw new Exception("Could not read json");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                retVal = new List<Location>();
            }
            return retVal;
        }

        public void PlaceOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetInventory(Location location)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            Log.Verbose("Retrieving all Products from File");
            List<Product> retVal;
            try
            {
                _jsonString = File.ReadAllText(_productFilePath);
                retVal = JsonSerializer.Deserialize<List<Product>>(_jsonString);
            }
            catch(JsonException){
                Log.Error("Could not Deserialize json");
                throw new Exception("Could not read json");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                retVal = new List<Product>();
            }
            return retVal;
        }
    }
}