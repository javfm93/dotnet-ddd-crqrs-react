using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace dotnet_meets_react.src.contexts.activityTracker.user.domain
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }

        private User()
        {
        }

        public static User Create()
        {
            return new User();
        }

        // internal void Update() {}

        // public UserPrimitives ToPrimitives() {}

        // public static User FromPrimitives( ){}
    }
}
