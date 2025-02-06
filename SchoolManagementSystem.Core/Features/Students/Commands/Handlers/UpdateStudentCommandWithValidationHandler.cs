using AutoMapper;
using MediatR;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Handlers
{
    internal class UpdateStudentCommandWithValidationHandler : IRequestHandler<UpdateStudentCommandWithValidation, Student>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public UpdateStudentCommandWithValidationHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Student> Handle(UpdateStudentCommandWithValidation request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentAsyncByID(request.StudentID);

            if (student == null)
            {
                throw new ArgumentException($"Student with ID {request.StudentID} not found.");
            }

            _mapper.Map(request, student);
            var updatedStudent = await _studentService.UpdateStudentAsync(student);

            return updatedStudent;
        }
    }
}

