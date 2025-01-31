using BEnd.Context;
using BEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BEnd.Repository {
    public class UserRepository {
        private readonly ContextDB context;

        public UserRepository(ContextDB context) {
            this.context = context;
        } 

        public async Task<User?> GetUserById(Guid id) {
            return await context.usrTable
            .AsNoTracking()
            .Where(u => u.id == id)
            .FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByUserNmae(String uName) {
            return await context.usrTable
            .AsNoTracking()
            .Where(u => u.username == uName)
            .FirstOrDefaultAsync();
        }
        public async Task<List<User>> GetAllUser() {
            return await context.usrTable
            .AsNoTracking()
            .OrderBy(u => u.username)
            .ToListAsync();
        }

        public async Task<PassHash?> GetUserPassH(Guid userId) {
            return await context.phTable
                .AsNoTracking()
                .Where(p => p.userId ==  userId)
                .FirstOrDefaultAsync();
        }
    }
}