using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentDtoQueryWithStatus : IRequest<Response<List<StudentDto>>>
    {
    }
}
