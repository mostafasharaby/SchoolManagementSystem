using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task AddCourseAsync(Course course)
        {
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

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _unitOfWork.Courses.GetByIdAsync(courseId);
        }

        public async Task<List<Course>> GetCoursesByDepartmentAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            var attendanceExists = await _unitOfWork.Courses.GetByIdAsync(course.CourseID);

            if (attendanceExists == null)
            {
                throw new KeyNotFoundException("Borrowed Book not found.");
            }

            var departmentExists = await _unitOfWork.Departments.GetByIdAsync(course.DepartmentID);
            if (departmentExists == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }

            //var classRoomExists = await _unitOfWork.Classrooms.GetByIdAsync(attendance.CourseID);
            //if (classRoomExists == null)
            //{
            //    throw new KeyNotFoundException("Classroom not found.");
            //}

            await _unitOfWork.Courses.UpdateAsync(course);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
