using System;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public class ActivityResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }

        public static ActivityResponse FromAggregate(Activity activity)
        {
            return new ActivityResponse()
            {
                Id = activity.Id.Value,
                Title = activity.Title.Value,
                Date = activity.Date.Value,
                Description = activity.Description.Value,
                Category = activity.Category.Value,
                City = activity.City.Value,
                Venue = activity.Venue.Value
            };
        }

        public Activity ToAggregate()
        {
            return Activity.FromPrimitives(
                new ActivityPrimitives
                {
                    Id = Id,
                    Title = Title,
                    Date = Date,
                    Description = Description,
                    Category = Category,
                    City = City,
                    Venue = Venue
                }
            );
        }
    }
}
