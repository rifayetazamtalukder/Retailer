using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Retailer.Areas.Identity.Data;
using Retailer.Data;

[assembly: HostingStartup(typeof(Retailer.Areas.Identity.IdentityHostingStartup))]
namespace Retailer.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<RetailerAuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RetailerAuthDbContextConnection")));

                services.AddDefaultIdentity<RetailerUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false; // For simplicity avoiding confirm email account

                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6; // at least 6 chars needed for password
                    options.Password.RequireNonAlphanumeric = false; // Don't Require special char like '#, &, $'
                })
                    .AddEntityFrameworkStores<RetailerAuthDbContext>();
            });
        }
    }
}