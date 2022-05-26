using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dotnet_meets_react.src.contexts.activityTracker.shared.domain;
using dotnet_meets_react.src.contexts.activityTracker.user.domain;

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
        public User Host { get; set; }
        public ICollection<User> Attendees { get; set; }
    }
}
