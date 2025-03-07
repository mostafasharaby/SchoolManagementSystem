using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class AssignmentService : IAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMemoryCache _cache;
        private readonly ILogger<AssignmentService> _logger;
        private readonly ICacheService _cacheService;


        public AssignmentService(IUnitOfWork unitOfWork, IValidationService validationService, IMemoryCache cache, ILogger<AssignmentService> logger, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _cache = cache;
            _logger = logger;
            _cacheService = cacheService;
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            await _validationService.ValidateCoursesExistsAsync(assignment.CourseID);
            await _unitOfWork.Assignments.AddAsync(assignment);
            await _unitOfWork.CompleteAsync();
        }

        //public async Task DeleteAssignmentAsync(int assignmentId)
        //{
        //    await _validationService.ValidateAssignmentExistsAsync(assignmentId);
        //    await _unitOfWork.Assignments.DeleteByIdAsync(assignmentId);
        //    await _unitOfWork.CompleteAsync();
        //}
        public async Task<bool> DeleteAssignmentAsync(int assignmentId)
        {
            var check = await _unitOfWork.Assignments.DeleteByIdAsync(assignmentId);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        //public async Task<List<Assignment>> GetAllAssignmentsAsync() // first way 
        //{
        //    return await _unitOfWork.Assignments.GetAllAsync();
        //}

        //public async Task<List<Assignment>> GetAllAssignmentsAsync() // second way with caching 
        //{
        //    string cacheKey = "Exams";
        //    var clock = new Stopwatch();
        //    clock.Start();

        //    if (_cache.TryGetValue(cacheKey, out List<Assignment>? assignmentList) && assignmentList != null)
        //    {
        //        _logger.LogInformation("exams results in cache");
        //    }
        //    else
        //    {
        //        _logger.LogInformation("exams results not in cache");
        //        assignmentList = await _unitOfWork.Assignments.GetAllAsync();
        //        //_cache.Set(cacheKey, examList);
        //        _cache.Set(cacheKey, assignmentList, new MemoryCacheEntryOptions
        //        {
        //            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
        //        });
        //    }
        //    clock.Stop();
        //    _logger.LogWarning("pass time : " + clock.ElapsedMilliseconds);
        //    return assignmentList!;
        //}

        // third way with caching and delegate
        public async Task<List<Assignment>> GetAllAssignmentsAsync() =>
         await _cacheService.GetOrAddToCacheAsync("Exams", _unitOfWork.Assignments.GetAllAsync, 30);

        public async Task<Assignment> GetAssignmentByIdAsync(int assignmentId)
        {
            //   await _validationService.ValidateAssignmentExistsAsync(assignmentId); no need the result will be  2 calls on DB
            return await _unitOfWork.Assignments.GetByIdAsync(assignmentId);
        }

        public async Task<List<Assignment>> GetAssignmentsByCourseIdAsync(int courseId)
        {
            await _validationService.ValidateCoursesExistsAsync(courseId);
            return await _unitOfWork.Assignments.GetAssignmentsByCourseIdAsync(courseId);
        }

        public async Task<bool> UpdateAssignmentAsync(Assignment assignment)
        {
            await _validationService.ValidateAssignmentExistsAsync(assignment.AssignmentID);
            await _validationService.ValidateCoursesExistsAsync(assignment.CourseID);

            await _unitOfWork.Assignments.UpdateAsync(assignment);
            await _unitOfWork.CompleteAsync();

            return true;
        }



    }
}
