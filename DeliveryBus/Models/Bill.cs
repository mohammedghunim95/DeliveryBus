using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryBus.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}