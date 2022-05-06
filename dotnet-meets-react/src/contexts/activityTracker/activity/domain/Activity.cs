using System;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public class Activity
    {
        public Guid Id { get; private set; }
        public ActivityTitle Title { get; private set; }
        public DateTime Date { get; private set; }
        public ActivityDescription Description { get; private set; }
        public ActivityCategory Category { get; private set; }
        public ActivityCity City { get; private set; }
        public ActivityVenue Venue { get; private set; }

        private Activity(
            Guid id,
            ActivityTitle title,
            DateTime date,
            ActivityDescription description,
            ActivityCategory category,
            ActivityCity city,
            ActivityVenue venue
        )
        {
            Id = id;
            Title = title;
            Date = date;
            Description = description;
            Category = category;
            City = city;
            Venue = venue;
        }

        public static Activity Create(
            Guid id,
            ActivityTitle title,
            DateTime date,
            ActivityDescription description,
            ActivityCategory category,
            ActivityCity city,
            ActivityVenue venue
        )
        {
            return new Activity(id, title, date, description, category, city, venue);
        }

        public ActivityDTO ToPrimitives()
        {
            return new ActivityDTO
            {
                Id = Id,
                Title = Title.Value,
                Date = Date,
                Description = Description.Value,
                Category = Category.Value,
                City = City.Value,
                Venue = Venue.Value
            };
        }

        internal void Update(
            ActivityTitle title,
            DateTime date,
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

        public static Activity FromPrimitives(ActivityDTO activityDTO)
        {
            var title = ActivityTitle.Create(activityDTO.Title);
            var description = ActivityDescription.Create(activityDTO.Description);
            var category = ActivityCategory.Create(activityDTO.Category);
            var city = ActivityCity.Create(activityDTO.City);
            var venue = ActivityVenue.Create(activityDTO.Venue);

            return new Activity(
                activityDTO.Id,
                title,
                activityDTO.Date,
                description,
                category,
                city,
                venue
            );
        }
    }
}
