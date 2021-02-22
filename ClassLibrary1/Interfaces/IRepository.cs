using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        // Todo Change void Tasks!
        /// <summary>
        /// Adding entity to database async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entity Id if succeeded. Return 0 if fails</returns>
        Task<long> AddAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        /// <summary>
        /// Edit entity async 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns>Return number of changes made to database</returns>
        Task<int> EditAsync(TEntity entity, long id);
        IQueryable<TEntity> GetAllAsync();
        /// <summary>
        /// Gets the entity without join tables - no including
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(long id);
        int GetCount();

        //Task<List<T>> ListAsync<T>(ISpecification<T> spec)

        //Task AddRangeAsync(IQueryable<TEntity> entities);

        //void RemoveRange(IQueryable<TEntity> entities);

        //IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        //TEntity Find(params object[] keys);

        //TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        //bool Any(Expression<Func<TEntity, bool>> predicate);

    }
}
