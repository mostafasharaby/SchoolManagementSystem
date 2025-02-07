using MediatR;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Handlers
{
    internal class TeacherHandler : IRequestHandler<GetAllTeachersQuery, List<Teacher>>
    {
        private readonly ITeacherService _teacherService;

        public TeacherHandler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public async Task<List<Teacher>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            return await _teacherService.GetTeachersAsync();
        }
    }
}
