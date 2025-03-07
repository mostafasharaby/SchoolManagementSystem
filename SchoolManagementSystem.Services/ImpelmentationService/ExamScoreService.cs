using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class ExamScoreService : IExamScoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly ICacheService _cacheService;

        public ExamScoreService(IUnitOfWork unitOfWork, IValidationService validationService, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _cacheService = cacheService;
        }

        public async Task AddExamScoreAsync(ExamScore ExamScore)
        {
            await _validationService.ValidateExamsExistsAsync(ExamScore.ExamID);
            await _validationService.ValidateStudentExistsAsync(ExamScore.StudentID);

            await _unitOfWork.ExamScores.AddAsync(ExamScore);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteExamScoreAsync(int id)
        {
            var check = await _unitOfWork.ExamScores.DeleteByIdAsync(id);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ExamScore>> GetAllExamScoresAsync() =>
            await _cacheService.GetOrAddToCacheAsync("ExamScores", _unitOfWork.ExamScores.GetAllAsync, 30);

        public async Task<ExamScore?> GetExamScoreByIdAsync(int id) =>
            await _unitOfWork.ExamScores.GetByIdAsync(id);

        public async Task<List<ExamScore>> GetExamScoresByExamIdAsync(int examId)
        {
            await _validationService.ValidateExamsExistsAsync(examId);
            return await _unitOfWork.ExamScores.GetExamScoresByExamIdAsync(examId);
        }

        public async Task<List<ExamScore>> GetExamScoresByStudentIdAsync(string studentId)
        {
            await _validationService.ValidateStudentExistsAsync(studentId);
            return await _unitOfWork.ExamScores.GetExamScoresByStudentIdAsync(studentId);
        }

        public async Task UpdateExamScoreAsync(ExamScore ExamScore)
        {
            await _validationService.ValidateExamsScoreExistsAsync(ExamScore.ExamScoreID);
            await _validationService.ValidateStudentExistsAsync(ExamScore.StudentID);
            await _validationService.ValidateExamsExistsAsync(ExamScore.ExamID);

            await _unitOfWork.ExamScores.UpdateAsync(ExamScore);
            await _unitOfWork.CompleteAsync();

        }
    }
}
