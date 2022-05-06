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
    public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQuery, Activities>
    {
        private readonly GetActivities _getActivities;

        public GetActivitiesQueryHandler(ActivityRepository activityRepository)
        {
            _getActivities = new GetActivities(activityRepository);
        }

        public Task<Activities> Handle(
            GetActivitiesQuery request,
            CancellationToken cancellationToken
        )
        {
            return _getActivities.Execute();
        }
    }
}
