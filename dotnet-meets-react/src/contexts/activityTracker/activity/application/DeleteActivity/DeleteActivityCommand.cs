using System;
using dotnet_meets_react.src.contexts.activityTracker.activity.application.Shared;
using MediatR;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity
{
    public class DeleteActivityCommand : IRequest<Result<Unit>>
    {
        public string ActivityId { get; set; }
    }
}
