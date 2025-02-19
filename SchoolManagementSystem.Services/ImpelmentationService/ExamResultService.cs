using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class ExamResultService : IExamResultService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamResultService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<bool> AddExamResultAsync(ExamResult examResult)
        {
            var examExists = await _unitOfWork.Exams.GetByIdAsync(examResult.ExamID);
            if (examExists == null)
            {
                throw new KeyNotFoundException("Exam not found.");
            }

            var studentExists = await _unitOfWork.Students.GetByIdAsync(examResult.StudentID);
            if (studentExists == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }


            await _unitOfWork.ExamResults.AddAsync(examResult);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteExamResultAsync(int examResultID)
        {
            var check = await _unitOfWork.ExamResults.DeleteByIdAsync(examResultID);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ExamResult>> GetAllExamResultsAsync()
        {
            return await _unitOfWork.ExamResults.GetAllAsync();
        }

        public async Task<ExamResult> GetExamResultByIdAsync(int examResultID)
        {
            return await _unitOfWork.ExamResults.GetByIdAsync(examResultID);
        }

        public async Task<List<ExamResult>> GetExamResultsByExamAsync(int examID)
        {
            return await _unitOfWork.ExamResults.GetExamResultsByExamAsync(examID);
        }

        public async Task<List<ExamResult>> GetExamResultsByStudentAsync(int studentID)
        {
            return await _unitOfWork.ExamResults.GetExamResultsByStudentAsync(studentID);
        }

        public async Task<bool> UpdateExamResultAsync(ExamResult examResult)
        {
            var attendanceExists = await _unitOfWork.ExamResults.GetByIdAsync(examResult.ExamResultID);

            if (attendanceExists == null)
            {
                throw new KeyNotFoundException("examResult  not found.");
            }

            var examExists = await _unitOfWork.Exams.GetByIdAsync(examResult.ExamID);
            if (examExists == null)
            {
                throw new KeyNotFoundException("Exam not found.");
            }

            var studentExists = await _unitOfWork.Students.GetByIdAsync(examResult.StudentID);
            if (studentExists == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }


            await _unitOfWork.ExamResults.UpdateAsync(examResult);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
