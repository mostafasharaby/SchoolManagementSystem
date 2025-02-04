using SchoolManagementSystem.Infrastructure;
using SchoolManagementSystem.Services;
using SchoolManagementSystem.Core;
namespace SchoolManagementSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddControllers();           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Dependency Injection
            builder.Services.AddInfrastructurefDependencyInjection(builder.Configuration);
            builder.Services.AddServiceDependencyInjection();
            builder.Services.AddCoreDependencyInjection();
            #endregion




            var app = builder.Build();
        
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
