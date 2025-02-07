using MediatR;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Results;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetTeacherDtoQuery : IRequest<List<TeacherDto>>
    {
    }
}
