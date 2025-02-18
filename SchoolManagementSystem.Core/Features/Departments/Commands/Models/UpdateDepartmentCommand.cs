using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Departments.Commands.Models
{
    public class UpdateDepartmentCommand : IRequest<Response<string>>
    {
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
    }
}
