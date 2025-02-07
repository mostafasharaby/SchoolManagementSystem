using MediatR;
using SchoolManagementSystem.Data.Entities;
namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetAllStudentsQuery : IRequest<List<Student>>
    {
    }
}
