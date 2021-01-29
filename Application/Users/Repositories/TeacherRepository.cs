using Domain.Entities.UserEntities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>
    {
        public TeacherRepository(ExamPrjDbContext context) : base(context) { }
    }
}
