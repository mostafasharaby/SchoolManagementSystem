using MediatR;
using SchoolManagementSystem.Data.DTO;
namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentDtoQuery : IRequest<List<StudentDto>>
    {
    }
}
