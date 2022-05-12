using System;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public class ActivityValueObjects
    {
        public ActivityId Id { get; set; }
        public ActivityTitle Title { get; set; }
        public ActivityDate Date { get; set; }
        public ActivityDescription Description { get; set; }
        public ActivityCategory Category { get; set; }
        public ActivityCity City { get; set; }
        public ActivityVenue Venue { get; set; }
    }
}
