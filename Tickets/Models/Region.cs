using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tickets.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public string Name { get; set; }
    }
}