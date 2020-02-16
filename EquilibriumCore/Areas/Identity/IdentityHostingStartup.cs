using System;
using EquilibriumCore.Areas.Identity.Data;
using EquilibriumCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EquilibriumCore.Areas.Identity.IdentityHostingStartup))]
namespace EquilibriumCore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SecurityContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddIdentity<EquilibriumCoreUser, IdentityRole>()
                    .AddEntityFrameworkStores<SecurityContext>();
                services.AddAuthentication().AddCookie(options =>
                {
                    options.LoginPath = new PathString("Identity/Account/Login/");
                    options.LogoutPath = new PathString("Identity/Account/Logout/");
                }

           );
            });
        }
    }
}