using MediatR;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Handlers
{
    internal class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return _studentService.DeleteStudentAsync(request.StudentID);
        }
    }
}
