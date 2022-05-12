using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    public class PutActivityController : BaseApiController
    {
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActivity(string id, ActivityRequest activity)
        {
            activity.Id = id;
            var result = await Mediator.Send(new UpdateActivityCommand { Activity = activity });
            return HandleResult(result);
        }
    }
}
