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
    public class GetActivities : IQueryUseCaseNoArgs<Task<List<Activity>>>
    {
        private readonly DataContext _context;

        public GetActivities(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> Execute()
        {
            var activities = await _context.Activities.ToListAsync();
            return activities.Select(a => Activity.FromPrimitives(a)).ToList();
        }
    }
}
