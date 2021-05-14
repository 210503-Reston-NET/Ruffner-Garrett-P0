using System.Data;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Linq;
using Models =StoreModels;
using Entity = Data.Entities;
using System;

namespace Data
{
    public class RepoDB : IRepository
    {
        private Entity.p0Context _context;
        public RepoDB(Entity.p0Context context)
        {
            _context = context;
        }
        public void AddCustomer(Models.Customer customer)
        {
            _context.Customers.Add(
                new Entity.Customer
                {
                    Name = customer.Name
                }
            );
            _context.SaveChanges();
        }

        public void AddLocation(Models.Location location)
        {
            _context.Locations.Add(
                new Entity.Location
                {
                   LocationName = location.LocationName,
                   Address = location.Address
                }
            );
           _context.SaveChanges();
        }

        public void AddProduct(Models.Product product)
        {
            _context.Products.Add(
               new Entity.Product
               {
                    Name = product.ProductName,
                    Price = product.Price
               }
            );
            _context.SaveChanges();
        }

        public void AddProductToInventory(Models.Location location, Models.Item item)
        { 
            // int eLocationId = GetLocation(location);
            // int eProductID = GetProduct(item.Product).Id;
            //Need location ID PRoduct ID and quantity
            _context.InventoryItems.Add( 
                new Entity.InventoryItem
                {
                    Location = GetLocation(location),
                    Product = GetProduct(item.Product),
                    Quantity = item.Quantity
                }
           );

           
           _context.SaveChanges();
        }

        public List<Models.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                customer => new Models.Customer(customer.Name)
            ).ToList();
        }

        public List<Models.Location> GetAllLocations()
        {
            //WHAT HAVE I CREATED
            return _context.Locations.Select(
                location => new Models.Location(
                    location.LocationName, 
                    location.Address, 
                    location.InventoryItems.Select( 
                        i => new Models.Item(
                            new Models.Product(
                                i.Product.Name, 
                                (double) i.Product.Price
                            ),
                            (int) i.Quantity
                        )
                    ).ToList()
                )
            ).ToList();
        }

        public List<Models.Product> GetAllProducts()
        {
            return _context.Products.Select(
                product => new Models.Product(product.Name, (double) product.Price)
            ).ToList();
        }

        public List<Models.Order> GetOrders(Models.Customer customer)
        {
            //OH GOD ITS SO GROSS
            //SOMEONE HELP ME FIND A BETTER WAY
            //Had to use client side Evelaution for where clause
            // int customerId = GetCustomer(customer).Id;
            List<Models.Order> mOrders=  _context.Orders.Select(
                order => new Models.Order(
                   new Models.Customer(order.Customer.Name, order.CustomerId),
                   new Models.Location(order.Location.LocationName, order.Location.Address),
                   order.OrderItems.Select(
                       i => new Models.Item(
                           new Models.Product(
                               i.Product.Name,
                               (double) i.Product.Price),
                               (int) i.Quantity)).ToList(),
                (DateTime) order.Date)
            ).AsEnumerable().Where(order => order.Customer.Name == customer.Name).ToList();
            

            return mOrders;          
            
        }
        // order => new Models.Order(
        //            new Models.Customer(order.Customer.Name),
        //            new Models.Location(order.Location.LocationName, order.Location.Address),
        //            order.OrderItems.Select(
        //                i => new Models.Item(
        //                    new Models.Product(
        //                        i.Product.Name,
        //                        (double) i.Product.Price),
        //                        (int) i.Quantity)).ToList(),
        //         (DateTime) order.Date)

        public List<Models.Order> GetOrders(Models.Location location)
        {
            List<Models.Order> mOrders=  _context.Orders.Select(
                order => new Models.Order(
                   new Models.Customer(order.Customer.Name, order.CustomerId),
                   new Models.Location(order.Location.LocationName, order.Location.Address),
                   order.OrderItems.Select(
                       i => new Models.Item(
                           new Models.Product(
                               i.Product.Name,
                               (double) i.Product.Price),
                               (int) i.Quantity)).ToList(),
                (DateTime) order.Date)
            ).AsEnumerable().Where(order => order.Location.LocationName == location.LocationName).ToList();

            return mOrders;
        }

        public void PlaceOrder(Models.Order mOrder)
        {
            // var eCustomer = GetCustomer(mOrder.Customer);
            // var eLocation = GetLocation(mOrder.Location);
           
        
            Entity.Order eOrder=  new Entity.Order
            {
                Customer = GetCustomer(mOrder.Customer),
                Location = GetLocation(mOrder.Location),
                Date = mOrder._date,
                Total = mOrder.Total, 
            };
            
            
            _context.Orders.Add(eOrder);
            _context.SaveChanges();
            //  List<Entity.OrderItem> eOrderItems = null;
            // foreach (var item in mOrder.Items)
            // {
            //     eOrderItems.Add(new Entity.OrderItem{Quantity = item.Quantity, Product = GetProduct(item.Product)});
            // }
            // _context.Add(eOrderItems);
               
            mOrder.Items.ForEach(item => _context.OrderItems.Add(
            new Entity.OrderItem
            {
                OrderId = eOrder.Id,
                Product = GetProduct(item.Product),
                Quantity = item.Quantity,
            }));

            _context.SaveChanges();
        }
        
        private Entity.Location GetLocation(Models.Location mLocation){
            Entity.Location found =  _context.Locations.FirstOrDefault( o => (o.LocationName == mLocation.LocationName) && (o.Address == mLocation.Address));
            return found;
        }
        private Entity.Customer GetCustomer(Models.Customer mCustomer){
            Entity.Customer found =  _context.Customers.FirstOrDefault( o => (o.Name == mCustomer.Name));
            return found;
        }
        private Entity.Product GetProduct(Models.Product mProduct){
            Entity.Product found = _context.Products.FirstOrDefault(o => (o.Name == mProduct.ProductName)&& (o.Price == mProduct.Price));
            return found;
        }
        private Entity.InventoryItem GetInventoryItem(Models.Item item, Entity.Location eLocation){
            Entity.InventoryItem found = _context.InventoryItems.FirstOrDefault(o=> (o.Product.Name == item.Product.ProductName) && (o.LocationId == eLocation.Id));
            return found;
        }

        public void UpdateInventoryItem(Models.Location location, Models.Item item)
        {
            Entity.Location eLocation = GetLocation(location);
            Entity.InventoryItem eItem = GetInventoryItem(item, eLocation);
            eItem.Quantity = item.Quantity;
            var thing =  _context.InventoryItems.Update(eItem);            
            _context.SaveChanges();
        }
    }
}