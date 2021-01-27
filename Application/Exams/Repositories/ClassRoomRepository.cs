using Domain.Entities.ObjectEntities;
using Domain.Entities.Relational;
using Infrastructure.Persistence;

namespace Application.Exams.Repositories
{
    public class ClassRoomRepository : EfRepository<ClassRoom>
    {
        public ClassRoomRepository(ExamPrjDbContext context) : base(context) { }
    }

}
