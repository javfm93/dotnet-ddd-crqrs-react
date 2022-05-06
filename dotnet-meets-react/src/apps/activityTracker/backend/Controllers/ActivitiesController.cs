using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.application;
using dotnet_meets_react.src.contexts.activityTracker.activity.application.CreateActivity;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;
using dotnet_meets_react.src.contexts.activityTracker.activity.infraestructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dotnet_meets_react.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<ActivityDTO>>> GetActivities()
        {
            var activities = await Mediator.Send(new GetActivitiesQuery());
            return activities.ToPrimitives();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDTO>> GetActivity(Guid id)
        {
            var activity = await Mediator.Send(new GetActivityQuery { Id = id });
            return activity.ToPrimitives();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActivity(Guid id, ActivityDTO activity)
        {
            activity.Id = id;
            await Mediator.Send(new UpdateActivityCommand { Activity = activity });

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(ActivityDTO activity)
        {
            await Mediator.Send(new CreateActivityCommand { Activity = activity });
            return Ok();
        }
    }
}
