using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentDtoQueryWithStatus : IRequest<Response<List<StudentDto>>>
    {
    }
}
