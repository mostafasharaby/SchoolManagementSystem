using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class AssignmentService : IAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            await _unitOfWork.Assignments.AddAsync(assignment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteAssignmentAsync(int assignmentId)
        {
            var check = await _unitOfWork.Assignments.DeleteByIdAsync(assignmentId);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Assignment>> GetAllAssignmentsAsync()
        {
            return await _unitOfWork.Assignments.GetAllAsync();
        }

        public async Task<Assignment?> GetAssignmentByIdAsync(int assignmentId)
        {
            return await _unitOfWork.Assignments.GetByIdAsync(assignmentId);
        }

        public async Task<List<Assignment>> GetAssignmentsByCourseIdAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAssignmentAsync(Assignment assignment)
        {
            var attendanceExists = await _unitOfWork.Assignments.GetByIdAsync(assignment.AssignmentID);

            if (attendanceExists == null)
            {
                throw new KeyNotFoundException("Assignment  not found.");
            }

            var courseExists = await _unitOfWork.Students.GetByIdAsync(assignment.CourseID);
            if (courseExists == null)
            {
                throw new KeyNotFoundException("Course not found.");
            }

            await _unitOfWork.Assignments.UpdateAsync(assignment);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
