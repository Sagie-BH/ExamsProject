using Domain.Entities.Relational;
using Infrastructure.Persistence;

namespace Application.Exams.Repositories
{
    public class ExamQuestionsRepository : EfRepository<ExamQuestions>
    {
        public ExamQuestionsRepository(ExamPrjDbContext context) : base(context) { }
    }
}
