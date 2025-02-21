using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class ExamTypeService : IExamTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;

        public ExamTypeService(IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
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

        public async Task<List<ExamType>> GetAllExamTypesAsync()
        {
            return await _unitOfWork.ExamsTypes.GetAllAsync();
        }

        public async Task<ExamType> GetExamTypeByIdAsync(int examTypeID)
        {
            return await _unitOfWork.ExamsTypes.GetByIdAsync(examTypeID);
        }

        public async Task UpdateExamTypeAsync(ExamType examType)
        {
            await _validationService.ValidateExamTypeExistsAsync(examType.ExamTypeID);

            await _unitOfWork.ExamsTypes.UpdateAsync(examType);
            await _unitOfWork.CompleteAsync();
        }
    }
}
