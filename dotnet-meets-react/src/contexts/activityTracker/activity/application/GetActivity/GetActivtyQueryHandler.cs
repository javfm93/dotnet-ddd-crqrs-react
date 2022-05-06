using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application
{
    public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, Activity>
    {
        private readonly GetActivity _getActivity;

        public GetActivityQueryHandler(ActivityRepository activityRepository)
        {
            _getActivity = new GetActivity(activityRepository);
        }

        public async Task<Activity> Handle(
            GetActivityQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _getActivity.Execute(request.Id);
        }
    }
}
