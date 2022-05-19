using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.application;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_meets_react.Controllers
{
    public class GetActivityController : BaseApiController
    {
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityResponse>> GetActivity(string id)
        {
            var result = await Mediator.Send(new GetActivityQuery { Id = id });
            return HandleResult(result);
        }
    }
}
