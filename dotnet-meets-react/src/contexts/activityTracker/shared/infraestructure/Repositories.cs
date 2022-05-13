using System;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.user.domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_meets_react.src.contexts.activityTracker.shared.infraestructure
{
    public class Repositories : IdentityDbContext<User>
    {
        public Repositories(DbContextOptions options) : base(options) { }

        public DbSet<ActivityPrimitives> Activities { get; set; }
    }
}
