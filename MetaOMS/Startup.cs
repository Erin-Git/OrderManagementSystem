using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using Core.DataAccess;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MetaOMS
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
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews();
            services.AddDbContext<DatabaseContext>(Options =>
            Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //My services
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IDeliveryStaffService, DeliveryStaffService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IShippingService, ShippingService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductInventoryService, ProductInventoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // The code is used to generate the database on startup

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.
                    GetRequiredService<DatabaseContext>();
                context.Database.EnsureCreated();

            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
