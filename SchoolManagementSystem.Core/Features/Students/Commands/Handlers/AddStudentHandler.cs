using MediatR;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Handlers
{
    public class AddStudentHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly IStudentService _studentService;

        public AddStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            return _studentService.AddStudentAsync(request.Student);
        }
    }
}
