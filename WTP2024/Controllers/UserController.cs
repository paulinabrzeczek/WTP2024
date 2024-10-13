using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using WTP2024.DAL;
using WTP2024.DTO;
using WTP2024.Services.User;

namespace WTP2024.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        private readonly WTP2024DbContext _context;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IConfiguration configuration, WTP2024DbContext context, IUserService userService)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
            _userService = userService;
        }

        [HttpPost("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Add user")]
        public async Task<ActionResult> AddUser(UserDto userDto, int userId)
        {
            await _userService.AddAsync(userDto, userId);
            return Ok();
        }

    }
}
