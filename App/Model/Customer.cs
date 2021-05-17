using System;
using System.Collections.Generic;
namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        public Customer(string name)
        {
            this.Name = name;
        }
        public Customer(string name, int id) : this(name)
        {
            this.ID = id;
        }
        public override string ToString()
        {
            return String.Format("{0}", this.Name);
        }
        public string Name { get; set; }
        public int ID { get; set; }
        
    }
}