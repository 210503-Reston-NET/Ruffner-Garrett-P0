using System;
using StoreModels;
using Data;
using System.Collections.Generic;

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
            _repo.AddCustomer(new Customer(name, null));
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

        public void placeOrder(Location location, Customer customer, Order order)
        {
            throw new System.NotImplementedException();
        }

        public void SearchCustomers(string name)
        {
            throw new System.NotImplementedException();
        }

        public void updateInventory(Location location, Item item)
        {
            throw new System.NotImplementedException();
        }

        public void viewInventory(Location location)
        {
            throw new System.NotImplementedException();
        }

        public void viewOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void viewOrders(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void viewOrders(Location location)
        {
            throw new System.NotImplementedException();
        }
    }
}