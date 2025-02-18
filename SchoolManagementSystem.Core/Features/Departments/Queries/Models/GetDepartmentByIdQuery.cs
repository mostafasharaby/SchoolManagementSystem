using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<Department>>
    {
        public int DepartmentID { get; set; }
    }
}
