using System;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity
{
    public class UpdateActivity : ICommandUseCase<ActivityDTO>
    {
        private readonly ActivityRepository _activityRepository;

        public UpdateActivity(ActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task Execute(ActivityDTO activityDTO)
        {
            var title = ActivityTitle.Create(activityDTO.Title);
            var description = ActivityDescription.Create(activityDTO.Description);
            var category = ActivityCategory.Create(activityDTO.Category);
            var city = ActivityCity.Create(activityDTO.City);
            var venue = ActivityVenue.Create(activityDTO.Venue);

            var activity = await _activityRepository.GetByID(activityDTO.Id);

            if (null == activity)
            {
                var newActivity = Activity.Create(
                    activityDTO.Id,
                    title,
                    activityDTO.Date,
                    description,
                    category,
                    city,
                    venue
                );
                await _activityRepository.Create(newActivity);
            }
            else
            {
                activity.Update(title, activityDTO.Date, description, category, city, venue);
                await _activityRepository.Update(activity);
            }
        }
    }
}
