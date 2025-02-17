using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class ParentService : IParentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddParentAsync(Parent Parent)
        {
            await _unitOfWork.Parents.AddAsync(Parent);
            await _unitOfWork.CompleteAsync(); // Saves changes to the database
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

        public async Task<Parent> GetParentsByIdAsync(int ParentID)
        {
            return await _unitOfWork.Parents.GetByIdAsync(ParentID);
        }

        public async Task UpdateParentsAsync(Parent Parent)
        {
            await _unitOfWork.Parents.UpdateAsync(Parent);
            await _unitOfWork.CompleteAsync();
        }
    }
}
