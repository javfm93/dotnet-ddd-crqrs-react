using System;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using Microsoft.EntityFrameworkCore;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure
{
    public class Repositories : DbContext
    {
        public Repositories(DbContextOptions options) : base(options) { }

        public DbSet<ActivityPrimitives> Activities { get; set; }
    }
}
