using System;
using System.Threading.Tasks;

namespace dotnet_meets_react.src.contexts.activityTracker.activity.domain
{
    public interface ICommandUseCase<Arguments>
    {
        Task Execute(Arguments args);
    }
}
