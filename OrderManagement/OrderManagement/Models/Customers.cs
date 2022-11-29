using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class Customers
    {
        public Customers()
        {
            CartItems = new HashSet<CartItems>();
            OrderItems = new HashSet<OrderItems>();
            Orders = new HashSet<Orders>();
        }

        public int Customerid { get; set; }
        public string Customername { get; set; }
        public string Customeremail { get; set; }
        public string Customerpassword { get; set; }

        public ICollection<CartItems> CartItems { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
