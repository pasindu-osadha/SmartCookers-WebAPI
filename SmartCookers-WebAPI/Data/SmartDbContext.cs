using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Data
{
    public class SmartDbContext: IdentityDbContext<SmartUser, SmartIdentityRole,Guid>
    {
        public SmartDbContext(DbContextOptions<SmartDbContext> options)
 : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Picture> Product_Pictures { get; set; }
        public DbSet<Outlet> Outlets { get; set; }
        public DbSet<Product_In_Outlet> Product_In_Outlets { get; set; }
        public DbSet<Product_Order> Product_Order { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<Customer_Address> Customer_Addresses { get; set; }
    }
}
