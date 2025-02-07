using MediatR;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentDtoQuery : IRequest<List<StudentDto>>
    {
    }
}
