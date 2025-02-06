using MediatR;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Models;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Handlers
{
    internal class GetTeacherByIdHandler : IRequestHandler<GetTeacherByIdQuery, Teacher>
    {
        private readonly ITeacherService _teacherService;

        public GetTeacherByIdHandler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public Task<Teacher> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
           return _teacherService.GetTeacherAsyncByID(request.TeacherID);
        }
    }
}
