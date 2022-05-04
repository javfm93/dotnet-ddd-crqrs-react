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
    public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQuery, List<Activity>>
    {
        private readonly GetActivities _getActivities;

        public GetActivitiesQueryHandler(DataContext context)
        {
            _getActivities = new GetActivities(context);
        }

        public Task<List<Activity>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
        {
            return _getActivities.Execute();
        }
    }
}
