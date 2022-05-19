using System.Threading.Tasks;
using dotnet_meets_react.src.apps.activityTracker.backend.Controllers.Users;
using dotnet_meets_react.src.contexts.activityTracker.user.application;
using dotnet_meets_react.src.contexts.activityTracker.user.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_meets_react.Controllers
{
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
        public async Task<ActionResult<UserResponse>> Login(LoginUserRequest login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (null == user)
                return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            return result.Succeeded
              ? new UserResponse
                {
                    DisplayName = user.DisplayName,
                    Image = null,
                    Token = _tokenService.CreateToken(user),
                    Username = user.UserName
                }
              : Unauthorized();
        }
    }
}
