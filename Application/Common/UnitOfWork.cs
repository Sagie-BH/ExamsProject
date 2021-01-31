using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.ObjectEntities;
using Domain.Entities.Relational;
using Domain.Entities.UserEntities;
using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Application.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamPrjDbContext _context;
        private bool _disposed = false;
        private IDbContextTransaction _transaction = null;

        public IAppExamRepository Exams { get; private set; }
        public IQuestionObjectRepository Questions { get; private set; }
        public ISubjectRepository Subjects { get; private set; }
        public IClassRoomRepository ClassRooms { get; private set; }
        public IFinishedExamsRepository StudentExams { get; private set; }
        public IStudentRepository Students { get; private set; }
        public ITeacherRepository Teachers { get; private set; }

        public UnitOfWork(ExamPrjDbContext context,
            IAppExamRepository exams,
            IQuestionObjectRepository questions,
            ISubjectRepository subjects,
            IClassRoomRepository classRooms,
            IFinishedExamsRepository studentExams,
            IStudentRepository students,
            ITeacherRepository teachers)
        {
            _context = context;
            Exams = exams;
            Questions = questions;
            Subjects = subjects;
            ClassRooms = classRooms;
            StudentExams = studentExams;
            Students = students;
            Teachers = teachers;
            _transaction = _context.Database.BeginTransaction();
        }


        public Task<int> SaveChangesAsync()
        {
            Task<int> changes;
            try
            {
                changes = _context.SaveChangesAsync();
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction = _context.Database.BeginTransaction();
            }
            return changes;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)    //      !!!
            {
                if (disposing)
                {
                    _transaction.Dispose();
                    _context.Dispose();
                }
            }
            this._disposed = true;   //     !!!
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
