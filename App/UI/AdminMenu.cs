using Service;
using System;
using Serilog;
namespace UI
{
    public class AdminMenu : IMenu
    {
         private IService _services;
        private IValidationUI _validate;

        public AdminMenu(IService services, IValidationUI validate)
        {
            _services = services;
            _validate = validate;
        }

        public void Start()
        {
           bool repeat = true;
            do{
                Console.Clear();
                Console.WriteLine("Admin Menu");
                Console.WriteLine("[0] Exit/Back");
                Console.WriteLine("[1] Add Customer");
                Console.WriteLine("[2] Add Location");
                Console.WriteLine("[3] Add Product");
                Console.WriteLine("[4] Update Inventory");
                
                
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.WriteLine("Bye");
                        Log.Information("program exit from menu");
                        repeat = false;
                    break;
                    case "1":
                        string str;
                        str = _validate.ValidationPrompt("Enter First and Last Name", ValidationService.ValidatePersonName);
                        try{
                        _services.AddCustomer(str);
                        }catch(Exception ex){
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Press Any Key to Continue ...");
                            Console.ReadKey();
                        }

                    break;
                    case "2":
                        //Add Location
                        string locationName = _validate.ValidationPrompt("Enter Location Name:", ValidationService.ValidateString);
                        Console.Clear();
                        string locationAddress = _validate.ValidationPrompt("Enter Location Address:",ValidationService.ValidateAddress);
                        Console.Clear();
                        try{
                            _services.AddLocation(locationName, locationAddress);
                            Console.WriteLine("Location added");
                        }catch(Exception ex){
                            Console.WriteLine(ex.Message);
                           
                        }
                        Console.WriteLine("Press Any Key to Continue ...");
                        Console.ReadKey();
                    break;
                    case "3":
                    //Add Product

                    break;
                    case "4":
                    //Update Inventory
                    
                    break;
                    default:
                        Console.WriteLine("Choose valid option");
                    break;

                }
            } while(repeat);
        }
    }
}