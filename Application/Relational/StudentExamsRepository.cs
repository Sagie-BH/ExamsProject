using Domain.Entities;
using Infrastructure.Persistence;

namespace Application.Exams.Repositories
{
    public class StudentExamsRepository : EfRepository<StudentExams>
    {
        public StudentExamsRepository(ExamPrjDbContext context) : base(context) { }
    }

}
