using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public TeacherService(IUnitOfWork unitOfWork, SchoolContext context, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }

        public async Task<bool> AddTeacherAsync(Teacher teacher)
        {
            await _validationService.ValidateDepartmentExistsAsync(teacher.DepartmentID);
            await _unitOfWork.Teachers.AddAsync(teacher);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteTeacherAsync(string teacherID)
        {
            var deletedStudent = await _unitOfWork.Teachers.DeleteByIdStringAsync(teacherID);
            if (deletedStudent)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<Teacher> GetTeachersByIdAsync(string teacherID)
        {
            return await _unitOfWork.Teachers.GetByIdStringAsync(teacherID);
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
            return await _unitOfWork.Teachers.GetAllAsync();
        }

        public async Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId)
        {
            await _validationService.ValidateDepartmentExistsAsync(departmentId);
            return await _unitOfWork.Teachers.GetTeachersByDepartmentAsync(departmentId);
        }

        public async Task<bool> UpdateTeacherAsync(Teacher teacher)
        {
            await _validationService.ValidateDepartmentExistsAsync(teacher.DepartmentID);
            await _unitOfWork.Teachers.UpdateAsync(teacher);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<List<Course>> GetCoursesByTeacherAsync(string teacherId)
        {
            await _validationService.ValidateTeacherExistsAsync(teacherId);
            return await _unitOfWork.Teachers.GetCoursesByTeacherAsync(teacherId); ;
        }

        public async Task<List<Classroom>> GetClassroomsByTeacherAsync(string teacherId)
        {
            await _validationService.ValidateTeacherExistsAsync(teacherId);
            return await _unitOfWork.Teachers.GetClassroomsByTeacherAsync(teacherId); ;
        }

        public async Task AddAssignmentToCourseAsync(string teacherId, int courseId, string assignmentName, DateTime dueDate)
        {
            await CheckForTeacherAndCourse(teacherId, courseId);
            await _unitOfWork.Teachers.AddAssignmentToCourseAsync(teacherId, courseId, assignmentName, dueDate);
        }

        public async Task<List<ExamResult>> GetExamResultsByCourseAsync(string teacherId, int courseId)
        {
            await CheckForTeacherAndCourse(teacherId, courseId);
            return await _unitOfWork.Teachers.GetExamResultsByCourseAsync(teacherId, courseId);
        }

        public async Task<List<Student>> GetStudentsInClassroomAsync(string teacherId, int classroomId)
        {
            await _validationService.ValidateTeacherExistsAsync(teacherId);
            await _validationService.ValidateClassRoomExistsAsync(classroomId);

            return await _unitOfWork.Teachers.GetStudentsInClassroomAsync(teacherId, classroomId);
        }

        public async Task CheckForTeacherAndCourse(string teacherId, int courseId)
        {
            await _validationService.ValidateTeacherExistsAsync(teacherId);
            await _validationService.ValidateCoursesExistsAsync(courseId);
        }
    }
}
