using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class DeleteTeacherCommand : IRequest<Response<string>>
    {
        public int TeacherID { get; set; }
    }
}
