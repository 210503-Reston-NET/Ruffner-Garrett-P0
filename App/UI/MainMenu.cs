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
                Console.WriteLine("[5] Admin Menu");
                // Console.WriteLine("[6] Select Product");

                
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
                   
                    break;
                    case "2":
                        //List Customers
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
                    break;
                    case "3":
                        //List Locations
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
                    break;
                    case "4":
                        //List Products
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
                    break;
                    case "5":
                    //Admin Menu
                    MenuFactory.GetMenu("adminmenu").Start();
                           
                    break;
                    case "6":
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
    }
}