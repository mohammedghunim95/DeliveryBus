using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryBus.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Time { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        [Required]
        public int BusLinesId { get; set; }
        public BusLine BusLine { get; set; }


    }
}