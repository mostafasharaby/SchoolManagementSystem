using MediatR;
using SchoolManagementSystem.Core.Features.Teachers.Commands.Models;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Handlers
{
    internal class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly ITeacherService _TeacherService;

        public DeleteTeacherHandler(ITeacherService TeacherService)
        {
            _TeacherService = TeacherService;
        }

        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _TeacherService.DeleteTeacherAsync(request.TeacherID);
        }
    }
}
