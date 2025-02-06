using SchoolManagementSystem.Data;
using SchoolManagementSystem.Infrastructure.Repositories;
using SchoolManagementSystem.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<bool> DeleteTeacherAsync(int teacherID)
        {
            var deletedStudent = await _teacherRepository.GetByIdAsync(teacherID);

            if (deletedStudent == null)
            {
                return false;
            }

            await _teacherRepository.DeleteAsync(deletedStudent);
            return true;
        }

        public async Task<Teacher> GetTeacherAsyncByID(int teacherID)
        {
            return await _teacherRepository.GetByIdAsync(teacherID);
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
           return await _teacherRepository.GetAllAsync();
        }

        public Task<Teacher> UpdateTeacherAsync(Teacher teacher)
        {
            return  _teacherRepository.UpdateAsync(teacher);
        }
    }
}
