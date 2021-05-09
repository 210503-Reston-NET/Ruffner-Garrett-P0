using System;
using Serilog;
namespace UI
{
    class UI
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File("App/logs/app.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // Log.Information("Hello, world!");

            // int a = 10, b = 0;
            // try
            // {
            //     Log.Debug("Dividing {A} by {B}", a, b);
            //     Console.WriteLine(a / b);
            // }
            // catch (Exception ex)
            // {
            //     Log.Error(ex, "Something went wrong");
            // }
            // Console.WriteLine("Hello World!");
            Log.Verbose("Starting Main Menu");
            try{
            MenuFactory.GetMenu("mainmenu").Start();
            }catch(Exception ex){
                Log.Error(ex.Message);
            }
            // IMenu menu = new MainMenu();
            // menu.Start();
           

        }
    }
}
