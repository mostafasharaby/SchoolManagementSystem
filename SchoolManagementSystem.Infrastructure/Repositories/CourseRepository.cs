﻿using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async override Task<Course> GetByIdAsync(int id)
        {
            return await _dbContext.Courses.AsNoTracking()
          .FirstOrDefaultAsync(b => b.CourseID == id);

        }

        public async Task<List<Student>> GetStudentsInCourseAsync(int courseId)
        {
            return await _dbContext.Courses
                .Where(cs => cs.CourseID == courseId)
                .SelectMany(i => i.Enrollments)
                .Select(o => o.Student)
                .ToListAsync();
        }

        public async Task<List<Assignment>> GetAssignmentsForCourseAsync(int courseId)
        {
            return await _dbContext.Assignments
                .Where(a => a.CourseID == courseId)
                .ToListAsync();
        }

        public async Task<List<Exam>> GetExamsForCourseAsync(int courseId)
        {
            return await _dbContext.Exams
                .Where(e => e.CourseID == courseId)
                .ToListAsync();
        }

        public async Task<List<Course>> GetCoursesByDepartmentAsync(int departmentId)
        {
            return await _dbContext.Courses.Where(e => e.DepartmentID == departmentId).ToListAsync();
        }
    }
}
