using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_meets_react.src.apps.activityTracker.backend.Controllers.Users;
using dotnet_meets_react.src.contexts.activityTracker.user.application;
using dotnet_meets_react.src.contexts.activityTracker.user.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_meets_react.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;

        public UsersController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenService tokenService
        )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponse>> Login(UserLoginRequest login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (null == user)
                return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            return result.Succeeded ? MapToUserResponseFrom(user) : Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(UserRegistrationRequest registration)
        {
            if (await _userManager.Users.AnyAsync(u => u.Email == registration.Email))
                return BadRequest("Email Taken");

            if (await _userManager.Users.AnyAsync(u => u.UserName == registration.UserName))
                return BadRequest("Username Taken");

            var user = new User
            {
                DisplayName = registration.DisplayName,
                Email = registration.Email,
                UserName = registration.UserName
            };

            var result = await _userManager.CreateAsync(user, registration.Password);
            return result.Succeeded
              ? MapToUserResponseFrom(user)
              : BadRequest("Problem registering user");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            return MapToUserResponseFrom(user);
        }

        private UserResponse MapToUserResponseFrom(User user)
        {
            return new UserResponse
            {
                DisplayName = user.DisplayName,
                Image = null,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName
            };
        }
    }
}
