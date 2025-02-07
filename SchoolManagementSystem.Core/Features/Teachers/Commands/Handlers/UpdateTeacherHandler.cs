using MediatR;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Handlers
{
    internal class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, Teacher>
    {
        private readonly ITeacherService _teacherService;

        public UpdateTeacherHandler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public Task<Teacher> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            return _teacherService.UpdateTeacherAsync(request.Teacher);
        }



    }
}
