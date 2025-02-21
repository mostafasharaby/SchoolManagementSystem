using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public DepartmentService(IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }
        public async Task AddDepartmentAsync(Department department)
        {
            await _unitOfWork.Departments.AddAsync(department);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            await _validationService.ValidateDepartmentExistsAsync(department.DepartmentID);
            await _validationService.ValidateTeacherExistsAsync(department.Teachers!.FirstOrDefault()!.TeacherID);
            await _validationService.ValidateCoursesExistsAsync(department.Courses!.FirstOrDefault()!.CourseID);

            await _unitOfWork.Departments.UpdateAsync(department);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> DeleteDepartmentAsync(int departmentId)
        {
            var check = await _unitOfWork.Departments.DeleteByIdAsync(departmentId);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            return await _unitOfWork.Departments.GetByIdAsync(departmentId);
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _unitOfWork.Departments.GetAllAsync();
        }

        public async Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId)
        {
            await _validationService.ValidateDepartmentExistsAsync(departmentId);
            return await _unitOfWork.Departments.GetTeachersByDepartmentAsync(departmentId);
        }

        public async Task<List<Course>> GetCoursesByDepartmentAsync(int departmentId)
        {
            await _validationService.ValidateDepartmentExistsAsync(departmentId);
            return await _unitOfWork.Departments.GetCoursesByDepartmentAsync(departmentId);
        }
    }
}
