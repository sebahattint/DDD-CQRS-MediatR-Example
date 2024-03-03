using MediatR;

namespace TestProject.Application.Queries.User.Request
{
    public class GetUserListQueryRequest : IRequest<List<GetUserListQueryResponse>>
    {
    }
}
