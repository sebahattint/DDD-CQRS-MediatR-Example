using MediatR;
using TestProject.Application.Commands.User.Response;

namespace TestProject.Application.Commands.User.Request
{
    public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
    {
    }
}
