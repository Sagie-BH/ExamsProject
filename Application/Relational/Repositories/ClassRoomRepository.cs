using Application.Common;
using Domain.Entities.Relational;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;


namespace Application.Relational.Repositories
{
    public class ClassRoomRepository : Repository<ClassRoom>, IClassRoomRepository
    {
        public ClassRoomRepository(ExamsAppDbContext context) : base(context) { }
    }
}
