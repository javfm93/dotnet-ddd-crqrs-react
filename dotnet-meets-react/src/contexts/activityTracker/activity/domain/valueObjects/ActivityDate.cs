using System;
using System.Collections.Generic;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public class ActivityDate : ValueObject
    {
        public string Value { get; private set; }

        private ActivityDate(string value)
        {
            Value = value;
        }

        public static ActivityDate Create(string value)
        {
            try
            {
                var date = DateTime.Parse(value);
                return new ActivityDate(date.ToString());
            }
            catch (Exception)
            {
                throw new InvalidParameterException("date");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
