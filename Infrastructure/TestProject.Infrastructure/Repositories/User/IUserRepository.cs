using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Entities;
using TestProject.Infrastructure.Repositories.Base.Interfaces;

namespace TestProject.Infrastructure.Repositories.User
{
    public interface IUserRepository: IRepositoryBase<Domain.Entities.User>
    {
        Task<IEnumerable<TestProject.Domain.Entities.User>> GetListAsync();
    }
}
