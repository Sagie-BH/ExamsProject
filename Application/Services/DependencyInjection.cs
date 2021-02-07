using Application.Common;
using Application.Interfaces;
using Application.Repositories;
using Infrastructure.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Services
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAppExamRepository, AppExamRepository>();
            services.AddScoped<IQuestionObjectRepository, QuestionObjectRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            services.AddScoped<IFinishedExamsRepository, FinishedExamsRepository>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<ITeacherService, TeacherService>();

            services.AddScoped<ISignInService, SignInService>();
        }

    }
}
