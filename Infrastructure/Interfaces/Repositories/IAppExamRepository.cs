using Domain.Entities.ObjectEntities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IAppExamRepository : IRepository<AppExam> 
    {
        /// <summary>
        /// Gets Exam with all inputs & Questions & Answer Options..
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AppExam> GetFullExamByIdAsync(long id);



        /// <summary>
        /// Create new exam entity in database
        /// </summary>
        /// <returns>Returns saved entity. Returns null if fails</returns>
        //Task<AppExam> CreateNewExamAsync();
    }
}
