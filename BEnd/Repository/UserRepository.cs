using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Backend.Contexts;
using Backend.Models;

namespace Backend.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<User?> GetUser(Guid id) {
            return await context.userTable
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.id == id);
        }

        public async Task<List<User>> GetAll() {
            return await context.userTable
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Create(User user) {
            await context.userTable.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) {
            await context.userTable
                .Where(u => u.id == id)
                .ExecuteDeleteAsync();
        }
    }
}