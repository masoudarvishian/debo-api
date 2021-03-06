using DEBO.Core.DomainService;
using DEBO.Core.Entity.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DEBO.Infrastructure.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationContext _context;

        public AuthRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username,
            string password)
        {
            var user = await _context.Set<User>()
                .FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password,
                user.PasswordHash,
                user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password,
            byte[] passwordHash,
            byte[] passwordSalt)
        {
            using (var hmac =
                new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(
                        System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0;
                    i < computedHash[i];
                    i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }

        public async Task<User> Register(User user,
            string password)
        {
            byte[] passwordHash,
                passwordSalt;
            CreatePasswordHash(password,
                out passwordHash,
                out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.CreateDate = DateTime.Now;
            user.ModifyDate = DateTime.Now;

            await _context.Set<User>()
                .AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password,
            out byte[] passwordHash,
            out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash =
                    hmac.ComputeHash(
                        System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username) =>
            await _context.Set<User>()
                .AnyAsync(x => x.Username == username);
    }
}