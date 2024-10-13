using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Security.Claims;
using WTP2024.DAL;
using WTP2024.DAL.Entity;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Add user")]
        public async Task<ActionResult> AddUser(UserDto userDto, int userId)
        {
            await _userService.AddAsync(userDto, userId);
            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Login user")]
        public async Task<IActionResult> LoginUser( UserDto user)
        {
            Task<ClaimsPrincipal> principal = _userService.Login(user);

            if (principal.Result != null)
            {
                await HttpContext.SignInAsync(principal.Result);
            }

            return Json(new { message = "Nazwa użytkownika lub hasło nieprawidłowe" });
        }
    }
}
