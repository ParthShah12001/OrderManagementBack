using System;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public partial class CustomerLogin
    {
        public int Customerid { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
    }
}
