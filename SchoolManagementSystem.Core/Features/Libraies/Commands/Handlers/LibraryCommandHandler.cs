using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Libraies.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;
namespace SchoolManagementSystem.Core.Features.Libraies.Commands.Handlers
{
    public class LibraryCommandHandler : IRequestHandler<AddBookCommand, Response<string>>,
                                       IRequestHandler<UpdateBookCommand, Response<string>>,
                                       IRequestHandler<DeleteBookCommand, Response<string>>
    {
        private readonly ILibraryService _libraryService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;

        public LibraryCommandHandler(IMapper mapper, ResponseHandler responseHandler, ILibraryService libraryService)
        {
            _responseHandler = responseHandler;
            _mapper = mapper;
            _libraryService = libraryService;
        }

        public async Task<Response<string>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var library = _mapper.Map<Library>(request);
            await _libraryService.AddLibraryAsync(library);
            return _responseHandler.Created("Library entry created successfully");
        }

        public async Task<Response<string>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var library = _mapper.Map<Library>(request);
                await _libraryService.UpdateLibraryAsync(library);
                return _responseHandler.Success("Library entry updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
            catch (Exception ex)
            {
                return _responseHandler.BadRequest<string>("An unexpected error occurred: " + ex.Message);
            }
        }

        public async Task<Response<string>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _libraryService.DeleteLibraryAsync(request.LibraryID);
            if (!result)
                return _responseHandler.NotFound<string>("Library entry not found.");

            return _responseHandler.Success("Library entry deleted successfully.");
        }
    }

}
