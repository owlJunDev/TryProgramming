// using Backend.Configurations;
using Backend.Models;

using Microsoft.EntityFrameworkCore;

namespace Backend.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> userTable { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            Database.EnsureCreated();
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}