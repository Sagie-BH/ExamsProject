using Application.Common;
using Domain.Entities.UserEntities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Application.Users.Repositories
{
    public class TeacherRepository : EfRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ExamPrjDbContext context) : base(context) { }
    }
}
