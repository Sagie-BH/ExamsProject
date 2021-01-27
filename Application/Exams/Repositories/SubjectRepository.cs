using Domain.Entities.ObjectEntities;
using Infrastructure.Persistence;

namespace Application.Exams.Repositories
{
    public class SubjectRepository : EfRepository<Subject>
    {
        public SubjectRepository(ExamPrjDbContext context) : base(context) { }
    }

}
