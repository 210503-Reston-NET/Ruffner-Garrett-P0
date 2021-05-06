using System;

namespace StoreModels
{

    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and locations.  
    /// </summary>
    public class Item
    {
        private int _quantity;
        public Item(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; set; }

        public int Quantity { 
            get => _quantity; 
            set
            {
                if (value < 0){
                    throw new Exception("Quantity cannot be < 0");
                }else{
                    _quantity = value;
                }
            } 
        }

    }
}