using System;
using Serilog;
namespace UI
{
    public class MainMenu : IMenu
    {

        public void Start()
        {
            bool repeat = true;
            do{
                Console.WriteLine("Welcome!");
                Console.WriteLine("[0] Add R");
                Console.WriteLine("[1] Add Review");
                Console.WriteLine("[2] exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":

                    break;
                    case "1":
                       //write file
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