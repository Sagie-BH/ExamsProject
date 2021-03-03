using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Services;
using Application.Services;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Persistence;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;

namespace ExamsWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSqlServer(Configuration);

            services.AddInfrastructure();

            services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequiredLength = 5;
                //config.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<ExamsAppDbContext>();


            services.AddMvc(opt =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();   // Use Authentication for the all website
                opt.Filters.Add(new AuthorizeFilter(policy));   // Adding new policy rule
            });

            services.AddControllers().AddNewtonsoftJson();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
