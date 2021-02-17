using Application.Common;
using Domain.Entities.ObjectEntities;
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

        /// <summary>
        /// Gets Exam with all inputs & Questions & Answer Options..
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AppExam> GetFullExamByIdAsync(long id)
        {
            return await Entities
                .Include(a => a.ExamImages)
                .Include(a => a.ExamSubject)
                .Include(a => a.ExamText)
                .Include(a => a.Questions).ThenInclude(q => q.QuestionText)
                .Include(a => a.Questions).ThenInclude(q => q.QuestionTimeLimit)
                .Include(a => a.Questions).ThenInclude(q => q.QuestionSubject).ThenInclude(s => s.Title)
                .Include(a => a.Questions).ThenInclude(q => q.QuestionSubject).ThenInclude(s => s.Description)
                .Include(a => a.Questions).ThenInclude(q => q.AnswerOptions).ThenInclude(a => a.IsRightAnswer)
                .Include(a => a.Questions).ThenInclude(q => q.AnswerOptions).ThenInclude(a => a.AnswerText)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
