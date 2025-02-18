using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Commands.Models
{
    public class UpdateClassroomCommand : ClassroomDto, IRequest<Response<string>>
    {
        public int ClassroomID { get; set; }
    }
}
