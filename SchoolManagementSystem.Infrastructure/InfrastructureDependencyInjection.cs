using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;
using SchoolManagementSystem.Infrastructure.RepositoryImpelementation;


namespace SchoolManagementSystem.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {

        public static void AddInfrastructurefDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddDbContext<SchoolContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("connection"));
            });
        }
    }
}
