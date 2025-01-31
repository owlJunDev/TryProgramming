using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BEnd.Service
{
    public class UserService
    {
        public async Task<string> HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password.Trim(("$2a$11$").ToCharArray()));
        }
        public async Task<bool> VerifyHashedPassword(string hashedPassword, string password) {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, "$2a$11$" + hashedPassword);
        }
    }
}