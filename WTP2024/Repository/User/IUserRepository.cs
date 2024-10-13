using WTP2024.DAL.Entity;

namespace WTP2024.Repository.User
{
    public interface IUserRepository
    {
        Task AddAsync(UserDb userDb);
        Task<bool> CheckIfExistsAsync(int userId);
        Task<UserDb?> FindByUsernameAsync(string username);
        Task<RoleDb?> GetUserRoleAsync(int roleId);
        Task<bool> UsernameExistsAsync(string username);

    }
}
