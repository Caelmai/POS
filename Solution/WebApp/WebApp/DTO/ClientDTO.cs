using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.DTO
{
    public class ClientDTO
    {
        public string Classification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string LastPurchase { get; set; }
        public string Seller { get; set; }
    }
}