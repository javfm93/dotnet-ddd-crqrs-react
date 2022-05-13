using System;
using System.Collections.Generic;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;

namespace dotnet_meets_react.src.contexts.activityTracker.shared.domain
{
    public class ActivityTitle : ValueObject
    {
        public string Value { get; private set; }

        private ActivityTitle(string value)
        {
            Value = value;
        }

        public static ActivityTitle Create(string value)
        {
            return new ActivityTitle(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
