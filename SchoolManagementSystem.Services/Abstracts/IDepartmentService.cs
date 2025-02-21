using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IDepartmentService
    {
        Task AddDepartmentAsync(Department department);
        Task<bool> UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentAsync(int departmentId);
        Task<Department> GetDepartmentByIdAsync(int departmentId);
        Task<List<Department>> GetAllDepartmentsAsync();

        Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId);
        Task<List<Course>> GetCoursesByDepartmentAsync(int departmentId);
    }
}
