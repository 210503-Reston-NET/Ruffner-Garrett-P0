using StoreModels;
namespace Service
{
    public interface IService
    {
         public void AddCustomer();
         public void SearchCustomers();
         public void viewOrders(Customer customer);
         public void viewOrders(Location location);
         public void viewOrder(Order order);
         public void placeOrder(Location location, Customer customer, Order order);
         public void viewInventory(Location location);

         public void updateInventory(Location location);
    }
}