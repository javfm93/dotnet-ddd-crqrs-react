using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.shared.domain;
using dotnet_meets_react.src.contexts.activityTracker.shared.infraestructure;
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

        public async Task Delete(Activity activity)
        {
            _repositories.Activities.Remove(activity.ToPrimitives());
            await _repositories.SaveChangesAsync();
        }

        public async Task<Activities> GetAll()
        {
            var activities = await _repositories.Activities.ToListAsync();
            return Activities.FromPrimitives(activities);
        }

        public async Task<Activity> GetByID(ActivityId activityId)
        {
            var activity = await _repositories.Activities.FindAsync(activityId.Value);
            _repositories.Entry(activity).State = EntityState.Detached;
            return null == activity ? null : Activity.FromPrimitives(activity);
        }

        public async Task Create(Activity activity)
        {
            _repositories.Activities.Add(activity.ToPrimitives());
            await _repositories.SaveChangesAsync();
        }

        public async Task Update(Activity activity)
        {
            _repositories.Activities.Update(activity.ToPrimitives());
            await _repositories.SaveChangesAsync();
        }
    }
}
