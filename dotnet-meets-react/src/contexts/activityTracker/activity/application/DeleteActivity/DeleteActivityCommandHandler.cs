using System;
using System.Threading;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.application.Shared;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using dotnet_meets_react.src.contexts.activityTracker.shared.domain;
using MediatR;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity
{
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, Result<Unit>>
    {
        private readonly DeleteActivity _deleteActivity;

        public DeleteActivityCommandHandler(DeleteActivity deleteActivity)
        {
            _deleteActivity = deleteActivity;
        }

        public async Task<Result<Unit>> Handle(
            DeleteActivityCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var activityId = ActivityId.Create(request.ActivityId);
                await _deleteActivity.Execute(activityId);
                return Result<Unit>.Success(Unit.Value);
            }
            catch (Exception e)
            {
                return Result<Unit>.Failure(e);
            }
        }
    }
}
