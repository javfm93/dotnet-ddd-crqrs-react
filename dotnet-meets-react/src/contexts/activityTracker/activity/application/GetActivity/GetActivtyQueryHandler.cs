using System;
using System.Threading;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.application.Shared;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using MediatR;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.application
{
    public class GetActivityQueryHandler
        : IRequestHandler<GetActivityQuery, Result<ActivityResponse>>
    {
        private readonly GetActivity _getActivity;

        public GetActivityQueryHandler(GetActivity getActivity)
        {
            _getActivity = getActivity;
        }

        public async Task<Result<ActivityResponse>> Handle(
            GetActivityQuery request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var activityId = ActivityId.Create(request.Id);
                var activity = await _getActivity.Execute(activityId);
                return null == activity
                  ? throw new ActivityNotFound()
                  : Result<ActivityResponse>.Success(ActivityResponse.FromAggregate(activity));
            }
            catch (Exception e)
            {
                return Result<ActivityResponse>.Failure(e);
            }
        }
    }
}
