using Domain.Entities.ObjectEntities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IAppExamRepository : IRepository<AppExam> 
    {
        Task<AppExam> GetFullExamByIdAsync(long id);
    }
}
