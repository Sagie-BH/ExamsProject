using Domain.Entities.ObjectEntities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IExamObjectRepository<TEntity> : IGenericRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task<bool> IsTitleUnique(string title);

        Task<TEntity> GetBySubject(Subject subject);

        Task<TEntity> GetByTitle(string title);
        

    }
}

