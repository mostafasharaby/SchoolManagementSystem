using Microsoft.AspNetCore.Http;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file, string folderName);
    }
}
