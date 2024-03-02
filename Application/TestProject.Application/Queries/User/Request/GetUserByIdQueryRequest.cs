using MediatR;
using TestProject.Application.Queries.User.Response;

namespace TestProject.Application.Queries.User.Request
{
    public class GetUserByIdQueryRequest : IRequest<GetUserByIdQueryResponse>
    {
    }
}
