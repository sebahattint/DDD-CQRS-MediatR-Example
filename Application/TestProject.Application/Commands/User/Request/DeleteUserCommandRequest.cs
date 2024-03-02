using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Commands.User.Response;

namespace TestProject.Application.Commands.User.Request
{
    public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
    {
    }
}
