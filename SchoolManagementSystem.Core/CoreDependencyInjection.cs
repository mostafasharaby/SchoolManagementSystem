using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Behavoir;
using SchoolManagementSystem.Core.Filter;
using SchoolManagementSystem.Core.Helpers;
using System.Reflection;
namespace SchoolManagementSystem.Core
{
    public static class CoreDependencyInjection
    {
        public static void AddCoreDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());// Without this, you would need to manually register each validator services.AddTransient<IValidator<AddStudentCommandWithResponse>, AddStudentValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient<IUserRegistrationHelper, UserRegistrationHelper>();
            services.AddTransient<ResponseHandler>(); // 
            services.AddScoped<AuthFilter>();


        }

    }
}
