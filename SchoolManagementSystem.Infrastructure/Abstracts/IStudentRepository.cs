using SchoolManagementSystem.Data;
using SchoolManagementSystem.Infrastructure.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SchoolManagementSystem.Infrastructure.Repositories
{
    //public interface IStudentRepository
    //{
    //   
    //}

    public interface IStudentRepository:IGenericRepository<Student>
    {
         Task<List<Student>> GetAllStudentsAsync();
        //Task<Student> GetStudentByIdAsync(int studentId);
        //Task AddStudentAsync(Student student);
        //Task<Student> UpdateStudentAsync(Student student);
        //Task<bool> DeleteStudentAsync(int studentId);
    }
}
