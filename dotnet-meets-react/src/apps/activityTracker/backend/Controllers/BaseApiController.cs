using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using dotnet_meets_react.src.contexts.activityTracker.activity.application.Shared;
using System.Runtime.CompilerServices;
using dotnet_meets_react.src.contexts.activityTracker.activity.domain;

namespace dotnet_meets_react.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result.Value);
            if (!result.IsSuccess && result.Error.Equals(new ActivityNotFound()))
                return NotFound();
            return BadRequest(result.Error);
        }
    }
}
