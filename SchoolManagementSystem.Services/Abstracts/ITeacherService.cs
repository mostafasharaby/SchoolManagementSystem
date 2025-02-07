using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface ITeacherService
    {
        public Task<List<Teacher>> GetTeachersAsync();
        public Task<Teacher> GetTeacherAsyncByID(int teacherID);
        Task<Teacher> UpdateTeacherAsync(Teacher teacher);
        Task<bool> DeleteTeacherAsync(int teacherID);
    }
}
