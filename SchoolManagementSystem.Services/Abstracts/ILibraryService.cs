using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface ILibraryService
    {
        Task AddLibraryAsync(Library Library);
        Task UpdateLibraryAsync(Library Library);
        Task<bool> DeleteLibraryAsync(int LibraryID);
        Task<Library> GetLibraryByIdAsync(int LibraryID);
        Task<List<Library>> GetAllLibrarysAsync();

    }
}
