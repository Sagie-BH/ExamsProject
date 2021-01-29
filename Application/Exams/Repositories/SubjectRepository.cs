using Domain.Entities.ObjectEntities;
using Infrastructure.Persistence;

namespace Application.Exams.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>
    {
        public SubjectRepository(ExamPrjDbContext context) : base(context) { }
    }

}
