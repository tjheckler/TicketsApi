﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tickets.Models
{
    public class Priority
    {
        [Key]
        public int PriorityId { get; set; }
        public string Name { get; set; }
    }
}