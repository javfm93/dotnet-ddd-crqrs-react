using System;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.application.Shared;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using dotnet_meets_react.src.contexts.activityTracker.shared.domain;
using MediatR;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity
{
    public class DeleteActivity : ICommandUseCase<ActivityId>
    {
        private readonly ActivityRepository _activityRepository;
        private readonly IMediator _mediator;

        public DeleteActivity(ActivityRepository activityRepository, IMediator mediator)
        {
            _activityRepository = activityRepository;
            _mediator = mediator;
        }

        public async Task Execute(ActivityId id)
        {
            var result = await _mediator.Send(new GetActivityQuery { Id = id.Value });
            if (!result.IsSuccess)
                throw result.Error;
            await _activityRepository.Delete(result.Value.ToAggregate());
        }
    }
}
