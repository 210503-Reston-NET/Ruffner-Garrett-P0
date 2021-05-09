using System;
using StoreModels;
using Data;
using System.Collections.Generic;
using Serilog;

namespace Service
{
    public class Services : IService
    {
        private IRepository _repo;
        public Services(IRepository repo)
        {
            _repo = repo;
        }

        public void AddCustomer(string name)
        {   
            try
            {
            _repo.AddCustomer(new Customer(name));
            }catch(Exception ex){
                throw ex;
            }
        }

        public void AddLocation(string name, string address)
        {
            try{
            Location l = new Location(name, address);
            _repo.AddLocation(l);
            }catch(Exception ex){
                throw ex;
            }
        }

        public List<Customer> GetAllCustomers(){
            List<Customer> retVal;
            try{
                retVal = _repo.GetAllCustomers();
            }catch(Exception ex){
                throw ex;
            }
            return retVal;
        }
        public List<Location> GetAllLocations(){
            List<Location> retVal;
            try{
                retVal = _repo.GetAllLocations();
            }catch(Exception ex){
                throw ex;
            }
            return retVal;

        }

        public void placeOrder(Location location, Customer customer, Order order)
        {
            throw new System.NotImplementedException();
        }

        public Customer SearchCustomers(string name)
        {
        //    List<Customer> retVal;
        //     try{
        //         retVal = _repo.GetAllCustomers();
        //     }catch(Exception ex){
        //         throw ex;
        //     }
        //     return retVal;
           
            List<Customer> customers = GetAllCustomers();
            
            foreach (Customer item in customers)
            {
                if(name == item.Name){
                   return item;
                }
            }
            Log.Verbose("Customer: {name} not found", name);
            throw new Exception("Customer not found");
            

            
        }

        public void updateInventory(Location location, Item item)
        {
            throw new System.NotImplementedException();
        }

        public void viewInventory(Location location)
        {
            throw new System.NotImplementedException();
        }


        public List<Order> viewOrders(Customer customer)
        {
            return  _repo.GetOrders(customer);
        }

        public List<Order> viewOrders(Location location)
        {
             return  _repo.GetOrders(location);
        }
    }
}