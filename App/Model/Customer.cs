using System.Net.Mail;
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
        public Customer(string name, string Address, MailAddress Email) : this(name)
        {
            this.Address = Address;
            this.Email = Email;
        }
        public override string ToString()
        {
            return String.Format("{0}", this.Name);
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public MailAddress Email { get; set; }
        
    }
}