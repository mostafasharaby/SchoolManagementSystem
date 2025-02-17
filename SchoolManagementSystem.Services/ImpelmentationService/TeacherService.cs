using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteTeacherAsync(int teacherID)
        {
            var deletedStudent = await _unitOfWork.Teachers.DeleteByIdAsync(teacherID);
            if (deletedStudent)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<Teacher> GetTeacherAsyncByID(int teacherID)
        {
            return await _unitOfWork.Teachers.GetByIdAsync(teacherID);
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
            return await _unitOfWork.Teachers.GetAllAsync();
        }

        public Task<Teacher> UpdateTeacherAsync(Teacher teacher)
        {
            return _unitOfWork.Teachers.UpdateAsync(teacher);
        }
    }
}
