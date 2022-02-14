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
    }
}
