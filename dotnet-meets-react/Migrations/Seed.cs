using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.shared.infraestructure;

namespace dotnet_meets_react.Migrations
{
    public class Seed
    {
        public static async Task InitialActivities(Repositories repositories)
        {
            if (repositories.Activities.Any())
                return;

            var activities = new List<ActivityPrimitives>
            {
                new ActivityPrimitives
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Past Activity 1",
                    Date = DateTime.Now.AddMonths(-2).ToString(),
                    Description = "Activity 2 months ago",
                    Category = "drinks",
                    City = "London",
                    Venue = "Pub",
                },
                new ActivityPrimitives
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Past Activity 2",
                    Date = DateTime.Now.AddMonths(-1).ToString(),
                    Description = "Activity 1 month ago",
                    Category = "culture",
                    City = "Paris",
                    Venue = "Louvre",
                },
                new ActivityPrimitives
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Future Activity 1",
                    Date = DateTime.Now.AddMonths(1).ToString(),
                    Description = "Activity 1 month in future",
                    Category = "culture",
                    City = "London",
                    Venue = "Natural History Museum",
                },
                new ActivityPrimitives
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Future Activity 2",
                    Date = DateTime.Now.AddMonths(2).ToString(),
                    Description = "Activity 2 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "O2 Arena",
                },
                new ActivityPrimitives
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Future Activity 3",
                    Date = DateTime.Now.AddMonths(3).ToString(),
                    Description = "Activity 3 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Another pub",
                },
                new ActivityPrimitives
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Future Activity 4",
                    Date = DateTime.Now.AddMonths(4).ToString(),
                    Description = "Activity 4 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Yet another pub",
                },
                new ActivityPrimitives
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Future Activity 5",
                    Date = DateTime.Now.AddMonths(5).ToString(),
                    Description = "Activity 5 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Just another pub",
                },
                new ActivityPrimitives
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Future Activity 6",
                    Date = DateTime.Now.AddMonths(6).ToString(),
                    Description = "Activity 6 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "Roundhouse Camden",
                },
                new ActivityPrimitives
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Future Activity 7",
                    Date = DateTime.Now.AddMonths(7).ToString(),
                    Description = "Activity 2 months ago",
                    Category = "travel",
                    City = "London",
                    Venue = "Somewhere on the Thames",
                },
                new ActivityPrimitives
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Future Activity 8",
                    Date = DateTime.Now.AddMonths(8).ToString(),
                    Description = "Activity 8 months in future",
                    Category = "film",
                    City = "London",
                    Venue = "Cinema",
                }
            };

            await repositories.Activities.AddRangeAsync(activities);
            await repositories.SaveChangesAsync();
        }
    }
}
