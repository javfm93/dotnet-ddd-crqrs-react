using System;
using System.Collections.Generic;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
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

