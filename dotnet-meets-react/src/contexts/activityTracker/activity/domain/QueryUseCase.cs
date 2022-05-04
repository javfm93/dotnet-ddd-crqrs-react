using System;
namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public interface IQueryUseCase<Arguments, ReturnType>
    {
        ReturnType Execute(Arguments args);
    }
}
