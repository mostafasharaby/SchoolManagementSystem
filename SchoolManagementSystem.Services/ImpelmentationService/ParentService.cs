using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class ParentService : IParentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public ParentService(IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }
        public async Task AddParentAsync(Parent Parent)
        {
            await _unitOfWork.Parents.AddAsync(Parent);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteParentsAsync(int ParentID)
        {
            var check = await _unitOfWork.Parents.DeleteByIdAsync(ParentID);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Parent>> GetAllParentsAsync()
        {
            return await _unitOfWork.Parents.GetAllAsync();
        }

        public async Task<List<Fee>> GetFeePaymentHistoryByParentAsync(int parentId)
        {
            await _validationService.ValidateParentExistsAsync(parentId);
            return await _unitOfWork.Parents.GetFeePaymentHistoryByParentAsync(parentId);
        }

        public async Task<Parent> GetParentsByIdAsync(int ParentID)
        {
            return await _unitOfWork.Parents.GetByIdAsync(ParentID);
        }

        public async Task<List<Student>> GetStudentsByParentAsync(int parentId)
        {
            await _validationService.ValidateParentExistsAsync(parentId);
            return await _unitOfWork.Parents.GetStudentsByParentAsync(parentId);
        }

        public async Task UpdateParentsAsync(Parent Parent)
        {
            await _validationService.ValidateParentExistsAsync(Parent.ParentID);
            await _unitOfWork.Parents.UpdateAsync(Parent);
            await _unitOfWork.CompleteAsync();
        }
    }
}
