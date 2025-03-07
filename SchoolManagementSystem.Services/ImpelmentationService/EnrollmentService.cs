using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly ICacheService _cacheService;

        public EnrollmentService(IUnitOfWork unitOfWork, IValidationService validationService, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _cacheService = cacheService;
        }
        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            await _validationService.ValidateStudentExistsAsync(enrollment.StudentID);
            await _validationService.ValidateCoursesExistsAsync(enrollment.CourseID);

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

        public async Task<List<Enrollment>> GetAllEnrollmentsAsync() =>
            await _cacheService.GetOrAddToCacheAsync("Enrollments", _unitOfWork.Enrollments.GetAllAsync, 30);


        public async Task<Enrollment?> GetEnrollmentByIdAsync(int enrollmentID) =>
            await _unitOfWork.Enrollments.GetByIdAsync(enrollmentID);


        public async Task<List<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            await _validationService.ValidateCoursesExistsAsync(courseId);
            return await _unitOfWork.Enrollments.GetEnrollmentsByCourseIdAsync(courseId);
        }

        public async Task<bool> UpdateEnrollmentAsync(Enrollment enrollment)
        {
            await _validationService.ValidateEnrollExistsAsync(enrollment.EnrollmentID);
            await _validationService.ValidateStudentExistsAsync(enrollment.StudentID);
            await _validationService.ValidateCoursesExistsAsync(enrollment.CourseID);

            await _unitOfWork.Enrollments.UpdateAsync(enrollment);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
