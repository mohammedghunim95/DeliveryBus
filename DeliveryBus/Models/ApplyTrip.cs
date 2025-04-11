using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryBus.Models
{
    public class ApplyTrip
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public double Subscribe { get; set; }
        public double Price { get; set; }  


        public int RegionId { get; set; }
        public string UserId { get; set; }

        public Region Region { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}