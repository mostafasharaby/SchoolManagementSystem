using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Departments.Queries.Models
{
    public class GetAllDepartmentsQuery : IRequest<Response<List<Department>>>
    {
    }
}
