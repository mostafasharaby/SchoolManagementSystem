using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Commands.Models
{
    public class AddClassroomCommand : ClassroomDto, IRequest<Response<string>>
    {
    }
}
