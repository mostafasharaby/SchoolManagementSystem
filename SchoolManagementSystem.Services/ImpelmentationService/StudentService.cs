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
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _StudentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _StudentRepository = studentRepository;
        }

        public async Task<List<Student>> GetStudentAsync()
        {
            return await _StudentRepository.GetAllStudentsAsync(); // related to studentRepository not Generic one 
        }     

        public async Task<Student> GetStudentAsyncByID(int studentID)
        {
            return await _StudentRepository.GetByIdAsync(studentID);
        }

        public async Task<Student?> AddStudentAsync(Student student)
        {
            var studentExists = _StudentRepository.GetTableNoTracking()
                .Any(i => i.StudentFirstName == student.StudentFirstName && i.StudentLastName == student.StudentLastName);

            if (studentExists)
            {
                return null; 
            }

            return await _StudentRepository.AddAsync(student);
        }

        public async Task<bool> DeleteStudentAsync(int studentID)
        {
            var deletedStudent = await _StudentRepository.GetByIdAsync(studentID);

            if (deletedStudent == null)
            {
                return false;
            }

            await _StudentRepository.DeleteAsync(deletedStudent);
            return true;
        }

        Task<Student> IStudentService.UpdateStudentAsync(Student student)
        {
            return  _StudentRepository.UpdateAsync(student);
        }
    }
}
