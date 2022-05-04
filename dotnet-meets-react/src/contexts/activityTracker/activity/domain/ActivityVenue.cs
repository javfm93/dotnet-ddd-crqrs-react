using System;
using System.Collections.Generic;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
	public class ActivityVenue : ValueObject
	{
		public string Value { get; private set; }

		private ActivityVenue(string value)
		{
			Value = value;
		}

		public static ActivityVenue Create(string value)
		{
			return new ActivityVenue(value);
		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}

