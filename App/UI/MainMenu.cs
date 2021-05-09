using System;
using Serilog;
using Service;
using StoreModels;
using System.Collections.Generic;
namespace UI
{
    public class MainMenu : IMenu
    {   
        // private ValidationUI _validate;
        // private IService _service;

        // public MainMenu(IService service, ValidationUI validation)
        // {
        //     _validate = validation;
        //     _service = service;
        // }
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
                Console.WriteLine("[4] ");
                Console.WriteLine("[5] Admin Menu");

                
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
                            Console.WriteLine("Customer found: {}", target.Name);
                        }catch(Exception ex){
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine("Press Any Key to Continue ...");
                        Console.ReadKey();
                   
                    break;
                    case "2":
                        //List Customers
                        try{
                            List<Customer> customers =_services.GetAllCustomers();
                            foreach (Customer customer in customers)
                            {
                                Console.WriteLine(customer.Name);
                            }  
                        }catch(Exception ex){
                            Console.WriteLine(ex.Message);
                        }                    
                        Console.WriteLine("Press Any Key to Continue ...");
                        Console.ReadKey();
                    break;
                    case "3":
                        //List Locations
                        try{
                            List<Location> locations =_services.GetAllLocations();
                            foreach (Location location in locations)
                            {
                                Console.WriteLine(location.ToString());
                            }  
                        }catch(Exception ex){
                            Console.WriteLine(ex.Message);
                        }                    
                        Console.WriteLine("Press Any Key to Continue ...");
                        Console.ReadKey();
                    break;
                    case "4":
                       
                    break;
                    case "5":
                    //Admin Menu
                    MenuFactory.GetMenu("adminmenu").Start();
                           
                    break;
                    default:
                        Console.WriteLine("Choose valid option");
                    break;

                }
            } while(repeat);
            
        }
    }
}