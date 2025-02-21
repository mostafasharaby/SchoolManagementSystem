using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Queries.Handlers
{
    internal class BorrowedBookQueryHandler : IRequestHandler<GetBorrowedBookByIdQuery, Response<BorrowedBookDto>>,
                                              IRequestHandler<GetAllBorrowedBooksQuery, Response<List<BorrowedBookDto>>>,
                                              IRequestHandler<GetBorrowedBooksByStudentQuery, Response<List<BorrowedBookDto>>>
    {
        private readonly IBorrowedBookService _borrowedBookService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        public BorrowedBookQueryHandler(IMapper mapper, ResponseHandler responseHandler, IBorrowedBookService borrowedBookService)
        {
            _responseHandler = responseHandler;
            _mapper = mapper;
            _borrowedBookService = borrowedBookService;
        }

        public async Task<Response<BorrowedBookDto>> Handle(GetBorrowedBookByIdQuery request, CancellationToken cancellationToken)
        {
            var borrowedBook = await _borrowedBookService.GetBorrowedBookByIdAsync(request.BorrowedBookId);
            if (borrowedBook == null)
                return _responseHandler.NotFound<BorrowedBookDto>("Borrowed Book not found.");

            var dto = _mapper.Map<BorrowedBookDto>(borrowedBook);
            return _responseHandler.Success(dto);
        }

        public async Task<Response<List<BorrowedBookDto>>> Handle(GetAllBorrowedBooksQuery request, CancellationToken cancellationToken)
        {
            var borrowedBooks = await _borrowedBookService.GetAllBorrowedBooksAsync();
            var dtoList = _mapper.Map<List<BorrowedBookDto>>(borrowedBooks);
            return _responseHandler.Success(dtoList);
        }

        public async Task<Response<List<BorrowedBookDto>>> Handle(GetBorrowedBooksByStudentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var borrowedBooks = await _borrowedBookService.GetBorrowedBooksByStudentIdAsync(request.StudentID);
                var dtoList = _mapper.Map<List<BorrowedBookDto>>(borrowedBooks);
                return _responseHandler.Success(dtoList);
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<List<BorrowedBookDto>>(ex.Message);

            }
        }

    }
}
