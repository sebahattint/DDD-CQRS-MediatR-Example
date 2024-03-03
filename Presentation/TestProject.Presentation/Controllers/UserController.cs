using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestProject.Application.Commands.User.Request;
using TestProject.Application.Commands.User.Response;

namespace TestProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}