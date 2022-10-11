using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class Orders
    {
        public int Orderid { get; set; }
        public int? Productid { get; set; }
        public string Productname { get; set; }
        public int? Customerid { get; set; }
        public string Stat { get; set; }
        public string Orderdetails { get; set; }
        public int? Qunatity { get; set; }
        public DateTime? Orderdate { get; set; }
        public string Paymentmethod { get; set; }
        public decimal? Price { get; set; }
    }
}
