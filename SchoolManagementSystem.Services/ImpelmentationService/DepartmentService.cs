using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task AddDepartmentAsync(Department department)
        {
            await _unitOfWork.Departments.AddAsync(department);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            var attendanceExists = await _unitOfWork.Departments.GetByIdAsync(department.DepartmentID);

            if (attendanceExists == null)
            {
                throw new KeyNotFoundException("Borrowed Book not found.");
            }

            //var studentExists = await _unitOfWork.Students.GetByIdAsync(department.DepartmentID);
            //if (studentExists == null)
            //{
            //    throw new KeyNotFoundException("Student not found.");
            //}

            //var classRoomExists = await _unitOfWork.Classrooms.GetByIdAsync(attendance.DepartmentID);
            //if (classRoomExists == null)
            //{
            //    throw new KeyNotFoundException("Classroom not found.");
            //}

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
    }
}
