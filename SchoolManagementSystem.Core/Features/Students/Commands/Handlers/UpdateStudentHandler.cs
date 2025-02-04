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
    internal class UpdateTeacherHandler : IRequestHandler<UpdateStudentCommand,Student>
    {
        private readonly IStudentService _studentService;

        public UpdateTeacherHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentService.UpdateStudentAsync(request.Student);           
        }
    }
}
