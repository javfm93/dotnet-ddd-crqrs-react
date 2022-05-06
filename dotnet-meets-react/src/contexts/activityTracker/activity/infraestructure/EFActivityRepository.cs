using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using Microsoft.EntityFrameworkCore;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly Repositories _repositories;

        public ActivityRepository(Repositories repositories)
        {
            _repositories = repositories;
        }

        public async Task Create(Activity entity)
        {
            _repositories.Activities.Add(entity.ToPrimitives());
            await _repositories.SaveChangesAsync();
        }

        public async Task<Activities> GetAll()
        {
            var activities = await _repositories.Activities.ToListAsync();
            return Activities.FromPrimitives(activities);
        }

        public async Task<Activity> GetByID(Guid guid)
        {
            var activity = await _repositories.Activities.FindAsync(guid);
            _repositories.Entry(activity).State = EntityState.Detached;
            if (null == activity)
                return null;
            return null == activity ? null : Activity.FromPrimitives(activity);
        }

        public async Task Update(Activity activity)
        {
            _repositories.Activities.Update(activity.ToPrimitives());
            await _repositories.SaveChangesAsync();
        }
    }
}
