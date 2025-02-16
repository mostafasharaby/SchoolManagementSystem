using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Commands.Models
{
    public class DeleteClassroomCommand : IRequest<Response<string>>
    {
        public int ClassroomID { get; set; }
    }
}
