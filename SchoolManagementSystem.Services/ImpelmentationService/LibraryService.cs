using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class LibraryService : ILibraryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly ICacheService _cacheService;

        public LibraryService(IUnitOfWork unitOfWork, IValidationService validationService, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _cacheService = cacheService;
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

        public async Task<List<Library>> GetAllLibrarysAsync() =>
            await _cacheService.GetOrAddToCacheAsync("Library", _unitOfWork.Library.GetAllAsync, 30);

        public async Task<Library> GetLibraryByIdAsync(int LibraryID) =>
            await _unitOfWork.Library.GetByIdAsync(LibraryID);

        public async Task UpdateLibraryAsync(Library Library)
        {
            await _validationService.ValidateLibraryExistsAsync(Library.LibraryID);
            await _unitOfWork.Library.UpdateAsync(Library);
            await _unitOfWork.CompleteAsync();
        }
    }
}
