using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class LibraryService : ILibraryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibraryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddLibraryAsync(Library Library)
        {
            await _unitOfWork.Library.AddAsync(Library);
            await _unitOfWork.CompleteAsync(); // Saves changes to the database
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
            await _unitOfWork.Library.UpdateAsync(Library);
            await _unitOfWork.CompleteAsync();
        }
    }
}
