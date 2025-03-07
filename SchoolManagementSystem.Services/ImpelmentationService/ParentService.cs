using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class ParentService : IParentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly ICacheService _cacheService;

        public ParentService(IUnitOfWork unitOfWork, IValidationService validationService, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _cacheService = cacheService;
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

        public async Task<List<Parent>> GetAllParentsAsync() =>
            await _cacheService.GetOrAddToCacheAsync("Parents", _unitOfWork.Parents.GetAllAsync, 30);

        public async Task<Parent> GetParentsByIdAsync(int ParentID) =>
            await _unitOfWork.Parents.GetByIdAsync(ParentID);

        public async Task<List<Fee>> GetFeePaymentHistoryByParentAsync(int parentId)
        {
            await _validationService.ValidateParentExistsAsync(parentId);
            return await _unitOfWork.Parents.GetFeePaymentHistoryByParentAsync(parentId);
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
