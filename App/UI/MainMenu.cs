using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System;
using Serilog;
using Service;
using StoreModels;
using System.Collections.Generic;
namespace UI
{
    public class MainMenu : IMenu
    {   
        private IService _services;
        private IValidationUI _validate;

        public MainMenu(IService services, IValidationUI validation)
        {
            _services = services;
            _validate = validation;
        }

        public void Start()
        {   
           // _validate = new ValidationUI();
            bool repeat = true;
            do{
                Console.Clear();
                Console.WriteLine("Welcome!");
                Console.WriteLine("Main Menu:");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("[1] Search For Customer");
                Console.WriteLine("[2] List Customers");
                Console.WriteLine("[3] List Locations");
                Console.WriteLine("[4] List Products");
                Console.WriteLine("[5] View Orders");
                Console.WriteLine("[6] Create Order");
                Console.WriteLine("[7] Admin Menu");
                // Console.WriteLine("[8] Select Product");

                
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        //Exit Menu
                        Console.WriteLine("Bye");
                        Log.Information("program exit from menu");
                        repeat = false;
                    break;
                    case "1":
                        // Search for Customer
                        SearchForCustomer();
                    break;
                    case "2":
                        //List Customers
                        ListCustomers();
                    break;
                    case "3":
                        //List Locations
                        ListLocations();
                    break;
                    case "4":
                        //List Products
                        ListProducts();
                    break;
                    case "5":
                    // View Orders
                        ViewOrders();
                    break;
                    case "6":
                    // Create Orders

                    break;
                    case "7":
                    //Admin Menu
                    MenuFactory.GetMenu("adminmenu").Start();
                           
                    break;
                    case "8":
                        //Get Product From List
                        try{ 
                            List<Object> products = _services.GetAllProducts().Cast<Object>().ToList<Object>();
                            
                            Object ret = SelectFromList.Start(products);
                            Product prod = (Product) ret;

                            Console.WriteLine("Product selected: {0}", prod.ToString());
                            Console.WriteLine("Press Any Key to Continue ...");
                            Console.ReadKey();

                        }catch(NullReferenceException ex){
                            Log.Verbose("Returned null from Product Selection", ex, ex.Message);
                            Console.WriteLine("Cancelled Product Selection");
                            Console.WriteLine("Press Any Key to Continue ...");
                            Console.ReadKey();
                        }catch(Exception ex){
                            Log.Error(ex, ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Choose valid option");
                    break;

                }
            } while(repeat);
            
        }

        private void SearchForCustomer(){
            string str;
            str = _validate.ValidationPrompt("Enter Customer Name", ValidationService.ValidatePersonName);
            Customer target = null;
            try{
                target =  _services.SearchCustomers(str);
                Console.Clear();
                Console.WriteLine("Customer found: {0}", target.Name);
            }catch(Exception ex){
                Log.Debug(ex.Message);
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press Any Key to Continue ...");
            Console.ReadKey();
        }

        private void ListCustomers(){
            try{
                List<Customer> customers =_services.GetAllCustomers();
                Console.Clear();
                Console.WriteLine("Customers:");
                foreach (Customer customer in customers)
                {
                    Console.WriteLine(customer.Name);
                }
                Console.WriteLine();  
            }catch(Exception ex){
                Log.Debug(ex.Message);
                Console.WriteLine(ex.Message);
            }                    
            Console.WriteLine("Press Any Key to Continue ...");
            Console.ReadKey();
        }

        private void ListLocations(){
            try{
                List<Location> locations =_services.GetAllLocations();
                Console.Clear();
                Console.WriteLine("Locations:");
                foreach (Location location in locations)
                {
                    Console.WriteLine(location.ToString());
                }
                Console.WriteLine();
            }catch(Exception ex){
                Log.Debug(ex.Message);
                Console.WriteLine(ex.Message);
            }                    
            Console.WriteLine("Press Any Key to Continue ...");
            Console.ReadKey();
        }
        private void ListProducts(){
             try{
                List<Product> products =_services.GetAllProducts();
                Console.Clear();
                Console.WriteLine("Products:");
                foreach (Product product in products)
                {
                    Console.WriteLine(product.ToString());
                }  
                Console.WriteLine();
            }catch(Exception ex){
                Log.Debug(ex.Message);
                Console.WriteLine(ex.Message);
            }                    
            Console.WriteLine("Press Any Key to Continue ...");
            Console.ReadKey();
        }

        private void ViewOrders(){
            //view by location or by customer
            bool repeat = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Main Menu:");
                    Console.WriteLine("[0] Exit");
                    Console.WriteLine("[1] View By customer");
                    Console.WriteLine("[2] View By Location");
                    String str = Console.ReadLine();
                    switch (str) {
                        case "0":
                           repeat = false;
                        break;
                        case "1":
                            //View by customer
                            //Choose customer
                            ViewByCustomer();
                        break;
                        case "2":
                            //View by Location
                            //Choose location
                        break;
                    }
                } while (repeat);
            //order by price asc/desc

            //order by date asc/desc
        }

        private void ViewByCustomer(){
            try{ 
                List<Object> objs = _services.GetAllCustomers().Cast<Object>().ToList<Object>();
                
                Object ret = SelectFromList.Start(objs);
                Customer customer = (Customer) ret;

                //get list of order history
                List<Object> orderList =  _services.GetOrders(customer).Cast<Object>().ToList<Object>();
                ret = SelectFromList.Start(orderList);
                ret.ToString();
                // Console.WriteLine("Customer selected: {0}", customer.ToString());
                Console.WriteLine("Press Any Key to Continue ...");
                Console.ReadKey();

            }catch(NullReferenceException ex){
                Log.Verbose("Returned null from Customer Selection", ex, ex.Message);
                Console.WriteLine("Cancelled Selection");
                Console.WriteLine("Press Any Key to Continue ...");
                Console.ReadKey();
            }catch(Exception ex){
                Log.Error(ex, ex.Message);
            }
        }
        private void ViewByLocation(){

        }
        private void CreateNewOrder(){
            //Get Customer
            Customer cust;
            try{ 
                List<Object> objs = _services.GetAllCustomers().Cast<Object>().ToList<Object>();
                
                Object ret = SelectFromList.Start(objs);
                cust = (Customer) ret;

                // Console.WriteLine("Customer selected: {0}", customer.ToString());
                Console.WriteLine("Press Any Key to Continue ...");
                Console.ReadKey();

            }catch(NullReferenceException ex){
                Log.Verbose("Returned null from Customer Selection", ex, ex.Message);
                Console.WriteLine("Cancelled Selection");
                Console.WriteLine("Press Any Key to Continue ...");
                Console.ReadKey();
                return;
            }catch(Exception ex){
                Log.Error(ex, ex.Message);
            }

            //Get Location
            Location loc;
            try{ 
                List<Object> objectList = _services.GetAllLocations().Cast<Object>().ToList<Object>();
                
                Object ret = SelectFromList.Start(objectList);
                loc = (Location) ret;
                

            }catch(NullReferenceException ex){
                Log.Verbose("Returned null from Location Selection", ex, ex.Message);
                Console.WriteLine("Cancelled Location Selection");
                Console.WriteLine("Press Any Key to Continue ...");
                Console.ReadKey();
                return;
            }catch(Exception ex){
                Log.Error(ex, ex.Message);
                return;
            }
            //Choose Items and Quanitity from inventory
            List<Item> itms = GetItems(loc);
            

            //Calculate Total


        }

        private List<Item> GetItems(Location loc){
            //Only allows one item to be selected also no stock checking
            List<Item> selectedItem = new List<Item>();
            string str;
                try{ 
                    List<Object> objectList = loc.Inventory.Cast<Object>().ToList<Object>();
                    
                    Object ret = SelectFromList.Start(objectList);
                    Item itm = (Item) ret;
                    Product p = itm.Product;
                    str = _validate.ValidationPrompt("Enter Qunatity to Purchase", ValidationService.ValidateInt);
                    selectedItem.Add(new Item(p, int.Parse(str)));
                    
                }catch(NullReferenceException ex){
                    Log.Verbose("Returned null from Item Selection", ex, ex.Message);
                    Console.WriteLine("Cancelled Item Selection");
                    Console.WriteLine("Press Any Key to Continue ...");
                    Console.ReadKey();
                    
                }catch(Exception ex){
                    Log.Error(ex, ex.Message);
                    
                }
                return selectedItem;
        }
    }
}