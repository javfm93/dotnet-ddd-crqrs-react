using System;
using System.Collections.Generic;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;

namespace dotnet_meets_react.src.contexts.activityTracker.shared.domain
{
    public class ActivityAttendees : ValueObject
    {
        public List<ActivityAttendee> Value { get; private set; }

        private ActivityAttendees(List<ActivityAttendee> value)
        {
            Value = value;
        }

        public static ActivityAttendees Create(List<ActivityAttendee> value)
        {
            return new ActivityAttendees(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
