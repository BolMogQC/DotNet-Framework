using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Common
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        protected ILogger Logger { get; init; }
        private ISender mediator;
        protected ISender Mediator => mediator ??= HttpContext.RequestServices.GetService<ISender>();

        public ApiControllerBase(ILogger logger) => Logger = logger;
    }
}
