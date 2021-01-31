using Application.Common;
using Domain.Interfaces;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAppExamRepository Exams { get; }
        IQuestionObjectRepository Questions { get; }
        ISubjectRepository Subjects { get; }
        IClassRoomRepository ClassRooms { get; }
        IFinishedExamsRepository StudentExams { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        Task<int> SaveChangesAsync();
    }
}

