using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliveryBus.Models
{
    public class BusCompany
    {
        [Key]
        public int BusCompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        public string Description { get; set; }

        public string Image { get; set; }

        public ICollection<BusLine> busLines  { get; set; }

    }
}