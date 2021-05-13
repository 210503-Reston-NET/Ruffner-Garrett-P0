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
            Customer newCustomer = new Customer(name);
            if(CheckForCustomer(newCustomer, _repo.GetAllCustomers())){
                //customer already exists
                Log.Debug("Customer {} Already exists",newCustomer.Name);
                throw new Exception("Customer Already Exits");
            }
            try{
                _repo.AddCustomer(newCustomer);
            }catch(Exception ex){
                Log.Error("Failed to Add Customer. {}",ex.Message);
            }
        }

        public void AddLocation(string name, string address)
        {
            Location newLocation = new Location(name, address);
            if(CheckForLocations(newLocation, _repo.GetAllLocations())){
                //customer already exists
                Log.Debug("Location {} Already exists",newLocation.LocationName);
                throw new Exception("Location Already Exits");
            }
            try{
                _repo.AddLocation(newLocation);
            }catch(Exception ex){
                Log.Error("Failed to Add Location. {}",ex.Message);
            }
        }

        public void AddProduct(string productName, double productPrice)
        {
            Product newProduct = new Product(productName, productPrice);
             if(CheckForProduct(newProduct, _repo.GetAllProducts())){
                //customer already exists
                Log.Debug("Product {} Already exists",newProduct.ProductName);
                throw new Exception("Product Already Exits");
            }
            try{
                _repo.AddProduct(newProduct);
            }catch(Exception ex){
                Log.Error("Failed to Add Product. {}",ex.Message);
            }
        }

        public void AddProductToInventory(Location location, Product product, int stock)
        {
           
            //Create new Item for inventory
            Item newItem = new Item(product, stock);
            //check inventory for product
            foreach (Item item in location.Inventory)
            {
                if(newItem.Product.ProductName == item.Product.ProductName){
                    throw new Exception("Product is Already in Inventory");
                }
            }
            //Product is not in inventory
            //Add Item to Inventory
            try{
                location.Inventory.Add(newItem);
                _repo.UpdateLocation(location);
            }catch(Exception ex){
                Log.Error("Failed to Add Product To Inventory", ex);
            }
        }

        public List<Customer> GetAllCustomers(){
            List<Customer> retVal;
            retVal = _repo.GetAllCustomers();
            return retVal;
        }
        public List<Location> GetAllLocations(){
            List<Location> retVal;
            retVal = _repo.GetAllLocations();
            return retVal;

        }

        public List<Product> GetAllProducts()
        {
           return _repo.GetAllProducts();
        }

        public void placeOrder(Location location, Customer customer, Order order)
        {
            throw new System.NotImplementedException();
        }

        public Customer SearchCustomers(string name)
        {           
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

        public void updateItemInStock(Location location, Item item, int amount)
        {
            item.ChangeQuantity(amount);
            try{
                _repo.UpdateLocation(location);
            }catch(Exception ex){
                Log.Error("Could not update Location",ex, ex.Message);
                item.ChangeQuantity(-amount);
            }
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
        private bool CheckForCustomer(Customer customer, List<Customer> Customers){

            foreach (Customer item in Customers)
            {
                if(customer.Name == item.Name)
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckForLocations(Location location, List<Location> locations){

            foreach (Location item in locations)
            {
                if((location.LocationName == item.LocationName)&&(location.Address == location.Address)){
                    return true;
                }
            }

            return false;
        }
        private bool CheckForProduct(Product product, List<Product> products){
            foreach (Product item in products)
            {
                if(item.ProductName == product.ProductName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}