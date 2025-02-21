using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class LibraryService : ILibraryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        public LibraryService(IUnitOfWork unitOfWork, IValidationService validationService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
        }
        public async Task AddLibraryAsync(Library Library)
        {
            await _unitOfWork.Library.AddAsync(Library);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteLibraryAsync(int LibraryID)
        {
            var check = await _unitOfWork.Library.DeleteByIdAsync(LibraryID);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Library>> GetAllLibrarysAsync()
        {
            return await _unitOfWork.Library.GetAllAsync();
        }

        public async Task<Library> GetLibraryByIdAsync(int LibraryID)
        {
            return await _unitOfWork.Library.GetByIdAsync(LibraryID);
        }

        public async Task UpdateLibraryAsync(Library Library)
        {
            await _validationService.ValidateLibraryExistsAsync(Library.LibraryID);
            await _unitOfWork.Library.UpdateAsync(Library);
            await _unitOfWork.CompleteAsync();
        }
    }
}
