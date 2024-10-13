using Microsoft.Extensions.Options;
using System.Security.Claims;
using WTP2024.DAL;
using WTP2024.DAL.Entity;
using WTP2024.DTO;
using WTP2024.DAL.Configuration.Settings;
using WTP2024.Repository.User;

namespace WTP2024.Services.User
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;
        private readonly string _salt;

        public UserService(WTP2024DbContext dbContext, ILogger<UserService> logger, IOptions<Settings>settings, IUserRepository userRepository) : base(dbContext)
        {
            _userRepository = userRepository;
            _logger = logger;
            _salt = settings.Value.Salt;
        }
        public async Task AddAsync(UserDto userDto, int userId)
        {
            if (!await _userRepository.CheckIfExistsAsync(userId))
            {
                var userDb = MapToUserDb(userDto);
                var newUserDb = new UserDb
                {
                    Id = userId,
                    Username = userDb.Username,
                    Passwordhash = userDb.Passwordhash,
                    Role = userDb.Role,
            };

                await _userRepository.AddAsync(newUserDb);
            }
        }
        public async Task<ClaimsPrincipal?> Login(UserDto user)
        {
            var foundUser = await _userRepository.FindByUsernameAsync(user.Username);
            if (foundUser == null)
            {
                return null; 
            }

            bool checkUserCredentials = BCrypt.Net.BCrypt.Verify(user.Passwordhash, foundUser.Passwordhash);
            if (checkUserCredentials)
            {
                var userRole = await _userRepository.GetUserRoleAsync(foundUser.RoleId);
                if (userRole == null)
                {
                    return null; 
                }

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole.NameRole),
                new Claim(ClaimTypes.Name, foundUser.Username),
                new Claim(ClaimTypes.NameIdentifier, foundUser.Id.ToString())
            };

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                return principal;
            }

            return null;
        }

#region "Private"

        private static UserDto MapToDto(UserDb userDb)
        {
            return Map<UserDto>(userDb);
        }

        private static UserDb MapToUserDb(UserDto userDto) => new()
        {
            Id = userDto.Id,
            Username = userDto.Username,
            Passwordhash = userDto.Passwordhash,
            RoleId = userDto.RoleId
        };

        private static T Map<T>(UserDb userDb) where T : UserDto, new()
            => new()
            {
                Id = userDb.Id,
                Username = userDb.Username,
                Passwordhash = userDb.Passwordhash,
                RoleId = userDb.RoleId
            };

#endregion
    }

}

