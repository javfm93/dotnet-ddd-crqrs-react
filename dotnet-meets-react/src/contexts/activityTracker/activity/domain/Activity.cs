using System.Collections.Generic;
using dotnet_meets_react.src.contexts.activityTracker.shared.domain;
using dotnet_meets_react.src.contexts.activityTracker.user.domain;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public class Activity
    {
        public ActivityId Id { get; private set; }
        public ActivityTitle Title { get; private set; }
        public ActivityDate Date { get; private set; }
        public ActivityDescription Description { get; private set; }
        public ActivityCategory Category { get; private set; }
        public ActivityCity City { get; private set; }
        public ActivityVenue Venue { get; private set; }
        public User Host { get; private set; }
        public ICollection<User> Attendees { get; private set; }

        private Activity(ActivityValueObjects activity)
        {
            Id = activity.Id;
            Title = activity.Title;
            Date = activity.Date;
            Description = activity.Description;
            Category = activity.Category;
            City = activity.City;
            Venue = activity.Venue;
            Host = activity.Host;
            Attendees = activity.Attendees;
        }

        public static Activity Create(ActivityValueObjects activity)
        {
            return new Activity(activity);
        }

        internal void Update(
            ActivityTitle title,
            ActivityDate date,
            ActivityDescription description,
            ActivityCategory category,
            ActivityCity city,
            ActivityVenue venue
        )
        {
            Title = title;
            Date = date;
            Description = description;
            Category = category;
            City = city;
            Venue = venue;
        }

        public ActivityPrimitives ToPrimitives()
        {
            return new ActivityPrimitives
            {
                Id = Id.Value,
                Title = Title.Value,
                Date = Date.Value,
                Description = Description.Value,
                Category = Category.Value,
                City = City.Value,
                Venue = Venue.Value,
                Host = Host,
                Attendees = Attendees,
            };
        }

        public static Activity FromPrimitives(ActivityPrimitives activity)
        {
            var id = ActivityId.Create(activity.Id);
            var title = ActivityTitle.Create(activity.Title);
            var description = ActivityDescription.Create(activity.Description);
            var category = ActivityCategory.Create(activity.Category);
            var city = ActivityCity.Create(activity.City);
            var venue = ActivityVenue.Create(activity.Venue);
            var date = ActivityDate.Create(activity.Date);

            return new Activity(
                new ActivityValueObjects
                {
                    Id = id,
                    Title = title,
                    Description = description,
                    Date = date,
                    Category = category,
                    City = city,
                    Venue = venue,
                    Host = activity.Host,
                    Attendees = activity.Attendees
                }
            );
        }
    }
}
