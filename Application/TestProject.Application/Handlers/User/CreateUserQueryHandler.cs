using MediatR;
using TestProject.Application.Commands.User.Request;
using TestProject.Application.Commands.User.Response;
using TestProject.Infrastructure.Repositories.Base.Interfaces;
using TestProject.Infrastructure.Repositories.User;

namespace TestProject.Application.Handlers.User
{
    public class CreateUserQueryHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IElasticSearchRepository<Domain.Entities.User> elastichSearchRepository;

        public CreateUserQueryHandler(IUserRepository userRepository, IElasticSearchRepository<Domain.Entities.User> elastichSearchRepository)
        {
            this.userRepository = userRepository;
            this.elastichSearchRepository = elastichSearchRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User() { Id = Guid.NewGuid(), Name = request.Name };
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
            await elastichSearchRepository.InsertOrUpdateDocument("test_project_data", user);
            return new CreateUserCommandResponse() { Id = user.Id };
        }
    }
}
