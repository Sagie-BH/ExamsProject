using Application.Common;
using Domain.Entities.ObjectEntities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Application.Exams.Repositories
{
    public class QuestionObjectRepository : EfRepository<QuestionObject>, IQuestionObjectRepository
    {
        public QuestionObjectRepository(ExamPrjDbContext context) : base(context) { }
    }
}
