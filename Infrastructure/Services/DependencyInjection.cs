using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ExamsAppDbContext>(options =>
                options.UseSqlServer(
                         configuration.GetConnectionString("ExamDbConnection"),
                         b => b.MigrationsAssembly(typeof(ExamsAppDbContext).Assembly.FullName)));

            return services;
        }
    }
}
