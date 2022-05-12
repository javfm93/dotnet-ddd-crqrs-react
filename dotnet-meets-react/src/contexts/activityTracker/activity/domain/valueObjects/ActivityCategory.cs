using System;
using System.Collections.Generic;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
	public class ActivityCategory : ValueObject
	{
		public string Value { get; private set; }

		private ActivityCategory(string value)
		{
			Value = value;
		}

		public static ActivityCategory Create(string value)
		{
			return new ActivityCategory(value);
		}	


		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}

