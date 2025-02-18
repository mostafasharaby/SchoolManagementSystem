using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BorrowedBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task AddBorrowedBookAsync(BorrowedBook borrowedBook)
        {
            var checkid = _unitOfWork.BorrowedBooks.GetByIdAsync(borrowedBook.BorrowID);
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

        public async Task<List<BorrowedBook>> GetAllBorrowedBooksAsync()
        {
            return await _unitOfWork.BorrowedBooks.GetAllAsync();
        }

        public async Task<BorrowedBook> GetBorrowedBookByIdAsync(int BorrowedBookId)
        {
            return await _unitOfWork.BorrowedBooks.GetByIdAsync(BorrowedBookId);
        }

        public async Task<List<BorrowedBook>> GetBorrowedBooksByStudentIdAsync(int studentId)
        {
            return await _unitOfWork.BorrowedBooks.GetBorrowedBooksByStudentIdAsync(studentId);
        }

        //public async Task<bool> UpdateBorrowedBookAsync(BorrowedBook borrowedBook)
        //{
        //    var borrowedBookExists = await _unitOfWork.BorrowedBooks.GetByIdAsync(borrowedBook.BorrowID);
        //    var studentExists = await _unitOfWork.Students.GetByIdAsync(borrowedBook.StudentID);
        //    var libraryExists = await _unitOfWork.Library.GetByIdAsync(borrowedBook.LibraryID);

        //    if (studentExists == null || libraryExists == null)
        //    {
        //        return false;
        //    }

        //    await _unitOfWork.BorrowedBooks.UpdateAsync(borrowedBook);
        //    await _unitOfWork.CompleteAsync();

        //    return true;
        //}
        public async Task<bool> UpdateBorrowedBookAsync(BorrowedBook borrowedBook)
        {
            var borrowedBookExists = await _unitOfWork.BorrowedBooks.GetByIdAsync(borrowedBook.BorrowID);

            if (borrowedBookExists == null)
            {
                throw new KeyNotFoundException("Borrowed Book not found.");
            }

            var studentExists = await _unitOfWork.Students.GetByIdAsync(borrowedBook.StudentID);
            if (studentExists == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }

            var libraryExists = await _unitOfWork.Library.GetByIdAsync(borrowedBook.LibraryID);
            if (libraryExists == null)
            {
                throw new KeyNotFoundException("Library not found.");
            }

            await _unitOfWork.BorrowedBooks.UpdateAsync(borrowedBook);
            await _unitOfWork.CompleteAsync();

            return true;
        }


    }
}
