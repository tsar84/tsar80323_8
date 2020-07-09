using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using tsar80323.DAL.Data;
using tsar80323.DAL.Entities;
using tsar80323.Services;
using Microsoft.AspNetCore.Mvc;
using tsar80323.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using tsar80323.Extensions;

namespace tsar80323
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));




            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();


            services.AddDistributedMemoryCache();
            services.AddSession(opt => { opt.Cookie.HttpOnly = true; opt.Cookie.IsEssential = true; });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped<Cart>(sp => CartService.GetCart(sp));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


           


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
IWebHostEnvironment env,
ApplicationDbContext context,
UserManager<ApplicationUser> userManager,
RoleManager<IdentityRole> roleManager, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            DbInitializer.Seed(context, userManager, roleManager)
.GetAwaiter()
.GetResult();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            //9 4.2.3
            app.UseFileLogging();



            app.UseAuthentication();


            app.UseSession();



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });



            logger.AddFile("Logs/log-{Date}.txt");





        }
    }
}

