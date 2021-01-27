using Domain.Entities.ObjectEntities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Exams
{
    public interface IAppExamRepository : IGenericRepository<AppExam>
    {
        Task<AppExam> GetExamsBySubject();

    }
}
