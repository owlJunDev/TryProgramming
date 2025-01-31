using BEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BEnd.Context
{
    public class ContextDB : DbContext 
    {
        public DbSet<User> usrTable { get; set; }
        public DbSet<PassHash> phTable { get; set; }
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) {}

    }
}