using Domain.Entities;
using Infrastructure.Persistence;

namespace Application.Relational.Repositories
{
    public class StudentExamsRepository : GenericRepository<StudentExams>
    {
        public StudentExamsRepository(ExamPrjDbContext context) : base(context) { }
    }

}
