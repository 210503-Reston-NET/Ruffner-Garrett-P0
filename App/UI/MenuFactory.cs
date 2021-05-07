namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuType){
            
            switch(menuType.ToLower()){
                case "menu":
                 return new MainMenu();
                case "other":

                break;

                default:
                    return null;
            }
            

            return null;
        }
    }
}