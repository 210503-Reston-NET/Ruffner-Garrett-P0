using Service;
using Data;
namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuType){
            
            switch(menuType.ToLower()){
                case "mainmenu":
                    return new MainMenu(new Services(new RepoFile()), new ValidationUI());
                case "customermenu":
                    return new CustomerMenu(new Services(new RepoFile()), new ValidationUI());
                case "adminmenu":
                    return new AdminMenu(new Services(new RepoFile()), new ValidationUI());
                default:
                    return null;
            }
        }
    }
}