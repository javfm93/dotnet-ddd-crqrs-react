using System;
using System.Collections.Generic;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
	public class ActivityCity : ValueObject
	{
		public string Value { get; private set; }

		private ActivityCity(string value)
		{
			Value = value;
		}

		public static ActivityCity Create(string value)
		{
			return new ActivityCity(value);
		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}

