using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_meets_react.src.contexts.activityTracker.activity.application;
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
        private readonly IMediator _mediator;

        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _mediator.Send(new GetActivitiesQuery.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return Ok();
        }
    }
}

