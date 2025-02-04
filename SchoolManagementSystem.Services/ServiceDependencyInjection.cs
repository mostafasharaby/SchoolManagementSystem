
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Services.Abstracts;
using SchoolManagementSystem.Services.ImpelmentationService;

namespace SchoolManagementSystem.Services
{
    public static class ServiceDependencyInjection
    {

        public static void AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
        }
    }
}
