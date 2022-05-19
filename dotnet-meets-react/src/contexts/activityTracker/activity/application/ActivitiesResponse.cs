using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public class ActivitiesResponse
    {
        public static List<ActivityResponse> FromAggregate(Activities activities)
        {
            return activities.ToList().Select(ActivityResponse.FromAggregate).ToList();
        }
    }
}
