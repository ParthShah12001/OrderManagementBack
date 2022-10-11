using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class Product
    {
        public int Productid { get; set; }
        public string Productname { get; set; }
        public string Productdetails { get; set; }
        public decimal? Productprice { get; set; }
    }
}
