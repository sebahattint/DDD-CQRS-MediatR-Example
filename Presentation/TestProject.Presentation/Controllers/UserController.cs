using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestProject.Application.Commands.User.Request;

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
        public IActionResult Create([FromBody] CreateUserCommandRequest request)
        {
            return Ok(mediator.Send(request));
        }
    }
}
