using System;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity
{
    public class CreateActivity: ICommandUseCase<ActivityDTO>
    {
        private readonly DataContext _context;

        public CreateActivity(DataContext context)
        {
            _context = context;
        }

        public async Task Execute(ActivityDTO activityDTO)
        {
            var title = ActivityTitle.Create(activityDTO.Title);
            var description = ActivityDescription.Create(activityDTO.Description);
            var category = ActivityCategory.Create(activityDTO.Category);
            var city = ActivityCity.Create(activityDTO.City);
            var venue = ActivityVenue.Create(activityDTO.Venue);

            var activity = Activity.Create(activityDTO.Id, title, activityDTO.Date, description, category, city, venue);

            _context.Activities.Add(activity.ToPrimitives());
            await _context.SaveChangesAsync();
        }
    }
}
