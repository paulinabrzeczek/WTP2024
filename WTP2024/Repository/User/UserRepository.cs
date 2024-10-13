using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using WTP2024.DAL;
using WTP2024.DAL.Configuration.Settings;
using WTP2024.DAL.Entity;

namespace WTP2024.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly WTP2024DbContext _dbContext;
        public UserRepository(WTP2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username == username);
        }
        public async Task AddAsync(UserDb userDb)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            userDb.Passwordhash = BCrypt.Net.BCrypt.HashPassword(userDb.Passwordhash, salt);
            userDb.RoleId = 2;
            await _dbContext.Users.AddAsync(userDb);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfExistsAsync(int userId)
        {
            return await _dbContext.Users.Where(x => x.Id == userId).AnyAsync();
        }
        public async Task<UserDb?> FindByUsernameAsync(string username)
        { 
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<RoleDb?> GetUserRoleAsync(int roleId)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        }

    }
}
