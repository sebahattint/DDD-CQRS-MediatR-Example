using Microsoft.EntityFrameworkCore;
using TestProject.Infrastructure.Context;
using TestProject.Infrastructure.Repositories.Base.Concrete;

namespace TestProject.Infrastructure.Repositories.User
{
    public class UserRepository : RepositoryBase<TestProject.Domain.Entities.User>, IUserRepository
    {
        public UserRepository(TestProjectDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TestProject.Domain.Entities.User>> GetListAsync()
        {
            return await base.GetList().OrderBy(c => c.Name).ToListAsync();
        }
    }
}
