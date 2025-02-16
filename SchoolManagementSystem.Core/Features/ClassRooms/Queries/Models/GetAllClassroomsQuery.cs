using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.ClassRooms.Queries.Models
{
    public class GetAllClassroomsQuery : IRequest<Response<List<Classroom>>> { }

}
