using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;

namespace SchoolManagementSystem.Infrastructure.RepositoryImpelementation
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SchoolContext context) : base(context)
        {
        }

        public async Task<List<Course>> GetCoursesByTeacherAsync(string teacherId)
        {
            return await _dbContext.TeacherCourses
                .Where(tc => tc.TeacherID == teacherId)
                .Select(tc => tc.Course)
                .ToListAsync();
        }

        public async Task<List<Classroom>> GetClassroomsByTeacherAsync(string teacherId)
        {
            return await _dbContext.Classrooms
                .Where(c => c.TeacherID == teacherId)
                .ToListAsync();
        }

        public async Task<List<Student>> GetStudentsInClassroomAsync(string teacherId, int classroomId)
        {
            return await _dbContext.Classrooms
                .Where(cs => cs.ClassroomID == classroomId && cs.TeacherID == teacherId)
                .SelectMany(cs => cs.Students)
                .ToListAsync();
        }

        public async Task AddAssignmentToCourseAsync(string teacherId, int courseId, string assignmentName, DateTime dueDate)
        {
            var course = await _dbContext.Courses
                    .Include(c => c.TeacherCourses)
                    .FirstOrDefaultAsync(c => c.CourseID == courseId && c.TeacherCourses.Any(tc => tc.TeacherID == teacherId));

            if (course == null)
            {
                throw new KeyNotFoundException("Course not found or teacher is not assigned to this course.");
            }

            var assignment = new Assignment
            {
                CourseID = courseId,
                AssignmentName = assignmentName,
                DueDate = dueDate
            };

            await _dbContext.Assignments.AddAsync(assignment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ExamResult>> GetExamResultsByCourseAsync(string teacherId, int courseId)
        {
            return await _dbContext.ExamResults
                .Where(er => er.Exam.CourseID == courseId && er.Exam.Course.TeacherCourses.Any(i => i.TeacherID == teacherId))
                .ToListAsync();
        }

        public async Task<List<Teacher>> GetTeachersByDepartmentAsync(int departmentId)
        {
            return await _dbContext.Teachers.Where(i => i.DepartmentID == departmentId).ToListAsync(); ;
        }
    }
}
