using Application.Common;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;


namespace Application.Relational.Repositories
{
    public class StudentExamsRepository : EfRepository<StudentExams>, IStudentExamsRepository
    {
        public StudentExamsRepository(ExamPrjDbContext context) : base(context) { }
    }
}
