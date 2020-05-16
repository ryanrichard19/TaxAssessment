using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        public IMediator Mediator { get; set; }
    }
}
