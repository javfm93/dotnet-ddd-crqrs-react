using System;
using System.Threading;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using MediatR;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand>
    {
        private readonly CreateActivity _createActivity;

        public CreateActivityCommandHandler(DataContext dataContext)
        {
            _createActivity = new CreateActivity(dataContext);
        }

        public async Task<Unit> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            await _createActivity.Execute(request.Activity);
            return Unit.Value;
        }
    }
}
