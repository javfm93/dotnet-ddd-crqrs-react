using System.ComponentModel.DataAnnotations;

namespace dotnet_meets_react.src.apps.activityTracker.backend.Controllers.Users
{
    public class UserRegistrationRequest
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
