using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class OrderItems
    {
        public int Itemid { get; set; }
        public int Productid { get; set; }
        public int Customerid { get; set; }
        public int Orderid { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Stat { get; set; }

        public Customers Customer { get; set; }
        public Products Product { get; set; }
    }
}
