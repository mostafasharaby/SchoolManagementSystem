using SchoolManagementSystem.Data;
using SchoolManagementSystem.Infrastructure.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public interface ITeacherRepository :IGenericRepository<Teacher>
    {
        //Task<List<Teacher>> GetAllTeachersAsync();
        //Task<Teacher> GetTeacherByIdAsync(int teacherId);
        //Task AddTeacherAsync(Teacher teacher);
        //Task<Teacher> UpdateTeacherAsync(Teacher teacher);
        //Task<bool> DeleteTeacherAsync(int teacherId);
    }
}
