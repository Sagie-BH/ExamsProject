using Domain.Entities.UserEntities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Repositories
{
    public class StudentRepository : EfRepository<Student>
    {
        public StudentRepository(ExamPrjDbContext context) : base (context) { }
    }
}
