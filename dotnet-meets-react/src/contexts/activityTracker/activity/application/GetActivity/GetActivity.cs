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
    public class GetActivity : IQueryUseCase<ActivityId, Task<Activity>>
    {
        private readonly ActivityRepository _activityRepository;

        public GetActivity(ActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public Task<Activity> Execute(ActivityId activityId) =>
            _activityRepository.GetByID(activityId);
    }
}
