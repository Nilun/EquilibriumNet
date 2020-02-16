using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using EquilibriumCore.Data;
using EquilibriumCore.Models;
using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using EquilibriumCore.Areas.Identity.Data;
using EquilibriumCore.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;

namespace EquilibriumCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            var environment = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();


            services.AddDataProtection()
                    .SetApplicationName($"my-app-{environment.EnvironmentName}")
                    .PersistKeysToFileSystem(new DirectoryInfo($@"{environment.ContentRootPath}\keys"));

           
            services.AddDbContext<DataContext>(option=> option.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddJsReport(new LocalReporting()
        .UseBinary(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)  ?
                    jsreport.Binary.JsReportBinary.GetBinary() :
                    jsreport.Binary.Linux.JsReportBinary.GetBinary())
        .AsUtility()
        .Create());
            services.AddResponseCaching();
            services.AddScoped<IToolTipService, ToolTipService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env ,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();
                
            }
            else
            {
                app.UseDeveloperExceptionPage();
             
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();           
            app.UseCookiePolicy();
          
            app.UseResponseCaching();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
	    {
		var context = serviceScope.ServiceProvider.GetService<DataContext>();
		context.Database.Migrate();
                var securcontext =    serviceScope.ServiceProvider.GetService<SecurityContext>();
                securcontext.Database.Migrate();
	    }
            createAdmin(serviceProvider).GetAwaiter().GetResult();
        }
        private async Task createAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<EquilibriumCoreUser>>();

            var roleCheck = await roleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                var roleResult = await roleManager.CreateAsync(new IdentityRole("Admin"));
               
            }

            var adminUser = await userManager.FindByNameAsync("Admin");
            if (adminUser == null)
            {
                adminUser = new EquilibriumCoreUser("Admin");
                var password = "Admin1";
                var userResult = await userManager.CreateAsync(adminUser, password);
                if (userResult != null)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    Console.WriteLine($"Created admin user with password {password}");
                }
            }
        }
    }
}
