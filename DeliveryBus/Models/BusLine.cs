using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryBus.Models
{
    public class BusLine
    {
        [Key]
        public int BusLinesId { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Gate { get; set; }

        public string Image { get; set; }


        public int BusCompanyId { get; set; }
        public BusCompany busCompany { get; set; }

        public int BusTimeId { get; set; }
        public BusTime busTime { get; set; }

        public ICollection<Region> regions { get; set; }

    }
}