using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Departments.Queries.Models
{
    public class GetTeachersByDepartmentQuery : IRequest<Response<List<TeacherDto>>>
    {
        public int DepartmentID { get; set; }
    }
}
