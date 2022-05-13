using System;
using System.Collections.Generic;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;

namespace dotnet_meets_react.src.contexts.activityTracker.shared.domain
{
    public class ActivityDescription : ValueObject
    {
        public string Value { get; private set; }

        private ActivityDescription(string value)
        {
            Value = value;
        }

        public static ActivityDescription Create(string value)
        {
            return new ActivityDescription(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
