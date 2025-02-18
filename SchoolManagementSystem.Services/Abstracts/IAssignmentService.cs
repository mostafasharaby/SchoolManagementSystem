using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IAssignmentService
    {
        Task AddAssignmentAsync(Assignment assignment);
        Task<bool> UpdateAssignmentAsync(Assignment assignment);
        Task<bool> DeleteAssignmentAsync(int assignmentId);
        Task<Assignment?> GetAssignmentByIdAsync(int assignmentId);
        Task<List<Assignment>> GetAllAssignmentsAsync();
        Task<List<Assignment>> GetAssignmentsByCourseIdAsync(int courseId);
    }
}
