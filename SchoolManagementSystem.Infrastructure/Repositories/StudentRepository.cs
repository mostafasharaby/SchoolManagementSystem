using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Infrastructure.Basics;
namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context):base(context) 
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.Include(st => st.Parent)
                                          .Include(st => st.Classroom)
                                            .ThenInclude(t => t.Teacher)
                                          .ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await GetByIdAsync(studentId);
        }
        public async Task<Student> GetStudentByNameAsync(string name)
        {
            return await GetByNameAsync(name);
        }
        public async Task AddStudentAsync(Student student)
        {          
            await AddAsync(student);           
        }


        public async Task<Student> UpdateStudentAsync(Student student)
        {
           await UpdateAsync(student);
            return student;
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var student = await GetByIdAsync(studentId);
            if (student != null)
            {               
                await DeleteAsync(student);
                return true;
            }
            return false;
        }
 
    }
}
