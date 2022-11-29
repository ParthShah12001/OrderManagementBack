using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class Products
    {
        public Products()
        {
            CartItems = new HashSet<CartItems>();
            OrderItems = new HashSet<OrderItems>();
        }

        public int Productid { get; set; }
        public string Productname { get; set; }
        public string Productdetail { get; set; }
        public decimal Productprice { get; set; }
        public int Productquantity { get; set; }
        public string Imglinks { get; set; }

        public ICollection<CartItems> CartItems { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
