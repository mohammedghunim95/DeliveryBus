using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeliveryBus.Models;
namespace DeliveryBus.ViewModels
{
    public class RegionLineVM
    {
        public ICollection<Region> Region { get; set; }
        public BusLine BusLine { get; set; }
    }
}