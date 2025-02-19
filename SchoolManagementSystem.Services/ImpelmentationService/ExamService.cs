using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public async Task AddExamAsync(Exam exam)
        {
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

        public async Task<List<Exam>> GetAllExamsAsync()
        {
            return await _unitOfWork.Exams.GetAllAsync();
        }

        public async Task<Exam?> GetExamByIdAsync(int examId)
        {
            return await _unitOfWork.Exams.GetByIdAsync(examId);
        }

        public async Task<List<Exam>> GetExamsByCourseAsync(int courseId)
        {
            return await _unitOfWork.Exams.GetExamsByCourseAsync(courseId);
        }

        public async Task<bool> UpdateExamAsync(Exam exam)
        {
            var attendanceExists = await _unitOfWork.Exams.GetByIdAsync(exam.ExamID);

            if (attendanceExists == null)
            {
                throw new KeyNotFoundException("Assignment  not found.");
            }

            var courseExists = await _unitOfWork.Students.GetByIdAsync(exam.CourseID);
            if (courseExists == null)
            {
                throw new KeyNotFoundException("Course not found.");
            }
            var examTypeIDExists = await _unitOfWork.ExamsTypes.GetByIdAsync(exam.ExamTypeID);
            if (examTypeIDExists == null)
            {
                throw new KeyNotFoundException("ExamType not found.");
            }


            await _unitOfWork.Exams.UpdateAsync(exam);
            await _unitOfWork.CompleteAsync();

            return true;
        }


    }
}
