using System;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using MediatR;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity
{
    public class UpdateActivity : ICommandUseCase<ActivityValueObjects>
    {
        private readonly ActivityRepository _activityRepository;
        private readonly IMediator _mediator;

        public UpdateActivity(ActivityRepository activityRepository, IMediator mediator)
        {
            _activityRepository = activityRepository;
            _mediator = mediator;
        }

        public async Task Execute(ActivityValueObjects activity)
        {
            var oldActivity = await _activityRepository.GetByID(activity.Id);
            var result = await _mediator.Send(new GetActivityQuery { Id = activity.Id.Value });

            if (!result.IsSuccess && result.Error.Equals(new ActivityNotFound()))
            {
                var newActivity = Activity.Create(activity);
                await _activityRepository.Create(newActivity);
            }
            else
            {
                oldActivity.Update(
                    activity.Title,
                    activity.Date,
                    activity.Description,
                    activity.Category,
                    activity.City,
                    activity.Venue
                );
                await _activityRepository.Update(oldActivity);
            }
        }
    }
}
