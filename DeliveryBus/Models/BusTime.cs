using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryBus.Models
{
    public class BusTime
    {
        [Key]
        public int BusTimeId { get; set; }

        [Required]
        public string Times { get; set; }

        [Required]
        public string Days { get; set; }

        public string Image { get; set; }


        public ICollection<BusLine> busLines { get; set; }


    }
}