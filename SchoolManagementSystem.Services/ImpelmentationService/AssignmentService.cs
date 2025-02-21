using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class AssignmentService : IAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public AssignmentService(IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            await _validationService.ValidateCoursesExistsAsync(assignment.CourseID);
            await _unitOfWork.Assignments.AddAsync(assignment);
            await _unitOfWork.CompleteAsync();
        }

        //public async Task DeleteAssignmentAsync(int assignmentId)
        //{
        //    await _validationService.ValidateAssignmentExistsAsync(assignmentId);
        //    await _unitOfWork.Assignments.DeleteByIdAsync(assignmentId);
        //    await _unitOfWork.CompleteAsync();
        //}
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

        public async Task<Assignment> GetAssignmentByIdAsync(int assignmentId)
        {
            //   await _validationService.ValidateAssignmentExistsAsync(assignmentId); no need the result will be  2 calls on DB
            return await _unitOfWork.Assignments.GetByIdAsync(assignmentId);
        }

        public async Task<List<Assignment>> GetAssignmentsByCourseIdAsync(int courseId)
        {
            await _validationService.ValidateCoursesExistsAsync(courseId);
            return await _unitOfWork.Assignments.GetAssignmentsByCourseIdAsync(courseId);
        }

        public async Task<bool> UpdateAssignmentAsync(Assignment assignment)
        {
            await _validationService.ValidateAssignmentExistsAsync(assignment.AssignmentID);
            await _validationService.ValidateCoursesExistsAsync(assignment.CourseID);

            await _unitOfWork.Assignments.UpdateAsync(assignment);
            await _unitOfWork.CompleteAsync();

            return true;
        }



    }
}
