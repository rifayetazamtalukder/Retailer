using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Retailer.Areas.Identity.Data;

namespace Retailer.Data
{
    public class RetailerAuthDbContext : IdentityDbContext<RetailerUser>
    {
        public RetailerAuthDbContext(DbContextOptions<RetailerAuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
