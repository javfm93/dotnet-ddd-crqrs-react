using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public interface IActivityRepository : IRepository
    {
        Task<Activities> GetAll();
        Task<Activity> GetByID(ActivityId activityId);
        Task Create(Activity entity);
        Task Update(Activity entity);
        Task Delete(Activity entity);
    }
}
