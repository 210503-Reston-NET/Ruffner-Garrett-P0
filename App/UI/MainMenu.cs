using System;
using Serilog;
namespace UI
{
    public class MainMenu : IMenu
    {   
        private ValidationService _validate;

        public void Start()
        {   
            _validate = new ValidationService();
            bool repeat = true;
            do{
                Console.WriteLine("Welcome!");
                Console.WriteLine("[0] ");
                Console.WriteLine("[1] Test Val");
                Console.WriteLine("[2] exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":

                    break;
                    case "1":
                     _validate.ValidateCityName("Enter City");
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