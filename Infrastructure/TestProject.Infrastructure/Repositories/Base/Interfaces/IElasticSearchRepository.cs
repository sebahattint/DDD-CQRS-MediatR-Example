using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Infrastructure.Repositories.Base.Interfaces
{
    public interface IElasticSearchRepository<TEntity> where TEntity : class
    {
        Task<bool> ChekIndex(string indexName);
        Task InsertOrUpdateDocument(string indexName, TEntity entity);
        Task InsertDocuments(string indexName, List<TEntity> entity);
        Task<TEntity> GetDocument(string indexName, Guid id);
        Task<List<TEntity>> GetDocuments(string indexName);
        Task RemoveDocument(string indexName, Guid id);
    }
}
