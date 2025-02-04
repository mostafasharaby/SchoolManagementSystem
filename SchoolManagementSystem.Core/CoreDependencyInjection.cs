using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Services.Abstracts;
using System.Reflection;

namespace SchoolManagementSystem.Core
{
    public static class CoreDependencyInjection
    {
        public static void AddCoreDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

    }
}
