using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        // Todo Change void Tasks!

        Task AddAsync(TEntity entity);
        Task EditAsync(TEntity entity, object key);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(long id);
        IQueryable<TEntity> GetAllAsync();

        //Task<List<T>> ListAsync<T>(ISpecification<T> spec)

        //Task AddRangeAsync(IQueryable<TEntity> entities);

        //void RemoveRange(IQueryable<TEntity> entities);

        //IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        //TEntity Find(params object[] keys);

        //TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        //bool Any(Expression<Func<TEntity, bool>> predicate);

    }
}
