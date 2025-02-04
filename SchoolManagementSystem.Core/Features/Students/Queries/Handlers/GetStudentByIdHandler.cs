using MediatR;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Handlers
{
    internal class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IStudentService _studentService;        

        public GetStudentByIdHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }  

        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudentAsyncByID(request.StudentID);
        }
    }
}
