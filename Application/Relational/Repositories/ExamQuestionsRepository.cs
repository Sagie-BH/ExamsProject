using Domain.Entities.Relational;
using Infrastructure.Persistence;

namespace Application.Relational.Repositories
{
    public class ExamQuestionsRepository : GenericRepository<ExamQuestions>
    {
        public ExamQuestionsRepository(ExamPrjDbContext context) : base(context) { }
    }
}
