using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class Orders
    {
        public int Orderid { get; set; }
        public int Customerid { get; set; }
        public decimal Totalprice { get; set; }
        public string PaymentMethod { get; set; }
        public string Addres { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime Orderdate { get; set; }

        public Customers Customer { get; set; }
    }
}
