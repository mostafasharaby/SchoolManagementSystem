﻿using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Helpers;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Repositories;
using SchoolManagementSystem.Services.Abstracts;
namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IClassRoomRepository _ClassRoomRepository;
        private readonly IParentRepository _ParentRepository;
        public StudentService(IStudentRepository studentRepository, IClassRoomRepository ClassRoomRepository, IParentRepository ParentRepository)
        {
            _StudentRepository = studentRepository;
            _ClassRoomRepository = ClassRoomRepository;
            _ParentRepository = ParentRepository;
        }

        public async Task<List<Student>> GetStudentAsync()
        {
            return await _StudentRepository.GetAllStudentsAsync(); // related to studentRepository not Generic one 
        }

        public async Task<Student> GetStudentAsyncByID(int studentID)
        {
            return await _StudentRepository.GetByIdAsync(studentID);
        }

        public async Task<Student> GetStudentAsyncByIDResponse(int studentID)
        {
            return await _StudentRepository.GetStudentByIdResponseAsync(studentID);
        }

        public async Task<Student?> AddStudentAsync(Student student)
        {
            var studentExists = _StudentRepository.GetTableNoTracking()
                .Any(i => i.StudentFirstNameAr == student.StudentFirstNameAr || i.StudentFirstNameEn == student.StudentFirstNameEn);

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
            return _StudentRepository.UpdateAsync(student);
        }

        public IQueryable<Student> GetStudentAsyncQureryable()
        {
            return _StudentRepository.GetTableNoTracking().AsQueryable();
        }

        public IQueryable<Student> GetStudentAsyncFilter(string search)
        {
            return _StudentRepository.GetTableNoTracking().
                Where(item => item.GetCultureLanguage(item.StudentFirstNameAr, item.StudentFirstNameEn).Contains(search)
                || item.GetCultureLanguage(item.StudentLastNameAr, item.StudentLastNameEn).Contains(search)).AsQueryable();
        }

        public IQueryable<Student> GetStudentAsyncOrderd(StudentOrderingEnum order)
        {
            var students = _StudentRepository.GetTableNoTracking();
            return order switch
            {
                StudentOrderingEnum.up2down => students.OrderBy(s => s.StudentID),
                StudentOrderingEnum.down2up => students.OrderByDescending(s => s.StudentID),
                StudentOrderingEnum.NameUp2Down => students.OrderBy(s => s.GetCultureLanguage(s.StudentFirstNameAr, s.StudentFirstNameEn)),
                StudentOrderingEnum.NameDownUp => students.OrderByDescending(s => s.GetCultureLanguage(s.StudentLastNameAr, s.StudentLastNameEn)),
                _ => students
            };
        }
    }
}
