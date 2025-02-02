using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BEnd.Service
{
    public class UserService
    {
        public async Task<string> HashPassword(string password) {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, BCrypt.Net.HashType.SHA512);
        }
        public async Task<bool> VerifyHashedPassword(string hashedPassword, string password) {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword, BCrypt.Net.HashType.SHA512);
        }
    }
}