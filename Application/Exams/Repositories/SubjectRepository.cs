using Application.Common;
using Domain.Entities.ObjectEntities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Application.Exams.Repositories
{
    public class SubjectRepository : EfRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ExamPrjDbContext context) : base(context) { }
    }
}
