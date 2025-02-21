using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Libraies.Queries.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Libraies.Queries.Handlers
{
    internal class LibraryQueryHandler : IRequestHandler<GetBookByIDCommand, Response<LibraryDto>>,
                                          IRequestHandler<GetAllBooksQuery, Response<List<LibraryDto>>>
    {
        private readonly ILibraryService _libraryService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public LibraryQueryHandler(IMapper mapper, ResponseHandler responseHandler, ILibraryService libraryService)
        {
            _responseHandler = responseHandler;
            _mapper = mapper;
            _libraryService = libraryService;
        }

        public async Task<Response<LibraryDto>> Handle(GetBookByIDCommand request, CancellationToken cancellationToken)
        {
            var books = await _libraryService.GetLibraryByIdAsync(request.LibraryID);
            var result = _mapper.Map<LibraryDto>(books);
            return _responseHandler.Success(result);
        }
        public async Task<Response<List<LibraryDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _libraryService.GetAllLibrarysAsync();
            var result = _mapper.Map<List<LibraryDto>>(books);
            return _responseHandler.Success(result);
        }


    }
}
