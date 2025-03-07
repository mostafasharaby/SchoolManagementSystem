using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class ExamTypeService : IExamTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly ICacheService _cacheService;

        public ExamTypeService(IUnitOfWork unitOfWork, IValidationService validationService, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _cacheService = cacheService;
        }

        public async Task AddExamTypeAsync(ExamType examType)
        {
            await _unitOfWork.ExamsTypes.AddAsync(examType);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteExamTypeAsync(int examTypeID)
        {
            var check = await _unitOfWork.ExamsTypes.DeleteByIdAsync(examTypeID);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ExamType>> GetAllExamTypesAsync() =>
            await _cacheService.GetOrAddToCacheAsync("ExamTypes", _unitOfWork.ExamsTypes.GetAllAsync, 30);

        public async Task<ExamType> GetExamTypeByIdAsync(int examTypeID) =>
            await _unitOfWork.ExamsTypes.GetByIdAsync(examTypeID);

        public async Task UpdateExamTypeAsync(ExamType examType)
        {
            await _validationService.ValidateExamTypeExistsAsync(examType.ExamTypeID);

            await _unitOfWork.ExamsTypes.UpdateAsync(examType);
            await _unitOfWork.CompleteAsync();
        }
    }
}
