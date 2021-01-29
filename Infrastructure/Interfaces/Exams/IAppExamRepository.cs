using Domain.Entities.ObjectEntities;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Exams
{
    public interface IAppExamRepository : IExamObjectRepository<AppExam>
    {
        //Task<bool> IsTitleUnique();
    }

}
