using Service;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Data.Entities;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuType){
            
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("App/appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("StoreDB");

            DbContextOptions<p0Context> options = new DbContextOptionsBuilder<p0Context>()
            .UseSqlServer(connectionString)
            .Options;
            
            var context = new p0Context(options);

            switch(menuType.ToLower()){
                case "mainmenu":
                    return new MainMenu(new Services(new RepoDB(context)), new ValidationUI());
                case "customermenu":
                    return new CustomerMenu(new Services(new RepoFile()), new ValidationUI());
                case "adminmenu":
                    return new AdminMenu(new Services(new RepoDB(context)), new ValidationUI());
                case "inventorymenu":
                    return new InventoryMenu(new Services(new RepoFile()), new ValidationUI());
                default:
                    return null;
            }
        }
    }
}