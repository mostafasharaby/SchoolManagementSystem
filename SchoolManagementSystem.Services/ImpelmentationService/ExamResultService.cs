using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class ExamResultService : IExamResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public ExamResultService(IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }
        public async Task AddExamResultAsync(ExamResult examResult)
        {
            await _validationService.ValidateStudentExistsAsync(examResult.StudentID);

            await _unitOfWork.ExamResults.AddAsync(examResult);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteExamResultAsync(int examResultID)
        {
            var check = await _unitOfWork.ExamResults.DeleteByIdAsync(examResultID);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ExamResult>> GetAllExamResultsAsync()
        {
            return await _unitOfWork.ExamResults.GetAllAsync();
        }

        public async Task<ExamResult> GetExamResultByIdAsync(int examResultID)
        {
            return await _unitOfWork.ExamResults.GetByIdAsync(examResultID);
        }

        public async Task<List<ExamResult>> GetExamResultsByExamAsync(int examID)
        {
            await _validationService.ValidateExamsExistsAsync(examID);
            return await _unitOfWork.ExamResults.GetExamResultsByExamAsync(examID);
        }

        public async Task<List<ExamResult>> GetExamResultsByStudentAsync(string studentID)
        {
            await _validationService.ValidateStudentExistsAsync(studentID);
            return await _unitOfWork.ExamResults.GetExamResultsByStudentAsync(studentID);
        }

        public async Task UpdateExamResultAsync(ExamResult examResult)
        {
            await _validationService.ValidateExamResultExistsAsync(examResult.ExamResultID);
            await _validationService.ValidateExamsExistsAsync(examResult.ExamID);
            await _validationService.ValidateStudentExistsAsync(examResult.StudentID);

            await _unitOfWork.ExamResults.UpdateAsync(examResult);
            await _unitOfWork.CompleteAsync();
        }
    }
}
