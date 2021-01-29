using Domain.Entities.Relational;
using Infrastructure.Persistence;

namespace Application.Relational.Repositories
{
    public class ClassRoomRepository : GenericRepository<ClassRoom>
    {
        public ClassRoomRepository(ExamPrjDbContext context) : base(context) { }
    }
}
