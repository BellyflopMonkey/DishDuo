using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DishDuo.Models;

namespace DishDuo.ContextDBConfig
{
    public class DishDuoDBContext:IdentityDbContext<ApplicationUser>
    {
        public DishDuoDBContext(DbContextOptions<DishDuoDBContext> options): base(options) 
        {      
            
        } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
