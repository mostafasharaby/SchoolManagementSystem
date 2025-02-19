using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class ExamTypeService : IExamTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddExamTypeAsync(ExamType examType)
        {
            var examExists = await _unitOfWork.ExamsTypes.GetByIdAsync(examType.ExamTypeID);
            if (examExists == null)
            {
                throw new KeyNotFoundException("Exam not found.");
            }

            await _unitOfWork.ExamsTypes.AddAsync(examType);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteExamTypeAsync(int examTypeID)
        {
            var check = await _unitOfWork.ExamsTypes.DeleteByIdAsync(examTypeID);
            if (check)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ExamType>> GetAllExamTypesAsync()
        {
            return await _unitOfWork.ExamsTypes.GetAllAsync();
        }

        public async Task<ExamType?> GetExamTypeByIdAsync(int examTypeID)
        {
            return await _unitOfWork.ExamsTypes.GetByIdAsync(examTypeID);
        }

        public async Task<bool> UpdateExamTypeAsync(ExamType examType)
        {
            var attendanceExists = await _unitOfWork.ExamsTypes.GetByIdAsync(examType.ExamTypeID);

            if (attendanceExists == null)
            {
                throw new KeyNotFoundException("examType  not found.");
            }

            var examExists = await _unitOfWork.Exams.GetByIdAsync(examType.ExamTypeID);
            if (examExists == null)
            {
                throw new KeyNotFoundException("Exam not found.");
            }


            await _unitOfWork.ExamsTypes.UpdateAsync(examType);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
