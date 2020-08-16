using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retailer.Models
{
    public class RetailerDbContext : DbContext
    {
        public RetailerDbContext(DbContextOptions<RetailerDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}
