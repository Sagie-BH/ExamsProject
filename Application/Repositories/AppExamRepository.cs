using Application.Common;
using Domain.Entities.ObjectEntities;
using Domain.Models;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class AppExamRepository : Repository<AppExam>, IAppExamRepository
    {
        public AppExamRepository(ExamsAppDbContext context) : base(context) { }

        public async Task<AppExam> GetFullExamByIdAsync(long id)
        {
            return await Entities
                .Include(a => a.ExamImages)
                .Include(a => a.ExamSubject)
                .Include(a => a.ExamText)
                .Include(a => a.Questions).ThenInclude(q => q.QuestionText)
                .Include(a => a.Questions).ThenInclude(q => q.QuestionSubject)
                .Include(a => a.Questions).ThenInclude(q => q.AnswerOptions)
                .FirstOrDefaultAsync(a => a.Id == id);
        }


        //public async Task<AppExam> CreateNewExamAsync()
        //{

        //    var entity = new AppExam();

        //    try
        //    {
        //        await Entities.AddAsync(entity);
        //        if (await context.SaveChangesAsync() > 0)
        //        {
        //            return await Entities.FindAsync(GetKey(entity));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RepositoryExceptions.Add(new Exception($"{nameof(entity)} could not be created: {ex.Message}"));
        //    }
        //    return null;
        //}
    }
}
