using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;
namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetAllStudentsAsync();
        //IQueryable<Student> GetAllStudentsAsyncQueryable();
        //Task<Student> GetStudentByIdAsync(int studentId);
        //Task AddStudentAsync(Student student);
        //Task<Student> UpdateStudentAsync(Student student);
        //Task<bool> DeleteStudentAsync(int studentId);
    }
}
