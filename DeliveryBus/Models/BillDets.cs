using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryBus.Models
{
    public class BillDets
    {
        public int Id { get; set; }

        public int BillId { get; set; }

        public int RegionId { get; set; }

        public double Qty { get; set; }
    }
}