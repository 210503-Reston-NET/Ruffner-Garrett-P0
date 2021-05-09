using System;
using System.Collections.Generic;
using Serilog;
using Service;
using StoreModels;
namespace UI
{
    public class CustomerMenu : IMenu
    {
        private IService _services;
        private IValidationUI _validate;

        public CustomerMenu(IService services, IValidationUI validation)
        {
            _services = services;
            _validate = validation;
        }

        public void Start()
        {
            Log.Verbose("Started Customer Menu");
            bool repeat = true;
            do{
                Console.Clear();
                Console.WriteLine("Customer Menu:");
                Console.WriteLine("[0] Add Customer");
                Console.WriteLine("[1] Search For Customer");
                Console.WriteLine("[2] List Customers");
                Console.WriteLine("[3] Exit");
                string input = Console.ReadLine();
                string str;
                switch (input)
                {
                    case "0":
                        str = _validate.ValidationPrompt("Enter First and Last Name", ValidationService.ValidatePersonName);
                        try{
                        _services.AddCustomer(str);
                        }catch(Exception ex){
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Press Any Key to Continue ...");
                            Console.ReadKey();
                        }

                    break;
                    case "1":
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
                       
                        // Console.WriteLine("Press m for order Menu");
                        // ConsoleKeyInfo key = Console.ReadKey();
                        // if(key.ToString().ToLower() == "m"){

                        // }
                    break;
                    case "2":
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
                        Log.Information("Closing Customer Menu");
                        repeat = false;
                    break;
                    default:
                    Console.WriteLine("Choose valid option");
                    break;

                }
            } while(repeat);
        }
    }
}