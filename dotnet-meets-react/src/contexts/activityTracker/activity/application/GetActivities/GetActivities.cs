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
    public class GetActivities : IQueryUseCaseNoArgs<Task<List<Activity>>>
    {
        private readonly DataContext _context;

        public GetActivities(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> Execute()
        {
            return await _context.Activities.ToListAsync();
        }
    }
}
