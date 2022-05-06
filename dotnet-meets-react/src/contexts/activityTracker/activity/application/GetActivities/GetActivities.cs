using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application
{
    public class GetActivities : IQueryUseCaseNoArgs<Task<Activities>>
    {
        private readonly ActivityRepository _activityRepository;

        public GetActivities(ActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public Task<Activities> Execute() => _activityRepository.GetAll();
    }
}
