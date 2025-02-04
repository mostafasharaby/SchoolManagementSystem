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
            return await _teacherRepository.DeleteTeacherAsync(teacherID);
        }

        public async Task<Teacher> GetTeacherAsyncByID(int teacherID)
        {
            return await _teacherRepository.GetTeacherByIdAsync(teacherID);
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
           return await _teacherRepository.GetAllTeachersAsync();
        }

        public Task<Teacher> UpdateTeacherAsync(Teacher teacher)
        {
            return  _teacherRepository.UpdateTeacherAsync(teacher);
        }
    }
}
