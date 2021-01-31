using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.ObjectEntities;

namespace Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConnection(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ExamPrjDbContext>(options =>
                options.UseSqlServer(
                         configuration.GetConnectionString("ExamDbConnection"),
                         b => b.MigrationsAssembly(typeof(ExamPrjDbContext).Assembly.FullName)));

            return services;
        }
    }
}
