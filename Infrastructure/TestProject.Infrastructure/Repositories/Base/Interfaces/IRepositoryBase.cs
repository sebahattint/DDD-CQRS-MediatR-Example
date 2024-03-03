using System.Linq.Expressions;

namespace TestProject.Infrastructure.Repositories.Base.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddCollectionAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateCollection(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        Task<bool> SaveChangesAsync();
        IQueryable<TEntity> GetList();
        IQueryable<TEntity> GetList(bool asNoTracking = true);
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> where, bool asNoTracking = true);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, bool asNoTracking = true);
        Task<Tuple<IEnumerable<TEntity>, int>> GetListAsync(int skip, int take, Expression<Func<TEntity, bool>> where, bool asNoTracking = true);
    }
}
