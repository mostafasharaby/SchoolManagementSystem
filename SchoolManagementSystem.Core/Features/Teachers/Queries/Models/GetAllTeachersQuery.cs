using MediatR;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetAllTeachersQuery : IRequest<List<Teacher>>
    {
    }
}
