using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetAllTeachersQuery : IRequest<Response<List<TeacherDto>>>
    {
    }
}
