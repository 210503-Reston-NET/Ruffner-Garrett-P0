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
        private const string _filePath = "App/Data/Data.json";
        private string _jsonString;

        public void AddCustomer(Customer customer)
        {
            List<Customer> customers = GetAllCustomers();
            //check customers for customer with the same name
            if(CheckForCustomer(customer, customers)){
                //customer already exists
                throw new Exception("Customer Already Exits");
            }

            customers.Add(customer);
            _jsonString = JsonSerializer.Serialize(customers);
            File.WriteAllText(_filePath,_jsonString);
            return;
        }

        public List<Customer> GetAllCustomers()
        {
            Log.Verbose("Retrieving all customers from File");
            List<Customer> retVal;
            try
            {
                _jsonString = File.ReadAllText(_filePath);
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
        

        public List<Item> GetInventory(Location location)
        {
            throw new System.NotImplementedException();
        }

        public List<Item> GetItem(){
            return JsonSerializer.Deserialize<List<Item>>(_jsonString);
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
        private bool CheckForCustomer(Customer customer, List<Customer> Customers){

            foreach (Customer item in Customers)
            {
                if(customer.Name == item.Name){
                    return true;
                }
            }

            return false;
        }
    }
}