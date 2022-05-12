using System;
using System.Collections.Generic;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public class ActivityNotFound : Exception
    {
        public ActivityNotFound() : base("Activity Not Found") { }

        public ActivityNotFound(string message) : base(message) { }

        public ActivityNotFound(string message, Exception inner) : base(message, inner) { }
    }
}
