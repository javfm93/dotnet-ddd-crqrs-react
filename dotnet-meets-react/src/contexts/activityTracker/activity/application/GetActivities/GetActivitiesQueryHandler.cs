using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.application.Shared;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application
{
    public class GetActivitiesQueryHandler
        : IRequestHandler<GetActivitiesQuery, Result<List<ActivityResponse>>>
    {
        private readonly GetActivities _getActivities;

        public GetActivitiesQueryHandler(GetActivities getActivities)
        {
            _getActivities = getActivities;
        }

        public async Task<Result<List<ActivityResponse>>> Handle(
            GetActivitiesQuery request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var activities = await _getActivities.Execute();
                return Result<List<ActivityResponse>>.Success(
                    ActivitiesResponse.FromAggregate(activities)
                );
            }
            catch (Exception e)
            {
                return Result<List<ActivityResponse>>.Failure(e);
            }
        }
    }
}
