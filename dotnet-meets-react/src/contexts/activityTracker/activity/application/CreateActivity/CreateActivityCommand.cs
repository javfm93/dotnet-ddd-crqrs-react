using System;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using MediatR;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity
{
    public class CreateActivityCommand : IRequest
    {
        public ActivityDTO Activity { get; set; }
    }
}
