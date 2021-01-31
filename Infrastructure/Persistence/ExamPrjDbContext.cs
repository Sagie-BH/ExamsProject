using Ardalis.EFCore.Extensions;
using Domain.Entities;
using Domain.Entities.ObjectEntities;
using Domain.Entities.Relational;
using Domain.Entities.UserEntities;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Persistence.Configuration;
using Infrastructure.Persistence.Configuration.AppObjects;
using Infrastructure.Persistence.Configuration.AppUsers;
using Infrastructure.Persistence.Configuration.Relational;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure.Persistence
{
    public class ExamPrjDbContext : IdentityDbContext
    {

        private readonly IMediator _mediator;

        public ExamPrjDbContext(DbContextOptions<ExamPrjDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }
        public DbSet<AppExam> Exams { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<QuestionObject> Questions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentExams> StudentExams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ExamQuestions> ExamQuestions { get; set; }
        public DbSet<UserNotification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppExamConfiguration());
            builder.ApplyConfiguration(new TeacherConfiguration());
            builder.ApplyConfiguration(new StudentExamsConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new ExamQuestionsConfiguration());
        }
    }
}
