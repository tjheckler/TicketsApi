using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tickets.Models;

namespace Tickets.Data
{
    public class ApplicationDbContext:DbContext
    {
       
            public ApplicationDbContext() : base("DefaultConnection")
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

            public DbSet<Ticket> Tickets { get; set; }
        }

    
}