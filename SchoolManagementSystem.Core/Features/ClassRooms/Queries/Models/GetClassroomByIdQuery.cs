using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Queries.Models
{
    public class GetClassroomByIdQuery : IRequest<Response<Classroom>>
    {
        public int ClassroomID { get; set; }
    }
}
