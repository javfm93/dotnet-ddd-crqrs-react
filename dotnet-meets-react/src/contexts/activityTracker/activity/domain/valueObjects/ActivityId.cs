using System;
using System.Collections.Generic;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;

namespace dotnet_meets_react.src.contexts.activityTracker.shared.domain
{
    public class ActivityId : ValueObject
    {
        public string Value { get; private set; }

        private ActivityId(string value)
        {
            Value = value;
        }

        public static ActivityId Create(string value)
        {
            try
            {
                Guid guid = Guid.Parse(value);
                return new ActivityId(guid.ToString());
            }
            catch (Exception)
            {
                throw new InvalidParameterException("guid");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
