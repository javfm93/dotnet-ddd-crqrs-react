using System;
using System.Collections.Generic;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException() { }

        public InvalidParameterException(string parameter)
            : base($" Invalid parameter: {parameter}") { }

        public InvalidParameterException(string message, Exception inner) : base(message, inner) { }
    }
}
