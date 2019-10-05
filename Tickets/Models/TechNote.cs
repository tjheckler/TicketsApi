using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tickets.Models
{
    public class TechNote
    {
        [Key]
        public int TechNoteId { get; set; }
        public string Note { get; set; }
    }
}