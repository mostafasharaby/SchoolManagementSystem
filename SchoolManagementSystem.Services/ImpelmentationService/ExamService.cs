using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ExamService> _logger;
        private readonly ICacheService _cacheService;
        public ExamService(IUnitOfWork unitOfWork, IValidationService validationService, IMemoryCache cache, ILogger<ExamService> logger, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _cache = cache;
            _logger = logger;
            _cacheService = cacheService;
        }


        public async Task AddExamAsync(Exam exam)
        {
            await _validationService.ValidateCoursesExistsAsync(exam.CourseID);
            await _validationService.ValidateExamTypeExistsAsync(exam.ExamTypeID);

            await _unitOfWork.Exams.AddAsync(exam);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteExamAsync(int examId)
        {
            var check = await _unitOfWork.Exams.DeleteByIdAsync(examId);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }


        //public async Task<List<Exam>> GetAllExamsAsync()
        //{
        //    return await _unitOfWork.Exams.GetAllAsync();
        //}

        //public async Task<List<Exam>> GetAllExamsAsync()
        //{
        //    string cacheKey = "Exams";
        //    var clock = new Stopwatch();
        //    clock.Start();

        //    if (_cache.TryGetValue(cacheKey, out List<Exam>? examList) && examList != null)
        //    {
        //        _logger.LogInformation("exams results in cache");
        //    }
        //    else
        //    {
        //        _logger.LogInformation("exams results not in cache");
        //        examList = await _unitOfWork.Exams.GetAllAsync();
        //        _cache.Set(cacheKey, examList, new MemoryCacheEntryOptions
        //        {
        //            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
        //        });
        //    }
        //    clock.Stop();
        //    _logger.LogWarning("pass time : " + clock.ElapsedMilliseconds);
        //    return examList;
        //}

        public async Task<List<Exam>> GetAllExamsAsync() =>
            await _cacheService.GetOrAddToCacheAsync("Exams", _unitOfWork.Exams.GetAllAsync, 30);

        public async Task<Exam?> GetExamByIdAsync(int examId) =>
            await _unitOfWork.Exams.GetByIdAsync(examId);

        public async Task<List<Exam>> GetExamsByCourseAsync(int courseId)
        {
            await _validationService.ValidateCoursesExistsAsync(courseId);
            return await _unitOfWork.Exams.GetExamsByCourseAsync(courseId);
        }

        public async Task<bool> UpdateExamAsync(Exam exam)
        {
            await _validationService.ValidateExamsExistsAsync(exam.ExamID);
            await _validationService.ValidateCoursesExistsAsync(exam.CourseID);
            await _validationService.ValidateExamTypeExistsAsync(exam.ExamTypeID);

            await _unitOfWork.Exams.UpdateAsync(exam);
            await _unitOfWork.CompleteAsync();

            return true;
        }


    }
}
