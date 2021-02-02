using Ardalis.EFCore.Extensions;
using Domain.Entities;
using Domain.Entities.ObjectEntities;
using Domain.Entities.Relational;
using Domain.Entities.UserEntities;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.Persistence.Configuration;
using Infrastructure.Persistence.Configuration.AppObjects;
using Infrastructure.Persistence.Configuration.AppUsers;
using Infrastructure.Persistence.Configuration.Relational;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.Persistence
{
    public class ExamsAppDbContext : IdentityDbContext
    {

        public ExamsAppDbContext(DbContextOptions<ExamsAppDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppExam> Exams { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<QuestionObject> Questions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<FinishedExams> FinishedExams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

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
