using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DeliveryStaff> DeliveryStaff { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductInventory> ProductInventory { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<User> User { get; set; }
    }
}
