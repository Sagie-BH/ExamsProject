using Domain.Entities.ObjectEntities;
using Infrastructure.Persistence;

namespace Application.Exams.Repositories
{
    public class AppExamRepository : GenericRepository<AppExam>
    {
        public AppExamRepository(ExamPrjDbContext context) : base(context) { }
    }

}
