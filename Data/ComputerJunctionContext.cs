using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComputerJunction.Models;

namespace ComputerJunction.Data
{
    public class ComputerJunctionContext : DbContext
    {
        public ComputerJunctionContext (DbContextOptions<ComputerJunctionContext> options)
            : base(options)
        {
        }

        public DbSet<ComputerJunction.Models.Product> Product { get; set; }

        public DbSet<ComputerJunction.Models.Brand> Brand { get; set; }

        public DbSet<ComputerJunction.Models.Printer> Printer { get; set; }
    }
}
