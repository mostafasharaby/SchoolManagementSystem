using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class ExamScoreService : IExamScoreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamScoreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddExamScoreAsync(ExamScore ExamScore)
        {
            var examExists = await _unitOfWork.ExamScores.GetByIdAsync(ExamScore.ExamID);
            if (examExists == null)
            {
                throw new KeyNotFoundException("Exam not found.");
            }

            var studentExists = await _unitOfWork.Students.GetByIdAsync(ExamScore.StudentID);
            if (studentExists == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }


            await _unitOfWork.ExamScores.AddAsync(ExamScore);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteExamScoreAsync(int id)
        {
            var check = await _unitOfWork.ExamScores.DeleteByIdAsync(id);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ExamScore>> GetAllExamScoresAsync()
        {
            return await _unitOfWork.ExamScores.GetAllAsync();
        }

        public async Task<ExamScore?> GetExamScoreByIdAsync(int id)
        {
            return await _unitOfWork.ExamScores.GetByIdAsync(id);
        }

        public async Task<List<ExamScore>> GetExamScoresByExamIdAsync(int examId)
        {
            return await _unitOfWork.ExamScores.GetExamScoresByExamIdAsync(examId);
        }

        public async Task<List<ExamScore>> GetExamScoresByStudentIdAsync(int studentId)
        {
            return await _unitOfWork.ExamScores.GetExamScoresByStudentIdAsync(studentId);
        }

        public async Task<bool> UpdateExamScoreAsync(ExamScore ExamScore)
        {
            var attendanceExists = await _unitOfWork.ExamScores.GetByIdAsync(ExamScore.ExamScoreID);

            if (attendanceExists == null)
            {
                throw new KeyNotFoundException("examResult  not found.");
            }

            var examExists = await _unitOfWork.Exams.GetByIdAsync(ExamScore.ExamID);
            if (examExists == null)
            {
                throw new KeyNotFoundException("Exam not found.");
            }

            var studentExists = await _unitOfWork.Students.GetByIdAsync(ExamScore.StudentID);
            if (studentExists == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }

            await _unitOfWork.ExamScores.UpdateAsync(ExamScore);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
