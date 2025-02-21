using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public CourseService(IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }
        public async Task AddCourseAsync(Course course)
        {
            await _validationService.ValidateDepartmentExistsAsync(course.DepartmentID);

            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            var check = await _unitOfWork.Courses.DeleteByIdAsync(courseId);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _unitOfWork.Courses.GetAllAsync();
        }

        public async Task<List<Assignment>> GetAssignmentsForCourseAsync(int courseId)
        {
            await _validationService.ValidateCoursesExistsAsync(courseId);
            return await _unitOfWork.Courses.GetAssignmentsForCourseAsync(courseId);
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            await _validationService.ValidateCoursesExistsAsync(courseId);
            return await _unitOfWork.Courses.GetByIdAsync(courseId);
        }

        public async Task<List<Course>> GetCoursesByDepartmentAsync(int departmentId)
        {
            return await _unitOfWork.Courses.GetCoursesByDepartmentAsync(departmentId);
        }

        public async Task<List<Exam>> GetExamsForCourseAsync(int courseId)
        {
            await _validationService.ValidateCoursesExistsAsync(courseId);
            return await _unitOfWork.Courses.GetExamsForCourseAsync(courseId);
        }

        public async Task<List<Student>> GetStudentsInCourseAsync(int courseId)
        {
            await _validationService.ValidateCoursesExistsAsync(courseId);
            return await _unitOfWork.Courses.GetStudentsInCourseAsync(courseId);
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            await _validationService.ValidateCoursesExistsAsync(course.CourseID);
            await _validationService.ValidateDepartmentExistsAsync(course.DepartmentID);

            await _unitOfWork.Courses.UpdateAsync(course);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
