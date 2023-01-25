using Microsoft.AspNetCore.Mvc;
using Application.Users;

namespace Web.API.Controllers;

public class UsersController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<string>> Post([FromBody] CreateUserCommand request)
    {
        return await Mediator.Send(request);
    }
}