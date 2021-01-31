using Application.Common;
using Domain.Entities.UserEntities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Repositories
{
    public class StudentRepository : EfRepository<Student>, IStudentRepository
    {
        public StudentRepository(ExamPrjDbContext context) : base(context) { }
    }
}
