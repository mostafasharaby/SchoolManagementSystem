using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class FeeService : IFeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public FeeService(IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }
        public async Task AddFeesAsync(Fee Fees)
        {
            await _validationService.ValidateStudentExistsAsync(Fees.StudentID);

            await _unitOfWork.Fee.AddAsync(Fees);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeletelFeesAsync(int FeesId)
        {
            var check = await _unitOfWork.Fee.DeleteByIdAsync(FeesId);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Fee>> GetAllFeessAsync()
        {
            return await _unitOfWork.Fee.GetAllAsync();
        }

        public async Task<Fee> GetFeesByIdAsync(int FeesId)
        {
            return await _unitOfWork.Fee.GetByIdAsync(FeesId);
        }

        public async Task<List<Fee>> GetOutstandingFeesAsync(int studentId)
        {
            await _validationService.ValidateStudentExistsAsync(studentId);
            return await _unitOfWork.Fee.GetOutstandingFeesAsync(studentId);
        }


        public async Task UpdatelFeesAsync(Fee Fee)
        {
            await _validationService.ValidateStudentExistsAsync(Fee.StudentID);

            await _unitOfWork.Fee.UpdateAsync(Fee);
            await _unitOfWork.CompleteAsync();
        }
    }
}
