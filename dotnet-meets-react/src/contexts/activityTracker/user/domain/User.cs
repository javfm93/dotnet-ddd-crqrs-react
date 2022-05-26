using System;
using System.Collections.Generic;
using System.ComponentModel;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using Microsoft.AspNetCore.Identity;

namespace dotnet_meets_react.src.contexts.activityTracker.user.domain
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }

        public ICollection<Activity> Activities { get; set; }

        // internal void Update() {}

        // public UserPrimitives ToPrimitives() {}

        // public static User FromPrimitives( ){}
    }
}
