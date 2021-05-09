using System;
using Serilog;
using Service;
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

        public void Start()
        {   
           // _validate = new ValidationUI();
            bool repeat = true;
            do{
                Console.Clear();
                Console.WriteLine("Welcome!");
                Console.WriteLine("[0] Customer Menu");
                Console.WriteLine("[1] Search Customer");
                Console.WriteLine("[2] exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        MenuFactory.GetMenu("CustomerMenu").Start();
                        //_validate.ValidationPrompt("Enter First and Last name:",_validate.ValidatePersonName);
                    break;
                    case "1":
                   //  _validate.ValidationPrompt("Enter City",_validate.ValidateCityName);
                    break;
                    case "2":
                        Console.WriteLine("Bye");
                        Log.Information("program exit from menu");
                        repeat = false;
                        Log.CloseAndFlush();
                    break;
                    default:
                    Console.WriteLine("Choose valid option");
                    break;

                }
            } while(repeat);
            
        }
    }
}