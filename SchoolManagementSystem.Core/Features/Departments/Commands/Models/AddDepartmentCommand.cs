using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Departments.Commands.Models
{
    public class AddDepartmentCommand : IRequest<Response<string>>
    {
        public string? DepartmentName { get; set; }
    }
}
