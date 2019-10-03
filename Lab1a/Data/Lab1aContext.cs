using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab1a.Models;

namespace Lab1a.Models
{
    public class Lab1aContext : DbContext
    {
        public Lab1aContext (DbContextOptions<Lab1aContext> options)
            : base(options)
        {
        }

        public DbSet<Lab1a.Models.Car> Car { get; set; }

        public DbSet<Lab1a.Models.Member> Member { get; set; }

        public DbSet<Lab1a.Models.Dealership> Dealership { get; set; }
    }
}
