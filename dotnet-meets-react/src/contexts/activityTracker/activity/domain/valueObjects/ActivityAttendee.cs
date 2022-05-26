using System;
using System.Collections.Generic;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;

// TODO: use this instead of directly users, it is a pain at infrastructure layer
namespace dotnet_meets_react.src.contexts.activityTracker.shared.domain
{
    public class ActivityAttendee : ValueObject
    {
        public string Id { get; private set; }
        public string DisplayName { get; private set; }
        public string Bio { get; private set; }

        private ActivityAttendee(string id, string displayName, string bio)
        {
            Id = id;
            DisplayName = displayName;
            Bio = bio;
        }

        public static ActivityAttendee Create(string id, string displayName, string bio)
        {
            try
            {
                Guid guid = Guid.Parse(id);
                return new ActivityAttendee(guid.ToString(), displayName, bio);
            }
            catch (Exception)
            {
                throw new InvalidParameterException("activityHostId");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return DisplayName;
            yield return Bio;
        }
    }
}
