using System;
namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public interface IQueryUseCaseNoArgs<ReturnType>
    {
        ReturnType Execute();

    }
}
