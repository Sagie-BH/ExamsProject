using Application.Common;
using Domain.Entities.Relational;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;


namespace Application.Relational.Repositories
{
    public class ClassRoomRepository : EfRepository<ClassRoom>, IClassRoomRepository
    {
        public ClassRoomRepository(ExamPrjDbContext context) : base(context) { }
    }
}
