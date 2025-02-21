using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.BorrowedBooks.Commands.Handlers
{
    public class BorrowedBookCommandHandler : IRequestHandler<AddBorrowedBookCommand, Response<string>>,
                                              IRequestHandler<UpdateBorrowedBookCommand, Response<string>>,
                                              IRequestHandler<DeleteBorrowedBookCommand, Response<string>>
    {
        private readonly IBorrowedBookService _borrowedBookService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        public BorrowedBookCommandHandler(IMapper mapper, ResponseHandler responseHandler, IBorrowedBookService borrowedBookService)
        {
            _responseHandler = responseHandler;
            _mapper = mapper;
            _borrowedBookService = borrowedBookService;
        }

        public async Task<Response<string>> Handle(AddBorrowedBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var borrowedBook = _mapper.Map<BorrowedBook>(request);
                await _borrowedBookService.AddBorrowedBookAsync(borrowedBook);
                return _responseHandler.Created(" created successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(UpdateBorrowedBookCommand request, CancellationToken cancellationToken)  /// issue here !!!
        {
            try
            {
                var borrowedBook = _mapper.Map<BorrowedBook>(request);
                await _borrowedBookService.UpdateBorrowedBookAsync(borrowedBook);
                return _responseHandler.Success("Borrowed Book updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }


        public async Task<Response<string>> Handle(DeleteBorrowedBookCommand request, CancellationToken cancellationToken)
        {

            var result = await _borrowedBookService.DeleteBorrowedBookAsync(request.BorrowID);
            if (!result)
                return _responseHandler.NotFound<string>("Borrowed Book not found.");

            return _responseHandler.Success("Borrowed Book deleted successfully.");

        }

    }
}
