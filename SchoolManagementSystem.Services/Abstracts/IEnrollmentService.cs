using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IEnrollmentService
    {
        Task AddEnrollmentAsync(Enrollment enrollment);
        Task<bool> UpdateEnrollmentAsync(Enrollment enrollment);
        Task<bool> DeleteEnrollmentAsync(int enrollmentID);
        Task<Enrollment?> GetEnrollmentByIdAsync(int enrollmentID);
        Task<List<Enrollment>> GetAllEnrollmentsAsync();
    }
}
