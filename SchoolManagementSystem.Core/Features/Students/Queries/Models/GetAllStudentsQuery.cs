using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;
namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetAllStudentsQuery : IRequest<Response<List<StudentDto>>>
    {
    }
}
