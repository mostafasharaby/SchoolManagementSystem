using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty or null");

            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, folderName); //"D:\\My_Projects\\SchoolManagementSystem\\SchoolManagementSystem.Api\\wwwroot\\uploads"
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            Console.WriteLine("Path", Path.GetExtension(file.FileName));
            var filePath = Path.Combine(uploadPath, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))  // path + mode (enum)
            {
                await file.CopyToAsync(fileStream); // fileStream-> desnation 
            }
            return $"/{folderName}/{uniqueFileName}";
        }
    }
}
