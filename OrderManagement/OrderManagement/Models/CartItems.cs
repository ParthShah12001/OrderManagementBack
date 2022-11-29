using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class CartItems
    {
        public int Itemid { get; set; }
        public int Productid { get; set; }
        public int Productquantity { get; set; }
        public decimal Productprice { get; set; }
        public int Customerid { get; set; }

        public Customers Customer { get; set; }
        public Products Product { get; set; }
    }
}
