using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public ExamService(IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }


        public async Task AddExamAsync(Exam exam)
        {
            await _validationService.ValidateCoursesExistsAsync(exam.CourseID);
            await _validationService.ValidateExamTypeExistsAsync(exam.ExamTypeID);

            await _unitOfWork.Exams.AddAsync(exam);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteExamAsync(int examId)
        {
            var check = await _unitOfWork.Exams.DeleteByIdAsync(examId);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Exam>> GetAllExamsAsync()
        {
            return await _unitOfWork.Exams.GetAllAsync();
        }

        public async Task<Exam?> GetExamByIdAsync(int examId)
        {
            return await _unitOfWork.Exams.GetByIdAsync(examId);
        }

        public async Task<List<Exam>> GetExamsByCourseAsync(int courseId)
        {
            await _validationService.ValidateCoursesExistsAsync(courseId);
            return await _unitOfWork.Exams.GetExamsByCourseAsync(courseId);
        }

        public async Task<bool> UpdateExamAsync(Exam exam)
        {
            await _validationService.ValidateExamsExistsAsync(exam.ExamID);
            await _validationService.ValidateCoursesExistsAsync(exam.CourseID);
            await _validationService.ValidateExamTypeExistsAsync(exam.ExamTypeID);

            await _unitOfWork.Exams.UpdateAsync(exam);
            await _unitOfWork.CompleteAsync();

            return true;
        }


    }
}
