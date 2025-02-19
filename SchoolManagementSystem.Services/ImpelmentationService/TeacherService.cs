using AutoMapper;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        SchoolContext _dbContext;
        IMapper _mapper;
        public TeacherService(IUnitOfWork unitOfWork, SchoolContext context, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<bool> AddTeacherAsync(Teacher teacher)
        {
            var examExists = await _unitOfWork.Teachers.GetByIdAsync(teacher.TeacherID);
            if (examExists == null)
            {
                throw new KeyNotFoundException("teacher not found.");
            }

            var departmentExists = await _unitOfWork.Departments.GetByIdAsync(teacher.DepartmentID);
            if (departmentExists == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }

            //var departmentExists = await _unitOfWork.Departments.GetByIdAsync(teacher.DepartmentID);    // teacherType 
            //if (departmentExists == null)
            //{
            //    throw new KeyNotFoundException("Student not found.");
            //}

            await _unitOfWork.Teachers.AddAsync(teacher);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteTeacherAsync(int teacherID)
        {
            var deletedStudent = await _unitOfWork.Teachers.DeleteByIdAsync(teacherID);
            if (deletedStudent)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<Teacher> GetTeachersByIdAsync(int teacherID)
        {
            return await _unitOfWork.Teachers.GetByIdAsync(teacherID);
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
            return await _unitOfWork.Teachers.GetAllAsync();
        }

        public async Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId)
        {
            return await _unitOfWork.Teachers.GetTeachersByDepartmentAsync(departmentId);
        }

        public async Task<bool> UpdateTeacherAsync(Teacher teacher)
        {
            var attendanceExists = await _unitOfWork.Teachers.GetByIdAsync(teacher.TeacherID);

            if (attendanceExists == null)
            {
                throw new KeyNotFoundException("examResult  not found.");
            }

            var examExists = await _unitOfWork.Departments.GetByIdAsync(teacher.DepartmentID);
            if (examExists == null)
            {
                throw new KeyNotFoundException("Exam not found.");
            }

            //var studentExists = await _unitOfWork.Students.GetByIdAsync(ExamScore.StudentID);  // will be teacher type 
            //if (studentExists == null)
            //{
            //    throw new KeyNotFoundException("Student not found.");
            //}

            await _unitOfWork.Teachers.UpdateAsync(teacher);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<List<Course>> GetCoursesByTeacherAsync(int teacherId)
        {
            var result = await _unitOfWork.Teachers.GetCoursesByTeacherAsync(teacherId);
            // var response = _mapper.Map<List<CourseDto>>(result);
            return result;
        }

        public async Task<List<Classroom>> GetClassroomsByTeacherAsync(int teacherId)
        {
            var result = await _unitOfWork.Teachers.GetClassroomsByTeacherAsync(teacherId);
            //var response = _mapper.Map<List<ClassroomDto>>(result);
            return result;
        }

        public Task AddAssignmentToCourseAsync(int teacherId, int courseId, string assignmentName, DateTime dueDate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExamResult>> GetExamResultsByCourseAsync(int teacherId, int courseId)
        {
            var result = await _unitOfWork.Teachers.GetExamResultsByCourseAsync(teacherId, courseId);
            //   var response = _mapper.Map<List<ExamResultDto>>(result);
            return result;
        }

        public async Task<List<Student>> GetStudentsInClassroomAsync(int teacherId, int classroomId)
        {
            var result = await _unitOfWork.Teachers.GetStudentsInClassroomAsync(teacherId, classroomId);
            //var response = _mapper.Map<List<StudentDto>>(result);
            return result;
        }
    }
}
