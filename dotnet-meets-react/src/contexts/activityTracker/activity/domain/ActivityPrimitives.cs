using System.Collections.Generic;
using dotnet_meets_react.src.contexts.activityTracker.user.domain;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public class ActivityPrimitives
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public User Host { get; set; }
        public ICollection<User> Attendees { get; set; }
    }
}
