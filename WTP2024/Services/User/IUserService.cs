using System.Security.Claims;
using WTP2024.DAL.Entity;
using WTP2024.DTO;

namespace WTP2024.Services.User
{
    public interface IUserService
    {
        Task AddAsync(UserDto userDto, int userId);
    }
}
