﻿using Domain.Entities;
using Domain.Entities.ObjectEntities;
using Domain.Entities.Relational;
using Domain.Entities.UserEntities;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IAppExamRepository : IRepository<AppExam> { }
    public interface IQuestionObjectRepository : IRepository<QuestionObject> { }
    public interface ISubjectRepository : IRepository<Subject> { }
    public interface IClassRoomRepository : IRepository<ClassRoom> { }
    public interface IStudentExamsRepository : IRepository<StudentExams> { }
    public interface IStudentRepository : IRepository<Student> { }
    public interface ITeacherRepository : IRepository<Teacher> { }
    public interface INotificationsRepository : IRepository<UserNotification> { }
}