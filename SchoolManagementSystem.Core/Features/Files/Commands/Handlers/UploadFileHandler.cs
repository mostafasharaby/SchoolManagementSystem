using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Files.Commands.Models;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Files.Commands.Handlers
{
    public class UploadFileHandler : IRequestHandler<UploadFileCommand, Response<string>>
    {
        private readonly IFileService _fileService;
        private readonly ResponseHandler _responseHandler;
        public UploadFileHandler(IFileService fileService, ResponseHandler responseHandler)
        {
            _fileService = fileService;
            _responseHandler = responseHandler;

        }

        public async Task<Response<string>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fileUrl = await _fileService.UploadFileAsync(request.File, "uploads");
                return _responseHandler.Success(fileUrl, "File uploaded successfully");
            }
            catch (Exception ex)
            {
                return _responseHandler.NotFound<string>(ex.Message);
            }
        }
    }
}
