using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tickets.Models
{
    public class Ticket
    {
        [Key]
        public int TicketsId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Location { get; set; }
        public string Region { get; set; }
        public string ComputerName { get; set; }
        public long AssetTag { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}