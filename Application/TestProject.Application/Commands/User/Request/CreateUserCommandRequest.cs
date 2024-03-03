using MediatR;
using TestProject.Application.Commands.User.Response;

namespace TestProject.Application.Commands.User.Request
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
