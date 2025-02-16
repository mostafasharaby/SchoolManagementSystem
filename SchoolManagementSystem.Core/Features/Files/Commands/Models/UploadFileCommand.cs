using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Files.Commands.Models
{
    public class UploadFileCommand : IRequest<Response<string>>
    {
        public IFormFile? File { get; set; }
    }
}
