using Domain.Entities.ObjectEntities;
using Infrastructure.Persistence;

namespace Application.Exams.Repositories
{
    public class QuestionObjectRepository : GenericRepository<QuestionObject>
    {
        public QuestionObjectRepository(ExamPrjDbContext context) : base(context) { }
    }

}
