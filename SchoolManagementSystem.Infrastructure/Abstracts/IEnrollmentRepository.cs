using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IEnrollmentRepository : IGenericRepository<Enrollment>
    {

        Task<List<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId);
    }
}
