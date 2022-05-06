using System;
using System.Threading;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using MediatR;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand>
    {
        private readonly UpdateActivity _updateActivity;

        public UpdateActivityCommandHandler(ActivityRepository activityRepository)
        {
            _updateActivity = new UpdateActivity(activityRepository);
        }

        public async Task<Unit> Handle(
            UpdateActivityCommand request,
            CancellationToken cancellationToken
        )
        {
            await _updateActivity.Execute(request.Activity);
            return Unit.Value;
        }
    }
}
