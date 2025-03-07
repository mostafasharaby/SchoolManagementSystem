using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly ICacheService _cacheService;

        public BorrowedBookService(IUnitOfWork unitOfWork, IValidationService validationService, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _cacheService = cacheService;
        }
        public async Task AddBorrowedBookAsync(BorrowedBook borrowedBook)
        {
            var checkid = _unitOfWork.BorrowedBooks.GetByIdAsync(borrowedBook.BorrowID);
            await _validationService.ValidateLibraryExistsAsync(borrowedBook.LibraryID);
            await _validationService.ValidateStudentExistsAsync(borrowedBook.StudentID);

            await _unitOfWork.BorrowedBooks.AddAsync(borrowedBook);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteBorrowedBookAsync(int borrowedBookId)
        {
            var check = await _unitOfWork.BorrowedBooks.DeleteByIdAsync(borrowedBookId);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<BorrowedBook>> GetAllBorrowedBooksAsync() =>
            await _cacheService.GetOrAddToCacheAsync("Exams", _unitOfWork.BorrowedBooks.GetAllAsync, 30);

        public async Task<BorrowedBook> GetBorrowedBookByIdAsync(int BorrowedBookId) =>
            await _unitOfWork.BorrowedBooks.GetByIdAsync(BorrowedBookId);


        public async Task<List<BorrowedBook>> GetBorrowedBooksByStudentIdAsync(string studentId)
        {
            await _validationService.ValidateStudentExistsAsync(studentId);
            return await _unitOfWork.BorrowedBooks.GetBorrowedBooksByStudentIdAsync(studentId);
        }

        public async Task<bool> UpdateBorrowedBookAsync(BorrowedBook borrowedBook)
        {
            await _validationService.ValidateBorrowedBookExistsAsync(borrowedBook.BorrowID);
            await _validationService.ValidateLibraryExistsAsync(borrowedBook.LibraryID);
            await _validationService.ValidateStudentExistsAsync(borrowedBook.StudentID);

            await _unitOfWork.BorrowedBooks.UpdateAsync(borrowedBook);
            await _unitOfWork.CompleteAsync();

            return true;
        }






    }
}
