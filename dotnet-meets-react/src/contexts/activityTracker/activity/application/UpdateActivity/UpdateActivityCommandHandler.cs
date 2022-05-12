using System;
using System.Threading;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.application.Shared;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using MediatR;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, Result<Unit>>
    {
        private readonly UpdateActivity _updateActivity;

        public UpdateActivityCommandHandler(UpdateActivity updateActivity)
        {
            _updateActivity = updateActivity;
        }

        public async Task<Result<Unit>> Handle(
            UpdateActivityCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var id = ActivityId.Create(request.Id);
                var title = ActivityTitle.Create(request.Title);
                var description = ActivityDescription.Create(request.Description);
                var date = ActivityDate.Create(request.Date);
                var category = ActivityCategory.Create(request.Category);
                var city = ActivityCity.Create(request.City);
                var venue = ActivityVenue.Create(request.Venue);

                await _updateActivity.Execute(
                    new ActivityValueObjects
                    {
                        Id = id,
                        Title = title,
                        Description = description,
                        Date = date,
                        Category = category,
                        City = city,
                        Venue = venue
                    }
                );
                return Result<Unit>.Success(Unit.Value);
            }
            catch (Exception e)
            {
                return Result<Unit>.Failure(e);
            }
        }
    }
}
