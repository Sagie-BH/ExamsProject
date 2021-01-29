using Domain.Entities.ObjectEntities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Exams
{
    public interface IQuestionObjectRepository : IGenericRepository<QuestionObject> 
    {
        Task<bool> IsQuestionUnique(QuestionObject question);
    }
}
