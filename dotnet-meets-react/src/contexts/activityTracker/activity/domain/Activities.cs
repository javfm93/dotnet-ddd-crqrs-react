using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public class Activities
    {
        private readonly List<Activity> _activities;

        private Activities(List<Activity> activities)
        {
            _activities = activities;
        }

        public static Activities Create(List<Activity> activities)
        {
            return new Activities(activities);
        }

        public List<ActivityPrimitives> ToPrimitives()
        {
            return _activities.Select(a => a.ToPrimitives()).ToList();
        }

        public List<Activity> ToList()
        {
            return _activities;
        }

        public static Activities FromPrimitives(List<ActivityPrimitives> activitiesDTO)
        {
            var activities = activitiesDTO
                .Select(activityDTO => Activity.FromPrimitives(activityDTO))
                .ToList();
            return new Activities(activities);
        }
    }
}
