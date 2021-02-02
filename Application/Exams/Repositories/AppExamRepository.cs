using Application.Common;
using Domain.Entities.ObjectEntities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exams.Repositories
{
    public class AppExamRepository : Repository<AppExam>, IAppExamRepository
    {
        public AppExamRepository(ExamsAppDbContext context) : base(context) { }
    }
}
