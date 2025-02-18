using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            await _unitOfWork.Enrollments.AddAsync(enrollment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteEnrollmentAsync(int enrollmentID)
        {
            var check = await _unitOfWork.Enrollments.DeleteByIdAsync(enrollmentID);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _unitOfWork.Enrollments.GetAllAsync();
        }

        public async Task<Enrollment?> GetEnrollmentByIdAsync(int enrollmentID)
        {
            return await _unitOfWork.Enrollments.GetByIdAsync(enrollmentID);
        }

        public async Task<bool> UpdateEnrollmentAsync(Enrollment enrollment)
        {
            var enrollmentExists = await _unitOfWork.Enrollments.GetByIdAsync(enrollment.EnrollmentID);

            if (enrollmentExists == null)
            {
                throw new KeyNotFoundException("Borrowed Book not found.");
            }

            var studentExists = await _unitOfWork.Students.GetByIdAsync(enrollment.StudentID);
            if (studentExists == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }

            var courseExists = await _unitOfWork.Courses.GetByIdAsync(enrollment.CourseID);
            if (courseExists == null)
            {
                throw new KeyNotFoundException("course not found.");
            }


            await _unitOfWork.Enrollments.UpdateAsync(enrollment);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
