
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Services.Abstracts;
using SchoolManagementSystem.Services.ImpelmentationService;
using SchoolManagementSystem.Services.ImplementationService;

namespace SchoolManagementSystem.Services
{
    public static class ServiceDependencyInjection
    {

        public static void AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IClassRoomService, ClassRoomService>();
            services.AddScoped<IClassRoomService, ClassRoomService>();
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IBorrowedBookService, BorrowedBookService>();
            services.AddScoped<ILibraryService, LibraryService>();
            services.AddScoped<IFeeService, FeeService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IAssignmentService, AssignmentService>();

        }
    }
}
