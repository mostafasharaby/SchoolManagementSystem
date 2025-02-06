using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentAsync();
        public Task<Student> GetStudentAsyncByID(int studentID);
        Task<Student> AddStudentAsync(Student student);
        Task<Student>UpdateStudentAsync(Student student);
         Task<bool> DeleteStudentAsync(int studentID);


    }
}
